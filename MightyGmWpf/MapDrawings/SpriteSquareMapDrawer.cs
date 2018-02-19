using Core.Map;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MightyGmWPF.MapDrawings {

	public class WallSprites {
		private BitmapSource _img;
		private BitmapSource _void;
		private BitmapSource _wall, _floor;

		//s: supérieur, i : inférieur, d : droite, g: gauche
		private BitmapSource _ciid, _cisd, _cisg, _ciig;//coins internes
		private BitmapSource _ceid, _cesd, _cesg, _ceig;//coins externes

		private BitmapSource _wup, _wdown, _wright, _wleft;//straight walls : the side the are looking at. (the properties design the side the wall is=>seem inversed)

		public BitmapSource Floor { get { return _floor; } }
		public BitmapSource Wall { get { return _wall; } }
		public BitmapSource Empty { get { return _void; } }
		public BitmapSource UpperLeftInnerCorner  { get { return _cisg; } }
		public BitmapSource LowerLeftInnerCorner  { get { return _ciig; } }
		public BitmapSource UpperRightInnerCorner { get { return _cisd; } }
		public BitmapSource LowerRightInnerCorner { get { return _ciid; } }
		public BitmapSource UpperLeftOuterCorner  { get { return _cesg; } }
		public BitmapSource LowerLeftOuterCorner  { get { return _ceig; } }
		public BitmapSource UpperRightOuterCorner { get { return _cesd; } }
		public BitmapSource LowerRightOuterCorner { get { return _ceid; } }
		public BitmapSource LowerWall { get { return _wup; } }
		public BitmapSource UpperWall { get { return _wdown; } }
		public BitmapSource RightWall { get { return _wleft; } }
		public BitmapSource LeftWall { get { return _wright; } }

		public BitmapSource OuterCorner(bool right, bool upper ) {
			if(right) {
				if(upper)
					return UpperRightOuterCorner;
				else
					return LowerRightOuterCorner;
			} else
				if(upper)
					return UpperLeftOuterCorner;
				else
					return LowerLeftOuterCorner;
		}
		public BitmapSource InnerCorner( bool right, bool upper ) {
			if(right) {
				if(upper)
					return UpperRightInnerCorner;
				else
					return LowerRightInnerCorner;
			} else
				if(upper)
				return UpperLeftInnerCorner;
			else
				return LowerLeftInnerCorner;
		}

		public WallSprites( string path ) {
			int s = 10;
			BitmapImage bi = new BitmapImage();
			bi.BeginInit();
			bi.UriSource = new Uri(path);
			bi.EndInit();
			_img = bi;
			_wall = new CroppedBitmap(bi, new Int32Rect(0, 0, s, s));
			_floor = new CroppedBitmap(bi, new Int32Rect(s, 0, s, s));
			_void = new CroppedBitmap(bi, new Int32Rect(2 * s, 0, s, s));
			_ciid = new CroppedBitmap(bi, new Int32Rect(2 * s, 2 * s, s, s));
			_cisd = new CroppedBitmap(bi, new Int32Rect(2 * s, 3 * s, s, s));
			_cisg = new CroppedBitmap(bi, new Int32Rect(3 * s, 3 * s, s, s));
			_ciig = new CroppedBitmap(bi, new Int32Rect(3 * s, 2 * s, s, s));
			_ceid = new CroppedBitmap(bi, new Int32Rect(1 * s, 3 * s, s, s));
			_cesd = new CroppedBitmap(bi, new Int32Rect(1 * s, 2 * s, s, s));
			_cesg = new CroppedBitmap(bi, new Int32Rect(0 * s, 2 * s, s, s));
			_ceig = new CroppedBitmap(bi, new Int32Rect(0 * s, 3 * s, s, s));
			_wup = new CroppedBitmap(bi, new Int32Rect(2 * s, 1 * s, s, s));
			_wdown = new CroppedBitmap(bi, new Int32Rect(0 * s, 1 * s, s, s));
			_wright = new CroppedBitmap(bi, new Int32Rect(1 * s, 1 * s, s, s));
			_wleft = new TransformedBitmap(_wup, new RotateTransform(-90));
        }
	}

	public class SpriteSquareDrawer : SquareDrawer {

		private SquareMapDrawer _map;

		DrawingGroup _image = new DrawingGroup();
		DrawingImage _drawingImage;
		Image imageControl = new Image();

		private WallSprites _sprites;
		private ImageDrawing[,] _squares;
		/// <summary>
		/// Détermine si le contour extérieur de la map doit être considéré comme un mur ou pas.
		/// </summary>
		public bool OutsideIsWall { get; set; }

		#region Init
		public SpriteSquareDrawer( WallSprites ws ) {
			_drawingImage = new DrawingImage(_image);
			imageControl.Source = _drawingImage;
			SetWallSprites(ws);
			OutsideIsWall = true;
        }
		public void SetWallSprites( WallSprites ws ) {
			if(ws == null)
				throw new ArgumentNullException("The argument ws can't be null");
			_sprites = ws;
		} 
		#endregion

		public void SetSquareApparence( int x, int y) {
			for(int i = x-1; i <= x+1; i++) {
				for(int j = y-1; j <= y+1; j++) {
					if(_map.IsWithin(i, j))
						SetSquareSprite(i, j);
				}
			}
		}
		private bool IsWall( int x, int y ) {
			if(!_map.IsWithin(x,y))
				return OutsideIsWall;
			return _map.Map.Map[x, y] == FloorType.Wall;
		}

		private void SetCornerSprite(int x, int y, bool right, bool up ) {
			ImageDrawing i = _squares[x * 3 + (right ? 2 : 0), y * 3 + (up ? 0 : 2)];
			bool side = IsWall(x + (right ? 1 : -1), y);//gauche ou droite
			bool front = IsWall(x, y + (up ? -1 : 1));//haut ou bas
			bool diag = IsWall(x + (right ? 1 : -1), y + (up ? -1 : 1));//diagonale
			if(!side && !front) {//outer corner
				i.ImageSource = _sprites.OuterCorner(right, up);
			} else if(side && front) {
				if(diag) {
					i.ImageSource = _sprites.Wall;
				} else {//inner corner
					i.ImageSource = _sprites.InnerCorner(right, up);
				}
			} else {//straight walls
				if(side) {//!front
					if(up)
						i.ImageSource = _sprites.LowerWall;
					else
						i.ImageSource = _sprites.UpperWall;
				} else {//front && !side
					if(right)
					i.ImageSource = _sprites.LeftWall;
				else
					i.ImageSource = _sprites.RightWall;
				}
			}
		}

		private void SetSquareSprite( int x, int y ) {
			if(_map.Map.Map[x,y] != FloorType.Wall) {
				for(int k = 0; k < 3; k++) {
					for(int l = 0; l < 3; l++) {
						if(_map.Map.Map[x, y] == FloorType.Floor)//sol
							_squares[3 * x + k, 3 * y + l].ImageSource = _sprites.Floor;
						else//empty square
							_squares[3 * x + k, 3 * y + l].ImageSource = _sprites.Empty;
					}
				}
			} else {
				//coins
				SetCornerSprite(x, y, true, false);
				SetCornerSprite(x, y, true, true);
				SetCornerSprite(x, y, false, false);
				SetCornerSprite(x, y, false, true);
				//centre
				_squares[3 * x + 1, 3 * y + 1].ImageSource = _sprites.Wall;
				//murs droits
				_squares[3*x + 1, 3*y + 0].ImageSource = IsWall(x, y - 1) ? _sprites.Wall : _sprites.LowerWall;//en haut
				_squares[3*x + 1, 3*y + 2].ImageSource = IsWall(x, y + 1) ? _sprites.Wall : _sprites.UpperWall;//en bas
				_squares[3*x + 2, 3*y + 1].ImageSource = IsWall(x + 1, y) ? _sprites.Wall : _sprites.LeftWall;//a droite
				_squares[3*x + 0, 3*y + 1].ImageSource = IsWall(x - 1, y) ? _sprites.Wall : _sprites.RightWall;//a gauche
			}
        }

		public void Draw( SquareMapDrawer map ) {
			if(_map != null)
				Remove();
			_map = map;
			Canvas canvas = map.Canvas;
			FloorType[,] grid = map.Map.Map;
			double squareSize = map.SquareSize;
			//draw squares
			canvas.Children.Clear();
			_squares = new ImageDrawing[grid.GetLength(0)*3, grid.GetLength(1) * 3];
			for(int i = 0; i < grid.GetLength(0); i++) {
				for(int j = 0; j < grid.GetLength(1); j++) {
					//add images
					for(int k = 0; k < 3; k++) {
						for(int l = 0; l < 3; l++) {
							ImageDrawing r = new ImageDrawing();
							_squares[3*i+k, 3*j+l] = r;
							r.Rect = new Rect(
								(i * squareSize) + (k * squareSize / 3),
								(j * squareSize) + (l * squareSize / 3),
								squareSize / 3, squareSize / 3);
							_image.Children.Add(r);
						}
					}
					SetSquareSprite(i, j);
				}
			}
            canvas.Children.Add(imageControl);
		}

		public void Remove() {
			_map.Canvas.Children.Remove(imageControl);
			_image.Children.Clear();
			_squares = null;
			_map = null;
        }

		public void Highlight( IEnumerable<iPoint> highlitedSquares ) {
			throw new NotImplementedException();
		}
	}
}
