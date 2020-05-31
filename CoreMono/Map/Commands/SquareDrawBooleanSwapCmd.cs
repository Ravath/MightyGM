using Microsoft.Xna.Framework;
using CoreMono.Map.Brush;
using CoreMono.Map.Layers;

namespace CoreMono.Map.Commands
{
	public class SquareDrawBooleanSwapCmd : MouseGridDrawCmd
	{
		private bool _ft;
		private MapLayerSquareGrid<bool> _lg;

		public SquareMapBrush Brush { get; set; }

		public SquareDrawBooleanSwapCmd()
		{
			this.Brush = new SquareMapBrush();
		}

		protected override void MouseDown(MapDrawer sender, int x, int y)
		{
			_lg = sender.GetActiveLayer<MapLayerSquareGrid<bool>>();
			_ft = !_lg.Map[x, y];
			BrushMap(sender, x, y);
		}
		protected override void MouseHold(MapDrawer sender, int x, int y)
		{
			BrushMap(sender, x, y);
		}
		protected override void MouseUp(MapDrawer sender, int x, int y)
		{
			/* Nothing */
		}

		private void BrushMap(MapDrawer sender, int x, int y)
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
