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
	public class SquareGrid<T> {

		#region Members
		private T[,] _map;
		#endregion

		#region Properties
		public T[,] Map {
			get {
				return _map;
			}
		}
		public int Column { get { return Map.GetLength(0); } }
		public int Row { get { return Map.GetLength(1); } }
		public T this[int i, int j]
		{
			get{ return _map[i,j]; }
			set { _map[i, j] = value; }
		}
		#endregion

		#region Init
		public SquareGrid( int w, int h ) : base() {
			_map = new T[w, h];
		}
		#endregion

		/// <summary>
		/// Resize the grid to the new given dimensions.
		/// If smaller size, troncated data is lost.
		/// Otherwize, new data is left to defaut value.
		/// </summary>
		/// <param name="newCol">The new width/columns number.</param>
		/// <param name="newRow">The new height/rows number.</param>
		public void Resize(int newCol, int newRow) {
			// Prevent the useless
			if (Column == newCol && Row == newRow)
				return;

			// Actual work
			T[,] _oldmap = _map;
			_map = new T[newCol,newRow];
			if(_oldmap != null) {
				for(int i = 0; i < System.Math.Min(_oldmap.GetLength(0), _map.GetLength(0)); i++) {
					for(int j = 0; j < System.Math.Min(_oldmap.GetLength(1), _map.GetLength(1)); j++) {
						_map[i, j] = _oldmap[i, j];
					}
				}
			}
		}

		/// <summary>
		/// Initialize the whole array to the given value.
		/// </summary>
		/// <param name="setValue">The new value to set.</param>
		public void SetMap(T setValue)
		{
			for (int i = 0; i < Column; i++)
			{
				for (int j = 0; j < Row; j++)
				{
					_map[i, j] = setValue;
				}
			}
		}

		/// <summary>
		/// Returns true if the given coordinates are contained in the grid dimensions.
		/// Index starts at 0.
		/// </summary>
		/// <param name="x">X coordinate. Column.</param>
		/// <param name="y">Y Coordinate. Row.</param>
		/// <returns>True if within boundaries.</returns>
		public bool Contains(int x, int y)
		{
			return x >= 0 && y >= 0 && y < Row && x < Column;
		}
	}
}
