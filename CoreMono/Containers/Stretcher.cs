using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace CoreMono.GUI.Containers
{
	public class Stretcher : GuiSingleChildElement
	{
		public override void ManageChild()
		{
			Child?.Resize(Position.X, Position.Y, Position.Width, Position.Height);
		}
	}
}
