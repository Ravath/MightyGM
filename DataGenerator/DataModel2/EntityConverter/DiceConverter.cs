using DataGenerator.DataModel2.AttributeConverter;
using DataGenerator.DataModel2.Model;
using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.EntityConverter
{
	public class DiceConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "dicetable"; } }

		public DiceConverter() : base()
		{
			MajorTagConverter = AbsMajorTagConverter.NoMajorTag;
			MinorTagConverter = AbsMinorTagConverter.NoMinorTags;
			AttributeConverter = new AbsAttributeConverter()
			{
				SectionConverter	= AbsAttributeSectionConverter.DiceSection,
				TypeConverter		= AbsAttributeTypeConverter.DiceType,
				NameConverter		= AbsAttributeNameConverter.DefaultConverter,
				CardinalityConverter = AbsAttributeCardinalityConverter.NoCardinality,
				ReflexReferenceConverter = AbsAttributeTargetConverter.NoReflex
			};
		}

		public override DataEntity AddEntity(DataModel dm, string tabName)
		{
			DataDice de = new DataDice(tabName);
			dm.AddDataDice(de);
			return de;
		}
	}
}
