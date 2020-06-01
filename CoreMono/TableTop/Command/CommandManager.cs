using CoreMono.TableTop.Grid;
using CoreMono.TableTop.Grid.Command;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Command
{
	public interface IMouseLayerCommand {
		void MouseDown(Map sender, MouseState e);
		void MouseHold(Map sender, MouseState e);
		void MouseUp(Map sender, MouseState e);
	}

	public class CommandManager
	{
		private MapDragCommand _dragMapCommand;

		private Dictionary<Type, IMouseLayerCommand> _mouseEvents = new Dictionary<Type, IMouseLayerCommand>();

		private Boolean _leftDown;
		private Boolean _middleDown;
		public double ZoomSensibility { get; set; } = 0.1;

		public CommandManager()
		{
			_dragMapCommand = new MapDragCommand();
			_mouseEvents.Add(typeof(GridLayer<bool>), new GridBooleanSwapDrawCmd());
		}

		public void MouseCommand(Map sender)
		{
			if (sender.LayerCount <= 0) { return; }

			MouseState e = Mouse.GetState();

			/* Override command : drag the map */
			if (e.MiddleButton == ButtonState.Pressed)
			{
				if (_middleDown)
				{
					_dragMapCommand.MouseHold(sender, e);
				}
				else
				{
					_dragMapCommand.MouseDown(sender, e);
				}
				_middleDown = true;
			}
			else
			{
				if (_middleDown == true)
				{
					_dragMapCommand.MouseUp(sender, e);
				}
				_middleDown = false;
			}

			/* Layer specific commands */
			if (_mouseEvents.TryGetValue(sender.GetActiveLayer<Layer>().GetType(), out IMouseLayerCommand command))
			{
				if (e.LeftButton == ButtonState.Pressed)
				{
					if (_leftDown)
					{
						command.MouseHold(sender, e);
					}
					else
					{
						command.MouseDown(sender, e);
					}
					_leftDown = true;
				}
				else
				{
					if (_leftDown == true)
					{
						command.MouseUp(sender, e);
					}
					_leftDown = false;
				}
			}
		}

		internal void WheelCommand(Map map, int mouseWheelChange)
		{
			map.MapScale.RelativeZoom += mouseWheelChange * ZoomSensibility;
		}
	}
}
