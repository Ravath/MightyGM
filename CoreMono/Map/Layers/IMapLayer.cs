using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.Map.Layers
{
	public interface IMapLayer
	{
		void Draw(SpriteBatch batch, MapDrawer lm);
		void Resize(int col, int row, int squareSize);
	}
}
