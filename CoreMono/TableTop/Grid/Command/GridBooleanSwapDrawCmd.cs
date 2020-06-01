using CoreMono.TableTop.Command;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Grid.Command
{
	public class GridBooleanSwapDrawCmd : MouseGridCmd<bool>
	{
		private bool _ft;
		private GridLayer<bool> _lg;

		public GridBrush Brush { get; set; }

		public GridBooleanSwapDrawCmd()
		{
			this.Brush = new GridBrush();
		}

		protected override void MouseDown(GridLayer<bool> sender, int x, int y)
		{
			_lg = sender;
			_ft = !_lg.Grid[x, y];
			BrushMap(sender, x, y);
		}
		protected override void MouseHold(GridLayer<bool> sender, int x, int y)
		{
			BrushMap(sender, x, y);
		}
		protected override void MouseUp(GridLayer<bool> sender, int x, int y)
		{
			/* Nothing */
		}

		private void BrushMap(Layer sender, int x, int y)
		{
			if (Brush != null)
			{
				foreach (Point p in Brush.GetPoints(x, y))
				{
					if (_lg.Contains(p))
					{
						_lg.Grid[p.X, p.Y] = _ft;
					}
				}
			}
			else
				_lg.Grid[x, y] = _ft;
		}
	}
}
