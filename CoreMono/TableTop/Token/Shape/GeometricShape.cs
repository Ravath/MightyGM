using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CoreMono.TableTop.Token.Shape
{
	public enum GeometricShapeE
	{
		SQUARE,
		CIRCLE
	}

	public class GeometricShape : ITokenShape
	{
		public GeometricShapeE Shape { get; set; }
		public int Width { get; set; }
		public Color BackgroundTint { get; set; }
		public Color WidthTint { get; set; }

		public GeometricShape()
		{

		}


		public void Draw(SpriteBatch batch, Token token)
		{
			switch (Shape)
			{
				case GeometricShapeE.SQUARE:
					DrawSquare(batch, token);
					break;
				case GeometricShapeE.CIRCLE:
					DrawCircle(batch, token);
					break;
				default:
					throw new NotImplementedException("Not implemented shape in GeometricShape.Draw() : " + Shape.ToString() );
			}
		}

		public void DrawSquare(SpriteBatch batch, Entity token)
		{
			// Pixel Texture
			Texture2D _pixel = new Texture2D(batch.GraphicsDevice, 1, 1);
			_pixel.SetData<Color>(new Color[] { Color.White });

			Rectangle bounds = token.GetActualDestRect();
			if (Width > 0)
			{
				// Draw borders
				batch.Draw(_pixel,
					bounds,
					null,
					WidthTint,   //colour of line
					0,  //angle of line (calulated above)
					Vector2.Zero, // point in line about which to rotate
					SpriteEffects.None,
					0);
			}

			bounds.X += Width;
			bounds.Y += Width;
			bounds.Width -= Width*2;
			bounds.Height -= Width*2;

			// Draw center
			batch.Draw(_pixel,
				bounds,
				null,
				BackgroundTint,   //colour of line
				0,  //angle of line (calulated above)
				Vector2.Zero, // point in line about which to rotate
				SpriteEffects.None,
				0);
		}

		public void DrawCircle(SpriteBatch batch, Entity token)
		{
			// Pixel Texture
			Texture2D _pixel = new Texture2D(batch.GraphicsDevice, 1, 1);
			_pixel.SetData<Color>(new Color[] { Color.White });

			Rectangle bounds = token.GetActualDestRect();
			if (Width > 0)
			{
				// Draw borders
				BasicDraws.DrawEllipse(batch, bounds, WidthTint);
			}

			bounds.X += Width/2;
			bounds.Y += Width/2;
			bounds.Width -= Width;
			bounds.Height -= Width;

			// Draw center
			BasicDraws.DrawEllipse(batch, bounds, BackgroundTint);
		}
	}
}
