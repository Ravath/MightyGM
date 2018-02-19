using Core.Engine;
using Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.CaracterConstructor {
	public class EditionEtatCivil : Step {

		private StarwarsPJConstructionArguments _args;
		private Fiche _fiche;

		public EditionEtatCivil() {
			_fiche = new Fiche();
			_fiche.ReadOnly = false;
			Content = _fiche;
        }

		public override bool CanProgress( out string errorMessage ) {
			if(string.IsNullOrWhiteSpace(_args.Personnage.EtatCivil.Name)) {
				errorMessage = "Name is compulsory.";
				return false;
			}
			if(_args.Personnage.EtatCivil.Name.Length>40) {
				errorMessage = "Name must be less than 40 caracters.";
				return false;
			}
			errorMessage = defaultErrorMessage;
            return true;
		}

		public override void GoBack() { /* nothing */}

		public override void Init( IStepsArgument args ) {
			_args = args as StarwarsPJConstructionArguments;
			_fiche.SelectedObject = _args.Personnage.EtatCivil;
        }
	}
}
