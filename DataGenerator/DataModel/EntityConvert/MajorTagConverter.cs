using DataGenerator.DataModel.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel.EntityConvert
{
	/// <summary>
	/// Base class of Major Tag Converters. Mainly consists in managing inheritance.
	/// </summary>
	public abstract class AbsMajorTagConverter
	{
		public static NoMajorTagConverter NoMajorTag = new NoMajorTagConverter();
		public static DataObjectNoMajorTagConverter DataObjectMajorTag = new DataObjectNoMajorTagConverter();

		public abstract void ConvertTag(DatabaseModel dm, DataEntity entity, RawTable tab);

		/// <summary>
		/// Checks the if no MajorTag.
		/// </summary>
		/// <param name="entity">Entity to check.</param>
		/// <param name="raw">The RawTable to check.</param>
		protected void NoTag(DataEntity entity, RawTable raw)
		{
			if (!string.IsNullOrWhiteSpace(raw.MajorTag))
			{
				ErrorManager.ErrorRef("TABLE_MAJOR_TAG_FOUND", entity.Name);
			}
		}
	}

	/// <summary>
	/// Check there isn't a MajorTag value in the RawTable, which is therefore not used.
	/// </summary>
	public class NoMajorTagConverter : AbsMajorTagConverter
	{
		public override void ConvertTag(DatabaseModel dm, DataEntity entity, RawTable tab)
		{
			NoTag(entity, tab);
		}
	}

	/// <summary>
	/// Uses the MajorTag of the RawTable in order to find the inherited entity in model.
	/// </summary>
	public class DataObjectNoMajorTagConverter : AbsMajorTagConverter
	{
		public override void ConvertTag(DatabaseModel dm, DataEntity entity, RawTable tab)
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
					ErrorManager.ErrorRef("TABLE_NOT_FOUND", entity.Name, tab.MajorTag);
				}
			}
		}
	}
}