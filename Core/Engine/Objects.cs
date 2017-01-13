using Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Engine {

	/// <summary>
	/// classe de base de tous les objets, armes et autres du framework
	/// </summary>
	public interface IObject {

	}

	public interface IWearable : IObject {
		void Equiper( IPersonnage personnage );
		void Desequiper( IPersonnage personnage );
	}

	public class ObjectCollection {

		#region Members
		/// <summary>
		/// Objects du stock d'inventaire.
		/// </summary>
		private List<IObject> _objects = new List<IObject>();
		/// <summary>
		/// Object porté.
		/// </summary>
		private List<IObject> _weared = new List<IObject>();
		#endregion

		#region Properties
		public IPersonnage Personnage { get; private set; }
		#endregion

		#region Init
		public ObjectCollection( IPersonnage perso ) {
			Personnage = perso;
		}
		#endregion

		#region Objects Collection
		public virtual void AddToStock( IObject cpt ) {
			_objects.Add(cpt);
		}
		public virtual void RemoveFromStock( IObject cpt ) {
			_objects.Remove(cpt);
		}

		public IEnumerable<IObject> AllStock {
			get {
				return _objects;
			}
		}
		public virtual void Wear(IWearable w ) {
			_weared.Add(w);
			w.Equiper(Personnage);
		}
		public virtual void UnWear(IWearable w ) {
			_weared.Remove(w);
			w.Desequiper(Personnage);
		}
		#endregion
	}
}
