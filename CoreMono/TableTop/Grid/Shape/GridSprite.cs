using CoreMono.TableTop.Grid;
using CoreMono.TableTop.Grid.Shape;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.Map.Sprites
{
	/// <summary>
	/// Draw each square with the corresponding tile from the given texture.
	/// The texture is interpreted as a 2D array of texture squares.
	/// </summary>
	public class GridSprite : IGridShape<bool>
	{
		/// <summary>
		/// Temporary File used for differing the loading of the Sprite
		/// </summary>
		private FileStream fileStream;

		private int _col, _row;

		public Texture2D Sprite { get; private set; }
		public int Column
		{
			get { return _col; }
			set { _col = value <= 0 ? 1 : value; }
		}
		public int Row
		{
			get { return _row; }
			set { _row = value <= 0 ? 1 : value; }
		}
		public Color Tint { get; set; }

		public GridSprite(Texture2D sprite, int nbrRow, int nbrColumn)
		{
			Row = nbrRow;
			Column = nbrColumn;
			Tint = Color.White;
			InitSprite(sprite);
		}

		public GridSprite(FileStream fileStream, int nbrRow, int nbrColumn)
		{
			Row = nbrRow;
			Column = nbrColumn;
			Tint = Color.White;
			this.fileStream = fileStream;
			Sprite = null;
		}

		private void InitSprite(Texture2D sprite)
		{
			Sprite = sprite;
		}

		public void Draw(SpriteBatch batch, GridLayer<bool> grid)
		{
			if (Sprite == null)
			{
				InitSprite(Texture2D.FromStream(batch.GraphicsDevice, fileStream));
				fileStream = null;
			}
			int ch = Sprite.Height / Row;
			int cw = Sprite.Width / Column;

			int spriteWidth, spriteHeight;
			int squareSize = (int)grid.MapScale.SquareSize;
			int offsetX = grid.MapScale.OffsetX;
			int offsetY = grid.MapScale.OffsetY;
			for (int i = 0; i < grid.Column; i++)
			{
				spriteWidth = (i % Column) * cw;
				for (int j = 0; j < grid.Row; j++)
				{
					if (grid.Grid[i, j])
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
