using CoreMono.UI;
using System.Linq;
using Core.Contexts;
using CinqAnneaux.Data;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using CinqAnneauxMono.Fiches;
using System.Collections.Generic;
using System.Text;

namespace CinqAnneauxMono.FichesCandidates
{
	public class StatusFc : AbsFicheCandidate
	{
		private SelectList[] tab = new SelectList[]
		{
			/*gloire     */new SelectList(Anchor.AutoCenter) { Size = new Vector2(0.9f, 0.9f)},
			/*infamie    */new SelectList(Anchor.AutoCenter) { Size = new Vector2(0.9f, 0.9f)},
			/*status     */new SelectList(Anchor.AutoCenter) { Size = new Vector2(0.9f, 0.9f)},
			/*gainGloire */new SelectList(Anchor.AutoCenter) { Size = new Vector2(0.9f, 0.9f)},
			/*gainHonneur*/new SelectList(Anchor.AutoCenter) { Size = new Vector2(0.9f, 0.9f)},
		};

		private string[] title = new string[]
		{
			"Gloire", "Infamie", "Statut", "Gain Gloire", "Gain Honneur"
		};

		public StatusFc() : base("Statut")
		{
			DropDown drop = new DropDown(new Vector2(0.9f, 0.1f), Anchor.TopCenter);
			drop.SelectList.Size = new Vector2(drop.SelectList.Size.X, 300);
			AddChild(drop);
			for (int i =0; i< tab.Length; i++)
			{
				AddChild(tab[i]);
				tab[i].Visible = false;
				tab[i].ItemsScale = 0.8f;
				drop.AddItem(title[i]);
			}
			drop.OnValueChange = (Entity e) =>
			{
				SetTabIndex(drop.SelectedIndex);
			};
			drop.SelectedIndex = 0;
		}

		public override void LoadData(IJdrContext context)
		{
			const string infoString = "{0,-50} {1,2}";
			const string gloireString = "{0,-20} {1}";
			const string honneurString = "{0,-85} {1,4} {2,4} {3,4} {4,4} {5,4} {6,4}";
			// lock and create title
			tab[0].AddItem("{{RED}}" + System.String.Format(infoString, "Gloire", "Rang"));
			tab[1].AddItem("{{RED}}" + System.String.Format(infoString, "Infamie", "Rang"));
			tab[2].AddItem("{{RED}}" + System.String.Format(infoString, "Statut", "Rang"));
			tab[3].AddItem("{{RED}}" + System.String.Format(gloireString, "Situation", "Description"));
			tab[4].AddItem("{{RED}}" + System.String.Format(honneurString, "Action", "1 ", "2-3", "4-5", "6-7", "8-9", "10"));

			tab[0].AddItem(context.UpperContext.Data.GetTable<GloireInfo>().OrderBy(t => t.Rang)
				.Select(info=> MgFont.Clean(string.Format(infoString, info.Description, info.Value))));
			tab[1].AddItem(context.UpperContext.Data.GetTable<InfamieInfo>().OrderBy(t => t.Rang)
				.Select(info => MgFont.Clean(string.Format(infoString, info.Description, info.Value))));
			tab[2].AddItem(context.UpperContext.Data.GetTable<StatutInfo>().OrderBy(t => t.Rang)
				.Select(info => MgFont.Clean(string.Format(infoString, info.Description, info.Value))));
			tab[3].AddItem(context.UpperContext.Data.GetTable<GainGloire>().OrderBy(t => t.Id)
				.Select(info => MgFont.Clean(string.Format(gloireString, info.Nom, info.Description))));
			tab[4].AddItem(context.UpperContext.Data.GetTable<HonneurInfo>().OrderBy(t => t.Id)
				.Select(info => MgFont.Clean(string.Format(honneurString, info.Description, info.Seuil1, info.Seuil2, info.Seuil3, info.Seuil4, info.Seuil5, info.Seuil6))));

			//Freeze header
			for (int i = 0; i < tab.Length; i++)
			{
				tab[i].LockedItems[0] = true;
			}
		}

		private int prevIndex = 0;
		public void SetTabIndex(int index)
		{
			tab[prevIndex].Visible = false;
			tab[index].Visible = true;
			prevIndex = index;
		}
	}
}
