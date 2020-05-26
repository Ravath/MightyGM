using Core.Contexts;
using CoreMono;
using CoreMono.UI;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class FichePanel : Entity
	{
		private IJdrContextMono uiContext;
		private IJdrContext jdrContext;
		private SelectList listFiches;
		private bool[] lazyload;
		private Panel fichePanel;

		public FichePanel() : base(new Vector2(0f))
		{
			MainApplication.Controler.Contexts.JdrChanged += Contexts_JdrChanged;

			Offset = Vector2.Zero;
			Padding = Vector2.Zero;

			MgSplitEntity split = new MgSplitEntity (new Vector2(0f))
			{
				MinLeftWidth = 200,
				MaxLeftWidth = 300,
				LeftWidth = 0.1f,
				LeftPanel = listFiches = new SelectList(Anchor.Center) { Size = new Vector2(0f) },
				RightPanel = fichePanel = new Panel(new Vector2(0f)) { Padding = new Vector2(0f) }
			};

			listFiches.OnValueChange = (Entity e) =>
			{
				fichePanel.ClearChildren();
				int index = listFiches.SelectedIndex;
				if (index >= 0)
				{
					AbsFicheCandidate selFiche = uiContext.Fiches.ElementAt(index);
					fichePanel.AddChild(selFiche);
					if (!lazyload[index])
					{
						selFiche.LoadData(jdrContext);
						lazyload[index] = true;
					}
				};
			};

			AddChild(split);

		}

		private void Contexts_JdrChanged(IJdrContext newJdrContext, IJdrContextUI newJdrUiContext)
		{
			jdrContext = newJdrContext;
			uiContext = newJdrUiContext as IJdrContextMono;
			listFiches.ClearItems();
			lazyload = new bool[uiContext.Fiches.Count()];
			listFiches.AddItem(uiContext.Fiches.Select(item=>item.Name));
		}
	}
}
