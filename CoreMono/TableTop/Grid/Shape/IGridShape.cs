﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Grid.Shape
{
	public enum GridShapeE
	{
		Tint, Sprite, ComputedSprite, Grid
	}

	public interface IGridShape<T>
	{
		void Draw(SpriteBatch batch, GridLayer<T> grid);
	}
}
