using Core.Map.Grid;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreMono.Map.Sprites
{
	/// <summary>
	/// Draw each square with the given tint color.
	/// </summary>
	public class SquareGridTintDrawer : ISquareDrawer<bool>
	{
		public Color Tint { get; set; }
		public GraphicsDevice GraphicDevice
		{
			get { return _pixel.GraphicsDevice; }
		}
		private static Texture2D _pixel;

		public SquareGridTintDrawer(GraphicsDevice graphicDevice, Color tint)
		{
			this.Tint = tint;
			_pixel = new Texture2D(graphicDevice, 1, 1);
			_pixel.SetData<Color>(new Color[] { Color.White });
		}

		public void Draw(SpriteBatch batch, MapDrawer lm, SquareGrid<bool> map)
		{
			int squareSize = (int)lm.ScreenSquareSize;
			int offsetX = (int)lm.ScreenOffsetX;
			int offsetY = (int)lm.ScreenOffsetY;
			for (int i = 0; i < map.Column; i++)
			{
				for (int j = 0; j < map.Row; j++)
				{
					if (map[i, j])
					{
						batch.Draw(_pixel, new Rectangle(
							offsetX + squareSize * i,
							offsetY + squareSize * j,
							squareSize, squareSize), Tint);
					}
				}
			}
		}
	}
}
