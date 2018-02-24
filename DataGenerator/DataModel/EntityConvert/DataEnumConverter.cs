using DataGenerator.DataModel.AttributeConvert;
using DataGenerator.DataModel.Model;

namespace DataGenerator.DataModel.EntityConvert
{
	public class DataEnumConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "enumtable"; } }

		public DataEnumConverter() : base()
		{
			MajorTagConverter = AbsMajorTagConverter.NoMajorTag;
			MinorTagConverter = AbsMinorTagConverter.NoMinorTags;
			AttributeConverter = new AttributeConverter()
			{
				SectionConverter	= AbsSectionConverter.EnumSection,
				TypeConverter		= AbsTypeConverter.EnumType,
				NameConverter		= AbsNameConverter.DefaultConverter,
				CardinalityConverter = AbsCardinalityConverter.NoCardinality,
				ReflexReferenceConverter = AbsTargetConverter.NoTarget
			};
		}

		public override DataEntity AddEntity(DatabaseModel dm, string tabName)
		{
			DataEnum de = new DataEnum(tabName);
			dm.AddDataEnum(de);
			return de;
		}
	}
}
