using CoreMono.TableTop.Graph.Shape;
using CoreMono.TableTop.Token;
using CoreMono.TableTop.Token.Shape;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Graph
{
	public class GraphLayer : Layer
	{
		public TokenLayer Nodes { get; private set; }
		public EdgeLayer Edges { get; private set; }

		public ITokenShape DefaultNodeShape { get; set; }
		public IEdgeShape DefaultEdgeShape{ get; set; }

		public GraphLayer(ITokenShape defaultNodeShape = null, IEdgeShape defaultEdgeShape = null,
			Vector2? size = null, Anchor anchor = Anchor.Center, Vector2? offset = null) : base(size, anchor, offset)
		{
			Nodes = new TokenLayer();
			Edges = new EdgeLayer();
			AddChild(Nodes);
			AddChild(Edges);
			DefaultNodeShape = defaultNodeShape;
			DefaultEdgeShape = defaultEdgeShape;
		}

		public void AddToken(Token.Token newToken)
		{
			if (newToken.Shape == null)
				newToken.Shape = DefaultNodeShape;
			Nodes.AddToken(newToken);
		}

		public Edge Bound(Token.Token a, Token.Token b, Object obj = null, IEdgeShape shape = null)
		{
			return Edges.Bound(a,b,shape ?? DefaultEdgeShape, obj);
		}
		
		public override void DisplayProperties(PropertyDisplay displayer)
		{
			Nodes.DisplayProperties(displayer);
			displayer.AddChild(new MgHeader("Default Edge"));
			displayer.AddObject(DefaultEdgeShape);
			displayer.AddChild(new MgHeader("Default Node"));
			displayer.AddObject(DefaultNodeShape);
		}

		public override void Resize(int col, int row)
		{
			/* Nothing to do */
		}
	}
}
