using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class PictGrid : Entity
	{
		private MgGrid grid;

		public int ObjWidth { get; set; }
		public int ObjHeight { get; set; }

		public PictGrid(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			ObjWidth = 5;
			ObjHeight = 5;
			grid = new MgGrid(ObjWidth, ObjHeight);

			AddChild(grid);

			Padding = Vector2.Zero;
		}

		public void SetPictures(Texture2D[] picts)
		{
			int idx = 0;
			foreach (Texture2D texture in picts)
			{
				if(idx >= ObjWidth*ObjHeight) { break; }

				Image img = new Image(texture, new Vector2(0f, 0.8f));
				MgParagraph name = new MgParagraph(texture.Name, size: new Vector2(0f, 0.8f))
				{
					WrapWords = true,
					BreakWordsIfMust = true,
					Scale = 0.8f
				};
				Entity e = new PanelBase(Vector2.Zero, PanelSkin.None)
				{
					Padding = Vector2.Zero
				};

				e.AddChild(img);
				e.AddChild(name);

				grid.AddEntity(idx % ObjWidth, idx / ObjWidth, e);

				idx++;
			}
		}
	}
}
