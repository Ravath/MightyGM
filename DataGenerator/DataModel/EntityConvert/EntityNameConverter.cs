using DataGenerator.Parser;
using System.Linq;

namespace DataGenerator.DataModel.EntityConvert
{
	public abstract class AbsEntityNameConverter
	{
		/// <summary>
		/// List of forbidden names for both table and attributes, in lower case.
		/// </summary>
		public static string[] ForbiddenNames = { "all", "and", "or", "create", "table", "not", "type", "limit", "range" };
		///et tant d'autres
		/// <summary>
		/// List of forbidden table names, in lower case.
		/// </summary>
		protected static string[] ForbiddenTableNames = { };

		public static EntityNameConverter DefaultEntityNameConverter = new EntityNameConverter();

		public abstract string GetName(RawTable raw);
	}


	public class EntityNameConverter : AbsEntityNameConverter
	{
		public override string GetName(RawTable raw)
		{
			string result = raw.Name;
			//Check if exists
			if (string.IsNullOrWhiteSpace(raw.Name))
			{
				ErrorManager.ErrorRef("TABLE_NO_NAME");
				result = "Without_Name";
			}
			else
			{
				string name = result.ToLower();
				//Check for forbidden keywords
				string f = ForbiddenTableNames.Concat(ForbiddenNames).FirstOrDefault(a => a == name);
				if (f != null)
				{
					ErrorManager.ErrorRef("TABLE_FORBIDDEN_NAME", name);
				}
			}
			return result;
		}
	}
}
