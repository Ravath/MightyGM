using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MightyGmWPF.MapDrawings {
	public enum BrushShape {
		Circle, Rectangle, Diamond
	}
	public class Brush<T> where T : struct, IConvertible {
		private T _radius;
        public T Radius {
			get{return _radius;}
			set { _radius = value;}
		}
		public BrushShape Shape { get; set; }
	}

	public class MapBrush : Brush<int> {
		public IEnumerable<iPoint> GetPoints( int x, int y ) {
			switch(Shape) {
				case BrushShape.Circle:
				return GetRectanglePoints(x, y, ( int i, int j ) => (x- i)*(x - i) + (y - j)*(y - j) <= (Radius - 1 )* (Radius - 1));
				case BrushShape.Rectangle:
				return GetRectanglePoints(x, y, ( int i, int j ) => true);
				case BrushShape.Diamond:
				return GetRectanglePoints(x, y, ( int i, int j ) => Math.Abs(x - i) + Math.Abs(y - j) <= Radius-1);
				default:
				return null;
			}
        }
		public IEnumerable<iPoint> GetRectanglePoints( int x, int y, Func<int,int,bool> select ) {
			if(Radius <= 1) {
				yield return new iPoint(x, y);
			} else { //rad = 2+
				int rad = Radius - 1;
				for(int i = x - rad; i <= x + rad; i++) {
					for(int j = y - rad; j <= y + rad; j++) {
						if(select(i,j))
							yield return new iPoint(i, j);
					}
				}
			}
		}
	}
}
