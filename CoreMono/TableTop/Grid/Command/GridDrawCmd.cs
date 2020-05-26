using CoreMono.TableTop.Command;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Grid.Command
{
	public class GridDrawCmd : MouseGridCmd
	{
		private bool _ft;
		private GridLayer _lg;

		public GridBrush Brush { get; set; }

		public GridDrawCmd()
		{
			this.Brush = new GridBrush();
		}

		protected override void MouseDown(GridLayer sender, int x, int y)
		{
			_lg = sender;
			_ft = !_lg.Map[x, y];
			BrushMap(sender, x, y);
		}
		protected override void MouseHold(GridLayer sender, int x, int y)
		{
			BrushMap(sender, x, y);
		}
		protected override void MouseUp(GridLayer sender, int x, int y)
		{
			/* Nothing */
		}

		private void BrushMap(TableLayer sender, int x, int y)
		{
			if (Brush != null)
			{
				foreach (Point p in Brush.GetPoints(x, y))
				{
					if (_lg.Contains(p))
					{
						_lg.Map[p.X, p.Y] = _ft;
					}
				}
			}
			else
				_lg.Map[x, y] = _ft;
		}
	}
}
