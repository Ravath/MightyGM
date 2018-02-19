using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTop.GUI;
using TableTop.Map.Brush;

namespace TableTop.Map.Commands
{
	public class SquareDrawCmd : MouseGridDrawCmd
	{
		private bool _ft;
		private LayerGrid _lg;

		public SquareMapBrush Brush { get; set; }

		public SquareDrawCmd()
		{
			this.Brush = new SquareMapBrush();
		}

		protected override void MouseDown(LayerMap sender, int x, int y)
		{
			_lg = sender.getActiveLayer<LayerGrid>();
			_ft = !_lg.Map[x, y];
			BrushMap(sender, x, y);
		}
		protected override void MouseHold(LayerMap sender, int x, int y)
		{
			BrushMap(sender, x, y);
		}
		protected override void MouseUp(LayerMap sender, int x, int y)
		{
			/* Nothing */
		}

		private void BrushMap(LayerMap sender, int x, int y)
		{
			if (Brush != null)
			{
				foreach (Point p in Brush.GetPoints(x,y))
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
