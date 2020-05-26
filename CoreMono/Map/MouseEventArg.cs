using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.Map
{
	public enum MouseBehaviour { MOUSE_GET_IN, MOUSE_IN, MOUSE_GET_OUT }

	public class MouseEventArg
	{
		public MouseBehaviour Behaviour { get; set; }
		public MouseState State { get; set; }

		public MouseEventArg(MouseBehaviour behaviour, MouseState state)
		{
			Behaviour = behaviour;
			State = state;
		}
	}
}
