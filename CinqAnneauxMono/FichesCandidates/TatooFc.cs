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
	public class TatooFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private DataList<TatouageTogashiModel> _listTatoo;
		private FicheTatoo _ficheTatoo;

		public TatooFc() : base("Tatouage")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listTatoo = new DataList<TatouageTogashiModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_ficheTatoo = new FicheTatoo(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listTatoo);
			AddChild(_ficheTatoo);

			_listTatoo.OnItemChanged += (DataList<TatouageTogashiModel> sender) => { _ficheTatoo.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_listTatoo.Data = context.UpperContext.Data.GetTable<TatouageTogashiModel>().OrderBy(t => t.Tag);
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheTatoo.Size = new Vector2(ficheWidth, 0.8f);
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
