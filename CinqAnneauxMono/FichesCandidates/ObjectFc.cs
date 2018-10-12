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
	public class ObjectFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private DataList<ObjetModel> _listObject;
		private FicheObject _ficheObject;

		public ObjectFc() : base("Objet")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listObject = new DataList<ObjetModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0), TextSize = 0.8f };
			_ficheObject = new FicheObject(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listObject);
			AddChild(_ficheObject);

			_listObject.OnItemChanged += (DataList<ObjetModel> sender) => { _ficheObject.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_listObject.Data = context.UpperContext.Data.GetTable<ObjetModel>().OrderBy(t => t.Tag);
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheObject.Size = new Vector2(ficheWidth, 0.8f);
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
