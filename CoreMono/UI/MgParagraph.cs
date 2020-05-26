using GeonBit.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CoreMono.UI
{
	public class MgParagraph : Paragraph
	{
		public override string Text
		{
			get { return base.Text; }
			set {
				base.Text = MgFont.Clean(value);
			}
		}

		public MgParagraph(string text = "", Anchor anchor = Anchor.Auto, Vector2? size = null, Vector2? offset = null, float? scale = null) : base(text, anchor, size, offset, scale)
		{
		}

		public MgParagraph(string text, Anchor anchor, Color color, float? scale = null, Vector2? size = null, Vector2? offset = null) : base(text, anchor, color, scale, size, offset)
		{
		}
	}

	public class MgProperty : MgParagraph
	{
		public MgProperty(string text = "", Anchor anchor = Anchor.Auto, Vector2? size = null, Vector2? offset = null, float? scale = null) : base(text, anchor, size, offset, scale)
		{
			FillColor = Color.Gold;
		}
	}

	public class MgSubProperty : MgParagraph
	{
		public MgSubProperty(string text = "", Anchor anchor = Anchor.Auto, Vector2? size = null, Vector2? offset = null, float? scale = null) : base(text, anchor, size, offset, scale)
		{
			FillColor = Color.DarkGoldenrod;
		}
	}

	public class MgTextInsert : MgParagraph
	{
		public MgTextInsert(string text = "", Anchor anchor = Anchor.Auto, Vector2? size = null, Vector2? offset = null, float? scale = null) : base(text, anchor, size, offset, scale)
		{
			Scale = 0.8f;
			Padding = new Vector2(10);
		}
	}

	public class MgCitation : MgParagraph
	{
		public MgCitation(string text = "", Anchor anchor = Anchor.Auto, Vector2? size = null, Vector2? offset = null, float? scale = null) : base(text, anchor, size, offset, scale)
		{
			Scale = 0.8f;
			Padding = new Vector2(40);
			TextStyle = FontStyle.Italic;
		}
	}

	public class MgDescription : MgParagraph
	{
		public MgDescription(Anchor anchor = Anchor.Auto, Vector2? offset = null) : base("", anchor, offset)
		{
			Locked = true;
			Scale = 0.8f;
			Padding = new Vector2(10);
		}
	}
}
