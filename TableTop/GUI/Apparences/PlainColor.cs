using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TableTop.GUI.Apparences
{
	/// <summary>
	/// Paint the background in the given color.
	/// </summary>
	public class PlainColor : IGuiApparence
	{
		public Color Tint { get; set; }

		public PlainColor(Color tint)
		{
			Tint = tint;
		}

		public void Draw(SpriteBatch batch, GuiElement e)
		{
			using (Texture2D pixel = new Texture2D(batch.GraphicsDevice, 1, 1))
			{
				batch.Begin();
				batch.Draw(pixel, e.Position, Tint);
				batch.End();
			}
		}
	}
}
