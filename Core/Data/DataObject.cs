using Core.Data.Schema;
using LinqToDB;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Core.Data {
	public interface IDataObject {// : IEquatable<IDataObject> {
		int Id { get; set; }
		void SaveObject();
		void DeleteObject();
	}
	/// <summary>
	/// Base de tous les objets de la base de donnée. A condition que les clefs primaires de la table soient des integers nommés 'Id'.
	/// </summary>
	public abstract class DataObject : IDataObject {

		//#region Egalite
		//public static bool operator ==( DataObject d, IDataObject o ) {
		//	if((object)d == null)
		//		return false;
		//	return d.Equals(o);
		//}
		//public static bool operator !=( DataObject d, IDataObject o ) {
		//	if((object)d == null)
		//		return false;
		//	return !d.Equals(o);
		//}
		//public override bool Equals( object obj ) {
		//	IDataObject id = obj as IDataObject;
		//	if(id == null)
		//		return base.Equals(obj);
		//	else
		//		return Equals(id);
		//}
		//public override int GetHashCode() {
		//	return base.GetHashCode();
		//}
		//public bool Equals( IDataObject other ) {
		//	if(base.Equals(other)) { return true; }
		//	return other.Id == Id;
		//}
		//#endregion

		#region Init
		/// <summary>
		/// Constructeur par défaut.
		/// </summary>
		public DataObject() { }
		#endregion

		protected Database Data {
			get { return Database.GlobalDataBase; }
		}

		public virtual void SaveObject() {
			if(Id == 0)
				Data.Insert(this);
			else
				Data.Update(this);
		}

		public virtual void DeleteObject() {
			Data.Delete(this);
		}

		private int _id;
		/// <summary>
		/// L'identifiant dans la base de donnée.
		/// </summary>
		[Category("Id")]
		[DisplayName("Identifiant")]
		[Description("Cet identificateur est à l'usage exclusif de la base de donnée. Ne pas manipuler.")]
		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("dataobject_id_seq")]
		[HiddenProperty]
		public int Id {
			get { return _id; }
			set { _id = value; }
		}

		public override string ToString() {
			return Id.ToString();
		}

		#region Interactions Base de Données
		protected Res LoadById<Res>( int id ) where Res : DataObject {
			Type t = typeof(Res);
			if(t.IsAbstract) {//use the other fonction because this one will look for the children types.
				var r = from c in Data.GetDataTable(t)
						where id == ((IDataObject)c).Id
						select c;
				return (Res)r.SingleOrDefault();
			}
			var q = from c in Data.GetTable<Res>()
					where id == c.Id
					select c;

			return q.SingleOrDefault();
		}

		protected IEnumerable<Res> LoadByForeignKey<Res>( Func<Res, int> fkey, int id )
				where Res : class, IDataObject {
			//version abstraite
			if(typeof(Res).IsAbstract) {
				var qa = from c in Data.GetDataTable(typeof(Res))
						select c;

				return qa.Cast<Res>().ToList().Where(p => fkey(p) == id);
			}
			//normal
			var q = from c in Data.GetTable<Res>()
					select c;

			return q.ToList().Where(p=>fkey(p) == id);
		} 
		
		protected IEnumerable<Res> LoadFromJointure<Res, Jointure>( bool loadLeft )
				where Res : class, IDataObject 
				where Jointure : class, IDataRelation {
			Res[] res;
			if(typeof(Res).IsAbstract)
				res = (from v in Data.GetDataTable(typeof(Res)) select v).Cast<Res>().ToArray();
			else
				res = (from v in Data.GetTable<Res>() select v).ToArray();
			Jointure[] j = (from v in Data.GetTable<Jointure>() select v).ToArray();
			List<Res> ret = new List<Res>();
			if(loadLeft) {//get left
				foreach(Jointure ij in j) {
					if(ij.Object2Id == Id) {
						ret.AddRange(res.Where(p => p.Id == ij.Object1Id));
					}
				}
				return ret;
				//return (from c in Data.GetTable<Jointure>()
				//	   where c.Object2Id == Id
				//	   join j in Data.GetTable<Res>() on c.Object1Id equals j.Id
				//	   select j).ToArray();
			} else {//get right
				foreach(Jointure ij in j) {
					if(ij.Object1Id == Id) {
						ret.AddRange(res.Where(p => p.Id == ij.Object2Id));
					}
				}
				return ret;
				//var q = from j in Data.GetTable<Jointure>()
				//		from v in Data.GetTable<Res>()
				//		where j.Object1Id == Id && j.Object2Id == v.Id
				//		select v;
				//return q.ToArray();
				//return (from c in Data.GetTable<Jointure>()
						//where c.Object1Id == Id
						//join j in Data.GetTable<Res>() on c.Object2Id equals j.Id
						//select j).ToArray();
			}
		}
		/// <summary>
		/// Sauvegarder la relation de jointure avec une liste d'objets.
		/// </summary>
		/// <typeparam name="Res">Le type de l'objet à joindre.</typeparam>
		/// <typeparam name="Jointure">Le Type de la jointure</typeparam>
		/// <param name="old">Les données déjà jointes.</param>
		/// <param name="save">Les données à raouter.</param>
		/// <param name="saveToLeft">side of the joint table where the new data has to be linked.</param>
		protected void SaveToJointure<Res, Jointure>( IEnumerable<Res> old, IEnumerable<Res> save , bool saveToLeft )
				where Res : DataObject
				where Jointure : class, IDataRelation, new() {
			if(old == null)
				old = new List<Res>();
			IEnumerable<Res> _erase = old.Except(save).ToList();
			IEnumerable<Res> _insert = save.Except(old).ToList();
			IEnumerable<Res> _keep = save.Intersect(old).ToList();

			Jointure[] oldData = (from q in Data.GetTable<Jointure>() select q).ToArray();

			foreach(Res item in _erase) {//enlever ceux qui ne servent plus (jointures uniquement)
				var q = from c in oldData
						where (saveToLeft ? c.Object1Id : c.Object2Id) == item.Id
						   && (saveToLeft ? c.Object2Id : c.Object1Id) == Id
						select c;
				foreach (Jointure ji in q.ToArray())
				{
					ji.DeleteObject();
				}
			}
			foreach (Res item in _insert) {//rajouter les nouveaux
				if(item.Id == 0)//sauvegarder si pas fait
					item.SaveObject();
				Jointure j = new Jointure();
				if(saveToLeft) {
					j.Object1 = item;
					j.Object2 = this;
				} else {
					j.Object2 = item;
					j.Object1 = this;
				}
				j.SaveObject();
			}
		}
		/// <summary>
		/// Delete the joints linking to the object
		/// </summary>
		/// <typeparam name="Res"></typeparam>
		/// <typeparam name="Jointure"></typeparam>
		/// <param name="data"></param>
		/// <param name="fromLeft"></param>
		protected void DeleteJoins<Res, Jointure>( bool fromLeft )
				where Jointure : class, IDataRelation {
			var q = from c in Data.GetTable<Jointure>()
					where (fromLeft ? c.Object1Id : c.Object2Id) == Id
					select c;
			foreach(Jointure j in q.ToArray()) {
				j.DeleteObject();
			}
		}
		protected IEnumerable<V> LoadFromDataValue<DV, V>()
				where DV : class, IDataValue {

			DV[] dv = (from q in Data.GetTable<DV>() select q).ToArray();
			return dv.Where(p => p.FromId == Id).Select(p => p.Value).Cast<V>();

			//var q =from c in Data.GetTable<DV>()
			//	   where c.FromId == Id
			//	   select c.Value;
			//return q.Cast<V>();
		}
		protected void SaveDataValue<DV,V>( IEnumerable<V> old, IEnumerable<V> save )
				where DV : class, IDataValue, new()
                 {
			if(old == null) { old = new List<V>(); }

			IEnumerable<V> _erase = old.Except(save).ToList();
			IEnumerable<V> _insert = save.Except(old).ToList();
			IEnumerable<V> _keep = save.Intersect(old).ToList();

			IEnumerable<DV> oldData = (from q in Data.GetTable<DV>() select q).ToArray().Where(p => p.FromId == Id);

			//var oldData = (from c in Data.GetTable<DV>()
			//		where c.FromId == Id
			//		select c).ToList();

			foreach(V val in _erase) {//enlever ceux qui ne servent plus
				DV d = oldData.Single(p => p.Value.Equals(val));
				d.DeleteObject();
			}
			foreach(V item in _insert) {//rajouter les nouveaux
				DV j = new DV
				{
					FromId = Id,
					Value = item
				};
				j.SaveObject();
			}
		}
		protected void DeleteDataValue<DV>() 
				where DV : class, IDataValue {

			DV[] dv = (from c in Data.GetTable<DV>() select c).ToArray();

			//var q = from c in Data.GetTable<DV>()
			//		where c.FromId == Id
			//		select c;

			foreach(DV j in dv.Where(p => p.FromId == Id)) {
				j.DeleteObject();
			}
		}
		#endregion
	}
}
