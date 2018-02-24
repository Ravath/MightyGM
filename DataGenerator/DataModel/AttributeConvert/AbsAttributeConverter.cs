namespace DataGenerator.DataModel.AttributeConvert
{
	/// <summary>
	/// The base class of every Attribute converters.
	/// </summary>
	public abstract class AbsAttributeConverter
	{
		/// <summary>
		/// Check the given attribute value, and register an error if any.
		/// </summary>
		/// <param name="tableName">The name of the table providing the value.</param>
		/// <param name="attName">The name of the attribute.</param>
		/// <param name="attVal">The value to check.</param>
		/// <param name="presence">Indicates if the value must exist or not.</param>
		/// <param name="attTypeName">The typeName of the attribute to check.</param>
		/// <returns></returns>
		public bool CheckAttributePresence(string tableName, string attName, string attVal, bool presence, string attTypeName)
		{
			bool result = true;
			if (presence != !string.IsNullOrWhiteSpace(attVal))
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
					ErrorManager.ErrorRef("ATT_FOUND", tableName, attName, attTypeName, attVal);
				}
			}
			return result;
		}

		/// <summary>
		/// Check the given attribute is an int, and convert if such, or register an error message.
		/// </summary>
		/// <param name="tableName">The name of the table providing the value.</param>
		/// <param name="attName">The name of the attribute.</param>
		/// <param name="attVal">The value to check.</param>
		/// <returns>The converted int, or 0 if any.</returns>
		public int CheckAttributeIsInt(string tableName, string attName, string attVal)
		{
			if (!int.TryParse(attVal, out int res))
			{
				ErrorManager.ErrorRef("ATT_VAL_NOT_INT", tableName, attName, attVal);
			}
			return res;
		}
	}
}