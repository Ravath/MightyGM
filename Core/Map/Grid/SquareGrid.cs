using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map.Grid {

	/// <summary>
	/// A 2D Square Grid.
	/// </summary>
	/// <typeparam name="T">The value stored in the Array.</typeparam>
	public abstract class SquareGrid<T> {

		#region Members
		private T[,] _map;
		#endregion

		#region Properties
		public T[,] Map {
			get {
				return _map;
			}
		}
		#endregion

		#region Init
		public SquareGrid( int w, int h ) : base() {
			_map = new T[w, h];
		}

		public void Resize( int oldw, int neww, int oldh, int newh ) {
			T[,] _oldmap = _map;
			_map = new T[neww,newh];
			if(_oldmap != null) {
				for(int i = 0; i < System.Math.Min(_oldmap.GetLength(0), _map.GetLength(0)); i++) {
					for(int j = 0; j < System.Math.Min(_oldmap.GetLength(1), _map.GetLength(1)); j++) {
						_map[i, j] = _oldmap[i, j];
					}
				}
			}
        }
		#endregion
	}
}
