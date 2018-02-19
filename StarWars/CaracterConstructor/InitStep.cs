using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UI;
using Core.Data.Schema;
using Core.Gestion;
using Core.Data;
using System.Windows.Controls;
using System.Windows;

namespace StarWars.CaracterConstructor {
	/// <summary>
	/// Les arguments de création d'un personnage de StarWars.
	/// </summary>
	public class StarwarsPJConstructionArguments : IStepsArgument {
		public StarwarsPJConstructionArguments( Database data ) {
			Data = data;
			NombreDeJoueur = 4;
			ArgentDepart = 500;
			XpBonus = 0;
		}
		public int NombreDeJoueur { get; set; }
		public bool UseHistorique { get; set; }
		public int XpBonus { get; set; }
		public int ArgentDepart { get; set; }
		public bool CanByForbiddenItems { get; set; }
		[HiddenProperty]
		public SWCaracterBuild Personnage { get; set; }
		[HiddenProperty]
		public Database Data { get; }
		
		public void Init() {
			Personnage = new SWCaracterBuild();
        }
	}
	/// <summary>
	/// La première étape de la création : Les paramètres de création, et le choix du joueur.
	/// </summary>
	public class InitStep : Step {

		private StarwarsPJConstructionArguments args;
		private Fiche agsF;
		private ListeFiche<Joueur> _listeJoueurs;

		private SWCaracterBuild personnage {
			get { return args.Personnage; }
		}

		public InitStep() {
			// * Interface * 
			//paramètres de création
			agsF = new Fiche() { ReadOnly = false };
			//liste des joueurs
			_listeJoueurs = new ListeFiche<Joueur>();
			_listeJoueurs.SelectionChanged += ( object sender, SelectionChangedEventArgs e ) => {
				personnage.Joueur = _listeJoueurs.SelectedItem;
			};
			_listeJoueurs.Afficheur = new Fiche();
			//stakPanel conteneur
			StackPanel sp = new StackPanel();
			sp.Children.Add(agsF);
			sp.Children.Add(_listeJoueurs);
			this.Content = sp;
		}

		public override bool CanProgress( out string message ) {
			message = "";
			if(args.NombreDeJoueur<0)
				args.NombreDeJoueur = 1;
			if(args.XpBonus < 0)
				args.XpBonus = 0;
			if(args.ArgentDepart < 0)
				args.ArgentDepart = 0;
			if(personnage.Joueur != null) {
				return true;
			}else {
				message = "Un joueur doit être sélectionné.";
				return false;
			}
		}

		public override void GoBack() {
			throw new NotImplementedException();
		}

		public override void Init( IStepsArgument iargs ) {
			this.args = (StarwarsPJConstructionArguments)iargs;
			agsF.SelectedObject = args;
			_listeJoueurs.SetDataSource(args.Data.GetTable<Joueur>());
		}
	}
}
