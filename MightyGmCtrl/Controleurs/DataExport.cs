using Core.Data;
using MightyGmCtrl.ImportExport;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MightyGmCtrl.Controleurs
{
	public class DataExport : Controleur
	{
		public DataExport(Context context) : base(context)
		{
		}

		public bool ExportDataToExcel(string outputFilePath, IEnumerable<Type> types)
		{
			bool success = false;
			// 1Etape/type + enregistrement fichier
			SetNbrEtapes(types.Count()+1);

			try
			{
				//Create excel document
				IWorkbook workbook = new XSSFWorkbook();

				//créer le style de cellule du header
				ICellStyle HeaderCellStyle = workbook.CreateCellStyle();
				HeaderCellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey40Percent.Index;
				IFont boldFont = workbook.CreateFont();
				boldFont.IsBold = true;
				HeaderCellStyle.SetFont(boldFont);

				//créer le sommaire
				ISheet sommaire = workbook.CreateSheet(GlobalContext.GetMessageRessource("SUMMARY"));

				//ajouter les types
				for (int i = 0; i < types.Count(); i++)
				{
					//nouvelle feuille
					string sheetName = "D" + i;
					ISheet newSheet = workbook.CreateSheet(sheetName);

					//maj sommaire : nouvelle ligne
					IRow rs = sommaire.CreateRow(i);
					rs.CreateCell(1).SetCellValue(types.ElementAt(i).Name);
					rs.CreateCell(0).SetCellValue(sheetName);
					//maj sommaire : Creation hyperlien
					XSSFHyperlink link2 = new XSSFHyperlink(HyperlinkType.Document);
					link2.Address = sheetName+"!A1";
					rs.GetCell(0).Hyperlink = link2;

					//Creation feuille
					ExportExcel.CreateSheet(newSheet, HeaderCellStyle, GlobalContext.Data, types.ElementAt(i));
					SetFinEtape();
				}

				//Write excel file
				using (FileStream file = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
				{
					workbook.Write(file);
				}
				SetFinEtape();

				//Finished
				success = true;
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			ReportSuccess("EXPORT_PROC", success);

			return success;
		}

		public bool ExportModeleDataToWord(Type t, string outputFilePath)
		{
			bool success = false;
			// Ecriture document + sauvegarde
			SetNbrEtapes(2);

			try
			{
				//Create word document
				XWPFDocument doc = ExportWord.WriteDocument(t, GlobalContext.Data);

				SetFinEtape();

				//Write word file
				using (FileStream outFile = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
				{
					doc.Write(outFile);
				}
				SetFinEtape();

				//Finished
				success = true;
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			ReportSuccess("EXPORT_PROC", success);

			return success;
		}
	}
}
