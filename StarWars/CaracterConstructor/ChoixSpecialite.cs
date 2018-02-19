using Core.UI;
using StarWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.CaracterConstructor {
	public class ChoixSpecialite : Step {

		SWCaracterBuild personnage;

		private ListeFiche<SpecialiteModel> _listeSpecialite;

		public ChoixSpecialite() {
			_listeSpecialite = new ListeFiche<SpecialiteModel>();
			_listeSpecialite.Afficheur = new Fiche();
			Content = _listeSpecialite;
		}

		public override bool CanProgress( out string errorMessage ) {
			personnage.Specialite = _listeSpecialite.SelectedItem;
			if(personnage.Race == null) {
				errorMessage = "You must select a speciality.";
				return false;
			} else {
				errorMessage = "";
				return true;
			}
		}

		public override void GoBack() {
			personnage.Specialite = null;
		}

		public override void Init( IStepsArgument iargs ) {
			StarwarsPJConstructionArguments args = (StarwarsPJConstructionArguments)iargs;
			personnage = args.Personnage;
			_listeSpecialite.SetDataSource( personnage.Carriere.Specialites );
		}
	}
}
