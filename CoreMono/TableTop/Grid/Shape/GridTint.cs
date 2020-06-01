using CoreMono.TableTop.Grid;
using CoreMono.TableTop.Grid.Shape;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreMono.Map.Sprites
{
	/// <summary>
	/// Draw each square with the given tint color.
	/// </summary>
	public class GridTint : IGridShape<bool>
	{
		public Color Tint { get; set; }

		public GridTint(Color tint)
		{
			Tint = tint;
		}

		public void Draw(SpriteBatch batch, GridLayer<bool> grid)
		{
			Texture2D _pixel = new Texture2D(batch.GraphicsDevice, 1, 1);
			_pixel.SetData<Color>(new Color[] { Color.White });

			int squareSize = (int) grid.MapScale.SquareSize;
			int offsetX = grid.MapScale.OffsetX;
			int offsetY = grid.MapScale.OffsetY;
			for (int i = 0; i < grid.Column; i++)
			{
				for (int j = 0; j < grid.Row; j++)
				{
					if (grid.Grid[i, j])
					{
						batch.Draw(_pixel, new Rectangle(
								offsetX + squareSize * i,
								offsetY + squareSize * j,
								squareSize, squareSize),
								Tint);
					}
				}
			}
		}
	}
}
