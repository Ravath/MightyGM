using DataGenerator.DataModel.AttributeConvert;
using DataGenerator.DataModel.Model;

namespace DataGenerator.DataModel.EntityConvert
{
	public class DataObjectConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "datatable"; } }

		public DataObjectConverter()
		{
			MajorTagConverter = AbsMajorTagConverter.DataObjectMajorTag;
			MinorTagConverter = AbsMinorTagConverter.ObjectTags;
			AttributeConverter = new AttributeConverter()
			{
				SectionConverter = AbsSectionConverter.ObjectSection,
				TypeConverter = AbsTypeConverter.DataType,
				NameConverter = AbsNameConverter.DefaultConverter,
				CardinalityConverter = AbsCardinalityConverter.DataCardinality,
				ReflexReferenceConverter = AbsTargetConverter.DataObjetTarget
			};
		}

		public override DataEntity AddEntity(DatabaseModel dm, string tabName)
		{
			DataObject de = new DataObject(tabName);
			dm.AddDataObject(de);
			return de;
		}
	}
}
