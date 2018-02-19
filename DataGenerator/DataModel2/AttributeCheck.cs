using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2
{
	public static class AttributeCheck
	{
		public static string CheckAttributeName(string tableName, string attName)
		{
			if (string.IsNullOrWhiteSpace(attName))
			{
				ErrorManager.ErrorRef("ATT_NO_NAME", tableName);
				return "Without_Name";
			}
			return attName;
		}

		public static bool CheckAttributePresence(string tableName, string attName, string attributeVal, bool presence, string attTypeName)
		{
			bool result = true;
			if (presence != !string.IsNullOrWhiteSpace(attributeVal))
			{
				result = false;
				//if presence expected and string not found
				if (presence)
				{
					ErrorManager.ErrorRef("ATT_NOT_FOUND", tableName, attName, attTypeName);
				}
				//if presence not expected and string found
				else
				{
					ErrorManager.ErrorRef("ATT_FOUND", tableName, attName, attTypeName);
				}
			}
			return result;
		}

		public static int CheckAttributeIsInt(string tableName, string attName, string attVal)
		{
			if(!int.TryParse(attVal, out int res))
			{
				ErrorManager.ErrorRef("ATT_VAL_NOT_INT", tableName, attName, attVal);
			}
			return res;
		}

		public static bool CheckRawAttributeDefault(this RawAttribute raw, string tableName,
			bool expSection, bool expType, bool expTypeTag, bool expCardMin, bool expCardMax, bool expTarget)
		{
			bool result = true;

			//Get Attribute Name
			string attName = CheckAttributeName(tableName, raw.Name);

			//Generic check
			Action<string, bool, string> checkAttribute = (string attributeVal, bool presence, string attTypeName) =>
			{
				if (presence != !string.IsNullOrWhiteSpace(attributeVal))
				{
					result = false;
					//if presence expected and string not found
					if (presence)
					{
						ErrorManager.ErrorRef("ATT_NOT_FOUND", tableName, attName, attTypeName);
					}
					//if presence not expected and string found
					else
					{
						ErrorManager.ErrorRef("ATT_FOUND", tableName, attName, attTypeName);
					}
				}
			};

			//Check every other field
			checkAttribute(raw.Section, expSection, "Section");
			checkAttribute(raw.Type, expType, "Type");
			checkAttribute(raw.TypeTag, expTypeTag, "TypeTag");
			checkAttribute(raw.CardMin, expCardMin, "CardMin");
			checkAttribute(raw.CardMax, expCardMax, "CardMax");
			checkAttribute(raw.Target, expTarget, "Target");
			return result;
		}
	}
}
