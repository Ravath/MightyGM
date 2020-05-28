using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map.Zone
{
	/// <summary>
	/// A composition of zones.
	/// </summary>
	public class ZoneSet : IZone, ICollection<IZone>, IEnumerable<IZone>, IEnumerable, ICollection, IReadOnlyList<IZone>, IReadOnlyCollection<IZone>
	{
		private List<IZone> _zones = new List<IZone>();

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
		public bool Contains(double x, double y)
		{
			for(int i = 0; i<_zones.Count; i++)
			{
				if (_zones[i].Contains(x, y))
					return true;
			}
			return false;
		}

		#region Collection Interface Implementation
		public IZone this[int index] => ((IReadOnlyList<IZone>)_zones)[index];

		public int Count { get { return _zones.Count; } }

		public bool IsReadOnly => ((ICollection<IZone>)_zones).IsReadOnly;

		public object SyncRoot => ((ICollection)_zones).SyncRoot;

		public bool IsSynchronized => ((ICollection)_zones).IsSynchronized;

		public void Add(IZone item)
		{
			((ICollection<IZone>)_zones).Add(item);
		}

		public void Clear()
		{
			((ICollection<IZone>)_zones).Clear();
		}

		public bool Contains(IZone item)
		{
			return ((ICollection<IZone>)_zones).Contains(item);
		}

		public void CopyTo(IZone[] array, int arrayIndex)
		{
			((ICollection<IZone>)_zones).CopyTo(array, arrayIndex);
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)_zones).CopyTo(array, index);
		}

		public IEnumerator<IZone> GetEnumerator()
		{
			return ((ICollection<IZone>)_zones).GetEnumerator();
		}

		public bool Remove(IZone item)
		{
			return ((ICollection<IZone>)_zones).Remove(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((ICollection<IZone>)_zones).GetEnumerator();
		} 
		#endregion
	}
}
