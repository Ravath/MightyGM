﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.GUI
{
	public interface IGuiApparence
	{
		void Draw(SpriteBatch batch, GuiElement e);
	}
}
