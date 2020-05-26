using Core.Data;
using CoreMono;
using GeonBit.UI.Entities;
using GeonBit.UI.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MightyGmCtrl.Controleurs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class OptionPanel : Entity
	{
		private DropDown _mmDevices;

		public OptionPanel()
		{
			const int lineHeight = 50;

			//Add Audio Output device Selection
			_mmDevices = new DropDown(new Vector2(0.8f, 0.5f), Anchor.AutoInline);
			_mmDevices.SelectedTextPanel.Size = new Vector2(_mmDevices.SelectedTextPanel.Size.X, lineHeight);
			_mmDevices.SelectList.Offset = new Vector2(_mmDevices.SelectList.Offset.X, lineHeight);
			UpdateMMList();

			AddChild(new LineSpace(0));
			Panel center = new Panel(new Vector2(0.1f, lineHeight), PanelSkin.None, Anchor.AutoInline) { Padding = Vector2.Zero };
			center.AddChild(new Label("Audio Device : ", Anchor.CenterLeft, new Vector2(0)));
			AddChild(center);
			AddChild(_mmDevices);


			//TODO other options
			AddChild(new LineSpace(0));
			AddChild(new Label("Machin de test", Anchor.AutoInline));


			// ADD EVENTS
			_mmDevices.OnValueChange = (Entity e) =>
			{
				MainApplication.Controler.Audio.SelectedDeviceIndex = Math.Abs( _mmDevices.SelectedIndex );
			};
		}

		private void UpdateMMList()
		{
			_mmDevices.ClearItems();
			foreach (var item in MainApplication.Controler.Audio.MMDevices)
			{
				_mmDevices.AddItem(item.FriendlyName);
			}
			_mmDevices.SelectedIndex = 0;
		}
	}
}
