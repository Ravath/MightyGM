using Core.Data;
using Core.Data.Schema;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MightyGmCtrl.ImportExport
{
	public static class ExportExcel
	{
		public const int COL_WIDTH_FACTOR = 256;
		public const int NBR_LIGNES_HEADER_SUMMARY = 2;
		public const int NBR_LIGNES_HEADER = 2;
		public const int NBR_MIN_COL_HEADER = 2;

		/// <summary>
		/// The Import/Exportdelegated rule for each managed property type, in priority order.
		/// </summary>
		public static IEnumerable<IExcelPropertyConverter> converters = new List<IExcelPropertyConverter>()
		{
			new ExcelPropModel(),
			new ExcelPropExemplar(),
			new ExcelPropDescription(),
			new ExcelPropDefaultCollection(),
			new ExcelPropStruct(),
			new ExcelPropDefault()
		};

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sheet"></param>
		/// <param name="HeaderCellStyle"></param>
		/// <param name="db">Data source. If null, only header will be generated.</param>
		/// <param name="t">Type to extract.</param>
		/// <returns>A formated and fed excel sheet.</returns>
		public static ISheet CreateSheet(ISheet sheet, ICellStyle HeaderCellStyle, ICellStyle HeaderCellStyleGrid, Database db, Type t)
		{
			if(!t.IsClass || t.IsAbstract) { return sheet; }

			//Filter properties
			IEnumerable<PropertyInfo> properties = t.GetExportableProperties();

			//Get data to export
			IEnumerable<object> enumer;
			if (db == null) { enumer = new List<Object>(); }
			else
			{
				enumer = db.GetDataTable(t);
			}

			//create rows
			IRow header0 = sheet.CreateRow(0); // Type
			IRow header1 = sheet.CreateRow(1); // PropertyName header
			for (int i = 0; i < enumer.Count(); i++)
			{
				sheet.CreateRow(i + NBR_LIGNES_HEADER);
			}

			//create columns
			int columnOffset = 0;
			foreach (PropertyInfo pf in properties)
			{
				IExcelPropertyConverter conv = converters.FirstOrDefault(c => c.CanConvertProperty(pf));
				if(conv != null)
				{
					int width = conv.CreateHeader(header1, pf, columnOffset);
					for (int iObj = 0; iObj < enumer.Count(); iObj++)
					{
						conv.ExportProp(sheet.GetRow(iObj + NBR_LIGNES_HEADER), enumer.ElementAt(iObj), pf, columnOffset);
					}
					columnOffset += width;
				}
			}
			if(columnOffset < NBR_MIN_COL_HEADER)
			{
				columnOffset = NBR_MIN_COL_HEADER;
			}

			//Header Completion
			for (int j = 0; j < NBR_LIGNES_HEADER - 1; j++)
			{
				IRow headerRow = sheet.GetRow(j);
				for (int i = 0; i < columnOffset; i++)
				{
					headerRow.CreateCell(i).CellStyle = HeaderCellStyle;
				}
			}

			// Header : default formatting
			for (int j = 0; j < NBR_LIGNES_HEADER; j++)
			{
				IRow headerRow = sheet.GetRow(j);
				for (int i = 0; i < columnOffset; i++)
				{
					if (j != NBR_LIGNES_HEADER - 1)
						headerRow.CreateCell(i).CellStyle = HeaderCellStyle;
					else//Last Row header has been created during the process
						headerRow.GetCell(i).CellStyle = HeaderCellStyleGrid;
				}
			}
			// Header : specific styles
			if (typeof(DataModel).IsAssignableFrom(t))
			{
				sheet.SetColumnWidth(1, 20 * COL_WIDTH_FACTOR);
				sheet.SetColumnWidth(columnOffset-1, 60 * COL_WIDTH_FACTOR);
				header0.GetCell(0).SetCellValue("Model");
				sheet.CreateFreezePane(2, NBR_LIGNES_HEADER);
			}
			else if (typeof(IDataRelation).IsAssignableFrom(t))
			{
				header0.GetCell(0).SetCellValue("Joint");
				sheet.CreateFreezePane(0, NBR_LIGNES_HEADER);
			}
			else
			{
				header0.GetCell(0).SetCellValue("Struct");
				sheet.CreateFreezePane(0, NBR_LIGNES_HEADER);
			}
			// Header : Table name
			string name = t.Name;
			if (name.EndsWith("Model"))
				name = name.Remove(name.Length - "Model".Length);
			header0.GetCell(1).SetCellValue(name);

			return sheet;
		}
	}
}
