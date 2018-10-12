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
	/// <summary>
	/// Works on references, developping the values as columns, wich names are prefixed, depending on the type of the reference.
	/// </summary>
	public abstract class RedirectionProp : IExcelPropertyConverter
	{
		public abstract string GetPrefix(string propname);

		public bool CanConvertColumn(PropertyInfo prop, IRow header)
		{
			return header.FindFirstCellStartingWith(GetPrefix(prop.Name)) != -1;
		}
		
		/// <summary>
		/// Need to remember the widths of each sub column created.
		/// Here, we use a stack, because single boolean won't work, because class is singleton.
		/// Hence, the risk is for the import to pass here more than one time in a row, and reset the previous values while it's still used.
		/// </summary>
		private Dictionary<PropertyInfo, List<int>> widthStack = new Dictionary<PropertyInfo, List<int>>();

		public int CreateHeader(IRow headerRow, PropertyInfo prop, int columnOffset)
		{
			//ajouter propriétés du type référencé
			int counter = 0;
			List<int> width = new List<int>();
			foreach (PropertyInfo subProp in prop.PropertyType.GetExportableProperties())
			{
				IExcelPropertyConverter conv = ExportExcel.converters.FirstOrDefault(c => c.CanConvertProperty(subProp));
				if (conv != null)
				{
					int w = conv.CreateHeader(headerRow, subProp, columnOffset + counter);
					width.Add(w);
					counter += w;
				}
			}

			//Add prefixes
			string pref = GetPrefix(prop.Name);
			AddPrefix(headerRow, columnOffset, counter, pref);

			if (!widthStack.ContainsKey(prop))
			{
				widthStack.Add(prop,width);
			}

			return counter;
		}

		private void AddPrefix(IRow headerRow, int columnOffset, int nbrOfRows, string pref)
		{
			for (int i = 0; i < nbrOfRows; i++)
			{
				ICell headerCell = headerRow.GetCell(columnOffset + i);
				headerCell.SetCellValue(pref + headerCell.StringCellValue);
			}
		}

		public void ExportProp(IRow row, object obj, PropertyInfo prop, int columnOffset)
		{
			List<int> width = widthStack[prop];
			//Exporter propriétés du type référencé
			object val = prop.GetValue(obj);
			var props = prop.PropertyType.GetExportableProperties();
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
			int startindex = headerRow.FindFirstCellStartingWith(GetPrefix(prop.Name));
			string pref = GetPrefix(prop.Name);
			int counter = 0;

			//Remove prefixes
			for (int i = startindex; i <= headerRow.LastCellNum; i++)
			{
				ICell headerCell = headerRow.GetCell(i);
				if (headerCell?.StringCellValue.StartsWith(pref) ?? false)
				{
					counter++;
					headerCell.SetCellValue(headerCell.StringCellValue.Remove(0, pref.Length));
				}
			}

			//Get under object
			object val = GetPropertyObject(prop, newObj);

			//import properties
			foreach (PropertyInfo subProp in prop.PropertyType.GetExportableProperties())
			{
				IExcelPropertyConverter conv = ExportExcel.converters.FirstOrDefault(
					c => c.CanConvertProperty(subProp)
					&& c.CanConvertColumn(subProp, headerRow));
				if (conv != null)
				{
					conv.ImportColumn(val, subProp, headerRow, currentRow, impType);
				}
			}

			if (saveAfter.Pop())
			{
				impType.AddLateSave((IDataObject)val);
			}

			//Replace prefixes back
			AddPrefix(headerRow, startindex, counter, pref);
		}

		/// <summary>
		/// Here, we use a stack, because single boolean won't work, because class is singleton.
		/// Hence, the risk is for the import to pass here more than one time in a row, and reset the previous values while it's still used.
		/// </summary>
		private Stack<Boolean> saveAfter = new Stack<bool>();
		public virtual object GetPropertyObject(PropertyInfo prop, object newObject)
		{
			bool save = false;

			object val;
			try
			{
				val = prop.GetValue(newObject);
			}
			catch (Exception e)
			{
				ImportExcel.ReportWarning("TYPE_PROP_NOT_FOUND", prop.Name, prop.DeclaringType);
				throw e;
			}


			if (val == null)
			{
				if (prop.CanWrite)//pointless if can't write the objet back
				{
					val = prop.PropertyType.GetConstructor(new Type[] { }).Invoke(new object[] { });
					if(val is IDataObject dao)
					{
						dao.SaveObject();
					}
					prop.SetValue(newObject, val);
					save = true;
				}
				else
				{
					throw new Exception("Encountered a troublesome property, wich can't be imported");
				}
			}
			saveAfter.Push(save);
			return val;
		}

		public abstract bool CanConvertProperty(PropertyInfo prop);
	}

	/// <summary>
	/// Works on ModelExemplars unique references. Prefixes with 'Ex_'
	/// </summary>
	public class ExcelPropExemplar : RedirectionProp
	{
		public override string GetPrefix(string propname)
		{
			return "Ex_" + propname + "_";
		}

		public override bool CanConvertProperty(PropertyInfo prop) { return typeof(IDataExemplaire).IsAssignableFrom(prop.PropertyType); }
	}

	/// <summary>
	/// Works on Structs unique references, left overs after Models, Descriptions and Exemplars.
	/// </summary>
	public class ExcelPropStruct : RedirectionProp
	{
		public override string GetPrefix(string propname)
		{
			return propname + "_";
		}

		public override bool CanConvertProperty(PropertyInfo prop) { return typeof(IDataObject).IsAssignableFrom(prop.PropertyType); }
	}

	/// <summary>
	/// Works on DataDescriptions, and prefix description properties with "Desc_".
	/// Notice this mechanic relies on the belief there will be only one Description per object.
	/// </summary>
	public class ExcelPropDescription : RedirectionProp
	{
		public override bool CanConvertProperty(PropertyInfo prop) { return typeof(IDataDescription).IsAssignableFrom(prop.PropertyType); }

		public override string GetPrefix(string propname)
		{
			return "Desc_" + propname;
		}
	}
}