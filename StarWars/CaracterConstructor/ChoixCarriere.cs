using Core.UI;
using StarWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.CaracterConstructor {
	public class ChoixCarriere : Step {

		SWCaracterBuild personnage;

		private ListeFiche<CarriereModel> _listeCarriere;
		private bool isFirstLoad = true;

		public ChoixCarriere() {
			_listeCarriere = new ListeFiche<CarriereModel>();
			_listeCarriere.Afficheur = new Fiche();
			Content = _listeCarriere;
		}

		public override bool CanProgress( out string errorMessage ) {
			personnage.Carriere = _listeCarriere.SelectedItem;
			if(personnage.Race == null) {
				errorMessage = "You must select a carriere.";
				return false;
			} else {
				errorMessage = "";
				return true;
			}
		}

		public override void GoBack() {
			personnage.Carriere = null;
		}

		public override void Init( IStepsArgument iargs ) {
			StarwarsPJConstructionArguments args = (StarwarsPJConstructionArguments)iargs;
			personnage = args.Personnage;
			if(isFirstLoad) {
				_listeCarriere.SetDataSource(args.Data.GetTable<CarriereModel>());
				isFirstLoad = false;
			}
		}
	}
}
