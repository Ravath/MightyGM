using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public class MgHeader : Header
	{
		/// <summary>
		/// Create the header.
		/// </summary>
		/// <param name="text">Header text.</param>
		/// <param name="anchor">Position anchor.</param>
		/// <param name="offset">Offset from anchor position.</param>
		public MgHeader(string text, Anchor anchor = Anchor.Auto, Vector2? offset = null) :
            base(MgFont.Clean(text), anchor, offset: offset)
        {
		}

		/// <summary>
		/// Create default header without text.
		/// </summary>
		public MgHeader() : this(string.Empty)
        {
		}

		public override string Text { get => base.Text; set => base.Text = MgFont.Clean(value); }
	}
}
