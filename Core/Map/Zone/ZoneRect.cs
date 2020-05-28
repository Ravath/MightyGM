using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map.Zone
{
	/// <summary>
	/// A rectangle zone.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class ZoneRect<T> : IZone
		where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
	{
		/// <summary>
		/// Upper left corner X coordinate.
		/// </summary>
		public T X { get; set; }
		/// <summary>
		/// Upper left corner Y coordinate.
		/// </summary>
		public T Y { get; set; }
		/// <summary>
		/// Rectangle width (X coordinate).
		/// </summary>
		public T Width { get; set; }
		/// <summary>
		/// Rectangle height (Y coordinate).
		/// </summary>
		public T Height { get; set; }
		/// <summary>
		/// The object associated with this zone.
		/// </summary>
		public object Object { get; set; }

		public abstract bool Contains(double x, double y);
	}

	public class ZoneRectInt : ZoneRect<Int32>
	{
		public override bool Contains(double x, double y)
		{
			return (x>=X) && (y>=Y) && (x<=X+Width) && (y<=Y+Height);
		}
	}

	public class ZoneRectDouble : ZoneRect<Double>
	{
		public override bool Contains(double x, double y)
		{
			return (x >= X) && (y >= Y) && (x <= X + Width) && (y <= Y + Height);
		}
	}
}
