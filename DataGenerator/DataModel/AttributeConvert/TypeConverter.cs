using DataGenerator.DataModel.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel.AttributeConvert
{
	/// <summary>
	/// Base class of attribute Type Converters.
	/// </summary>
	public abstract class AbsTypeConverter : AbsAttributeConverter
	{
		public static EnumTypeConverter EnumType = new EnumTypeConverter();
		public static DiceTypeConverter DiceType = new DiceTypeConverter();
		public static DataTypeConverter DataType = new DataTypeConverter();

		public abstract DataEntityAttribute Convert(DataEntity entity, RawAttribute raw, string attName);

		/// <summary>
		/// Check there are no TypeTag value in the RawAttribute, which is therefore not used.
		/// </summary>
		/// <param name="entity">Entity related to the attribute.</param>
		/// <param name="raw">Attribute providing the value to check.</param>
		protected void NoTypeTag(DataEntity entity, RawAttribute raw)
		{
			CheckAttributePresence(entity.Name, raw.Name, raw.TypeTag, false, "TypeTag");
		}
		/// <summary>
		/// Check there are is a Type value in the RawAttribute.
		/// </summary>
		/// <param name="entity">Entity related to the attribute.</param>
		/// <param name="raw">Attribute providing the value to check.</param>
		protected void HasTypeTag(DataEntity entity, RawAttribute raw)
		{
			CheckAttributePresence(entity.Name, raw.Name, raw.TypeTag, true, "TypeTag");
		}
		/// <summary>
		/// Check there are no Type value in the RawAttribute, which is therefore not used.
		/// </summary>
		/// <param name="entity">Entity related to the attribute.</param>
		/// <param name="raw">Attribute providing the value to check.</param>
		protected void NoType(DataEntity entity, RawAttribute raw)
		{
			CheckAttributePresence(entity.Name, raw.Name, raw.Type, false, "Type");
		}
		/// <summary>
		/// Get the converted typeTag as an int. Also check presence of the tag.
		/// </summary>
		/// <param name="entity">Entity related to the attribute.</param>
		/// <param name="raw">Attribute providing the value to check.</param>
		/// <returns>The converted in, or 0 if any.</returns>
		protected int GetTypeTagAsInt(DataEntity entity, RawAttribute raw)
		{
			return CheckAttributeIsInt(entity.Name, raw.Name, raw.TypeTag);
		}
	}

	public class EnumTypeConverter : AbsTypeConverter
	{
		public override DataEntityAttribute Convert(DataEntity entity, RawAttribute raw, string attName)
		{
			NoTypeTag(entity, raw);
			NoType(entity, raw);
			return new DataEnumAttribute(attName);
		}
	}

	public class DiceTypeConverter : AbsTypeConverter
	{
		public override DataEntityAttribute Convert(DataEntity entity, RawAttribute raw, string attName)
		{
			NoType(entity, raw);
			int odds = GetTypeTagAsInt(entity, raw);
			return new DataDiceAttribute(attName, odds);
		}
	}

	public class DataTypeConverter : AbsTypeConverter
	{
		public static readonly DataEnum DistanceEnum = new DataEnum("DistanceUnity", "Distance");
		public static readonly DataEnum TimeEnum = new DataEnum("TimeUnity", "TimePeriod");

		public override DataEntityAttribute Convert(DataEntity entity, RawAttribute raw, string attName)
		{
			AbsDataStructAttribute result = null;
			string type = raw.Type.ToLower();
			switch (type)
			{
				case "int":
					NoTypeTag(entity, raw);
					result = new DataObjectIntAttribute(raw.Name);
					break;
				case "bool":
					NoTypeTag(entity, raw);
					result = new DataObjectBooleanAttribute(raw.Name);
					break;
				case "text":
					NoTypeTag(entity, raw);
					result = new DataObjectTextAttribute(raw.Name);
					break;
				case "real":
					NoTypeTag(entity, raw);
					result = new DataObjectRealAttribute(raw.Name);
					break;
				case "decimal":
					NoTypeTag(entity, raw);
					result = new DataObjectDecimalAttribute(raw.Name);
					break;
				case "range":
					NoTypeTag(entity, raw);
					result = new DataObjectRangeAttribute(raw.Name);
					break;
				case "unit":
					HasTypeTag(entity, raw);
					result = new DataObjectUnitAttribute(raw.Name);
					break;
				case "time":
					NoTypeTag(entity, raw);
					result = new DataObjectUnitAttribute(raw.Name) { Enum = TimeEnum };
					break;
				case "distance":
					NoTypeTag(entity, raw);
					result = new DataObjectUnitAttribute(raw.Name) { Enum = DistanceEnum };
					break;
				case "varchar":
					HasTypeTag(entity, raw);
					int length = GetTypeTagAsInt(entity, raw);
					result = new DataObjectVarcharAttribute(attName, length);
					break;
				case "ref":
					HasTypeTag(entity, raw);
					result = new DataObjectModelRefAttribute(raw.Name);
					break;
				case "refex":
					HasTypeTag(entity, raw);
					result = new DataObjectExemplarRefAttribute(raw.Name);
					break;
				case "enum":
					HasTypeTag(entity, raw);
					result = new DataObjectEnumAttribute(raw.Name);
					break;
				case "timestamp":
					NoTypeTag(entity, raw);
					result = new DataObjectTimestampAttribute(raw.Name);
					break;
				default:
					ErrorManager.ErrorRef("ATT_UNKNOWN_TYPE", entity.Name, attName, raw.Type);
					break;
			}
			return result;
		}
	}
}
