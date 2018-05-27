using CoreMono.GUI;
using CoreMono.Panels;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreMono.Map.Commands
{
	public interface IMapCommand
	{
		void MouseCommand(MapDrawer sender, MouseEventArg e);
	}
	/// <summary>
	/// A Mouse command implementing a hold left button behaviour.
	/// </summary>
	public abstract class MouseDrawCmd : IMapCommand
	{
		private bool _msDown;

		public void MouseCommand(MapDrawer sender, MouseEventArg e)
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

		public abstract void MouseDown(MapDrawer sender, MouseState ms);
		public abstract void MouseHold(MapDrawer sender, MouseState ms);
		public abstract void MouseUp(MapDrawer sender, MouseState ms);
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

		public sealed override void MouseDown(MapDrawer sender, MouseState ms)
		{
			int x, y;
			if (sender.GetSquareCoordinate(ms.Position, out x, out y))
			{
				MouseDown(sender, x, y);
				_prevX = x;
				_prevY = y;
			}
		}
		public sealed override void MouseHold(MapDrawer sender, MouseState ms)
		{
			int x, y;
			if (sender.GetSquareCoordinate(ms.Position, out x, out y) && CheckPrevCoordinates(x, y))
			{
				MouseHold(sender, x, y);
			}
		}
		public sealed override void MouseUp(MapDrawer sender, MouseState ms)
		{
			int x, y;
			if (sender.GetSquareCoordinate(ms.Position, out x, out y) && CheckPrevCoordinates(x, y))
			{
				MouseUp(sender, x, y);
			}
		}
		protected abstract void MouseDown(MapDrawer sender, int x, int y);
		protected abstract void MouseHold(MapDrawer sender, int x, int y);
		protected abstract void MouseUp(MapDrawer sender, int x, int y);
	}
}