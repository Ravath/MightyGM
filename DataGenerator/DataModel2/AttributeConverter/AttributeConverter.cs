using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.AttributeConverter
{
	public class AbsAttributeConverter
	{
		public AbsAttributeSectionConverter			SectionConverter		{ get; set; }
		public AbsAttributeTypeConverter			TypeConverter			{ get; set; }
		public AbsAttributeNameConverter			NameConverter			{ get; set; }
		public AbsAttributeCardinalityConverter		CardinalityConverter	{ get; set; }
		public AbsAttributeTargetConverter ReflexReferenceConverter { get; set; }

		public void AddAttribute(DataEntity entity, RawAttribute raw)
		{
			string attName = NameConverter.GetName(entity, raw);
			DataAttribute att = TypeConverter.Convert(entity, raw, attName);

			CardinalityConverter.Convert(entity, att, raw);

			SectionConverter.AddAttribute(entity, att, raw);
		}
	}
}
