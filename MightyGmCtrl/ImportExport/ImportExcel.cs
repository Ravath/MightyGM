using Core.Data;
using Core.Data.Schema;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MightyGmCtrl.ImportExport
{
	public class ImportExcel
	{
		public delegate void ReportWarningHandler(string tag, params object[] ags);
		public static event ReportWarningHandler EventReported;
		internal static void ReportWarning(string tag, params object[] args)
		{
			EventReported?.Invoke(tag, args);
		}

		/// <summary>
		/// Une liste d'objets du type désiré, importé de la feuille excel spécifiée.
		/// La correspondance avec les données se base sur les noms de colonnes spécifiés en première ligne. Casse respectée.
		/// </summary>
		/// <param name="import">Contient les infos sur le type de données à enregistrer, et récupère le résultat.</param>
		/// <param name="sheet">Feuille excel à importer.</param>
		/// <returns>null si n'a pas trouvé de feuille ou si ne peux pas ouvrir le fichier.</returns>
		public static void Import(ISheet sheet, ImportType import)
		{
			IRow headerRow = sheet.GetRow(ExportExcel.NBR_LIGNES_HEADER-1);
			//Extraire les données (1eres lignes : header)
			for (int i = ExportExcel.NBR_LIGNES_HEADER; i <= sheet.LastRowNum; i++)
			{
				//pour chaque ligne
				IRow currentRow = sheet.GetRow(i);
				if (currentRow == null)
					continue;
				object newObject = import.CreateInstance();

				//Faire correspondre propriété avec colonne
				foreach (PropertyInfo prop in import.ModelType.GetExportableProperties())
				{
					//Find a converter
					IExcelPropertyConverter conv = ExportExcel.converters.FirstOrDefault(
						c => c.CanConvertProperty(prop)
						&& c.CanConvertColumn(prop, headerRow));
					if (conv != null)
					{
						// Do the importation of the property for this row
						conv.ImportColumn(newObject, prop, headerRow, currentRow, import);
					}
				}
			}
		}
	}
}
