using DataGenerator.DataModel2.Model;
using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.AttributeConverter
{
	public abstract class AbsAttributeNameConverter
	{
		public static AttributeNameConverter DefaultConverter = new AttributeNameConverter();

		public abstract string GetName(DataEntity entity, RawAttribute raw);
	}

	public class AttributeNameConverter : AbsAttributeNameConverter
	{
		public override string GetName(DataEntity entity, RawAttribute raw)
		{
			if (string.IsNullOrWhiteSpace(raw.Name))
			{
				ErrorManager.ErrorRef("ATT_NO_NAME", raw.Name);
				return "Without_Name";
			}
			//TODO Check for forbidden keywords
			return raw.Name;
		}
	}
}
