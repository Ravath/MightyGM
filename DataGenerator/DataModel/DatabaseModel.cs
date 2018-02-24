using DataGenerator.DataModel.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataGenerator.DataModel
{
	/// <summary>
	/// The Complete and refined model.
	/// </summary>
	public class DatabaseModel
	{
		/// <summary>
		/// Name of the Model.
		/// </summary>
		public string Name { get; set; }
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		/// <param name="name">Name of the Model.</param>
		public DatabaseModel(string name)
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
		public IEnumerable<DataEnum> Enums
		{
			get { return _dataEnums.Select(a => a.Value); }
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
		public IEnumerable<DataDice> Dices
		{
			get { return _dataDices.Select(a => a.Value); }
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
		public IEnumerable<DataObject> Objects
		{
			get { return _dataObjects.Select(a => a.Value); }
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
		public IEnumerable<DataStruct> Structs
		{
			get { return _dataStructs.Select(a => a.Value); }
		}
		#endregion

		/// <summary>
		/// Check the is not any entities with duplicated names, or any entity with duplicated attribute names.
		/// </summary>
		internal void CheckDuplicateTableNames()
		{
			//Looking among table names
			CheckDuplicates(
				_dataDices.Select(s => s.Value.Name).
				Union(_dataEnums.Select(s => s.Value.Name)).
				Union(_dataStructs.Select(s => s.Value.Name)).
				Union(_dataObjects.Select(s => s.Value.Name)), "Tables");

			//Looking among attributes of each table
			foreach (DataDice tab in _dataDices.Values)
			{
				CheckDuplicates(tab.Attributes.Attributes.Select(s=>s.Name), tab.Name);
			}
			foreach (DataEnum tab in _dataEnums.Values)
			{
				CheckDuplicates(tab.Attributes.Attributes.Select(s => s.Name), tab.Name);
			}
			foreach (DataStruct tab in _dataStructs.Values)
			{
				CheckDuplicates(tab.Attributes.Attributes.Select(s => s.Name), tab.Name);
			}
			foreach (DataObject tab in _dataObjects.Values)
			{
				CheckDuplicates(tab.ModelAttributes.Attributes.Select(s => s.Name), tab.Name);
				CheckDuplicates(tab.ExemplarAttributes.Attributes.Select(s => s.Name), tab.Name);
				CheckDuplicates(tab.DescriptionAttributes.Attributes.Select(s => s.Name), tab.Name);
			}
		}

		/// <summary>
		/// Print the description of the model.
		/// </summary>
		/// <param name="printer">Where to print.</param>
		public void Print(TextWriter printer)
		{
			printer.WriteLine("Name: " + Name);
			foreach (var item in _dataDices)
			{
				item.Value.Print(printer);
			}
			foreach (var item in _dataEnums)
			{
				item.Value.Print(printer);
			}
			foreach (var item in _dataStructs)
			{
				item.Value.Print(printer);
			}
			foreach (var item in _dataObjects)
			{
				item.Value.Print(printer);
			}
		}

		/// <summary>
		/// Looking for duplicates, and send an error message for each one.
		/// </summary>
		/// <param name="en"></param>
		/// <returns></returns>
		private bool CheckDuplicates(IEnumerable<string> en, string context)
		{
			bool duplicate = false;
			for (int i = 0; i < en.Count(); i++)
			{
				for (int j = i + 1; j < en.Count(); j++)
				{
					if (en.ElementAt(i).ToLower() == en.ElementAt(j).ToLower())
					{
						ErrorManager.ErrorRef("ERR_DUPLICATE", context, en.ElementAt(i));
						duplicate = true;
					}
				}
			}
			return duplicate;
		}

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
