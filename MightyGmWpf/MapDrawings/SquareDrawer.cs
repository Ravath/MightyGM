using Core.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MightyGmWPF.MapDrawings {
	public interface SquareDrawer {
		/// <summary>
		/// Set the SquareMap it has to draw on.
		/// </summary>
		/// <param name="map"></param>
		void Draw( SquareMapDrawer map );
		/// <summary>
		/// Remove the map.
		/// </summary>
		void Remove();
		void SetSquareApparence( int x, int y );
		void Highlight( IEnumerable<iPoint> highlitedSquares );
	}

	public class DefaultSquareDrawer : SquareDrawer {
		private SquareMapDrawer _mapdrawer;
		private Rectangle[,] _squares;
		private Canvas _canvas;
		private FloorType[,] _grid;

		public void SetSquareApparence( int x, int y ) {
			Rectangle r = _squares[x, y];
			switch(_grid[x, y]) {
				case FloorType.Empty:
				r.Fill = Brushes.Black;
				break;
				case FloorType.Floor:
				r.Fill = Brushes.Green;
				break;
				case FloorType.Wall:
				r.Fill = Brushes.Beige;
				break;
			}
		}

		public void Draw( SquareMapDrawer map ) {
			if(_canvas != null)
				Remove();
			_mapdrawer = map;
			_canvas = map.Canvas;
			_grid = map.Map.Map;
			//draw squares
			_squares = new Rectangle[_grid.GetLength(0), _grid.GetLength(1)];
			for(int i = 0; i < _grid.GetLength(0); i++) {
				for(int j = 0; j < _grid.GetLength(1); j++) {
					Rectangle r = new Rectangle();
					_squares[i, j] = r;
					r.Width = map.SquareSize;
					r.Height = map.SquareSize;
					//r.Stroke = _gridColor;
					map.SetSquareType(i, j, _grid[i, j]);
					Canvas.SetLeft(r, (i * map.SquareSize));
					Canvas.SetTop(r, (j * map.SquareSize));
					_canvas.Children.Add(r);
				}
			}
		}

		public void Remove() {
			foreach(Rectangle r in _squares) {
				_canvas.Children.Remove(r);
			}
			_squares = null;
			_mapdrawer = null;
			_canvas = null;
			_grid = null;
		}

		public void Highlight( IEnumerable<iPoint> highlitedSquares ) {
			throw new NotImplementedException();
		}
	}

}
