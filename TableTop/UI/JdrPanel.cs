using CoreMono;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using MightyGmCtrl.Controleurs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class JdrPanel : Entity
	{
		private SelectList _jdrSelection = new SelectList();
		private IEnumerable<JdrAssembly> _assemblies;

		public JdrPanel()
		{
			AddChild(_jdrSelection);

			_assemblies = MainApplication.Controler.Contexts.JdrAssemblies;
			foreach (JdrAssembly jdr in _assemblies)
			{
				_jdrSelection.AddItem(jdr.Name);
			}

			_jdrSelection.OnValueChange = (Entity entity) =>
			{
				if(_jdrSelection.SelectedIndex < 0)
				{
					MainApplication.Controler.Contexts.SetJdrAssembly(null);
				}
				else
				{
					MainApplication.Controler.Contexts.SetJdrAssembly(_assemblies.ElementAt(_jdrSelection.SelectedIndex));
				}
			};

			//Grid test
			MgGrid gr = new MgGrid(
				new float[] { 0.2f, 0.3f, 0.3f, 0.2f },
				new float[] { 0.3f, 0.4f, 0.3f },
				new Vector2(500, 500));
			for (int i = 0; i < gr.GridHeight; i++)
			{
				for (int j = 0; j < gr.GridWidth; j++)
				{
					gr.AddEntity(j, i, new Panel(new Vector2(0.0f), anchor:Anchor.TopRight));
				}
			}
			AddChild(gr);
		}

		public int JdrCount { get { return _assemblies.Count(); } }
		public int JdrIndex {
			get { return _jdrSelection.SelectedIndex; }
			set { _jdrSelection.SelectedIndex = value; }
		}
	}
}
