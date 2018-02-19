using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TableTop.GUI;

namespace TableTop.Map.Commands
{
	public interface IMapCommand
	{
		void MouseCommand(LayerMap sender, GuiMouseEventArg e);
	}
	/// <summary>
	/// A Mouse command implementing a hold left button behaviour.
	/// </summary>
	public abstract class MouseDrawCmd : IMapCommand
	{
		private bool _msDown;

		public void MouseCommand(LayerMap sender, GuiMouseEventArg e)
		{
			if (e.State.LeftButton == ButtonState.Pressed)
			{
				if (_msDown)
				{
					MouseHold(sender, e.State);
				}
				else
				{
					MouseDown(sender, e.State);
				}
				_msDown = true;
			}
			else
			{
				if (_msDown == true)
				{
					MouseUp(sender, e.State);
				}
				_msDown = false;
			}
		}

		protected abstract void MouseDown(LayerMap sender, MouseState ms);
		protected abstract void MouseHold(LayerMap sender, MouseState ms);
		protected abstract void MouseUp(LayerMap sender, MouseState ms);
	}

	/// <summary>
	/// A Mouse command implementing a hold left button behaviour, 
	/// but will call the templated functions only when changing squareGrid.
	/// </summary>
	public abstract class MouseGridDrawCmd : MouseDrawCmd
	{
		private int _prevX = -1, _prevY = -1;

		private bool CheckPrevCoordinates(int x, int y)
		{
			bool ret = _prevX != x || _prevY != y;
			_prevY = y;
			_prevX = x;
			return ret;
		}

		protected sealed override void MouseDown(LayerMap sender, MouseState ms)
		{
			int x, y;
			if (sender.getSquareCoordinate(ms.Position, out x, out y))
			{
				MouseDown(sender, x, y);
				_prevX = x;
				_prevY = y;
			}
		}
		protected sealed override void MouseHold(LayerMap sender, MouseState ms)
		{
			int x, y;
			if (sender.getSquareCoordinate(ms.Position, out x, out y) && CheckPrevCoordinates(x, y))
			{
				MouseHold(sender, x, y);
			}
		}
		protected sealed override void MouseUp(LayerMap sender, MouseState ms)
		{
			int x, y;
			if (sender.getSquareCoordinate(ms.Position, out x, out y) && CheckPrevCoordinates(x, y))
			{
				MouseUp(sender, x, y);
			}
		}
		protected abstract void MouseDown(LayerMap sender, int x, int y);
		protected abstract void MouseHold(LayerMap sender, int x, int y);
		protected abstract void MouseUp(LayerMap sender, int x, int y);
	}
}