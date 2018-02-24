using DataGenerator.DataModel.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel.AttributeConvert
{
	/// <summary>
	/// Base class of the attribute cardinality converters.
	/// </summary>
	public abstract class AbsCardinalityConverter : AbsAttributeConverter
	{
		public static NoCardinalityConverter NoCardinality = new NoCardinalityConverter();
		public static DataCardinalityConverter DataCardinality = new DataCardinalityConverter();

		public abstract void Convert(DataEntity entity, DataEntityAttribute att, RawAttribute raw);

		public bool NoCardinalityMin(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			return CheckAttributePresence(entity.Name, att.Name, raw.CardMin, false, "CardMin");
		}
		public bool NoCardinalityMax(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			return CheckAttributePresence(entity.Name, att.Name, raw.CardMax, false, "CardMax");
		}
	}

	/// <summary>
	/// Check there are no cardinality values in the RawAttribute, which are therefore not used.
	/// </summary>
	public class NoCardinalityConverter : AbsCardinalityConverter
	{
		public override void Convert(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			NoCardinalityMin(entity, att, raw);
			NoCardinalityMax(entity, att, raw);
		}
	}

	/// <summary>
	/// Basic convertion of the cardinality.
	/// </summary>
	public class DataCardinalityConverter : AbsCardinalityConverter
	{
		public override void Convert(DataEntity entity, DataEntityAttribute aatt, RawAttribute raw)
		{
			AbsDataStructAttribute att = (AbsDataStructAttribute)aatt;
			if (!string.IsNullOrWhiteSpace(raw.CardMin))
			{
				//retrieve Card min
				switch (raw.CardMin)
				{
					case "0":
						att.CanBeNull = true;
						break;
					case "1":
						//do nothing
						break;
					default:
						ErrorManager.ErrorRef("ATT_UNKNOWN_VALUE", entity.Name, att.Name, raw.CardMin);
						break;
				}
			}
			if (!string.IsNullOrWhiteSpace(raw.CardMax))
			{
				//retrive Card max
				switch (raw.CardMax)
				{
					case "*":
						att.IsCollection = true;
						break;
					case "1":
						//do nothing
						break;
					default:
						ErrorManager.ErrorRef("ATT_UNKNOWN_VALUE", entity.Name, att.Name, raw.CardMax);
						break;
				}
			}
		}
	}
}
