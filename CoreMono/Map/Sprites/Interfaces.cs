using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CoreMono.Map.Sprites
{
	public interface ISpriteDrawer
	{
	}
	public interface I2DGridDrawer : ISpriteDrawer
	{
		void Draw(SpriteBatch batch, MapDrawer layerMap, Boolean[,] map);
	}
	public interface ISquareDrawer : I2DGridDrawer
	{
	}
	public interface IHexaDrawer : I2DGridDrawer
	{
	}
}
