using Core.Map.Grid;
using CoreMono.Map.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CoreMono.Map.Layers
{
	public class MapLayerSquareGrid<T> : IMapLayer
	{
		public ISquareDrawer<T> Drawer { get; set; }
		public SquareGrid<T> Map { get; private set; }
		public int Column { get { return Map.Column; } }
		public int Row { get { return Map.Row; } }

		public MapLayerSquareGrid(SquareGrid<T> map, ISquareDrawer<T> drawer)
		{
			Map = map;
			Drawer = drawer;
		}

		public void Draw(SpriteBatch batch, MapDrawer lm)
		{
			Drawer.Draw(batch, lm, Map);
		}

		public void Resize(int col, int row, int squareSize)
		{
			Map.Resize(col, row);
		}

		/// <summary>
		/// Initialize the whole array to the given value.
		/// </summary>
		/// <param name="setValue"></param>
		public void SetMap(T setValue)
		{
			Map.SetMap(setValue);
		}

		/// <summary>
		/// Returns true if the given coordinates are contained in the grid dimensions.
		/// Index starts at 1.
		/// </summary>
		/// <param name="p">Point coordinates.</param>
		/// <returns>True if within boundaries.</returns>
		public bool Contains(Point p)
		{
			return Map.Contains(p.X - 1, p.Y - 1);
		}
	}
}
