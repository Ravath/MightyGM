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
	public class HeroicOpportunityFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<OpportuniteHeroiqueModel> _opportunities;

		private DataList<OpportuniteHeroiqueModel> _listOpportunities;
		private FicheHeroicOpportunity _ficheOpportunity;

		public HeroicOpportunityFc() : base("Opportunite")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listOpportunities = new DataList<OpportuniteHeroiqueModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listOpportunities.TextSize = 0.8f;

			_ficheOpportunity = new FicheHeroicOpportunity(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listOpportunities);
			AddChild(_ficheOpportunity);

			_listOpportunities.OnItemChanged += (DataList<OpportuniteHeroiqueModel> sender) => { _ficheOpportunity.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_opportunities = context.UpperContext.Data.GetTable<OpportuniteHeroiqueModel>().OrderBy(t => t.Tag);
			_listOpportunities.Data = _opportunities;
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheOpportunity.Size = new Vector2(ficheWidth, 0.8f);
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
