using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map {
	/// <summary>
	/// A position in the 2D space.
	/// </summary>
	/// <typeparam name="T">int, double, ... for discrete or continuous spaces.</typeparam>
	public interface I2DPosition<T> {
		T X { get; set; }
		T Y { get; set; }
		double Distance( I2DPosition<T> pos );
		int SqrtDistance( I2DPosition<T> pos );
	}

	public interface Discrete2DPosition : I2DPosition<int> {

    }

	class Discrete2DPositionClass : Discrete2DPosition {
		public int X { get; set; }

		public int Y { get; set; }

		public double Distance( I2DPosition<int> pos ) {
			int dx = pos.X - X;
			int dy = pos.Y - Y;
			return Math.Sqrt( dx * dx + dy * dy );
		}
		public int SqrtDistance( I2DPosition<int> pos ) {
			int dx = pos.X - X;
			int dy = pos.Y - Y;
			return dx * dx + dy * dy;
		}
	}

	struct Discrete2DPositionStrut : Discrete2DPosition {
		public int X { get; set; }

		public int Y { get; set; }

		public double Distance( I2DPosition<int> pos ) {
			int dx = pos.X - X;
			int dy = pos.Y - Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}
		public int SqrtDistance( I2DPosition<int> pos ) {
			int dx = pos.X - X;
			int dy = pos.Y - Y;
			return dx * dx + dy * dy;
		}
	}
}
