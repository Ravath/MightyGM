using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.Map
{
	public abstract class MapLayer
	{
		public abstract void Draw(SpriteBatch batch, MapDrawer lm);
	}
}
