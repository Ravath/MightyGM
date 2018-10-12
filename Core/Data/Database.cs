using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data {
	public class Database : DataConnection {

		private static Object DataAccess = new object();

		#region Init
		public Database() : base("Jdr") {
			GlobalDataBase = this;
		}
		#endregion

		#region Static
		private static Database _database;
		internal static Database GlobalDataBase {
			get {
				return _database;
			}
			private set {
				if(_database != null) {
					_database.Close();
					_database.Dispose();
				}
				_database = value;
			}
		} 
		#endregion

		public bool Update( IDataObject obj ) {
			Type type = obj.GetType();
			IEnumerable<MethodInfo> insertMethods = typeof(DataExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).Where(p => p.Name == "Update");
			MethodInfo insertMethod = insertMethods.First(t => t.GetParameters().ElementAt(0).ParameterType == typeof(IDataContext));
			MethodInfo insertGeneric = insertMethod.MakeGenericMethod(new Type[] { type });
			lock (DataAccess)
			{
				insertGeneric.Invoke(this, new object[] { this, obj, null, null, null });
			}
			return true;
		}
		public bool Insert( IDataObject obj ) {
			Type type = obj.GetType();
			IEnumerable<MethodInfo> insertMethods = typeof(DataExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).Where(p => p.Name == "InsertWithIdentity");
			var list = insertMethods.ToList();
			MethodInfo insertMethod = insertMethods.First(t => t.GetParameters().ElementAt(0).ParameterType == typeof(IDataContext));
			MethodInfo insertGeneric = insertMethod.MakeGenericMethod(new Type[] { type });
			lock (DataAccess)
			{
				object o = insertGeneric.Invoke(this, new object[] { this, obj, null, null, null });//InsertWithIdentity
				obj.Id = Convert.ToInt32(o);
			}
			return true;
		}
		public bool Delete( IDataObject obj ) {
			Type type = obj.GetType();
			IEnumerable<MethodInfo> insertMethods = typeof(DataExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).Where(p => p.Name == "Delete");
			MethodInfo insertMethod = insertMethods.First(t => t.GetParameters().ElementAt(0).ParameterType == typeof(IDataContext));
			MethodInfo insertGeneric = insertMethod.MakeGenericMethod(new Type[] { type });
			lock (DataAccess)
			{
				insertGeneric.Invoke(this, new object[] { this, obj });
			}
			return true;
		}

		/// <summary>
		/// Récupère les données en database. Si classe abstraite, charge les enfants.
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public IEnumerable<object> GetDataTable( Type t ) {
			lock (DataAccess)
			{
				if (t.IsAbstract)
				{
					SonFilterCriteria sfc = new SonFilterCriteria { Parent = t };
					Type[] ts = t.Module.FindTypes(ChildrenFilter, sfc);
					List<object> enumer = new List<object>();
					foreach (Type item in ts)
					{
						enumer.AddRange(GetDataTable(item));
					}
					return enumer;
				}
				else
				{
					MethodInfo method = typeof(DataConnection).GetMethod("GetTable", new Type[] { });
					MethodInfo generic = method.MakeGenericMethod(new Type[] { t });
					IEnumerable<object> enumer = (IEnumerable<object>)generic.Invoke(this, null);
					return enumer;
				}
			}
		}
		public class SonFilterCriteria {
			public Type Parent;
		}
		public bool ChildrenFilter( Type t, object FilterCriteria ) {
			SonFilterCriteria sf = FilterCriteria as SonFilterCriteria;
			if(t.BaseType == sf.Parent) {
                return (t.GetCustomAttribute(typeof(TableAttribute), false) != null);
            }
            return false;
		}
		public bool Contains( Type type, DataModel mod ) {
			return ContainsByTag(type, mod.Tag);
			}
		/// <summary>
		/// Check if there already is a DataModel whith this name.
		/// </summary>
		/// <param name="type">A DataModel type.</param>
		/// <param name="name">The name to llok for.</param>
		/// <returns>True if already exists.</returns>
		public bool Contains( Type type, string name ) {
			var q = from t in GetDataTable(type)
					where ((DataModel)t).Name == name
					select t;
			return q.Count() == 1;
		}
		/// <summary>
		/// Check if there already is a DataModel object whith this tag.
		/// </summary>
		/// <param name="type">A DataModel type.</param>
		/// <param name="name">The tag to look for.</param>
		/// <returns>True if already exists.</returns>
		public bool ContainsByTag( Type type, string tag ) {
			var q = from t in GetDataTable(type)
					where ((DataModel)t).Tag == tag
					select t;
			return q.Count() == 1;
		}
		/// <summary>
		/// returns the Id of the DataModel object whith the given Tag.
		/// </summary>
		/// <param name="type">The type of the object.</param>
		/// <param name="tag">The tag to look for.</param>
		/// <returns>-1 if not found.</returns>
		public int GetIdByTag( Type type, string tag ) {
			var q = from t in GetDataTable(type)
					where ((DataModel)t).Tag == tag
					select t;
			if(q.Count() == 1)
				return ((DataModel)q.First()).Id;
			return -1;
		}

		public T GetById<T>( int id ) where T : IDataObject {
			return (T)GetById(typeof(T), id);
		}

		public IDataObject GetById( Type t, int id ) {
			var q = from s in GetDataTable(t)
					where ((IDataObject)s).Id == id
					select s;

			return ((IDataObject)q.SingleOrDefault());
		}
		/// <summary>
		/// If 0, the name doesn't exist.
		/// </summary>
		/// <param name="type">The type of the data to look for.</param>
		/// <param name="name">The name we are looking for.</param>
		/// <returns>0 if not found.</returns>
		public int GetIdFromName( Type type, string name ) {
			var q = from t in GetDataTable(type)
					where ((DataModel)t).Name == name
					select t;

			return ((DataModel)q.SingleOrDefault())?.Id ?? 0;
		}
	}
}
