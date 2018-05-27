using CoreMono.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.Panels
{
	public class MapLayerGrid : MapLayer
	{
		public ISquareDrawer Drawer { get; set; }
		public bool[,] Map { get; private set; }
		public int Column { get { return Map.GetLength(0); } }
		public int Row { get { return Map.GetLength(1); } }

		public MapLayerGrid(int col, int row, ISquareDrawer drawer)
		{
			Map = new bool[col, row];
			Drawer = drawer;
		}

		public override void Draw(SpriteBatch batch, MapDrawer lm)
		{
			Drawer.Draw(batch, lm, Map);
		}

		/// <summary>
		/// Initialize the whole array to the given value.
		/// </summary>
		/// <param name="setValue"></param>
		public void SetMap(Boolean setValue)
		{
			for (int i = 0; i < Column; i++)
			{
				for (int j = 0; j < Row; j++)
				{
					Map[i, j] = setValue;
				}
			}
		}

		public bool Contains(Point p)
		{
			return !(p.X < 0 || p.Y < 0 || p.Y >= Row || p.X >= Column);
		}
	}
}
