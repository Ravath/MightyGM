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
	public interface IExcelPropertyConverter
	{
		bool CanConvertProperty(PropertyInfo prop);
		bool CanConvertColumn(PropertyInfo prop, IRow header);
		int CreateHeader(IRow headerRow, PropertyInfo prop, int columnOffset);
		void ExportProp(IRow row, object obj, PropertyInfo prop, int columnOffset);
		void ImportColumn(object newObj, PropertyInfo prop, IRow headerRow, IRow currentRow, ImportType impType);
	}


	/// <summary>
	/// Exports a collection into one column, with values separated by ';'.
	/// </summary>
	public class ExcelPropDefaultCollection : IExcelPropertyConverter
	{
		public bool CanConvertColumn(PropertyInfo prop, IRow header)
		{
			return header.FindCell(prop.Name) != -1;
		}

		public bool CanConvertProperty(PropertyInfo prop) {
			if(typeof(String).IsAssignableFrom(prop.PropertyType))
			{
				return false;
			}
			if (!typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
			{
				return false;
			}
			Type subt = prop.PropertyType.GenericTypeArguments[0];
			return subt.IsValueType || typeof(String).IsAssignableFrom(subt);
		}

		public int CreateHeader(IRow headerRow, PropertyInfo prop, int columnOffset)
		{
			ICell headerCell = headerRow.CreateCell(columnOffset);
			headerCell.SetCellValue(prop.Name);

			return 1;
		}

		public void ExportProp(IRow row, object obj, PropertyInfo prop, int columnOffset)
		{
			IEnumerable val = (IEnumerable)prop.GetValue(obj);
			string ev = "";
			foreach (object item in val)
			{
				ev += item.ToString() + ";";
			}
			row.CreateCell(columnOffset).SetCellValue(ev);
		}

		public void ImportColumn(object newObj, PropertyInfo prop, IRow headerRow, IRow currentRow, ImportType impType)
		{
			//Find column
			int i = headerRow.FindCell(prop.Name);

			//Get values
			ICell currentCell = currentRow.GetCell(i);
			string[] vals = currentCell?.StringCellValue.Split(';') ?? new string[0];

			//Create Collection
			Type subType = prop.PropertyType.GenericTypeArguments[0];
			ConstructorInfo ci = typeof(List<>).MakeGenericType(subType).GetConstructor(new Type[] { });
			IList il = (IList)ci.Invoke(new object[] { });

			//Convert values
			foreach (string str in vals)
			{
				if (!String.IsNullOrWhiteSpace(str))
				{
					object o = str.ConvertFromType(subType);
					if (o == null)
					{
						ImportExcel.ReportWarning("CANT_CONVERT", str, subType);
					}
					else
					{
						il.Add(o);
					}
				}
			}

			//Update
			impType.AddCollectionValue((IDataObject)newObj, prop, il);
		}
	}


	/// <summary>
	/// Exports DatModel into 2 columns, suffixed _Tag and _Name.
	/// </summary>
	public class ExcelPropModel : IExcelPropertyConverter
	{
		public bool CanConvertColumn(PropertyInfo prop, IRow header)
		{
			return header.FindCell(prop.Name + "_Tag") != -1;
		}

		public bool CanConvertProperty(PropertyInfo prop) { return typeof(DataModel).IsAssignableFrom(prop.PropertyType); }

		public int CreateHeader(IRow headerRow, PropertyInfo prop, int columnOffset)
		{
			ICell headerCell = headerRow.CreateCell(columnOffset);
			ICell headerCell2 = headerRow.CreateCell(columnOffset+1);
			headerCell.SetCellValue(prop.Name+"_Tag");
			headerCell2.SetCellValue(prop.Name + "_Name");

			return 2;
		}

		public void ExportProp(IRow row, object obj, PropertyInfo prop, int columnOffset)
		{
			DataModel val = (DataModel)prop.GetValue(obj);
			row.CreateCell(columnOffset).SetCellValue(val?.Tag??"");
			row.CreateCell(columnOffset+1).SetCellValue(val?.Name??"");
		}

		public void ImportColumn(object newObj, PropertyInfo prop, IRow headerRow, IRow currentRow, ImportType impType)
		{
			//Find column
			int i = headerRow.FindCell(prop.Name + "_Tag");
			//Get Tag
			IDataObject ido = (IDataObject)newObj;
			PropertyInfo dataModelType = newObj.GetType().GetProperty(prop.Name+"Id");
			ICell cell = currentRow.GetCell(i);
			if(cell != null && !String.IsNullOrWhiteSpace(cell.StringCellValue))
			{
				impType.AddTagReference(ido, dataModelType, cell.StringCellValue, prop.PropertyType);
			}
		}
	}
}