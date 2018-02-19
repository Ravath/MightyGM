using Core.Data;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MightyGmCtrl.ImportExport
{
	/// <summary>
	/// Get everything, and convert as the closer type value.
	/// use property name as column header name.
	/// </summary>
	public class ExcelPropDefault : IExcelPropertyConverter
	{
		public bool CanConvertColumn(PropertyInfo prop, IRow header)
		{
			return header.FindCell(prop.Name) != -1;
		}
		public bool CanConvertProperty(PropertyInfo prop) { return typeof(String).IsAssignableFrom(prop.PropertyType) || !typeof(IEnumerable).IsAssignableFrom(prop.PropertyType); }

		public int CreateHeader(IRow headerRow, PropertyInfo prop, int columnOffset)
		{
			//create header
			ICell headerCell = headerRow.CreateCell(columnOffset);
			headerCell.SetCellValue(prop.Name);

			return 1;
		}

		public void ExportProp(IRow row, object obj, PropertyInfo prop, int columnOffset)
		{
			ICell cell = row.CreateCell(columnOffset);
			object val = prop.GetValue(obj) ?? "";
			if (typeof(double).IsAssignableFrom(val.GetType()))
			{
				cell.SetCellValue((double)val);
			}
			else if (typeof(decimal).IsAssignableFrom(val.GetType()))
			{
				cell.SetCellValue(val.ToString());
			}
			else if (typeof(int).IsAssignableFrom(val.GetType()))
			{
				cell.SetCellValue((int)val);
			}
			else if (typeof(bool).IsAssignableFrom(val.GetType()))
			{
				cell.SetCellValue((bool)val);
			}
			else if (typeof(IDataDescription).IsAssignableFrom(val.GetType()))
			{
				cell.SetCellValue(((IDataDescription)val).Description);
			}
			else
			{
				cell.SetCellValue(val.ToString());
			}
		}

		public void ImportColumn(object newObj, PropertyInfo prop, IRow headerRow, IRow currentRow, ImportType impType)
		{
			ICell currentCell = currentRow.GetCell(headerRow.FindCell(prop.Name));
			Object o;
			if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				// If can be null
				Type gent = prop.PropertyType.GetGenericArguments()[0];
				o = currentCell.ConvertFromType(gent);
			}
			else
			{
				// if can"t be null
				o = currentCell.ConvertFromType(prop.PropertyType);
				// if null, assign default value
				if (o == null)
				{
					if (prop.PropertyType == typeof(string))
						o = "";
					else if (prop.PropertyType == typeof(bool))
						o = false;
					else if (prop.PropertyType == typeof(int))
						o = (int)0;
					else if (prop.PropertyType == typeof(decimal))
						o = (decimal)0;
					else if (prop.PropertyType == typeof(float))
						o = (float)0f;
					else if (prop.PropertyType == typeof(double))
						o = (double)0f;
					else if (prop.PropertyType == typeof(byte))
						o = (byte)0f;
				}
			}
			// Update
			prop.SetMethod.Invoke(newObj, new Object[] { o });
		}
	}
}