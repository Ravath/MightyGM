using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map {
	/// <summary>
	/// Not a fair square, but the interjection between the Y and X axis.
	/// </summary>
	public class DiscreteSquare {
		#region Members
		private Discrete2DPositionClass _pos = new Discrete2DPositionClass();
		private List<DiscreteMapObject> _objets = new List<DiscreteMapObject>();
		#endregion

		#region Properties
		public int X {
			get { return _pos.X; }
		}
		public int Y {
			get { return _pos.Y; }
		}
		#endregion

		#region Init
		public DiscreteSquare() : this(0, 0) { }
		public DiscreteSquare( int x, int y ) {
			_pos.X = x;
			_pos.Y = y;
		}
		public IEnumerable<DiscreteMapObject> Objects {
			get { return _objets; }
		}

		#endregion
		
		public void AddMapObject( DiscreteMapObject mo ) {
			if(_objets.Contains(mo)) { return; }
			_objets.Add(mo);
			mo.AddDiscreteSquare(this);
		}
		public void RemoveMapObject( DiscreteMapObject mo ) {
			if(!_objets.Contains(mo)) { return; }
			_objets.Remove(mo);
			mo.RemoveDiscreteSquare(this);
		}
	}
}
