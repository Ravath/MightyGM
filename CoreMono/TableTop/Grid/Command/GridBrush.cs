using CoreMono.Map.Brush;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Grid.Command
{
	public class GridBrush : Brush<int>
	{
		public GridBrush(BrushShape shape = BrushShape.Circle, int radius = 1)
		{
			this.Shape = shape;
			this.Radius = radius;
		}

		public IEnumerable<Point> GetPoints(int x, int y)
		{
			switch (Shape)
			{
				case BrushShape.Circle:
					return GetRectanglePoints(x, y, (int i, int j) => (x - i) * (x - i) + (y - j) * (y - j) <= (Radius - 1) * (Radius - 1));
				case BrushShape.Rectangle:
					return GetRectanglePoints(x, y, (int i, int j) => true);
				case BrushShape.Diamond:
					return GetRectanglePoints(x, y, (int i, int j) => Math.Abs(x - i) + Math.Abs(y - j) <= Radius - 1);
				default:
					return null;
			}
		}

		public IEnumerable<Point> GetRectanglePoints(int x, int y, Func<int, int, bool> select)
		{
			if (Radius <= 1)
			{
				yield return new Point(x, y);
			}
			else
			{ //rad = 2+
				int rad = Radius - 1;
				for (int i = x - rad; i <= x + rad; i++)
				{
					for (int j = y - rad; j <= y + rad; j++)
					{
						if (select(i, j))
							yield return new Point(i, j);
					}
				}
			}
		}
	}
}
