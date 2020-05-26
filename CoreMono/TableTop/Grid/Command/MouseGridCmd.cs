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
	public abstract class MouseGridCmd : IMouseLayerCommand
	{
		private int _prevX = -1, _prevY = -1;

		private bool CheckPrevCoordinates(int x, int y)
		{
			bool ret = _prevX != x || _prevY != y;
			_prevY = y;
			_prevX = x;
			return ret;
		}

		public void MouseDown(TableMap sender, MouseState ms)
		{
			if (sender.GetActiveLayer<GridLayer>().GetCoordinate(ms.Position, out int x, out int y))
			{
				MouseDown(sender.GetActiveLayer<GridLayer>(), x, y);
				_prevX = x;
				_prevY = y;
			}
		}
		public void MouseHold(TableMap sender, MouseState ms)
		{
			if (sender.GetActiveLayer<GridLayer>().GetCoordinate(ms.Position, out int x, out int y) && CheckPrevCoordinates(x, y))
			{
				MouseHold(sender.GetActiveLayer<GridLayer>(), x, y);
			}
		}
		public void MouseUp(TableMap sender, MouseState ms)
		{
			if (sender.GetActiveLayer<GridLayer>().GetCoordinate(ms.Position, out int x, out int y) && CheckPrevCoordinates(x, y))
			{
				MouseUp(sender.GetActiveLayer<GridLayer>(), x, y);
			}
		}
		protected abstract void MouseDown(GridLayer sender, int x, int y);
		protected abstract void MouseHold(GridLayer sender, int x, int y);
		protected abstract void MouseUp(GridLayer sender, int x, int y);
	}
}
