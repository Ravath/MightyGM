using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Objets;
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
	public class FicheWeapon : FicheModel<ArmeModel>
	{
		private Header _fName = new MgHeader();
		private Paragraph _fSize = new MgProperty();
		private Paragraph _fDamage = new MgProperty();
		private Paragraph _fCost = new MgProperty();
		private Paragraph _fKeyWords = new MgTextInsert();
		private MgDescription _fDescription = new MgDescription();
		private Paragraph _fSpecial = new MgTextInsert();

		public FicheWeapon(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_fName);
			AddChild(_fSize);
			AddChild(_fDamage);
			AddChild(_fCost);
			AddChild(_fKeyWords);
			AddChild(_fDescription);
			AddChild(_fSpecial);
		}

		protected override void SetModel(ArmeModel model)
		{
			_fName.Text = model.Name;
			_fSize.Text = model.Taille.ToString();
			_fDamage.Text = String.Format("Degats : {0}g{1}", model.RollVD, model.KeepVD);
			_fCost.Text = String.Format("Cout : {0} {1}" ,model.CoutVal, model.CoutUnit);
			
			SetKeyWords(model);
			SetSpecial(model);

			_fDescription.Text = model.Description.Description;
		}

		protected override void SetNoObject()
		{
			_fName.Text = "Arme";
			_fSize.Text = "";
			_fDamage.Text = "";
			_fCost.Text = "";
			_fKeyWords.Visible = false;
			_fDescription.Text = "";
			_fSpecial.Visible = false;
		}

		private void SetKeyWords(ArmeModel weapon)
		{
			StringBuilder sb = new StringBuilder("Mots-Clefs");
			bool added = false;

			if (weapon.Samurai)
			{
				added = true;
				sb.AddItem("Samurai");
			}

			if(weapon.Paysan)
			{
				added = true;
				sb.AddItem("Paysan");
			}

			if (added)
			{
				_fKeyWords.Text = sb.ToString();
			}
			_fKeyWords.Visible = added;
		}

		private void SetSpecial(ArmeModel weapon)
		{
			StringBuilder sb = new StringBuilder("\nSpecial");
			bool added = false;

			foreach (SpecialObjetExemplar item in weapon.Special)
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
	}
}
