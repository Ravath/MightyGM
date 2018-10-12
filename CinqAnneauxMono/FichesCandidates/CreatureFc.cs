using CoreMono.UI;
using System.Linq;
using Core.Contexts;
using CinqAnneaux.Data;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using CinqAnneauxMono.Fiches;
using System.Collections.Generic;

namespace CinqAnneauxMono.FichesCandidates
{
	public class CreatureFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private DataList<FigurantModel> _listChara;
		private FicheFigurant _ficheChara;
		Panel _scroll;

		public CreatureFc() : base("Creature")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listChara = new DataList<FigurantModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_scroll = new Panel(new Vector2(ficheWidth, 0.0f), PanelSkin.None, Anchor.CenterRight, new Vector2(0.0f, -0.2f))
			{
				PanelOverflowBehavior = PanelOverflowBehavior.VerticalScroll
			};
			_ficheChara = new FicheFigurant(new Vector2(0.0f), Anchor.Auto);

			AddChild(_listChara);
			_scroll.AddChild(_ficheChara);
			AddChild(_scroll);

			_listChara.OnItemChanged += (DataList<FigurantModel> sender) => { _ficheChara.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_listChara.Data = context.UpperContext.Data.GetTable<FigurantModel>().OrderBy(t => t.Tag);
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_scroll.Size = new Vector2(ficheWidth, 0.0f);
			return ret;
		}

		private float ComputeFicheWidth(float destinationWidth)
		{
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;
			return (destinationWidth * actualScale) - 2 * leftpadding - listWidth;
		}
	}
}
