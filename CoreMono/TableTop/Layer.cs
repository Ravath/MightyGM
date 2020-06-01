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
	public abstract class Layer : Entity
	{
		public Map Map { get; private set; }
		public RelativeMapScale MapScale { get; private set; } = new RelativeMapScale();

		public Layer(Vector2? size = null, Anchor anchor = Anchor.Center, Vector2? offset = null) : base(size, anchor, offset)
		{
			ClickThrough = true;
		}

		internal void SetMap(Map map)
		{
			Map = map;
			MapScale.RelativeParent = map.MapScale;
		}

		public abstract void DisplayProperties(PropertyDisplay displayer);

		public abstract void Resize(int col, int row);
	}
}
