using Core;
using CoreWpf.UI;
using CinqAnneaux.JdrCore;
using CinqAnneaux.Data;
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
using CoreWpf;
using Core.Contexts;

namespace CinqAnneauxWpf.CreationPersonnage {
	/// <summary>
	/// Logique d'interaction pour FicheGestionPersonnage.xaml
	/// </summary>
	public partial class FicheGestionPersonnage : UserControl, IFicheCandidate {

		#region States
		private bool _creationState;
		private void SetReadState() {
			_creationState = false;
			xCreationButton.Content = "Nouveau Personnage";
			xViewer.Content = _fichePersonnage;
		}
		private void SetCreationState() {
			_creationState = true;
			xCreationButton.Content = "Annuler";
			_ficheConstruction.InitSteps();
			xViewer.Content = _ficheConstruction;
		}
		#endregion

		#region Members
		private ListeFiche<PersonnageModel> _fichePersonnage = new ListeFiche<PersonnageModel>();
		private ConstructeurPersonnages _ficheConstruction;
		private IGlobalContext _globalContext;
		#endregion

		public FicheGestionPersonnage() {
			InitializeComponent();
			_fichePersonnage.Afficheur = new Fiche();
        }

		public UserControl Control {
			get { return this; }
		}

		string IFicheCandidate.FicheName {
			get { return "Personnages"; }
		}

		public void Afficher( IGlobalContext c ) {
			if(_ficheConstruction == null) {
				_ficheConstruction = new ConstructeurPersonnages(c.Data);
				_ficheConstruction.StepsFinished += _constructeur_StepsFinished;
			}
			_fichePersonnage.SetDataSource(c.Data.GetTable<PJModel>());
			_globalContext = c;
		}

		private void _constructeur_StepsFinished( IStepsArgument arg, StepsWindowsFinishedArguments endargs ) {
			ParametresCreationPJ arguments = (ParametresCreationPJ)arg;
			SetReadState();
			xViewer.Content = new Fiche() { SelectedObject = arguments.Personnage };
        }

		private void Button_Click( object sender, RoutedEventArgs e ) {
			if(_creationState)
				SetReadState();
			else
				SetCreationState();
		}
	}
}
