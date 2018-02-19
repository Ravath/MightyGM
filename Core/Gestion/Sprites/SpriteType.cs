using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion.Sprites
{
	public enum SpriteType
	{
		/// <summary>
		/// An unique elements.
		/// </summary>
		OBJECT,
		/// <summary>
		/// A 2D array grid of elements.
		/// </summary>
		OBJECT_ARRAY,
		/// <summary>
		/// A frame border, forming a resizable rectangle.
		/// </summary>
		FRAME,
		/// <summary>
		/// A specific type of sprite assembly where the minimal element fits in a square.
		/// </summary>
		SQUARE_SURFACE,
		/// <summary>
		/// A specific type of sprite assembly where the minimal element fits around a vertice.
		/// </summary>
		VERTICE_SURFACE
	}
}