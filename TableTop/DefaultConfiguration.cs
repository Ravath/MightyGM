﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace CoreMono
{
	public class DefaultConfiguration
	{
		public DefaultConfiguration(GraphicsDeviceManager graphics, string path)
		{
			if (!path.EndsWith("\\"))
			{
				path += "\\";
			}
			MouseSprite = Texture2D.FromStream(graphics.GraphicsDevice, File.Open(path+"DefaultCursor.png", FileMode.Open));
		}
		public Texture2D MouseSprite;
	}
}
