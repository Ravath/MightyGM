using CinqAnneaux.Data;
using CinqAnneauxMono.Fiches;
using Core.Contexts;
using CoreMono.UI;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System.Linq;

namespace CinqAnneauxMono.FichesCandidates
{
	public class AdvantageFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private DataList<AvantageModel> _listAdvantage;
		private DataList<DesavantageModel> _listeDesadvantage;

		private FicheAdvantage _ficheAdvantage;
		private FicheAdvantage _ficheDesadvantage;

		public AdvantageFc() : base("Avantage")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listAdvantage = new DataList<AvantageModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0), TextSize = 0.8f };
			_listeDesadvantage = new DataList<DesavantageModel>(new Vector2(listWidth, 0.8f), Anchor.AutoInline) { Padding = new Vector2(0), TextSize = 0.8f };

			_ficheAdvantage = new FicheAdvantage(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);
			_ficheDesadvantage = new FicheAdvantage(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listAdvantage);
			AddChild(_ficheAdvantage);
			AddChild(_listeDesadvantage);
			AddChild(_ficheDesadvantage);

			_listAdvantage.OnItemChanged += (DataList<AvantageModel> sender) => { _ficheAdvantage.SetDisplayedModel(sender.SelectedItem); };
			_listeDesadvantage.OnItemChanged += (DataList<DesavantageModel> sender) => { _ficheDesadvantage.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_listAdvantage.Data = context.UpperContext.Data.GetTable<AvantageModel>().OrderBy(t => t.Tag);
			_listeDesadvantage.Data = context.UpperContext.Data.GetTable<DesavantageModel>().OrderBy(t => t.Tag);
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheAdvantage.Size = new Vector2(ficheWidth, 0.8f);
			_ficheDesadvantage.Size = new Vector2(ficheWidth, 0.8f);
			return ret;
		}

		private float ComputeFicheWidth(float destinationWidth)
		{
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;
			return ((destinationWidth * actualScale) - 2 * (listWidth + leftpadding)) / 2;
		}
	}
}
