using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map {
	/// <summary>
	/// An object with a position on a map. It is linked with a formal type of object.
	/// </summary>
	/// <typeparam name="T">The type os space : int for discrete, double(real) for continuous.</typeparam>
	/// <typeparam name="O">The type of formal object it is linked with.</typeparam>
	public abstract class MapObject<T>{
		#region Members
		private Abs2DMap<T> _map;
		#endregion

		public T X { get; }
		public T Y { get; }

		public virtual Abs2DMap<T> Map {
			get{ return _map; }
			set {
				if(_map == value) { return; }
				Abs2DMap<T> _old = _map;
				_map = value;
				if(_old != null)
					_map.RemoveMapObject(this);
				if(value != null)
					value.AddMapObject(this);
            }
		}

		public FormalObject Object { get; set; }
	}
	/// <summary>
	/// An object with a position on a continuous map. It is linked with a formal type of object.
	/// </summary>
	/// <typeparam name="O">The type of formal object it is linked with.</typeparam>
	public class ContinuousMapObject : MapObject<double> {

	}
	/// <summary>
	/// An object with a position on a discrete map. It is linked with a formal type of object.
	/// </summary>
	/// <typeparam name="O">The type of formal object it is linked with.</typeparam>
	public abstract class DiscreteMapObject : MapObject<int> {
		public abstract int Width { get; }
		public abstract int Height { get; }
		public abstract IEnumerable<DiscreteSquare> Squares { get; }
        public abstract void AddDiscreteSquare( DiscreteSquare ds );
		public abstract void RemoveDiscreteSquare( DiscreteSquare ds );
	}

	public class OneSquareMapObject : DiscreteMapObject {

		#region Members
		private DiscreteSquare _square;
		#endregion

		#region Properties
		public DiscreteSquare Square {
			get { return _square; }
			set {
				AddDiscreteSquare(value);
            }
		}

		public override IEnumerable<DiscreteSquare> Squares {
			get { return new DiscreteSquare[] { _square }; }
		}
		public override int Width { get { return 1; } }
		public override int Height { get { return 1; } }
		#endregion

		public override void AddDiscreteSquare( DiscreteSquare ds ) {
			if(_square == ds) { return; }
			_square.RemoveMapObject(this);
			_square = ds;
			_square.AddMapObject(this);
        }

		public override void RemoveDiscreteSquare( DiscreteSquare ds ) {
			if(_square != ds) { return; }
			_square = null;
			ds.RemoveMapObject(this);
		}
	}

	public class MultiSquareMapObject : DiscreteMapObject {
		#region Members
		private int _width;
		private int _height;
		private List<DiscreteSquare> _squares = new List<DiscreteSquare>();
		#endregion

		#region properties
		public override IEnumerable<DiscreteSquare> Squares {
			get { return _squares; }
		}
		public override int Width {
			get { return _width; }
		}
		public void SetWidth(int w ) { _width = w; }
		public override int Height {
			get { return _height; }
		}
		public void SetHeigth(int h) { _height = h; }
		#endregion

		public override void AddDiscreteSquare( DiscreteSquare ds ) {
			if(_squares.Contains(ds)) { return; }
			_squares.Add(ds);
			ds.AddMapObject(this);
		}
		public override void RemoveDiscreteSquare( DiscreteSquare ds ) {
			if(!_squares.Contains(ds)) { return; }
			_squares.Remove(ds);
			ds.RemoveMapObject(this);
		}
	}
}
