using CoreMono.TableTop.Command;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Grid.Command
{
	/// <summary>
	/// A Mouse command implementing a hold left button behaviour, 
	/// but will call the templated functions only when changing Grid.
	/// </summary>
	public abstract class MouseGridCmd<T> : IMouseLayerCommand
	{
		private int _prevX = -1, _prevY = -1;

		private bool CheckPrevCoordinates(int x, int y)
		{
			bool ret = _prevX != x || _prevY != y;
			_prevY = y;
			_prevX = x;
			return ret;
		}

		public void MouseDown(Map sender, MouseState ms)
		{
			if (sender.GetActiveLayer<GridLayer<T>>().GetCoordinate(ms.Position, out int x, out int y))
			{
				MouseDown(sender.GetActiveLayer<GridLayer<T>>(), x, y);
				_prevX = x;
				_prevY = y;
			}
		}
		public void MouseHold(Map sender, MouseState ms)
		{
			if (sender.GetActiveLayer<GridLayer<T>>().GetCoordinate(ms.Position, out int x, out int y) && CheckPrevCoordinates(x, y))
			{
				MouseHold(sender.GetActiveLayer<GridLayer<T>>(), x, y);
			}
		}
		public void MouseUp(Map sender, MouseState ms)
		{
			if (sender.GetActiveLayer<GridLayer<T>>().GetCoordinate(ms.Position, out int x, out int y) && CheckPrevCoordinates(x, y))
			{
				MouseUp(sender.GetActiveLayer<GridLayer<T>>(), x, y);
			}
		}
		protected abstract void MouseDown(GridLayer<T> sender, int x, int y);
		protected abstract void MouseHold(GridLayer<T> sender, int x, int y);
		protected abstract void MouseUp(GridLayer<T> sender, int x, int y);
	}
}
