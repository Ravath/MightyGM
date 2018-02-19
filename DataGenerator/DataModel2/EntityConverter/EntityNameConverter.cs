using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2.EntityConverter
{
	public abstract class AbsEntityNameConverter
	{
		public static EntityNameConverter DefaultEntityNameConverter = new EntityNameConverter();

		public abstract string GetName(RawTable raw);
	}


	public class EntityNameConverter : AbsEntityNameConverter
	{
		public override string GetName(RawTable raw)
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
