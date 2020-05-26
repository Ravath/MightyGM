using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CoreMono.TableTop.Graph.Shape
{
	public enum LineShapeE
	{
		Straight,
		HorizontalMid,
		VerticalMid

	}

	public class PlainLineShape : IEdgeShape
	{
		public LineShapeE Shape { get; set; }
		public int Width { get; set; }
		public Color Tint { get; set; }

		public void Draw(SpriteBatch spriteBatch, Edge edge)
		{
			switch(Shape)
			{
				case LineShapeE.Straight:
					DrawStraight(spriteBatch, edge);
					break;
				case LineShapeE.HorizontalMid:
					DrawHorizontalMid(spriteBatch, edge);
					break;
				case LineShapeE.VerticalMid:
					DrawVerticalMid(spriteBatch, edge);
					break;
				default:
					throw new NotImplementedException("Not implemented shape in PlainLineShape.Draw() : " + Shape.ToString());
			}
		}

		public void DrawStraight(SpriteBatch spriteBatch, Edge edge)
		{
			BasicDraws.DrawLine(spriteBatch,
				edge.TokenA.GetActualDestRect().Center.ToVector2(),
				edge.TokenB.GetActualDestRect().Center.ToVector2(),
				Width, Tint);

		}

		public void DrawVerticalMid(SpriteBatch spriteBatch, Edge edge)
		{
			Vector2 p1 = edge.TokenA.GetActualDestRect().Center.ToVector2();
			Vector2 p2 = edge.TokenB.GetActualDestRect().Center.ToVector2();
			Vector2 l = p2 - p1;
			int hw = Width / 2;
			if (l.Y > 0) { hw = -hw; }
			BasicDraws.DrawLine(spriteBatch,
				p1,
				new Vector2(p1.X + l.X/2, p1.Y),
				Width, Tint);
			BasicDraws.DrawLine(spriteBatch,
				new Vector2(p1.X + l.X / 2, p1.Y + hw),
				new Vector2(p2.X - l.X / 2, p2.Y - hw),
				Width, Tint);
			BasicDraws.DrawLine(spriteBatch,
				new Vector2(p2.X - l.X/2, p2.Y),
				p2,
				Width, Tint);
		}

		public void DrawHorizontalMid(SpriteBatch spriteBatch, Edge edge)
		{
			Vector2 p1 = edge.TokenA.GetActualDestRect().Center.ToVector2();
			Vector2 p2 = edge.TokenB.GetActualDestRect().Center.ToVector2();
			Vector2 l = p2 - p1;
			int hw = Width / 2;
			if(l.X>0) { hw = -hw; }
			BasicDraws.DrawLine(spriteBatch,
				p1,
				new Vector2(p1.X, p1.Y + l.Y / 2),
				Width, Tint);
			BasicDraws.DrawLine(spriteBatch,
				new Vector2(p1.X + hw, p1.Y + l.Y / 2),
				new Vector2(p2.X - hw, p2.Y - l.Y / 2),
				Width, Tint);
			BasicDraws.DrawLine(spriteBatch,
				new Vector2(p2.X, p2.Y - l.Y / 2),
				p2,
				Width, Tint);
		}
	}
}
