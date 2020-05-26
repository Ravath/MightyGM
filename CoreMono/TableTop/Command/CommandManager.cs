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
		void MouseDown(TableMap sender, MouseState e);
		void MouseHold(TableMap sender, MouseState e);
		void MouseUp(TableMap sender, MouseState e);
	}

	public class CommandManager
	{
		private Dictionary<Type, IMouseLayerCommand> _mouseEvents = new Dictionary<Type, IMouseLayerCommand>();

		public CommandManager()
		{
			_mouseEvents.Add(typeof(GridLayer), new GridDrawCmd());
		}

		private Boolean _msDown;
		public void MouseCommand(TableMap sender)
		{
			if (sender.LayerCount <= 0) { return; }

			MouseState e = Mouse.GetState();
			if (_mouseEvents.TryGetValue(sender.GetActiveLayer<TableLayer>().GetType(), out IMouseLayerCommand command))
			{
				if (e.LeftButton == ButtonState.Pressed)
				{
					if (_msDown)
					{
						command.MouseHold(sender, e);
					}
					else
					{
						command.MouseDown(sender, e);
					}
					_msDown = true;
				}
				else
				{
					if (_msDown == true)
					{
						command.MouseUp(sender, e);
					}
					_msDown = false;
				}
			}
		}
	}
}
