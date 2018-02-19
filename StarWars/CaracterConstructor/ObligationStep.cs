using Core.Data;
using Core.Dice;
using Core.UI;
using StarWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StarWars.CaracterConstructor {
	public class ObligationStep : Step {

		private StarwarsPJConstructionArguments args;

		private IEnumerable<ObligationsModel> _obligations;

		private List<ObligationsModel> _selectedObligations = new List<ObligationsModel>();
		private ListeFiche<ObligationsModel> obligationFiche;

		private TextBlock obligationDeBase;
        private RadioButton rbn	;
        private RadioButton rbx1;
        private RadioButton rbx2;
        private RadioButton rbc1;
		private RadioButton rbc2;

		#region Init
		public ObligationStep() {
			obligationDeBase = new TextBlock();
			//radiobuttons
			rbn = new RadioButton() { Content = "Nothing" };//+0 obligation
			rbx1 = new RadioButton() { Content = "+5xp : +5 obligation" };  //+5 obligation
			rbx2 = new RadioButton() { Content = "+10xp : +10 obligation" };    //+10 obligation
			rbc1 = new RadioButton() { Content = "+1000Credits : +5 obligation" };//+5 obligation
			rbc2 = new RadioButton() { Content = "+2500Credits : +10 obligation" };//+10 obligation
			rbn.IsChecked = true;
			//obligations
			obligationFiche = new ListeFiche<ObligationsModel>();
			obligationFiche.Afficheur = new Fiche();
			obligationFiche.SelectionChanged += ( object sender, SelectionChangedEventArgs e ) => {
				if(obligationFiche.SelectedItems.Count() <= 0)
					return;
				else if (obligationFiche.SelectedItems.Count() == 1) {
					SetSelectedObligations(obligationFiche.SelectedItem, null);
				} else {
					SetSelectedObligations(
						obligationFiche.SelectedItem,
						obligationFiche.SelectedItems.ElementAt(1));
				}
			};
			//conteneur
			StackPanel sp = new StackPanel();
			sp.Children.Add(obligationDeBase);
			sp.Children.Add(rbn);
			sp.Children.Add(rbx1);
			sp.Children.Add(rbx2);
			sp.Children.Add(rbc1);
			sp.Children.Add(rbc2);
			sp.Children.Add(obligationFiche);
			this.Content = sp;
		}

		public override void Init( IStepsArgument iargs ) {
			args = (StarwarsPJConstructionArguments)iargs;
			obligationDeBase.Text = string.Format("Nombre de joueurs : {0} obligation de base : {1}",
				args.NombreDeJoueur, ObligationDeDepart(args.NombreDeJoueur));
			_obligations = args.Data.GetTable<ObligationsModel>();
            obligationFiche.SetDataSource(_obligations);
		}
		#endregion

		public override bool CanProgress( out string message ) {
			if(_selectedObligations.Count() == 0) {
				message = "Vous devez choisir une obligation";
				return false;
			} else
				message = "";
			InitPersoVals();
			//calcul valeur obligation
			int obVal = ObligationDeDepart(args.NombreDeJoueur);
			if(!(bool)rbn.IsChecked) {
				if((bool)rbc1.IsChecked || (bool)rbx1.IsChecked) {
					obVal += 5;
				} else
					obVal += 10;
			}
			//assigner obligation
			ObligationsExemplar oe = new ObligationsExemplar() {
				Valeur = obVal,
				Model = _selectedObligations.ElementAt(0)
			};
			ObligationsExemplar oe2 = null;
			if(_selectedObligations.Count() != 1) {
				oe2 = new ObligationsExemplar() {
					Valeur = obVal / 2,
					Model = _selectedObligations.ElementAt(1)
				};
				oe.Valeur /= 2;
				if(obVal % 2 == 0)//si impair
					oe.Valeur += 1;//ajouter 1 à cause des arrondis
			}
			args.Personnage.AddObligation(oe);
			if(oe2 != null)
				args.Personnage.AddObligation(oe2);
			//bonus credits et xp
			if((bool)rbx1.IsChecked) {
				args.Personnage.XP.GagnerXP(5);
			} else if((bool)rbx2.IsChecked) {
				args.Personnage.XP.GagnerXP(5);
			} else if((bool)rbc1.IsChecked) {
				args.Personnage.Credits = 1000;
			} else if((bool)rbc2.IsChecked) {
				args.Personnage.Credits = 2500;
			}
			return true;
		}

		private void InitPersoVals() {
			args.Personnage.ClearObligations();
			args.Personnage.Credits = 0;
			args.Personnage.XP.Reset();
		}

		public override void GoBack() {
			InitPersoVals();
        }
		/// <summary>
		/// Choisit une obligation au hasard.
		/// Chaque obligation a une chance égale de tomber, mais il y a 4% de chance pour que 2 soient choisies.
		/// </summary>
		private void TirerObligation() {
			int nbr = _obligations.Count();
			int first = Pool.RollD(nbr);
			int second = first;
            if(Pool.RollD(100) >= 97){
				while(second == first) {
					second = Pool.RollD(nbr);
				}
			}
			ObligationsModel m = _obligations.ElementAt(first - 1);
			if(second != first)
				SetSelectedObligations(m,_obligations.ElementAt(second - 1));
			else
				SetSelectedObligations(m, null);
        }
		/// <summary>
		/// Définit les obligations comme celles choisies pour le personage.
		/// </summary>
		/// <param name="m1"></param>
		/// <param name="m2"></param>
		public void SetSelectedObligations(ObligationsModel m1, ObligationsModel m2 ) {
			_selectedObligations.Clear();
			_selectedObligations.Add(m1);
			if(m2 != null)
				_selectedObligations.Add(m2);
		}
		/// <summary>
		/// Calcule l'obligation de départ en fonction du nombre de joueurs
		/// </summary>
		/// <param name="nbrJoueurs"></param>
		/// <returns></returns>
		private int ObligationDeDepart(int nbrJoueurs ) {
			switch(nbrJoueurs) {
				case 1:
				case 2:
				return 20;
				case 3:
				return 15;
				case 4:
				return 10;
				case 5:
				return 10;
				default://6+
				return 5;
			}
		}
	}
}
