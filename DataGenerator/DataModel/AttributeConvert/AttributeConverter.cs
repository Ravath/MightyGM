using DataGenerator.DataModel.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel.AttributeConvert
{
	/// <summary>
	/// The full Manager of a attribute convertino from Raw to a DataModel Attribute.
	/// </summary>
	public class AttributeConverter
	{
		public AbsSectionConverter			SectionConverter		{ get; set; }
		public AbsTypeConverter			TypeConverter			{ get; set; }
		public AbsNameConverter			NameConverter			{ get; set; }
		public AbsCardinalityConverter		CardinalityConverter	{ get; set; }
		public AbsTargetConverter ReflexReferenceConverter { get; set; }

		/// <summary>
		/// Add the given RawAttribute to the given DataEntity.
		/// </summary>
		/// <param name="entity">DataEntity where belongs the attribute.</param>
		/// <param name="raw">Raw definition of the attribute.</param>
		public void AddAttribute(DataEntity entity, RawAttribute raw)
		{
			string attName = NameConverter.GetName(entity, raw);
			DataEntityAttribute att = TypeConverter.Convert(entity, raw, attName);

			CardinalityConverter.Convert(entity, att, raw);

			SectionConverter.AddAttribute(entity, att, raw);
		}
	}
}
