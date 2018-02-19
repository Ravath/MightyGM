using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Parser;
using DataGenerator.DataModel2.Model;

namespace DataGenerator.DataModel2.EntityConverter
{
	public abstract class AbsMinorTagConverter
	{
		public static NoTagConverter NoMinorTags = new NoTagConverter();
		public static DataStructTagsConverter StructTags = new DataStructTagsConverter();
		public static DataObjectTagsConverter ObjectTags = new DataObjectTagsConverter();

		public abstract bool ConvertTags(DataEntity entity, IEnumerable<string> tags);
	}

	public class NoTagConverter : AbsMinorTagConverter
	{
		public override bool ConvertTags(DataEntity entity, IEnumerable<string> tags)
		{
			bool result = true;
			if(tags.Count() != 0)
			{
				ErrorManager.ErrorRef("NO_TAGS_EXPECTED", entity.Name);
				result = false;
			}
			return result;
		}
	}

	public class DataTagsConverter : AbsMinorTagConverter
	{
		public override bool ConvertTags(DataEntity entity, IEnumerable<string> tags)
		{
			bool result = true;
			//TODO implements
			return result;
		}
	}

	public class DataObjectTagsConverter : DataTagsConverter
	{
		public override bool ConvertTags(DataEntity entity, IEnumerable<string> tags)
		{
			bool result = base.ConvertTags(entity, tags);
			DataObject datObj = (DataObject)entity;
			//TODO specific
			return result;
		}
	}
	public class DataStructTagsConverter : DataTagsConverter
	{
		public override bool ConvertTags(DataEntity entity, IEnumerable<string> tags)
		{
			bool result = base.ConvertTags(entity, tags);
			DataStruct datObj = (DataStruct)entity;
			//TODO specific
			return result;
		}
	}
}
