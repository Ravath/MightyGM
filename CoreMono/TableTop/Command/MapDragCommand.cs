using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace CoreMono.TableTop.Command
{
	public class MapDragCommand : IMouseLayerCommand
	{
		private int startX, startY;
		private Point startMouse;

		public void MouseDown(Map sender, MouseState e)
		{
			startX = sender.MapScale.RelativeOffsetX;
			startY = sender.MapScale.RelativeOffsetY;
			startMouse = e.Position;
		}

		public void MouseHold(Map sender, MouseState e)
		{
			Point diff = e.Position - startMouse;
			sender.MapScale.RelativeOffsetX = startX + diff.X;
			sender.MapScale.RelativeOffsetY = startY + diff.Y;
		}

		public void MouseUp(Map sender, MouseState e)
		{
			/* Nothing to do */
		}
	}
}
