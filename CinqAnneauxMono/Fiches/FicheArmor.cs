using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Objets;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Text;

namespace CinqAnneauxMono.Fiches
{
	public class FicheArmor : FicheModel<ArmureModel>
	{
		private Header _fName = new MgHeader();
		private Paragraph _fReduction = new MgProperty();
		private Paragraph _fND = new MgProperty();
		private Paragraph _fCost = new MgProperty();
		private MgDescription _fDescription = new MgDescription();
		private Paragraph _fSpecial = new MgTextInsert();

		public FicheArmor(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_fName);
			AddChild(_fReduction);
			AddChild(_fND);
			AddChild(_fCost);
			AddChild(_fDescription);
			AddChild(_fSpecial);
		}

		protected override void SetModel(ArmureModel model)
		{
			_fName.Text = model.Name;
			_fReduction.Text = String.Format("Reduction : {0}",model.Reduction);
			_fND.Text = String.Format("ND : {0}", model.BonusND);
			_fCost.Text = String.Format("Cout : {0} {1}", model.CoutUnit, model.CoutVal);
			_fDescription.Text = model.Description.Description;

			// Add Special Effects
			bool added = false;
			StringBuilder sb = new StringBuilder("\nSpecial");
			foreach (var item in model.Special)
			{
				added = true;
				var spe = SpecialImplementation.Instanciate(item);
				sb.AddItem(spe.Description);
			}
			if (added)
			{
				_fSpecial.Text = sb.ToString();
			}
			_fSpecial.Visible = added;
		}

		protected override void SetNoObject()
		{
			_fName.Text = "Armure";
			_fReduction.Text = "";
			_fND.Text = "";
			_fCost.Text = "";
			_fDescription.Text = "";
			_fSpecial.Visible = false;
		}
	}
}
