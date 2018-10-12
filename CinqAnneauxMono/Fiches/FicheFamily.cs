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
	public class FicheFamily : FicheModel<FamilleModel>
	{
		private Header _familyName = new MgHeader();
		private Paragraph _familyAttribute = new MgProperty();
		private MgDescription _familyDescription = new MgDescription();

		public FicheFamily(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_familyName);
			AddChild(_familyAttribute);
			AddChild(_familyDescription);
		}

		protected override void SetModel(FamilleModel family)
		{
			_familyName.Text = family.Name;
			_familyAttribute.Text = family.BonusInitial.ToString();
			_familyDescription.Text = family.Description.Description;
		}

		protected override void SetNoObject()
		{
			_familyName.Text = "Famille";
			_familyAttribute.Text = "";
			_familyDescription.Value = "";
		}
	}
}
