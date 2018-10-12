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
	public class IntrigueFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<IntrigueModel> _intrigues;

		private DataList<IntrigueModel> _listIntrigues;
		private FicheIntrigue _ficheIntrigues;

		public IntrigueFc() : base("Intrigue")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listIntrigues = new DataList<IntrigueModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listIntrigues.TextSize = 0.8f;

			_ficheIntrigues = new FicheIntrigue(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listIntrigues);
			AddChild(_ficheIntrigues);

			_listIntrigues.OnItemChanged += (DataList<IntrigueModel> sender) => { _ficheIntrigues.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_intrigues = context.UpperContext.Data.GetTable<IntrigueModel>().OrderBy(t => t.Tag);
			_listIntrigues.Data = _intrigues;
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheIntrigues.Size = new Vector2(ficheWidth, 0.8f);
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
