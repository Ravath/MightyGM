using GeonBit.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop
{
	public interface IMapScale
	{
		int OffsetX { get; }
		int OffsetY { get; }
		double SquareSize { get; }
	}

	public class MapScale : IMapScale
	{
		public int OffsetX { get; set; }
		public int OffsetY { get; set; }
		public double SquareSize { get; set; }

		public MapScale(int squareSize = 80, int offsetX = 0, int offsetY = 0)
		{
			SquareSize = squareSize;
			OffsetX = offsetX;
			OffsetY = offsetY;
		}
	}

	public class EntityMapScale : IMapScale
	{
		private Entity _entity;
		public int OffsetX { get { return _entity.InternalDestRect.X; } }
		public int OffsetY { get { return _entity.InternalDestRect.Y; } }
		public double SquareSize { get; set; } = 80;

		public EntityMapScale(Entity entity)
		{
			_entity = entity;
		}
	}

	public class RelativeMapScale : IMapScale
	{
		/// <summary>
		/// The relative parent.
		/// </summary>
		public IMapScale RelativeParent { get; set; }

		public int RelativeOffsetX { get; set; } = 0;
		public int RelativeOffsetY { get; set; } = 0;
		public double RelativeZoom { get; set; } = 1;

		/// <summary>
		/// The absolute offset X value of this landmark.
		/// </summary>
		public int OffsetX {
			get { return RelativeOffsetX + RelativeParent?.OffsetX ?? 0; }
		}
		/// <summary>
		/// The absolute offset Y value of this landmark.
		/// </summary>
		public int OffsetY {
			get { return RelativeOffsetY + RelativeParent?.OffsetY ?? 0; }
		}
		/// <summary>
		/// The absolute Square Size value of this landmark.
		/// </summary>
		public double SquareSize
		{
			get { return RelativeZoom * RelativeParent?.SquareSize ?? 1; }
		}

		public RelativeMapScale(IMapScale parent = null)
		{
			RelativeParent = parent;
		}
	}
}
