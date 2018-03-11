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
		public static int NBR_LIGNES_HEADER = 1;

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
		public static ISheet CreateSheet(ISheet sheet, ICellStyle HeaderCellStyle, Database db, Type t)
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
			IRow header = sheet.CreateRow(0);
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
					int width = conv.CreateHeader(header, pf, columnOffset);
					for (int iObj = 0; iObj < enumer.Count(); iObj++)
					{
						conv.ExportProp(sheet.GetRow(iObj + NBR_LIGNES_HEADER), enumer.ElementAt(iObj), pf, columnOffset);
					}
					columnOffset += width;
				}
			}

			//header formatting
			for (int j = 0; j < NBR_LIGNES_HEADER; j++)
			{
				IRow headerRow = sheet.GetRow(j);
				for (int i = 0; i < columnOffset; i++)
				{
					headerRow.GetCell(i).CellStyle = HeaderCellStyle;
				}
			}

			return sheet;
		}
	}
}
