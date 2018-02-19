using Core.UI;
using StarWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.CaracterConstructor {
	public class ChoixRace : Step {

		SWCaracterBuild personnage;

		private ListeFiche<RaceModel> _listeRace;
		private bool isFirstLoad = true;

		public ChoixRace() {
			_listeRace = new ListeFiche<RaceModel>();
			_listeRace.Afficheur = new Fiche() { HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch };
			_listeRace.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
			Content = _listeRace;
        }

		public override bool CanProgress( out string errorMessage ) {
			personnage.Race = _listeRace.SelectedItem;
			if(personnage.Race == null) {
				errorMessage = "You must select a race.";
				return false;
			} else {
				errorMessage = "";
				return true;
			}
        }

		public override void GoBack() {
			personnage.Race = null;
		}

		public override void Init( IStepsArgument iargs ) {
            StarwarsPJConstructionArguments args = (StarwarsPJConstructionArguments)iargs;
            personnage = args.Personnage;
			if(isFirstLoad) {
				_listeRace.SetDataSource(args.Data.GetTable<RaceModel>());
				isFirstLoad = false;
            }
        }
	}
}
