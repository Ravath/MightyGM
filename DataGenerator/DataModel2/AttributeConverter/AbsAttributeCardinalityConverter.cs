using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.AttributeConverter
{

	public abstract class AbsAttributeCardinalityConverter
	{
		public static NoCardinalityConverter NoCardinality = new NoCardinalityConverter();
		public static DataCardinalityConverter DataCardinality = new DataCardinalityConverter();

		public abstract void Convert(DataEntity entity, DataAttribute att, RawAttribute raw);

		public bool NoCardinalityMin(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			return AttributeCheck.CheckAttributePresence(entity.Name, att.Name, raw.CardMin, false, "CardMin");
		}
		public bool NoCardinalityMax(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			return AttributeCheck.CheckAttributePresence(entity.Name, att.Name, raw.CardMax, false, "CardMax");
		}
	}

	public class NoCardinalityConverter : AbsAttributeCardinalityConverter
	{
		public override void Convert(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			NoCardinalityMin(entity, att, raw);
			NoCardinalityMax(entity, att, raw);
		}
	}

	public class DataCardinalityConverter : AbsAttributeCardinalityConverter
	{
		public override void Convert(DataEntity entity, DataAttribute aatt, RawAttribute raw)
		{
			DataObjectAttribute att = (DataObjectAttribute)aatt;
			//Check if Cardinality
			if (!string.IsNullOrWhiteSpace(raw.CardMin) || !string.IsNullOrWhiteSpace(raw.CardMax))
			{
				//retrieve Card min
				if (NoCardinalityMin(entity, att, raw))
				{
					switch (raw.CardMin)
					{
						case "0":
							att.CanBeNull = true;
							break;
						default:
							ErrorManager.ErrorRef("ATT_UNKNOWN_VALUE", entity.Name, att.Name, raw.CardMin);
							break;
					}
				}
				//retrive Card max
				if (NoCardinalityMax(entity, att, raw))
				{
					switch (raw.CardMax)
					{
						case "*":
							att.IsCollection = true;
							break;
						default:
							ErrorManager.ErrorRef("ATT_UNKNOWN_VALUE", entity.Name, att.Name, raw.CardMax);
							break;
					}
				}
			}
		}
	}
}
