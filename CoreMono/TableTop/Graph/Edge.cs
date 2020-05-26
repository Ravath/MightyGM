using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using CoreMono.TableTop.Token;
using CoreMono.TableTop.Graph.Shape;

namespace CoreMono.TableTop.Graph
{
	public class Edge
	{
		public Object Object { get; set; }

		public Token.Token TokenA { get; set; }
		public Token.Token TokenB { get; set; }

		public IEdgeShape Shape { get; set; }

		internal void Draw(SpriteBatch spriteBatch)
		{
			Shape?.Draw(spriteBatch, this);
		}
	}
}
