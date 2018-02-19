using Core.Map;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MightyGmWPF.MapDrawings {

	public interface MapCommand {
		void MouseDown( SquareMapDrawer sender, MouseButtonEventArgs e );
		void MouseUp( SquareMapDrawer sender, MouseButtonEventArgs e );
		void MouseMove( SquareMapDrawer sender, MouseEventArgs e );
	}

	public class GrabCommand : MapCommand {
		private bool _mdown = false;
		private Point p;
		private double ix, iy;

		public GrabCommand() { }

		public void MouseDown( SquareMapDrawer sender, MouseButtonEventArgs e ) {
			_mdown = true;
			p = e.GetPosition(null);
			ix = sender.XOffset;
			iy = sender.YOffset;
		}

		public void MouseMove( SquareMapDrawer sender, MouseEventArgs e ) {
			if(_mdown) {
				Point cp = e.GetPosition(null);
				sender.XOffset = ix + cp.X - p.X;
				sender.YOffset = iy + cp.Y - p.Y;
			}
		}

		public void MouseUp( SquareMapDrawer sender, MouseButtonEventArgs e ) {
			_mdown = false;
		}
	}

	public class ScaleCommand : MapCommand {
		private bool _mdown = false;
		private Point p;
		private double _izoom;
		private Line _set = new Line() { Stroke = Brushes.WhiteSmoke };
		private Line _cur = new Line() { Stroke = Brushes.Gray };

		public void MouseDown( SquareMapDrawer sender, MouseButtonEventArgs e ) {
			_mdown = true;
			_izoom = sender.Zoom;
			p = e.GetPosition(sender.Canvas);
			_set.X1 = p.X;
			_set.Y1 = p.Y;
			_set.X2 = sender.Canvas.ActualWidth / 4;
			_set.Y2 = sender.Canvas.ActualHeight / 4;
			_cur.X2 = _set.X2;
			_cur.Y2 = _set.Y2;
			sender.Canvas.Children.Add(_set);
			sender.Canvas.Children.Add(_cur);
		}

		public void MouseMove( SquareMapDrawer sender, MouseEventArgs e ) {
			//if(_mdown) {
			//	Point cp = e.GetPosition(sender.Canvas);
			//	_cur.X1 = cp.X;
			//	_cur.Y1 = cp.Y;
			//	sender.Zoom = _izoom * (cp.X - _cur.X2) / (p.X - _cur.X2);
			//}
		}

		public void MouseUp( SquareMapDrawer sender, MouseButtonEventArgs e ) {
			_mdown = false;
			sender.Canvas.Children.Remove(_set);
			sender.Canvas.Children.Remove(_cur);
		}
	}

	public class WallDrawerCommand : MapCommand {

		private MapBrush _brush;
		private bool _msDown = false;
		protected FloorType _ft;

		public MapBrush Brush {
			get { return _brush; }
			set { _brush = value; }
		}

		private void BrushMap( SquareMapDrawer sender, int x,int y ) {
			if(_brush != null)
				sender.SetSquareType(x, y, _ft, _brush);
			else
				sender.SetSquareType(x, y, _ft);
		}

		protected virtual void SetFloorType( FloorType ft ) {
			switch(ft) {
				case FloorType.Empty:
				case FloorType.Wall:
				_ft = FloorType.Floor;
				break;
				case FloorType.Floor:
				_ft = FloorType.Wall;
				break;
				default:
				_ft = FloorType.Wall;
				break;
			}
		}

		public void MouseDown( SquareMapDrawer sender, MouseButtonEventArgs e ) {
			int x, y;
			if(sender.GetMapSquareFromMouseClic(e, out x, out y)) {
				_msDown = true;
				SetFloorType(sender.Map.Map[x, y]);
				BrushMap(sender, x, y);
            }
		}

		public void MouseMove( SquareMapDrawer sender, MouseEventArgs e ) {
			int x, y;
			if(_msDown) {
				if(sender.GetMapSquareFromMouseClic(e, out x, out y)) {
					//if(sender.Map.Map[x, y] != _ft) {
						BrushMap(sender, x, y);
					//}
				}
			}
		}

		public void MouseUp( SquareMapDrawer sender, MouseButtonEventArgs e ) {
			_msDown = false;
		}
	}

	public class EmptyDrawerCommand : WallDrawerCommand {
		protected override void SetFloorType( FloorType ft ) {
			_ft = FloorType.Empty;
        }
	}
}
