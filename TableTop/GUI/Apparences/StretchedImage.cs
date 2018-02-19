using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.GUI.Apparences
{
	public class StretchedImage : IGuiApparence
	{
		public Color Tint { get; set; }
		public Texture2D Image { get; set; }

		public StretchedImage(Texture2D image) : this(image, Color.White){}

		public StretchedImage(Texture2D image, Color tint)
		{
			Tint = tint;
			Image = image;
		}

		public void Draw(SpriteBatch batch, GuiElement e)
		{
			batch.Begin();
			batch.Draw(Image, e.Position, Tint);
			batch.End();
		}
	}
}