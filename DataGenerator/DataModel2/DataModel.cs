using DataGenerator.DataModel2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.DataModel2
{
	public class DataModel
	{
		public string Name { get; set; }

		public DataModel(string name)
		{
			Name = name;
		}


		#region Data Enum Collection
		private Dictionary<string, DataEnum> _dataEnums = new Dictionary<string, DataEnum>();

		public DataEnum AddDataEnum(DataEnum dataEnum)
		{
			AddEntity(_dataEnums, dataEnum);
			return dataEnum;
		}

		public DataEnum GetDataEnum(string entityName)
		{
			return GetEntity(_dataEnums, entityName);
		} 
		#endregion


		#region Data Dice Collection
		private Dictionary<string, DataDice> _dataDices = new Dictionary<string, DataDice>();

		public void AddDataDice(DataDice dataDice)
		{
			AddEntity(_dataDices, dataDice);
		}

		public DataDice GetDataDice(string entityName)
		{
			return GetEntity(_dataDices, entityName);
		}
		#endregion


		#region DataObject Collection
		private Dictionary<string, DataObject> _dataObjects = new Dictionary<string, DataObject>();

		public void AddDataObject(DataObject dataObject)
		{
			AddEntity(_dataObjects, dataObject);
		}

		public DataObject GetDataObject(string entityName)
		{
			return GetEntity(_dataObjects, entityName);
		} 
		#endregion


		#region Data Struct Collection
		private Dictionary<string, DataStruct> _dataStructs = new Dictionary<string, DataStruct>();

		public void AddDataStruct(DataStruct dataStruct)
		{
			AddEntity(_dataStructs, dataStruct);
		}

		public DataStruct GetDataStruct(string entityName)
		{
			return GetEntity(_dataStructs, entityName);
		} 
		#endregion

		/// <summary>
		/// Checks for duplicate names, and add to collection.
		/// </summary>
		/// <typeparam name="T">Type of the object to add.</typeparam>
		/// <param name="list">List to add to.</param>
		/// <param name="entity">Object to add.</param>
		private void AddEntity<T>(Dictionary<string, T> list, T entity) where T : DataEntity
		{
			string name = entity.Name.ToLower();
			if (list.Keys.Contains(name))
			{
				ErrorManager.ErrorRef("TABLE_DUPLICATE_NAME", name);
			}
			else
			{
				list.Add(name, entity);
			}
		}
		/// <summary>
		/// Get the table with the corresponding name. Caseless.
		/// </summary>
		/// <typeparam name="T">Type of the object to get.</typeparam>
		/// <param name="list">List where looking for.</param>
		/// <param name="name">Name to find.</param>
		/// <returns></returns>
		private T GetEntity<T>(Dictionary<string, T> list, string name) where T : DataEntity
		{
			name = name.ToLower();
			if (list.Keys.Contains(name))
			{
				return list[name];
			}
			else
			{
				return null;
			}
		}
	}
}
