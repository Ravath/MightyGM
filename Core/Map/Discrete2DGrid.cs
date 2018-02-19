using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map {
	public enum FloorType {
		Empty, Floor, Wall
	}
	/// <summary>
	/// A 2D Grid where the positions are real numbers.
	/// </summary>
	public abstract class Discrete2DMap : Abs2DMap<int> {

		#region Members
		private FloorType[,] _map;
		//private DiscreteSquare[,] _Squares;
		#endregion

		#region Properties
		public FloorType[,] Map {
			get {
				return _map;
			}
		}
		#endregion

		#region Init
		public Discrete2DMap( int w, int h ) : base() {
			Resize(w, h);
		}
		protected override void OnResize( int oldw, int neww, int oldh, int newh ) {
			FloorType[,] _oldmap = _map;
			_map = new FloorType[neww,newh];
			if(_oldmap != null) {
				for(int i = 0; i < Math.Min(_oldmap.GetLength(0), _map.GetLength(0)); i++) {
					for(int j = 0; j < Math.Min(_oldmap.GetLength(1), _map.GetLength(1)); j++) {
						_map[i, j] = _oldmap[i, j];
					}
				}
			}
        }
		#endregion
	}
}
