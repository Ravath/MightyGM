using Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {

	/// <summary>
	/// Une liste d'objets appartenant à un personnage.
	/// </summary>
	/// <typeparam name="O"></typeparam>
	/// <typeparam name="P"></typeparam>
	public class ListeObjets<O, P> : INamedCollection
									where O : IObject
									where P : IAgent {
		#region Members
		/// <summary>
		/// Objects du stock d'inventaire.
		/// </summary>
		private List<O> _objects = new List<O>();
		#endregion

		#region Properties
		public P Personnage { get; private set; }
		#endregion

		#region Init
		public ListeObjets( P perso ) {
			Personnage = perso;
		}
		#endregion

		#region Events
		public delegate void ObjectHandler( ListeObjets<O, P>  sender, O obj );
		public event ObjectHandler ObjectAdded;
		public event ObjectHandler ObjectRemoved;
		public delegate void ListObjectHandler( ListeObjets<O, P> sender, IEnumerable<O> listObj );
		public event ListObjectHandler AllObjectsRemoved;
		public event SelectionChangedHandler SelectionChanged;
		#endregion

		public IEnumerable<O> AllStock {
			get {
				return _objects;
			}
		}

		public IEnumerable<INamed> NamedCollection {
			get {
				return AllStock.Cast<INamed>();
			}
		}

		public virtual void Add( O newObj ) {
			_objects.Add(newObj);
			if(ObjectAdded != null)
				ObjectAdded(this, newObj);
			if(SelectionChanged != null)
				SelectionChanged(this);
		}

		public virtual bool Remove( O newObj ) {
			if(_objects.Remove(newObj)) {
				if(ObjectRemoved!=null)
					ObjectRemoved(this, newObj);
				if(SelectionChanged != null)
					SelectionChanged(this);
				return true;
			}
			return false;
		}

		public virtual void RemoveAll() {
			List<O> _objs = new List<O>();
			_objs.AddRange(_objects);
			_objects.Clear();
			if(AllObjectsRemoved != null)
				AllObjectsRemoved(this, _objs);
			if(SelectionChanged != null)
				SelectionChanged(this);
		}

		public void RemoveFirst() {
			if(_objects.Count()>0)
				Remove(_objects.First());
		}
		public void RemoveLast() {
			if(_objects.Count() > 0)
				Remove(_objects.Last());
		}

		public void RemoveNamed( INamed item ) {
			Remove((O)item);
		}

		public void AddNamed( INamed item ) {
			Add((O)item);
		}
	}

	/// <summary>
	/// Une liste d'objets équipés par un personnage.
	/// </summary>
	/// <typeparam name="O"></typeparam>
	/// <typeparam name="P"></typeparam>
	public class ListeWearable<O, P> : ListeObjets<O,P> where O : IWearable where P : IAgent {
		#region Init
		public ListeWearable(P perso) : base(perso){ }
		#endregion

		public override void Add( O newObj ) {
			base.Add(newObj);
			newObj.Equiper(Personnage);
		}
		public override bool Remove( O newObj ) {
			if(base.Remove(newObj)) {
				newObj.Desequiper(Personnage);
				return true;
			}
			return false;
		}

		public override void RemoveAll() {
			foreach(O item in AllStock) {
				item.Desequiper(Personnage);
			}
			base.RemoveAll();
        }
	}
}
