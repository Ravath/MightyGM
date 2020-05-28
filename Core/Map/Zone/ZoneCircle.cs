using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map.Zone
{
	public abstract class ZoneCircle<T> : IZone
		where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
	{
		/// <summary>
		/// Center X coordinate.
		/// </summary>
		public T X { get; set; }
		/// <summary>
		/// Center Y coordinate.
		/// </summary>
		public T Y { get; set; }
		/// <summary>
		/// Circle Radius.
		/// </summary>
		public T Radius { get; set; }
		/// <summary>
		/// Distance type to use for the radius.
		/// </summary>
		public DistanceType DistanceType { get; set; }
		/// <summary>
		/// The object associated with this zone.
		/// </summary>
		public object Object { get; set; }

		/// <summary>
		/// Check if the given point is contained in the zone.
		/// </summary>
		/// <param name="x">X coordinate of the point.</param>
		/// <param name="y">Y coordinate of the point.</param>
		/// <returns>True if contains the point.</returns>
		public abstract bool Contains(double x, double y);
	}

	public class ZoneCircleInt : ZoneCircle<Int32>
	{
		public override bool Contains(double x, double y)
		{
			return Radius > Math.Distance(DistanceType, x - X, y - Y);
		}
	}

	public class ZoneCircleDouble : ZoneCircle<Double>
	{
		public override bool Contains(double x, double y)
		{
			return Radius > Math.Distance(DistanceType, x - X, y - Y);
		}
	}
}
