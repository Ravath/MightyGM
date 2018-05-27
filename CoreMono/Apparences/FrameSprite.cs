using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreMono.GUI;
using Microsoft.Xna.Framework.Graphics;

namespace CoreMono.GUI.Apparences
{
	/// <summary>
	/// Draw a bakground grame using a stretched Frame Texture.
	/// </summary>
	public class FrameSprite : IGuiApparence
	{
		private double _borderPercentage;

		#region Properties
		/// <summary>
		/// The width percentage used for the border, relative to the whole used texture.
		/// </summary>
		public double BorderPercentage
		{
			get { return _borderPercentage; }
			set
			{
				if (value < 0)
				{
					_borderPercentage = 0;
				}
				else if (value > 1)
				{
					_borderPercentage = 1;
				}
				else
				{
					_borderPercentage = value;
				}
			}
		}
		public Color TintColor { get; set; }
		public Texture2D Sprite { get; set; }
		#endregion

		#region Init
		public FrameSprite(Texture2D sprite, double borderPercetage = 0.33)
		{
			BorderPercentage = borderPercetage;
			Sprite = sprite;
			TintColor = Color.White;
		} 
		#endregion

		public void Draw(SpriteBatch batch, GuiElement e)
		{
			int spOffx = (int)(Sprite.Width * BorderPercentage);
			int spOffy = (int)(Sprite.Height * BorderPercentage);
			Rectangle dest = e.Position;
			int spCW = Sprite.Width - 2 * spOffx;
			int spCH = Sprite.Height - 2 * spOffy;
			int destCW = dest.Width - 2 * spOffx;
			int destCH = dest.Height - 2 * spOffy;
			batch.Begin();
			//Corners
			//	up left
			batch.Draw(Sprite, 
				new Rectangle(dest.Left, dest.Top, spOffx, spOffy),
				new Rectangle(0, 0, spOffx, spOffy),
				TintColor);
			//	up right
			batch.Draw(Sprite,
				new Rectangle(dest.Right - spOffx, dest.Top, spOffx, spOffy),
				new Rectangle(Sprite.Width - spOffx, 0, spOffx, spOffy),
				TintColor);
			//	down left
			batch.Draw(Sprite,
				new Rectangle(dest.Left, dest.Bottom - spOffy, spOffx, spOffy),
				new Rectangle(0, Sprite.Height - spOffy, spOffx, spOffy),
				TintColor);
			//	down right
			batch.Draw(Sprite,
				new Rectangle(dest.Right - spOffx, dest.Bottom - spOffy, spOffx, spOffy),
				new Rectangle(Sprite.Width - spOffx, Sprite.Height - spOffy, spOffx, spOffy),
				TintColor);
			//Edges
			//	top
			batch.Draw(Sprite,
				new Rectangle(dest.Left + spOffx, dest.Top, destCW, spOffy),
				new Rectangle(spOffx, 0, spCW, spOffy),
				TintColor);
			//	down
			batch.Draw(Sprite,
				new Rectangle(dest.Left + spOffx, dest.Bottom - spOffy, destCW, spOffy),
				new Rectangle(spOffx, Sprite.Height - spOffy, spCW, spOffy),
				TintColor);
			//	left
			batch.Draw(Sprite,
				new Rectangle(dest.Left, dest.Top + spOffy, spOffx, destCH),
				new Rectangle(0, spOffy, spOffx, spCH),
				TintColor);
			//	right
			batch.Draw(Sprite,
				new Rectangle(dest.Right - spOffx, dest.Top + spOffy, spOffx, destCH),
				new Rectangle(Sprite.Width - spOffx, spOffy, spOffx, spCH),
				TintColor);
			//Center
			batch.Draw(Sprite,
				new Rectangle(dest.Left + spOffx, dest.Top + spOffy, destCW, destCH),
				new Rectangle(spOffx, spOffx, spCW, spCH),
				TintColor);
			batch.End();
		}
	}
}
