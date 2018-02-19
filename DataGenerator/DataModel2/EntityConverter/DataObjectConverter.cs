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
	public class DataObjectConverter : AbsEntityConverter
	{
		public override string EntityTag { get { return "datatable"; } }

		public DataObjectConverter()
		{
			MajorTagConverter = AbsMajorTagConverter.DataObjectMajorTag;
			MinorTagConverter = AbsMinorTagConverter.ObjectTags;
			AttributeConverter = new AbsAttributeConverter()
			{
				SectionConverter		= AbsAttributeSectionConverter.ObjectSection,
				TypeConverter			= AbsAttributeTypeConverter.DataType,
				NameConverter			= AbsAttributeNameConverter.DefaultConverter,
				CardinalityConverter	= AbsAttributeCardinalityConverter.DataCardinality,
				ReflexReferenceConverter = null
			};
		}

		public override DataEntity AddEntity(DataModel dm, string tabName)
		{
			DataObject de = new DataObject(tabName);
			dm.AddDataObject(de);
			return de;
		}
	}
}
