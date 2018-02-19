using DataGenerator.DataModel2.EntityConverter;
using DataGenerator.DataModel2.Model;
using DataGenerator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2
{
	public class Converter
	{
		public static DataModel Convert(RawData raw)
		{
			DataModel dm = new DataModel(raw.DatabaseName);

			//Create Data Entity converters
			Dictionary<string, AbsEntityConverter> entityConverters = new Dictionary<string, AbsEntityConverter>();
			EnumConverter enumCv = new EnumConverter();
			DiceConverter diceCv = new DiceConverter();
			DataStructConverter dataStructCv = new DataStructConverter();
			DataObjectConverter dataObjectCv = new DataObjectConverter();
			entityConverters.Add(enumCv.EntityTag, enumCv);
			entityConverters.Add(diceCv.EntityTag, diceCv);
			entityConverters.Add(dataStructCv.EntityTag, dataStructCv);
			entityConverters.Add(dataObjectCv.EntityTag, dataObjectCv);

			//stacks
			List<Tuple<DataEntity, AbsEntityConverter, RawTable>> createdTables = new List<Tuple<DataEntity, AbsEntityConverter, RawTable>>();

			//Create entities
			foreach (RawTable tab in raw.RawTables)
			{
				string tag = tab.Name.ToLower();
				if (entityConverters.ContainsKey(tag))
				{
					AbsEntityConverter cv = entityConverters[tag];
					DataEntity de = cv.AddEntity(dm, cv.GetName(tab));
					cv.GetTags(de, tab);
					createdTables.Add(new Tuple<DataEntity, AbsEntityConverter, RawTable>(de, cv, tab));
				}
				else
				{
					ErrorManager.ErrorRef("ENTITY_UNKNOWN_TAG", tag);
				}
			}

			foreach (var item in createdTables)
			{
				AbsEntityConverter cv = item.Item2;
				//link heritage
				cv.LinkInheritance(dm, item.Item1, item.Item3);
				//linking attributes
				cv.LinkAttributes(dm, item.Item1, item.Item3);
			}

			//check for duplicates
			//TODO dm.CheckDuplicateTableNames();

			return dm;
		}
	}
}
