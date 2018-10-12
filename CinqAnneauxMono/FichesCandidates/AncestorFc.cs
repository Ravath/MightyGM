using CoreMono.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contexts;
using CinqAnneaux.Data;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using CinqAnneauxMono.Fiches;

namespace CinqAnneauxMono.FichesCandidates
{
	public class AncestorFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private DataList<AncetreModel> _listAncestor;
		private FicheAncestor _ficheAncestor;

		public AncestorFc() : base("Ancetre")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listAncestor = new DataList<AncetreModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_ficheAncestor = new FicheAncestor(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listAncestor);
			AddChild(_ficheAncestor);

			_listAncestor.OnItemChanged += (DataList<AncetreModel> sender) => { _ficheAncestor.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_listAncestor.Data = context.UpperContext.Data.GetTable<AncetreModel>().OrderBy(t => t.Tag);
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheAncestor.Size = new Vector2(ficheWidth, 0.8f);
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
