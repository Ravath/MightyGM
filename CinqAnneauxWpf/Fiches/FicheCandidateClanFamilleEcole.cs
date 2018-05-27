using CinqAnneaux.Data;
using Core;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CoreWpf;
using Core.Contexts;
using CoreWpf.UI;
using Core.Processes;
using CinqAnneaux.Processes;

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Une fiche pour afficher sur une même interface les clans, et leurs familles et écoles associées.
	/// </summary>
	public class FicheCandidateClanFamilleEcole : UserControl, IFicheCandidate, IProcessStepWpf
	{

		#region Members
		//lists views
		private ListView lvClans = new ListView();
		private ListView lvFamilles = new ListView();
		private ListView lvEcoles = new ListView();
		//fiches
		private FicheClan fClan = new FicheClan();
		private FicheFamille fFamille = new FicheFamille();
		private FicheEcole fEcole = new FicheEcole();
		//data
		private IEnumerable<ClanModel> _dataClan;
		private IEnumerable<FamilleModel> _dataFamille;
		private IEnumerable<EcoleModel> _dataEcole;
		//selections
		private ClanModel _selectedClan;
		private FamilleModel _selectedFamily;
		private EcoleModel _selectedSchool;
		#endregion

		#region Properties
		public ClanModel SelectedClan
		{
			get { return _selectedClan; }
			set {
				_selectedClan = value;
				if (_step != null) { _step.SelectedClan = value; }
			}
		}
		public FamilleModel SelectedFamily
		{
			get { return _selectedFamily; }
			set {
				_selectedFamily = value;
				if (_step != null) { _step.SelectedFamily = value; }
			}
		}
		public EcoleModel SelectedSchool
		{
			get { return _selectedSchool; }
			set {
				_selectedSchool = value;
				if (_step != null) { _step.SelectedSchool = value; }
			}
		}
		public string FicheName { get { return "Clans"; } }
		public UserControl Control { get { return this; } }
		#endregion

		public FicheCandidateClanFamilleEcole() {
			fClan.SelectedObject = SelectedClan;
			fClan.Margin = new System.Windows.Thickness(5);
			fClan.MinHeight = 100;
			fFamille.SelectedObject = SelectedFamily;
			fFamille.Margin = new System.Windows.Thickness(5);
			fFamille.MinWidth = 200;
			fEcole.SelectedObject = SelectedSchool;
			fEcole.Margin = new System.Windows.Thickness(5);
			fEcole.MinWidth = 200;
			lvClans.MinWidth = 100;
			lvFamilles.MinWidth = 100;
			lvEcoles.MinWidth = 100;
			DockPanel spH1 = new DockPanel();
			DockPanel spV1 = new DockPanel() { Margin = new System.Windows.Thickness(2) };
			Grid spH2 = new Grid() { Margin = new System.Windows.Thickness(0, 5, 0, 0) };
			spH2.ColumnDefinitions.Add(new ColumnDefinition());
			spH2.ColumnDefinitions.Add(new ColumnDefinition());
			DockPanel dpFam = new DockPanel();
			DockPanel dpEcl = new DockPanel();
			spH1.Children.Add(lvClans);
			DockPanel.SetDock(lvClans, Dock.Left);
			spH1.Children.Add(spV1);
			spV1.Children.Add(fClan);
			DockPanel.SetDock(fClan, Dock.Top);
			spV1.Children.Add(spH2);
			spH2.Children.Add(dpFam);
			spH2.Children.Add(dpEcl);
			Grid.SetColumn(dpFam, 0);
			Grid.SetColumn(dpEcl, 1);
			dpFam.Children.Add(lvFamilles);
			dpFam.Children.Add(fFamille);
			DockPanel.SetDock(lvFamilles, Dock.Left);
			dpEcl.Children.Add(lvEcoles);
			dpEcl.Children.Add(fEcole);
			DockPanel.SetDock(lvEcoles, Dock.Left);
			this.AddChild(spH1);
			// events linkage
			lvClans.SelectionChanged += LvClans_SelectionChanged;
			lvFamilles.SelectionChanged += LvFamilles_SelectionChanged;
			lvEcoles.SelectionChanged += LvEcoles_SelectionChanged;
		}
		public void SetData(Database data) {
			_dataClan = data.GetTable<ClanModel>().OrderBy(n => n.Tag);
			_dataFamille = data.GetTable<FamilleModel>().OrderBy(n => n.Name);
			_dataEcole = data.GetTable<EcoleModel>().OrderBy(n => n.Name);
			lvClans.ItemsSource = _dataClan;
		}
		public void Afficher( IGlobalContext c ) {
			SetData(c.Data);
		}

		#region events
		private void LvEcoles_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			EcoleModel cm = lvEcoles.SelectedItem as EcoleModel;
			fEcole.SelectedObject = cm;
			SelectedSchool = cm;
		}

		private void LvFamilles_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			FamilleModel cm = lvFamilles.SelectedItem as FamilleModel;
			fFamille.SelectedObject = cm;
			SelectedFamily = cm;
		}

		private void LvClans_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			ClanModel cm = lvClans.SelectedItem as ClanModel;
			fClan.SelectedObject = cm;
			SelectedClan = cm;
			SelectedFamily = null;
			SelectedSchool = null;
			//update families & schools
			if(cm == null) {
				lvFamilles.ItemsSource = null;
				lvEcoles.ItemsSource = null;
			} else {
				lvFamilles.ItemsSource = _dataFamille.Where(f => f.ClanId == cm.Id);
				lvEcoles.ItemsSource = _dataEcole.Where(f => f.ClanId == cm.Id);
			}
		}
		#endregion

		#region Agent Creation Process implementation
		private AgentE1 _step;
		public void InitStep(IProcessStep currentStep)
		{
			_step = (AgentE1)currentStep;
			_dataClan = _step.SelectableClan;
			_dataFamille = _step.SelectableFamily;
			_dataEcole = _step.SelectableSchool;
			lvClans.ItemsSource = _dataClan;
		}
		#endregion
	}
}
