using Core.Data;
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
		public static IEnumerable<IExcelPropertyConverter> converters = new List<IExcelPropertyConverter>()
		{
			new ExcelPropModel(),
			new ExcelPropExemplar(),
			new ExcelPropDescription(),
			new ExcelPropDefaultCollection(),
			new ExcelPropDefault()
		};

		public static ISheet CreateSheet(ISheet sheet, ICellStyle HeaderCellStyle, Database db, Type t)
		{
			if(!t.IsClass || t.IsAbstract) { return sheet; }

			//Filter properties
			IEnumerable<PropertyInfo> properties = t.GetProperties().Reverse();
			if (typeof(DataObject).IsAssignableFrom(t))
			{
				//Remove Id property
				properties = properties.Where(tp => !(tp.Name.EndsWith("Id") && tp.PropertyType == typeof(int)));
			}
			if (typeof(IDataRelation).IsAssignableFrom(t))
			{
				//Remove Object properties
				properties = properties.Where(tp => 
					tp.Name != "Object1" && tp.Name != "Object2" 
					&& tp.Name != "Property1" && tp.Name != "Property2"
					&& tp.Name != "Obj1Type" && tp.Name != "Obj2Type");
			}

			//create rows
			IEnumerable<object> enumer = db.GetDataTable(t);
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

			//mise en forme du header
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
