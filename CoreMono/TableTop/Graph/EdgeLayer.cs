using CoreMono.TableTop.Graph.Shape;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Graph
{
	public class EdgeLayer : Entity
	{
		private List<Edge> _edges = new List<Edge>();

		public EdgeLayer(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			
		}

		public Edge Bound(Token.Token a, Token.Token b, IEdgeShape shape = null, Object obj = null)
		{
			Edge ret = new Edge()
			{
				TokenA = a,
				TokenB = b,
				Shape = shape,
				Object = obj
			};
			_edges.Add(ret);
			return ret;
		}

		protected override void DrawEntity(SpriteBatch spriteBatch, DrawPhase phase)
		{
			if (phase == DrawPhase.Base)
			{
				foreach (Edge edge in _edges)
				{
					edge.Draw(spriteBatch);
				}
			}
		}
	}
}
