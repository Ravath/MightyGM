using Core.Data;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MightyGmCtrl.ImportExport
{
	public class ExcelPropExemplar : IExcelPropertyConverter
	{
		public bool CanConvertColumn(PropertyInfo prop, IRow header)
		{
			return header.FindFirstCellStartingWith("Ex_" + prop.Name + "_") != -1;
		}

		public bool CanConvertProperty(PropertyInfo prop) { return typeof(IDataExemplaire).IsAssignableFrom(prop.PropertyType); }

		private IEnumerable<PropertyInfo> GetProperties(Type sub)
		{
			return sub.GetProperties().Where(sp => !sp.Name.EndsWith("Id")).Reverse();
		}

		//need to remember the widths of each sub column created.
		private List<int> width = new List<int>();

		public int CreateHeader(IRow headerRow, PropertyInfo prop, int columnOffset)
		{
			//ajouter propriétés du type référencé
			int counter = 0;
			width.Clear();
			foreach (PropertyInfo subProp in GetProperties(prop.PropertyType))
			{
				IExcelPropertyConverter conv = ExportExcel.converters.FirstOrDefault(c => c.CanConvertProperty(subProp));
				if (conv != null)
				{
					int w = conv.CreateHeader(headerRow, subProp, columnOffset + counter);
					width.Add(w);
					counter += w;
				}
			}

			//Ajouter préfixe
			string pref = "Ex_" + prop.Name + "_";
			for (int i = 0; i < counter; i++)
			{
				ICell headerCell = headerRow.GetCell(columnOffset + i);
				headerCell.SetCellValue(pref + headerCell.StringCellValue);
			}

			return counter;
		}

		public void ExportProp(IRow row, object obj, PropertyInfo prop, int columnOffset)
		{
			//Exporter propriétés du type référencé
			Type sub = prop.GetType().GenericTypeArguments[0];
			object val = prop.GetValue(obj);
			var props = GetProperties(sub);
			int subOffset = columnOffset;

			for (int i = 0; i < props.Count(); i++)
			{
				IExcelPropertyConverter conv = ExportExcel.converters.First(c => c.CanConvertProperty(props.ElementAt(i)));
				conv.ExportProp(row, val, props.ElementAt(i), subOffset);
				subOffset += width[i];
			}
		}

		public void ImportColumn(object newObj, PropertyInfo prop, IRow headerRow, IRow currentRow, ImportType impType)
		{
			//return null;
			throw new NotImplementedException();
		}
	}
}