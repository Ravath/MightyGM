using CoreMono.TableTop.Grid;
using CoreMono.TableTop.Grid.Shape;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreMono.Map.Sprites
{
	/// <summary>
	/// Draw each square with the given tint color.
	/// </summary>
	public class GridTint : IGridShape
	{
		public Color Tint { get; set; }

		public GridTint(Color tint)
		{
			Tint = tint;
		}

		public void Draw(SpriteBatch batch, GridLayer grid)
		{
			Texture2D _pixel = new Texture2D(batch.GraphicsDevice, 1, 1);
			_pixel.SetData<Color>(new Color[] { Color.White });

			int sqrS = grid.SquareSize;
			for (int i = 0; i < grid.Map.GetLength(0); i++)
			{
				for (int j = 0; j < grid.Map.GetLength(1); j++)
				{
					if (grid.Map[i, j])
					{
						batch.Draw(_pixel, new Rectangle(
							sqrS * i + grid.InternalDestRect.X,
							sqrS * j + grid.InternalDestRect.Y,
							sqrS, sqrS), Tint);
					}
				}
			}
		}
	}
}
