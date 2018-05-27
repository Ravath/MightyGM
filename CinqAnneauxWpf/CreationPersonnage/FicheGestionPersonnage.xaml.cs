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
using Core.Processes;
using CinqAnneaux.Processes;
using CinqAnneauxWpf.Fiches;
using Xceed.Wpf.Toolkit.PropertyGrid;
using CoreWpf.Dialogs;

namespace CinqAnneauxWpf.CreationPersonnage {
	/// <summary>
	/// Logique d'interaction pour FicheGestionPersonnage.xaml
	/// </summary>
	public partial class FicheGestionPersonnage : UserControl, IFicheCandidate {

		#region States
		private bool _creationState;
		private PersonnageProcess persoCreation;
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
		private StepsWindow _ficheConstruction;
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
			_fichePersonnage.SetDataSource(c.Data.GetTable<PJModel>());
			_globalContext = c;
		}

		private void _constructeur_StepsFinished(IProcessEndArguments endargs) {
			SetReadState();
			if(endargs.FinishedState == FinishedState.Done)
			{
				xViewer.Content = new Fiche() { SelectedObject = persoCreation.Personnage };
			}
        }

		private void Button_Click( object sender, RoutedEventArgs e ) {
			if(_creationState)
				SetReadState();
			else
			{
				if (_ficheConstruction == null)
				{
					persoCreation = new PersonnageProcess(_globalContext.Data, GetCreationparameters());
					_ficheConstruction = new StepsWindow(persoCreation, new List<IProcessStepWpf>()
					{
						new FicheCandidateClanFamilleEcole(),
						new StepOptions(),
						new StepSpells(),
						new StepExperience()
					});
					persoCreation.EndOfProcess += _constructeur_StepsFinished;
				}
				else
				{
					persoCreation.Parameters = GetCreationparameters();
				}
				SetCreationState();
			}
		}

		private PersonnageParameters GetCreationparameters()
		{
			PersonnageParameters parameters = new PersonnageParameters();
			//fenetre
			Window w = new Window()
			{
				Width = 300,
				Title = "Creation Parameters",
				Content = new PropertyGrid() { SelectedObject = parameters }
			};
			w.ShowDialog();
			return parameters;
		}
	}
}
