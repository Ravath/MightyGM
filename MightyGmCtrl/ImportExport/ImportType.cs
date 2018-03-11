using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MightyGmCtrl.Controleurs;
using Core.Contexts;

namespace MightyGmCtrl.ImportExport
{
	public class ImportType
	{
		private Type _type;
		private List<IDataObject> _instances = new List<IDataObject>();
		private List<ImportRelation> _relations = new List<ImportRelation>();
		private List<CollectionValue> _collections = new List<CollectionValue>();
		private List<IDataObject> _lateSaves = new List<IDataObject>();

		public Type ModelType
		{
			get { return _type; }
		}

		public ImportType(Type currentType)
		{
			this._type = currentType;
		}

		/// <summary>
		/// Create a new instance of the managed type, and stores it in the imported data.
		/// </summary>
		/// <returns>The new instance</returns>
		public IDataObject CreateInstance()
		{
			IDataObject ido = (IDataObject)_type.GetConstructor(new Type[] { }).Invoke(new object[] { });
			_instances.Add(ido);
			return ido;
		}

		/// <summary>
		/// Insert the data in the database. It will send messages and not insert the object if the data already exists.
		/// </summary>
		/// <param name="errors">Where the error messages will be send</param>
		/// <param name="data">The database where the data will be saved.</param>
		public void InsertData(Database data, Action<MessageType, string, object[]> reportRef)
		{
			List<IDataObject> toRemove = new List<IDataObject>();
			foreach (IDataObject temp in _instances)
			{
				if (temp is DataModel dataMod)
				{//est un DataModel
					if (string.IsNullOrWhiteSpace(dataMod.Tag))
					{
						reportRef(MessageType.WARNING, "DATAMOD_NO_TAG", new object[] { temp.GetType() });
						//we don't want objects without tag in DB
						toRemove.Add(temp);
					}
					else if (string.IsNullOrWhiteSpace(dataMod.Name))
					{
						reportRef(MessageType.WARNING, "DATAMOD_NO_NAME", new object[] { temp.GetType() });
						//we don't want objects without name in DB
						toRemove.Add(temp);
					}
					else if (data.Contains(_type, dataMod))
					{
						reportRef(MessageType.WARNING, "NAME_ALREADY_IN_DATABASE", new object[] { dataMod.Name, temp.GetType() });
					}
					else
					{
						dataMod.Id = 0;
						dataMod.Description.Id = 0;
						dataMod.SaveObject();
					}
				}
				else
				{//bidule aléatoire
					IDataObject dtobject = temp;
					dtobject.Id = 0;
					dtobject.SaveObject();
				}
			}

			// remove unwanted data, or it will be added in the next steps
			foreach (var item in toRemove)
			{
				_instances.Remove(item);
			}
		}

		/// <summary>
		/// Update the objects with id to references.
		/// </summary>
		/// <param name="context">Where the error messages will be send</param>
		/// <param name="data"></param>
		public void SaveCrossReferences(Database data, Action<MessageType, string, object[]> reportRef)
		{
			foreach (ImportRelation rel in _relations)
			{
				int id = data.GetIdByTag(rel.refType, rel.tag);
				if (id > 0)
				{
					rel.refProperty.SetValue(rel.inst, id);
				}
				else
				{
					reportRef(MessageType.WARNING, "NO_TAG", new object[] { rel.tag, rel.inst.GetType() });
				}
			}
			foreach (CollectionValue col in _collections)
			{
				col.Property.SetMethod.Invoke(col.Instance, new Object[] { col.Value });
			}
		}

		public void AddCollectionValue(IDataObject newObj, PropertyInfo prop, IEnumerable il)
		{
			_collections.Add(
				new CollectionValue()
				{
					Instance = newObj,
					Value = il,
					Property = prop
				});
		}

		public void AddTagReference(IDataObject instance, PropertyInfo pi, string tag, Type refType)
		{
			_relations.Add(new ImportRelation()
			{
				inst = instance,
				tag = tag,
				refProperty = pi,
				refType = refType
			});
		}

		public void AddLateSave(IDataObject val)
		{
			_lateSaves.Add(val);
		}

		public void SaveLateDatas(Database data)
		{
			foreach (IDataObject item in _lateSaves)
			{
				item.SaveObject();
			}
		}

		public void SaveData(Database data)
		{
			foreach (IDataObject dataMod in _instances)
			{
				dataMod.SaveObject();
			}
		}
	}

	internal class ImportRelation
	{
		/// <summary>
		/// The refered type.
		/// </summary>
		internal Type refType;
		internal IDataObject inst;
		internal string tag;
		/// <summary>
		/// The property to update the reference Id.
		/// </summary>
		internal PropertyInfo refProperty;
	}

	internal class CollectionValue
	{
		internal IEnumerable Value;
		internal IDataObject Instance;
		internal PropertyInfo Property;
	}
}
