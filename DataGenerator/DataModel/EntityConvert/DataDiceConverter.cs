using DataGenerator.DataModel.AttributeConvert;
using DataGenerator.DataModel.Model;

namespace DataGenerator.DataModel.EntityConvert
{
	public class DataDiceConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "dicetable"; } }

		public DataDiceConverter() : base()
		{
			MajorTagConverter = AbsMajorTagConverter.NoMajorTag;
			MinorTagConverter = AbsMinorTagConverter.NoMinorTags;
			AttributeConverter = new AttributeConverter()
			{
				SectionConverter	= AbsSectionConverter.DiceSection,
				TypeConverter		= AbsTypeConverter.DiceType,
				NameConverter		= AbsNameConverter.DefaultConverter,
				CardinalityConverter = AbsCardinalityConverter.NoCardinality,
				ReflexReferenceConverter = AbsTargetConverter.NoTarget
			};
		}

		public override DataEntity AddEntity(DatabaseModel dm, string tabName)
		{
			DataDice de = new DataDice(tabName);
			dm.AddDataDice(de);
			return de;
		}
	}
}
