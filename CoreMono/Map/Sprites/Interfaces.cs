using Core.Map.Grid;
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
	public interface I2DGridDrawer<T> : ISpriteDrawer
	{
		void Draw(SpriteBatch batch, MapDrawer layerMap, SquareGrid<T> map);
	}
	public interface ISquareDrawer<T> : I2DGridDrawer<T>
	{
	}
	public interface IHexaDrawer<T> : I2DGridDrawer<T>
	{
	}
}
