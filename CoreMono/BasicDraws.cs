using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono
{
	public static class BasicDraws
	{
		public static void DrawLine(SpriteBatch batch, Vector2 start, Vector2 end, int width, Color color)
		{
			// Pixel Texture
			Texture2D _pixel = new Texture2D(batch.GraphicsDevice, 1, 1);
			_pixel.SetData<Color>(new Color[] { Color.White });

			// Compute edge
			Vector2 edge = end - start;

			// Compute angle to rotate line
			float angle = (float)Math.Atan2(edge.Y, edge.X);

			// Draw
			batch.Draw(_pixel,
				new Rectangle(
					(int)start.X, (int)start.Y, // Start of line
					(int)edge.Length(), //Lenght of line
					width), //width of line
				null,
				color,   //colour of line
				angle,  //angle of line (calulated above)
				new Vector2(0, 0.5f), // point in line about which to rotate
				SpriteEffects.None,
				0);
		}

		public static void DrawCircle(SpriteBatch batch, Vector2 center, int radius, Color color)
		{
			Texture2D circle = GetCircle(batch.GraphicsDevice);

			// Draw
			batch.Draw(circle,
				new Rectangle(
					(int)center.X - radius, (int)center.Y - radius,
					2 * radius, 2 * radius),
				null,
				color,	//colour of circle
				0,		//rotation
				Vector2.Zero, // point in Texture about which to rotate
				SpriteEffects.None,
				0);
		}

		public static void DrawEllipse(SpriteBatch batch, Rectangle bounds, Color color)
		{
			Texture2D circle = GetCircle(batch.GraphicsDevice);

			// Draw
			batch.Draw(circle,
				bounds,
				null,
				color,  //colour of circle
				0,      //rotation
				Vector2.Zero, // point in Texture about which to rotate
				SpriteEffects.None,
				0);
		}

		public static Texture2D _defaultCircleTexture;
		public static Texture2D GetCircle(GraphicsDevice graphicsDevice)
		{
			//TODO refresh if different Graphic device?
			if (_defaultCircleTexture == null)
			{
				_defaultCircleTexture = GenerateCircleTexture(graphicsDevice, 255, Color.White, 1f);
			}
			return  _defaultCircleTexture;
		}
		private static Texture2D GenerateCircleTexture(GraphicsDevice graphicsDevice, int radius, Color color, float sharpness)
		{
			int diameter = radius * 2;
			Texture2D circleTexture = new Texture2D(graphicsDevice, diameter, diameter, false, SurfaceFormat.Color);
			Color[] colorData = new Color[circleTexture.Width * circleTexture.Height];
			Vector2 center = new Vector2(radius);

			for (int colIndex = 0; colIndex < circleTexture.Width; colIndex++)
			{
				for (int rowIndex = 0; rowIndex < circleTexture.Height; rowIndex++)
				{
					Vector2 position = new Vector2(colIndex, rowIndex);
					float distance = Vector2.Distance(center, position);

					// hermite interpolation
					float x = distance / diameter;
					float edge0 = (radius * sharpness) / (float)diameter;
					float edge1 = radius / (float)diameter;
					float temp = MathHelper.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
					float result = temp * temp * (3.0f - 2.0f * temp);

					colorData[rowIndex * circleTexture.Width + colIndex] = color * (1f - result);
				}
			}
			circleTexture.SetData<Color>(colorData);

			return circleTexture;
		}
	}
}
