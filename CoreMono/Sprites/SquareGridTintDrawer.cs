using CoreMono.Panels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreMono.Sprites
{
	/// <summary>
	/// Draw each square with the given tint color.
	/// </summary>
	public class SquareGridTintDrawer : ISquareDrawer
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

		public void Draw(SpriteBatch batch, MapDrawer lm, bool[,] map)
		{
			int sqrS = lm.SquareSize;
			batch.Begin();
			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					if (map[i, j])
					{
						batch.Draw(_pixel, new Rectangle(
							sqrS * i + lm.Parent.InternalDestRect.X,
							sqrS * j + lm.Parent.InternalDestRect.Y,
							sqrS, sqrS), Tint);
					}
				}
			}
			batch.End();
		}
	}
}
