using DataGenerator.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.DataModel.EntityConvert
{
	/// <summary>
	/// List of every possible MinorTag.
	/// </summary>
	public enum MinorTag
	{
		Odd, Abstract, Pj, Implementation
	}

	/// <summary>
	/// Base class of Minor Tag Converters.
	/// </summary>
	public abstract class AbsMinorTagConverter
	{
		public static NoMinorTagConverter NoMinorTags = new NoMinorTagConverter();
		public static DataStructMinorTagsConverter StructTags = new DataStructMinorTagsConverter();
		public static DataObjectMinorTagsConverter ObjectTags = new DataObjectMinorTagsConverter();

		public abstract bool ConvertTags(DataEntity entity, IEnumerable<string> tags);

		/// <summary>
		/// Convert from string to the equivalent enumeration.
		/// </summary>
		/// <param name="tags">Strings to convert.</param>
		/// <param name="tableName">The name of the tables providing the values.</param>
		/// <returns>Converted MinorTags.</returns>
		public HashSet<MinorTag> GetTags(IEnumerable<string> tags, string tableName)
		{
			HashSet<MinorTag> result = new HashSet<MinorTag>();
			foreach (string tag in tags)
			{
				foreach (var item in Enum.GetValues(typeof(MinorTag)))
				{
					if (item.ToString().ToLower() == tag.ToLower())
					{
						if (result.Contains((MinorTag)item))
						{
							ErrorManager.ErrorRef("TAG_DUPLICATE", tableName, tag);
						}
						else
						{
							result.Add((MinorTag)item);
						}
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Checks if Forbidden MinorTags are used.
		/// </summary>
		/// <param name="tags">The tags to check.</param>
		/// <param name="forbiddens">The orbidden tags.</param>
		/// <param name="tableName">The name of the table providing the tags.</param>
		/// <param name="tableTypeName">The nameType of the table providing the names.</param>
		public void ForbiddenTags(IEnumerable<MinorTag> tags, HashSet<MinorTag> forbiddens, string tableName, string tableTypeName)
		{
			foreach (MinorTag tag in tags)
			{
				if (forbiddens.Contains(tag))
				{
					ErrorManager.ErrorRef("TAG_FORBIDDEN", tableName, tag, tableTypeName);
				}
			}
		}
	}

	/// <summary>
	/// Check there isn't any MiinorTag values in the RawTable, which are therefore not used.
	/// </summary>
	public class NoMinorTagConverter : AbsMinorTagConverter
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

	/// <summary>
	/// Converts the MinorTags from string to MinorTag enumeration.
	/// </summary>
	public class DataMinorTagsConverter : AbsMinorTagConverter
	{
		public override bool ConvertTags(DataEntity entity, IEnumerable<string> tags)
		{
			bool result = true;
			entity.AddTags(GetTags(tags, entity.Name));
			return result;
		}
	}

	public class DataObjectMinorTagsConverter : DataMinorTagsConverter
	{
		public override bool ConvertTags(DataEntity entity, IEnumerable<string> tags)
		{
			bool result = base.ConvertTags(entity, tags);
			return result;
		}
	}

	public class DataStructMinorTagsConverter : DataMinorTagsConverter
	{
		public override bool ConvertTags(DataEntity entity, IEnumerable<string> tags)
		{
			bool result = base.ConvertTags(entity, tags);
			return result;
		}
	}
}
