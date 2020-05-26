using GeonBit.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using CoreMono.UI;

namespace CoreMono.TableTop
{
	public abstract class TableLayer : Entity
	{
		public TableLayer(Vector2? size = null, Anchor anchor = Anchor.Center, Vector2? offset = null) : base(size, anchor, offset)
		{
			ClickThrough = true;
		}

		public abstract void DisplayProperties(PropertyDisplay displayer);
	}
}
