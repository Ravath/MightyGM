using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.GUI
{
	public class GuiResizeEventArg
	{

	}

	public enum MouseBehaviour { MOUSE_GET_IN, MOUSE_IN, MOUSE_GET_OUT }
	public class GuiMouseEventArg
	{
		public MouseBehaviour Behaviour { get; set; }
		public MouseState State { get; set; }

		public GuiMouseEventArg(MouseBehaviour behaviour, MouseState state)
		{
			this.Behaviour = behaviour;
			this.State = state;
		}
	}
}
