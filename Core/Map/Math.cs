using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map
{
	/// <summary>
	/// The main mathematical distances which can be used to compute distances between 2 points.
	/// </summary>
	public enum DistanceType
	{
		// 1 - Distance
		Manhattan,
		// 2 - Distance
		Euclidian,
		// oo- Distance
		Tchebychev
	}

	public static class Math
	{
		#region Distance
		/// <summary>
		/// Compute the Manhattan distance.
		/// </summary>
		/// <param name="w">Width.</param>
		/// <param name="h">Height.</param>
		/// <returns>Manhattan distance</returns>
		public static double ManhattanDistance(double w, double h)
		{
			return System.Math.Abs(w) + System.Math.Abs(w);
		}
		/// <summary>
		/// Compute the Euclidian distance.
		/// </summary>
		/// <param name="w">Width.</param>
		/// <param name="h">Height.</param>
		/// <returns>Euclidian distance</returns>
		public static double EuclidianDistance(double w, double h)
		{
			return System.Math.Sqrt(w * w + h * h);
		}
		/// <summary>
		/// Compute the square of the Euclidian distance.
		/// </summary>
		/// <param name="w">Width.</param>
		/// <param name="h">Height.</param>
		/// <returns>The square of the hypotenuse.</returns>
		public static double EuclidianDistanceSquare(double w, double h)
		{
			return w * w + h * h;
		}
		/// <summary>
		/// Compute the Tchebychev distance.
		/// </summary>
		/// <param name="w">Width.</param>
		/// <param name="h">Height.</param>
		/// <returns>Tchebychev distance</returns>
		public static double TchebychevDistance(double w, double h)
		{
			return System.Math.Max(System.Math.Abs(w), System.Math.Abs(w));
		}

		public static double Distance(DistanceType type, double w, double h)
		{
			switch (type)
			{
				case DistanceType.Manhattan:
					return ManhattanDistance(w, h);
				case DistanceType.Euclidian:
					return EuclidianDistance(w, h);
				case DistanceType.Tchebychev:
					return TchebychevDistance(w, h);
				default:
					throw new NotImplementedException("Distance Type '" + type + "' not implemented");
			}
		}
		#endregion

		#region Grid Magnetism
		/// <summary>
		/// Returns the coordinates of the closer upper left square corner to magnetise with.
		/// </summary>
		/// <param name="xOffset"></param>
		/// <param name="yOffset"></param>
		/// <param name="size"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public static void CornerMagnetism(double xOffset, double yOffset, double size, ref double x, ref double y)
		{
			x = x - ((x - xOffset) % size);
			y = y - ((y - yOffset) % size);
		}
		/// <summary>
		/// Returns the coordinates of the closer upper left square center to magnetise with.
		/// </summary>
		/// <param name="xOffset"></param>
		/// <param name="yOffset"></param>
		/// <param name="size"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public static void CenterMagnetism(double xOffset, double yOffset, double size, ref double x, ref double y)
		{
			x = x - ((x - xOffset - size/2) % size);
			y = y - ((y - yOffset - size/2) % size);
		}
		/// <summary>
		/// Returns the coordinates of the closer upper left square center or corner to magnetise with.
		/// </summary>
		/// <param name="xOffset"></param>
		/// <param name="yOffset"></param>
		/// <param name="size"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public static void CloserMagnetism(double xOffset, double yOffset, double size, ref double x, ref double y)
		{
			x = x - ((x - xOffset) % size/2);
			y = y - ((y - yOffset) % size/2);
		}
		#endregion
	}

}
