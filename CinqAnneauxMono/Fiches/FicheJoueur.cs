using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneauxMono.Fiches
{
	public class FicheJoueur : FicheAgent<PersonnageJoueurModel, Personnage>
	{
		public FicheJoueur(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
		}

		protected override void SetModel(PersonnageJoueurModel model)
		{
			_character.SetPersonnage(model);
			base.SetModel(model);
		}

		protected override void SetNoObject()
		{
			base.SetNoObject();
			_character.SetPersonnage((PersonnageJoueurModel)null);
		}
	}
}
