using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map {
	/// <summary>
	/// A plan where objects can be places and localised with 2D coordinates.
	/// </summary>
	public abstract class Abs2DMap<T> {
		#region Members
		private HashSet<MapObject<T>> _objects = new HashSet<MapObject<T>>();
		private T _w, _h;

		#endregion

		#region Properties
		public T Width {
			get{ return _w; }
			set { Resize( value,_h ); }
		}
		public T Height {
			get{ return _h; }
			set { Resize( _w, value ); }
		}
		#endregion

		public void Resize(T w, T h ) {
			T ow = _w, oh = _h;
			_w = w;
			_h = h;
			OnResize(ow, w, oh, h);
        }

		protected abstract void OnResize( T oldw, T neww, T oldh, T newh );

		public virtual void AddMapObject( MapObject<T> mo ) {
			_objects.Add(mo);
			mo.Map = this;
        }

		public virtual void RemoveMapObject( MapObject<T> mo ) {
			_objects.Remove(mo);
			mo.Map = null;
		}
	}
	/// <summary>
	/// A 2D Grid where the positions are real numbers.
	/// </summary>
	public abstract class Continuous2DMap : Abs2DMap<double> {

	}
}
