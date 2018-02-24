using DataGenerator.DataModel.EntityConvert;
using DataGenerator.DataModel.Model;
using DataGenerator.Parser;
using System;
using System.Collections.Generic;

namespace DataGenerator.DataModel
{
	/// <summary>
	/// Convertion from the Raw Tables to a complete data model.
	/// </summary>
	public static class Converter
	{
		private static Dictionary<string, AbsEntityConverter> entityConverters;
		/// <summary>
		/// Initialize the convertion logics.
		/// </summary>
		static Converter()
		{
			// Initialize the DataEntity converters.
			entityConverters = new Dictionary<string, AbsEntityConverter>();
			DataEnumConverter enumCv = new DataEnumConverter();
			DataDiceConverter diceCv = new DataDiceConverter();
			DataStructConverter dataStructCv = new DataStructConverter();
			DataObjectConverter dataObjectCv = new DataObjectConverter();
			entityConverters.Add(enumCv.EntityTag, enumCv);
			entityConverters.Add(diceCv.EntityTag, diceCv);
			entityConverters.Add(dataStructCv.EntityTag, dataStructCv);
			entityConverters.Add(dataObjectCv.EntityTag, dataObjectCv);
		}

		/// <summary>
		/// The convertion process.
		/// </summary>
		/// <param name="raw">The Raw Tables to process.</param>
		/// <returns>The complete and checked DataModel.</returns>
		public static DatabaseModel Convert(RawData raw)
		{
			DatabaseModel dm = new DatabaseModel(raw.DatabaseName);
			
			//stacks
			List<Tuple<DataEntity, AbsEntityConverter, RawTable>> createdTables = new List<Tuple<DataEntity, AbsEntityConverter, RawTable>>();

			//Create entities
			foreach (RawTable tab in raw.RawTables)
			{
				string tag = tab.Type.ToLower();

				//Look if a converter exists for the given entityTypeTag.
				if (entityConverters.ContainsKey(tag))
				{
					AbsEntityConverter cv = entityConverters[tag];
					DataEntity de = cv.AddEntity(dm, cv.GetName(tab));
					cv.CreateAttributes(de, tab);
					cv.GetTags(de, tab);
					createdTables.Add(new Tuple<DataEntity, AbsEntityConverter, RawTable>(de, cv, tab));
				}
				else
				{
					ErrorManager.ErrorRef("ENTITY_UNKNOWN_TAG", tag);
				}
			}

			//Do links
			foreach (var item in createdTables)
			{
				AbsEntityConverter cv = item.Item2;
				//link heritage
				cv.LinkInheritance(dm, item.Item1, item.Item3);
				//linking attributes
				cv.LinkAttributes(dm, item.Item1, item.Item3);
			}

			//check for duplicates
			dm.CheckDuplicateTableNames();

			return dm;
		}
	}
}
