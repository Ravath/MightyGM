using DataGenerator.DataModel.EntityConvert;
using DataGenerator.DataModel.Model;
using DataGenerator.Parser;
using System.Linq;

namespace DataGenerator.DataModel.AttributeConvert
{
	/// <summary>
	/// Base class of the attribute name converters.
	/// </summary>
	public abstract class AbsNameConverter
	{
		/// <summary>
		/// List of forbidden attribute names, in lower case.
		/// </summary>
		protected static string[] ForbiddenAttributeNames = { };

		public static NameConverter DefaultConverter = new NameConverter();

		public abstract string GetName(DataEntity entity, RawAttribute raw);
	}

	/// <summary>
	/// The default attribute name converters. Check it existts, and its not a forbidden word.
	/// </summary>
	public class NameConverter : AbsNameConverter
	{
		public override string GetName(DataEntity entity, RawAttribute raw)
		{
			string result = raw.Name;
			//Check if exists
			if (string.IsNullOrWhiteSpace(raw.Name))
			{
				ErrorManager.ErrorRef("ATT_NO_NAME", entity.Name);
				result = "Without_Name";
			}
			else
			{
				string name = result.ToLower();
				//Check for forbidden keywords
				string f = ForbiddenAttributeNames.Concat(AbsEntityNameConverter.ForbiddenNames).FirstOrDefault(a => a == name);
				if (f != null)
				{
					ErrorManager.ErrorRef("ATT_FORBIDDEN_NAME", entity.Name, name);
				}
			}
			return result;
		}
	}
}
