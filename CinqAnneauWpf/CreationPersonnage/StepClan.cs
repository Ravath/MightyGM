using CinqAnneaux.Data;
using CinqAnneauxWpf.Fiches;
using CinqAnneaux.JdrCore.Ecoles;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CinqAnneaux.JdrCore.Agent;
using System.Windows.Media;

namespace CinqAnneauxWpf.CreationPersonnage {
	public class StepClan : Step {

		#region Members
		private ParametresCreationPJ _params;
		private FicheCandidateClanFamilleEcole fiche = new FicheCandidateClanFamilleEcole();
		#endregion

		#region Init
		public StepClan() {
			AddChild(fiche);
		}
		#endregion

		#region Steps Implementation
		public override bool CanProgress( out string errorMessage ) {
			bool error = false;
			errorMessage = "";
            if(fiche.SelectedClan== null) {
				errorMessage = "You must choose a Clan";
				error = true;
            }
			if(fiche.SelectedFamille == null) {
				errorMessage = "You must choose a Family";
				error = true;
			}
			if(fiche.SelectedEcole == null) {
				errorMessage = "You must choose a School";
				error = true;
			}
			if(!error) {
				InitNext(_params.Personnage);
			} 
			return !error;
		}

		private void InitNext( Personnage personnage ) {
			//clan
			personnage.Clan.SetModel(fiche.SelectedClan);
			//famille
			personnage.Famille.SetModel(fiche.SelectedFamille);
			personnage.Attributs.GetAttribut(personnage.Famille.BonusTrait).BaseValue++;
			//ecole
			Ecole e = new Ecole();
			e.SetModel(fiche.SelectedEcole);
			personnage.Ecoles.AddEcole(e,1);
			personnage.Attributs.GetAttribut(e.BonusTrait).BaseValue++;
			//TODO Compétences
			//TODO Equipement
			//TODO Argent
			// gloire, status et honneur
			personnage.Status.SetRank(1, 0);
			personnage.Gloire.SetRank(1, 0);
			personnage.Souillure.SetRank(0, 0);
			personnage.Honneur.SetRank(e.HonneurInitial);
		}

		public override void GoBack() {/* nothing */}

		public override void Init( IStepsArgument args ) {
			_params = (ParametresCreationPJ)args;
			//init attributs
			foreach(var item in _params.Personnage.Attributs.AllAttributs) {
				item.BaseValue = 2;
			}
			_params.Personnage.Attributs.MaxVide.BaseValue = 2;
			//set data
			fiche.SetData(_params.Data);
			//todo : filter with creation parameters (ronin, monk, minor clan,...)
		}
		#endregion
	}
}
