using Core.Contexts;
using Core.Data;
using MightyGmCtrl.ImportExport;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MightyGmCtrl.Controleurs
{
	public class DataImport : Controleur
	{
		private List<string> _warnings = new List<string>();

		public DataImport(Context context) : base(context) {
			ImportExcel.EventReported += (string TAG, object[] arg) =>
			{
				string str = GlobalContext.ReportManager.GetMessageRessource(TAG, arg);
				_warnings.Add(str);
				ReportMessage(MessageType.WARNING, str);
			};
		}

		/// <summary>
		/// Look for the type in the summary.
		/// </summary>
		/// <param name="t"></param>
		/// <param name="workbook"></param>
		/// <returns>The sheet of the specified type.</returns>
		private ISheet GetSheet(Type t, IWorkbook workbook)
		{
			ISheet summary = workbook.GetSheetAt(0);
			for (int i = ExportExcel.NBR_LIGNES_HEADER_SUMMARY; i <= summary.LastRowNum; i++)
			{
				IRow r = summary.GetRow(i);
				if(r?.GetCell(1)?.StringCellValue == t.Name)
				{
					return workbook.GetSheet(r.GetCell(0).StringCellValue);
				}
			}
			return null;
		}

		/// <summary>
		/// Importe les données de la feuille Excel des types donnés.
		/// Utilise pour cela la feuille de données qui a le nom du type courant.
		/// </summary>
		public bool ExcelImport(string filePath, IEnumerable<Type> types)
		{
			bool success = false;
			_warnings.Clear();
			// 1Etape/type + ouverture fichier + sauvegarde en DB
			SetNbrEtapes(types.Count() + 2);
			
			try {
				IWorkbook workbook;
				List<ImportType> _types = new List<ImportType>();

				// Open File
				using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				{
					workbook = WorkbookFactory.Create(file);
				}
				SetFinEtape();

				// importer tous les types
				foreach (Type ct in types)
				{
					//look for sheet
					ISheet sheet = GetSheet(ct, workbook);
					if (sheet == null)
					{
						ReportMessageRef(MessageType.WARNING, "IMPORT_ERROR_NO_SHEET", ct.Name);
					}
					else
					{
						ReportMessageRef(MessageType.INFO, "IMPORT", ct.Name);
						//Import sheet
						ImportType imp = new ImportType(ct);
						ImportExcel.Import(sheet, imp);
						_types.Add(imp);
					}
					SetFinEtape();
				}

				if(_warnings.Count() == 0)
				{
					// Save in DB
					// save raw data (must have IDs before linking references)
					foreach (ImportType it in _types) { it.InsertData(GlobalContext.Data, ReportMessageRef); }
					// update cross references
					foreach (ImportType it in _types) { it.SaveCrossReferences(GlobalContext.Data, ReportMessageRef); }
					// save with references
					foreach (ImportType it in _types) { it.SaveData(GlobalContext.Data); }
					foreach (ImportType it in _types) { it.SaveLateDatas(GlobalContext.Data);  }

					SetFinEtape();

					// Finisehd
					success = true;
				}
			}
			catch (IOException)
			{
				ReportMessageRef(MessageType.ERROR, "CANT_OPEN_FILE");
			}
			catch(Exception ex)
			{
				ReportException(ex);
			}

			ReportSuccess("IMPORT_PROC", success);

			return success;
		}

		/// <summary>
		/// Parse le fichier excel donné et vérifie toutes les règles d'import.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public bool CheckExcelData(string filePath)
		{
			bool success = false;
			// Ouvrir fichier + parser
			SetNbrEtapes(2);

			try
			{
				ImportChecker ic = new ImportChecker();

				// Open File
				using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				{
					ic.Workbook = WorkbookFactory.Create(file);
				}
				SetFinEtape();
				
				// Parse file
				ic.CheckFile();
				// Report results
				ReportMessageRef(MessageType.INFO, "NBR_ERROR_FOUND", ic.ErrorCount);
				foreach (string errMess in ic.Errors)
				{
					ReportMessage(MessageType.INFO, errMess);
				}
				SetFinEtape();

				// Finisehd
				success = true;
			}
			catch (IOException)
			{
				ReportMessageRef(MessageType.ERROR, "CANT_OPEN_FILE");
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			ReportSuccess("IMPORT_PROC", success);

			return success;
		}
	}
}