using DataGenerator.DataModel2.AttributeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Parser;
using DataGenerator.DataModel2.Model;

namespace DataGenerator.DataModel2.EntityConverter
{
	public class EnumConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "enumtable"; } }

		public EnumConverter() : base()
		{
			MajorTagConverter = AbsMajorTagConverter.NoMajorTag;
			MinorTagConverter = AbsMinorTagConverter.NoMinorTags;
			AttributeConverter = new AbsAttributeConverter()
			{
				SectionConverter	= AbsAttributeSectionConverter.EnumSection,
				TypeConverter		= AbsAttributeTypeConverter.EnumType,
				NameConverter		= AbsAttributeNameConverter.DefaultConverter,
				CardinalityConverter = AbsAttributeCardinalityConverter.NoCardinality,
				ReflexReferenceConverter = AbsAttributeTargetConverter.NoReflex
			};
		}

		public override DataEntity AddEntity(DataModel dm, string tabName)
		{
			DataEnum de = new DataEnum(tabName);
			dm.AddDataEnum(de);
			return de;
		}
	}
}
