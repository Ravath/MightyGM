using CoreMono.TableTop.Grid;
using CoreMono.TableTop.Grid.Shape;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreMono.Map.Sprites
{
	/// <summary>
	/// Draw the grid of the given grid.
	/// </summary>
	public class GridShape<T> : IGridShape<T>
	{
		public Color Tint { get; set; }
		public int Width { get; set; }

		public GridShape(Color tint, int width = 1)
		{
			Tint = tint;
			Width = width;
		}

		public void Draw(SpriteBatch batch, GridLayer<T> grid)
		{
			Texture2D _pixel = new Texture2D(batch.GraphicsDevice, 1, 1);
			_pixel.SetData<Color>(new Color[] { Color.White });

			int squareSize = (int) grid.MapScale.SquareSize;
			int offsetX = grid.MapScale.OffsetX;
			int offsetY = grid.MapScale.OffsetY;
			for (int i = 0; i <= grid.Column; i++)
			{
				BasicDraws.DrawLine(batch,
					new Vector2(
							offsetX + squareSize * i,
							offsetY),
					new Vector2(
							offsetX + squareSize * i,
							offsetY + squareSize * grid.Row),
					Width, Tint);
			}
			for (int j = 0; j <= grid.Row; j++)
			{
				BasicDraws.DrawLine(batch,
					new Vector2(
							offsetX,
							offsetY + squareSize * j),
					new Vector2(
							offsetX + squareSize * grid.Column,
							offsetY + squareSize * j),
					Width, Tint);
			}
		}
	}
}
