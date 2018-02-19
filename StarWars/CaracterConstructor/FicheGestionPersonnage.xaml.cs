using Core;
using Core.UI;
using StarWars.CaracterConstructor;
using StarWars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StarWarsData.CaracterConstructor {
	/// <summary>
	/// Logique d'interaction pour FichePersonnage.xaml
	/// </summary>
	public partial class FicheGestionPersonnage : UserControl, IFicheCandidate {
		private enum State {
			read, create, buy
		}
		#region Members
		private ListeFiche<PJModel> _fiches;
		private IGlobalContext _gc;
		private State _currentState;
		private ConstructeurPersonnage _constructeur;
		#endregion

		#region Properties
		string IFicheCandidate.FicheName {
			get { return "Personnages"; }
		}
		
		public UserControl Control {
			get { return this; }
		}
		#endregion

		#region Init
		public FicheGestionPersonnage() {
			InitializeComponent();
			_fiches = new ListeFiche<PJModel>();
			_fiches.Afficheur = new Fiche();
			SetFicheMode();
        }

		private void _constructeur_StepsFinished( IStepsArgument stepArgs, StepsWindowsFinishedArguments endargs ) {
			StarwarsPJConstructionArguments a = stepArgs as StarwarsPJConstructionArguments;
			if(endargs.FinishedState == FinishedState.Done) {
				PJModel p = a.Personnage.CreateModel();
				p.SaveObject();
			}
			SetFicheMode();
			_fiches.SetDataSource(_gc.Data.GetTable<PJModel>());
        }

		/// <summary>
		/// Mode de lecture de fiche de perso.
		/// </summary>
		public void SetFicheMode() {
			_currentState = State.read;
            xContainer.Content = _fiches;
			xCreation.Content = "Create Character";
		}
		/// <summary>
		/// Mode de création d'un personnage
		/// </summary>
		public void SetConstructeurMode() {
			_currentState = State.create;
			_constructeur.InitSteps();
            xContainer.Content = _constructeur;
			xCreation.Content = "Cancel";
		}
		/// <summary>
		/// Mode de répartition de l'xp.
		/// </summary>
		public void SetGestionMode() {
			_currentState = State.buy;

		}

		public void Afficher( IGlobalContext c ) {
			if(_constructeur == null) {
				_constructeur = new ConstructeurPersonnage(c.Data);
				_constructeur.StepsFinished += _constructeur_StepsFinished;
			}
			_fiches.SetDataSource(c.Data.GetTable<PJModel>());
			_gc = c;
			xCreation.IsEnabled = true;
        }
		#endregion

		private void xCreation_Click( object sender, RoutedEventArgs e ) {
			if(_currentState == State.read)
				SetConstructeurMode();
			else if(_currentState == State.create)
				SetFicheMode();
        }
	}
}
