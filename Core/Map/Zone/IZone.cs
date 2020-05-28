using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map.Zone
{
	/// <summary>
	/// Main Interface of the zones Composite Pattern.
	/// </summary>
	public interface IZone
	{
		/// <summary>
		/// Check if the given point is contained in the zone.
		/// </summary>
		/// <param name="x">X coordinate of the point.</param>
		/// <param name="y">Y coordinate of the point.</param>
		/// <returns>True if contains the point.</returns>
		bool Contains(double x, double y);
		/// <summary>
		/// Each zone can be associated to an object.
		/// </summary>
		object Object { get; set; }
	}
}
