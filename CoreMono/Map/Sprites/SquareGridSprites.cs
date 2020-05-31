using Core.Map.Grid;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.Map.Sprites
{
	/// <summary>
	/// Draw each square with the corresponding tile from the given texture.
	/// The texture is interpreted as a 2D array of texture squares.
	/// </summary>
	public class SquareGridSprites : ISquareDrawer<bool>
	{
		public int Column { get; }
		public int Row { get; }
		public Texture2D Sprite { get; }
		public Color Tint { get; set; }
		private int ch, cw;

		public SquareGridSprites(Texture2D sprite, int nbrRow, int nbrColumn)
		{
			Row = nbrRow;
			Column = nbrColumn;
			Sprite = sprite;
			Tint = Color.White;
			ch = Sprite.Height / Column;
			cw = Sprite.Width / Row;
		}

		public void Draw(SpriteBatch batch, MapDrawer lm, SquareGrid<bool> map)
		{
			int spriteWidth, spriteHeight;
			int squareSize = (int)lm.ScreenSquareSize;
			int offsetX = (int)lm.ScreenOffsetX;
			int offsetY = (int)lm.ScreenOffsetY;
			for (int i = 0; i < map.Column; i++)
			{
				spriteWidth = (i % Column) * cw;
				for (int j = 0; j < map.Row; j++)
				{
					if (map[i, j])
					{
						spriteHeight = (j % Row) * ch;
						batch.Draw(Sprite,
							new Rectangle(
								offsetX + squareSize * i,
								offsetY + squareSize * j,
								squareSize, squareSize),
							new Rectangle(spriteWidth, spriteHeight, cw, ch),
							Tint);
					}
				}
			}
		}
	}
}
