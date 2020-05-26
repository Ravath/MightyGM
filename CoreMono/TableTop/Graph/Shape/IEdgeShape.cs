using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace CoreMono.TableTop.Graph.Shape
{
	public interface IEdgeShape
	{
		void Draw(SpriteBatch spriteBatch, Edge edge);
	}
}
