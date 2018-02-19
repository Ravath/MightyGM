using DataGenerator.DataModel2.Model;
using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.AttributeConverter
{
	public abstract class AbsAttributeTypeConverter
	{
		public static EnumTypeConverter EnumType = new EnumTypeConverter();
		public static DiceTypeConverter DiceType = new DiceTypeConverter();
		public static DataTypeConverter DataType = new DataTypeConverter();

		public abstract DataAttribute Convert(DataEntity entity, RawAttribute raw, string attName);

		protected void NoTypeTag(DataEntity entity, RawAttribute raw)
		{
			AttributeCheck.CheckAttributePresence(entity.Name, raw.Name, raw.TypeTag, false, "TypeTag");
		}
		protected void HasTypeTag(DataEntity entity, RawAttribute raw)
		{
			AttributeCheck.CheckAttributePresence(entity.Name, raw.Name, raw.TypeTag, true, "TypeTag");
		}
		protected void NoType(DataEntity entity, RawAttribute raw)
		{
			AttributeCheck.CheckAttributePresence(entity.Name, raw.Name, raw.Type, false, "Type");
		}
		protected int GetTypeTagAsInt(DataEntity entity, RawAttribute raw)
		{
			return AttributeCheck.CheckAttributeIsInt(entity.Name, raw.Name, raw.TypeTag);
		}
	}

	public class EnumTypeConverter : AbsAttributeTypeConverter
	{
		public override DataAttribute Convert(DataEntity entity, RawAttribute raw, string attName)
		{
			NoTypeTag(entity, raw);
			NoType(entity, raw);
			return new DataEnumAttribute(attName);
		}
	}

	public class DiceTypeConverter : AbsAttributeTypeConverter
	{
		public override DataAttribute Convert(DataEntity entity, RawAttribute raw, string attName)
		{
			NoType(entity, raw);
			int odds = GetTypeTagAsInt(entity, raw);
			return new DataDiceAttribute(attName, odds);
		}
	}

	public class DataTypeConverter : AbsAttributeTypeConverter
	{
		public override DataAttribute Convert(DataEntity entity, RawAttribute raw, string attName)
		{
			DataObjectAttribute result = null;
			string type = raw.Type.ToLower();
			switch (type)
			{
				case "int":
					NoTypeTag(entity, raw);
					result = new DataIntAttribute(raw.Name);
					break;
				case "bool":
					NoTypeTag(entity, raw);
					result = new DataBooleanAttribute(raw.Name);
					break;
				case "text":
					NoTypeTag(entity, raw);
					result = new DataTextAttribute(raw.Name);
					break;
				case "real":
					NoTypeTag(entity, raw);
					result = new DataRealAttribute(raw.Name);
					break;
				case "decimal":
					NoTypeTag(entity, raw);
					result = new DataDecimalAttribute(raw.Name);
					break;
				case "range"://int only
								//TODO add Unit(enumRef) (int only)
				case "time"://is a specialized Unit(TimeEnum) reference
				case "distance"://is a specialized Unit(DistanceEnum) reference
								//TODO implement ConvertDataObjectAttribute of every type
					throw new NotImplementedException();
				case "varchar":
					HasTypeTag(entity, raw);
					int length = GetTypeTagAsInt(entity, raw);
					result = new DataVarcharAttribute(attName, length);
					break;
				case "ref":
					HasTypeTag(entity, raw);
					result = new DataRefAttribute(raw.Name);
					break;
				case "refex":
					HasTypeTag(entity, raw);
					result = new DataRefexAttribute(raw.Name);
					break;
				case "enum":
					HasTypeTag(entity, raw);
					result = new DataObjectEnumAttribute(raw.Name);
					break;
				default:
					ErrorManager.ErrorRef("ATT_UNKNOWN_TYPE", entity.Name, attName, raw.Type);
					break;
			}
			return result;
		}
	}
}
