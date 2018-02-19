using Core.Gestion;
using CoreWpf.UI;
using Shadowrun5.JdrCore;
using Shadowrun5.JdrCore.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Shadowrun5Wpf.CreationPersonnage {
	/// <summary>
	/// Etape de sélection du joueur, et des options de création.
	/// </summary>
	public class InitStep : Step {

		private ParametresCreationPJ _args;
		private ListeFiche<Joueur> _listeJoueurs;
		private Fiche _fiche; //Fiche d'affichage des options
		/// <summary>
		/// Le Personnage à créer
		/// </summary>
		private Personnage personnage {
			get { return _args.Personnage; }
		}
		/// <summary>
		/// Une liste des joueurs et des options de création.
		/// </summary>
		public InitStep() {
			// * Interface * 
			//paramètres de création
			_fiche = new Fiche() { ReadOnly = false };
			//liste des joueurs
			_listeJoueurs = new ListeFiche<Joueur>();
			_listeJoueurs.SelectionChanged += ( object sender, SelectionChangedEventArgs e ) => {
				personnage.Joueur = _listeJoueurs.SelectedItem;
			};
			_listeJoueurs.Afficheur = new Fiche();
			//stakPanel conteneur
			StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
			sp.Children.Add(_listeJoueurs);
			sp.Children.Add(_fiche);
			this.Content = sp;
		}
		/// <summary>
		/// Vérifie qu'un joueur ait bien été choisit pour le personnage.
		/// </summary>
		/// <param name="errorMessage">Un message d'erreur en cas de problème.</param>
		/// <returns>True si tout va bien.</returns>
		public override bool CanProgress( out string errorMessage ) {
			errorMessage = "";
            if(personnage.Joueur != null) {
				return true;
			} else {
				errorMessage = "Un joueur doit être sélectionné.";
				return false;
			}
		}
		/// <summary>
		/// Not implemented. Première étape, donc on ne peut pas revenir en arrière.
		/// </summary>
		public override void GoBack() {
			throw new NotImplementedException();
		}

		public override void Init( IStepsArgument args ) {
			this._args = (ParametresCreationPJ)args;
			_fiche.SelectedObject = args;
			_listeJoueurs.SetDataSource(_args.Data.GetTable<Joueur>());
		}
	}
}
