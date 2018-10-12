using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public class MgDescription : TextInput
	{
		public String Text
		{
			get { return base.Value; }
			set { base.Value = MgFont.Clean(value); }
		}

		public MgDescription(Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(true, anchor, offset)
		{
			Locked = true;
			TextParagraph.Scale = 0.8f;
			Padding = new Vector2(10);
			Skin = PanelSkin.None;
		}
	}
}
