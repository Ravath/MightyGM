using CinqAnneaux.Data;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneauxMono.Fiches
{
	public class FicheAdvantage<D> : FicheModel<D> where D : AbsAvantageModel
	{
		private Header _fName = new MgHeader();
		private Paragraph _fCost = new MgProperty();
		private Paragraph _fRgMax = new MgProperty();
		private MgDescription _fDescription = new MgDescription();
		private MgDescription _fGroupeDescription = new MgDescription();

		public FicheAdvantage(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_fName);
			AddChild(_fCost);
			AddChild(_fRgMax);
			AddChild(_fGroupeDescription);
			AddChild(_fDescription);
		}

		protected override void SetModel(D model)
		{
			_fName.Text = String.Format("{0} [{1}]",model.Name, model.SousType);
			_fCost.Text = String.Format("Cout : {0} points", model.Cout);
			_fRgMax.Visible = model.RangMax > 1;
			_fRgMax.Text = String.Format("Rang Max : {0}", model.RangMax);
			_fDescription.Text = model.Description.Description;
			_fGroupeDescription.Visible = model.Groupe != null;
			if (model.Groupe != null)
			{
				_fGroupeDescription.Text = model.Groupe.Description.Description;
			}
		}

		protected override void SetNoObject()
		{
			_fName.Text = "Avantage";
			_fCost.Text = "";
			_fCost.Text = "";
			_fGroupeDescription.Text = "";
			_fDescription.Text = "";
		}
	}
}
