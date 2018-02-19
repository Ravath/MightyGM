using Core.Map;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MightyGmWPF.MapDrawings {

	public struct iPoint {
		public int X;
		public int Y;

		public iPoint( int x, int y ) : this() {
			this.X = x;
			this.Y = y;
		}
		public iPoint(Point p) {
			X = (int)p.X;
			Y = (int)p.Y;
		}
	}

	public class SquareMapDrawer {

		#region Members
		protected Canvas _canvas;
		protected SquareGrid _grid;
		private Brush _gridColor = Brushes.Black;
		private SquareDrawer _sqrDrawer;
		#region positionnement
		private double _squareSize = 30;//size of a square.
		private double _size;//factor for a full size view at zoom = 1.
		private double _zoom = 1;
		private TranslateTransform _translate = new TranslateTransform();
		private ScaleTransform _scale = new ScaleTransform();
		private TransformGroup _transformation = new TransformGroup();
		private List<iPoint> _change = new List<iPoint>();//used for storing momenterary the list of squares we we want to change the appearance.
		#endregion
		#endregion

		#region Properties
		public Brush GridColor {
			get { return _gridColor; }
			set { _gridColor = value; }
		}

		public double SquareSize {
			get { return _squareSize; }
			protected set { _squareSize = value<1?1:value; }
		}
		public SquareGrid Map {
			get {
				return _grid;
			}
		}
		public Canvas Canvas {
			get {
				return _canvas;
			}
		}
		public double XOffset {
			get { return _translate.X; }
			set {
				_translate.X = value > 0 ? value : 0;
			}
		}
		public double YOffset {
			get { return _translate.Y; }
			set {
				_translate.Y = value > 0 ? value : 0;
			}
		}
		public double Zoom {
			get { return _zoom; }
			set {
				_zoom = value;
				_scale.ScaleX = _zoom * _size;
				_scale.ScaleY = _zoom * _size;
			}
		}
		/// <summary>
		/// The factor for the map to fit the dimensions of the canvas.
		/// </summary>
		protected double SizeFactor {
			get {
				return _size;
			}
			set {
				_size = value;
				_scale.ScaleX = _zoom * _size;
				_scale.ScaleY = _zoom * _size;
			}
		}

		#endregion

		#region Init
		public SquareMapDrawer( SquareGrid grid, Canvas canvas, SquareDrawer sqr ) {
			_transformation.Children.Add(_scale);
			_transformation.Children.Add(_translate);
			SetGrid(grid);
			SetCanvas(canvas);
			SetSquareDrawer(sqr);
        }

		public void SetGrid( SquareGrid grid ) {
			_grid = grid ?? throw new ArgumentNullException("Grid can't be null.");
		}
		public void SetCanvas( Canvas canvas ) {
			_canvas = canvas ?? throw new ArgumentNullException("Canvas can't be null.");
			_canvas.RenderTransform = _transformation;
		}
		public void SetSquareDrawer( SquareDrawer sqr ) {
			_sqrDrawer = sqr ?? throw new ArgumentNullException("SquareDrawer can't be null.");
		}
		#endregion

		/// <summary>
		/// Set the canvas dimensions.
		/// </summary>
		/// <param name="width">Width of the canvas.</param>
		/// <param name="height">Height of the canvas.</param>
		public void SetDimension( double width, double height ) {
			double _xScale = width / _grid.Width;
			double _yScale = height / _grid.Height;
			SizeFactor = Math.Min(_xScale, _yScale) / _squareSize;
		}
		public void SetSquareType( int x, int y, FloorType ft ) {
			if(_grid.Map[x,y] == ft) { return; }
			_grid.Map[x, y] = ft;
			SetSquareApparence(x, y);
        }

		public void SetSquareType( int x, int y, FloorType ft, MapBrush brush ) {
			if(brush == null || brush.Radius <= 1) {
				SetSquareType(x, y, ft);
				return;
			}
			_change.Clear();
            foreach(iPoint p in brush.GetPoints(x, y)) {
				if(p.X < 0 || p.Y < 0 || p.X >= Map.Width || p.Y >= Map.Height)
					continue;
				if(_grid.Map[p.X, p.Y] == ft) { continue; }
				_grid.Map[p.X, p.Y] = ft;
				_change.Add(p);
			}
			foreach(iPoint p in _change) {
				SetSquareApparence(p.X, p.Y);
			}
			_change.Clear();
		}

		public void SetAllMap( FloorType t ) {
			for(int i = 0; i < _grid.Map.GetLength(0); i++) {
				for(int j = 0; j < _grid.Map.GetLength(1); j++) {
					SetSquareType(i, j, t);
				}
			}
			for(int i = 0; i < _grid.Map.GetLength(0); i++) {
				for(int j = 0; j < _grid.Map.GetLength(1); j++) {
					SetSquareApparence(i, j);
				}
			}
		}

		/// <summary>
		/// Get the coordinates of a square from the clic on the canvas.
		/// </summary>
		/// <param name="e">Event of the mouse clic.</param>
		/// <param name="x">x coordinate of the square.</param>
		/// <param name="y">y coordinate of the square.</param>
		/// <returns>true if the coordinates are within the map.</returns>
		public bool GetMapSquareFromMouseClic( MouseEventArgs e, out int x, out int y ) {
			iPoint p = new iPoint(_canvas.RenderTransform.Inverse.Transform(e.GetPosition((IInputElement)_canvas.Parent)));
			x = (int)(p.X / _squareSize);
			y = (int)(p.Y / _squareSize);
			return x < Map.Width && y < Map.Height && x >= 0 && y >= 0;
		}
		/// <summary>
		/// Check if the coordinates are valuable acces to the map coordinates.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>true if positive and less than maxsize.</returns>
		public bool IsWithin( int x, int y ) {
			return !(x<0 || y<0 || x>=Map.Width || y>=Map.Height);
		}

		public void Draw() {
			_sqrDrawer.Draw(this);
		}

		protected void SetSquareApparence( int x, int y ) {
			_sqrDrawer.SetSquareApparence(x, y);
		}

		public void Highlight( IEnumerable<iPoint> highlitedSquares ) {
			_sqrDrawer.Highlight(highlitedSquares);
		}
	}

	}
