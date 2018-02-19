using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTop.GUI.Apparences;
using TableTop.Sprites;

namespace TableTop
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
			FrameApparence = new FrameSprite(Texture2D.FromStream(graphics.GraphicsDevice, File.Open(path+"FrameI.png", FileMode.Open)));
		}
		public Texture2D MouseSprite;
		public FrameSprite FrameApparence;
	}
}
