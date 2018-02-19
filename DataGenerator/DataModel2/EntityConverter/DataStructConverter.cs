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
	public class DataStructConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "structtable"; } }

		public DataStructConverter() : base()
		{
			MajorTagConverter = AbsMajorTagConverter.DataObjectMajorTag;
			MinorTagConverter = AbsMinorTagConverter.StructTags;
			AttributeConverter = new AbsAttributeConverter()
			{
				SectionConverter	= AbsAttributeSectionConverter.StructSection,
				TypeConverter		= AbsAttributeTypeConverter.DataType,
				NameConverter		= AbsAttributeNameConverter.DefaultConverter,
				CardinalityConverter = AbsAttributeCardinalityConverter.DataCardinality,
				ReflexReferenceConverter = null
			};
		}

		public override DataEntity AddEntity(DataModel dm, string tabName)
		{
			DataStruct de = new DataStruct(tabName);
			dm.AddDataStruct(de);
			return de;
		}
	}
}
