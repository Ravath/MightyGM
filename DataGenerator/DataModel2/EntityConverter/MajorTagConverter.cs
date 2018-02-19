using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataGenerator.DataModel2.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel2.EntityConverter
{
	public abstract class AbsMajorTagConverter
	{
		public static NoMajorTagConverter NoMajorTag = new NoMajorTagConverter();
		public static DataObjectNoMajorTagConverter DataObjectMajorTag = new DataObjectNoMajorTagConverter();

		public abstract void ConvertTag(DataModel dm, DataEntity entity, RawTable tab);

		protected void NoTag(DataEntity entity, RawTable raw)
		{
			if (!string.IsNullOrWhiteSpace(raw.MajorTag))
			{
				ErrorManager.ErrorRef("TABLE_MAJOR_TAG_FOUND", entity.Name);
			}
		}
	}

	public class NoMajorTagConverter : AbsMajorTagConverter
	{
		public override void ConvertTag(DataModel dm, DataEntity entity, RawTable tab)
		{
			NoTag(entity, tab);
		}
	}

	public class DataObjectNoMajorTagConverter : AbsMajorTagConverter
	{
		public override void ConvertTag(DataModel dm, DataEntity entity, RawTable tab)
		{
			if (!string.IsNullOrWhiteSpace(tab.MajorTag))
			{
				DataEntity parent = null;
				if(entity is DataObject entityObj)
				{
					parent = dm.GetDataObject(tab.MajorTag);
					entityObj.Parent = (DataObject)parent;
				}
				else if (entity is DataStruct entityStr)
				{
					parent = dm.GetDataStruct(tab.MajorTag);
					entityStr.Parent = (DataStruct)parent;
				}
				if(parent == null)
				{
					ErrorManager.ErrorRef("TABLE_NOT_FOUND_PARENT", entity.Name, tab.MajorTag);
				}
			}
		}
	}
}