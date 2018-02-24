using DataGenerator.DataModel.AttributeConvert;
using DataGenerator.DataModel.Model;

namespace DataGenerator.DataModel.EntityConvert
{
	public class DataStructConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "structtable"; } }

		public DataStructConverter() : base()
		{
			MajorTagConverter = AbsMajorTagConverter.DataObjectMajorTag;
			MinorTagConverter = AbsMinorTagConverter.StructTags;
			AttributeConverter = new AttributeConverter()
			{
				SectionConverter	= AbsSectionConverter.StructSection,
				TypeConverter		= AbsTypeConverter.DataType,
				NameConverter		= AbsNameConverter.DefaultConverter,
				CardinalityConverter = AbsCardinalityConverter.DataCardinality,
				ReflexReferenceConverter = AbsTargetConverter.StructTarget
			};
		}

		public override DataEntity AddEntity(DatabaseModel dm, string tabName)
		{
			DataStruct de = new DataStruct(tabName);
			dm.AddDataStruct(de);
			return de;
		}
	}
}
