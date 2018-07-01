﻿using CoreWpf.Dialogs;
using MightyGmWPF.GUIcore;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.IO;
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
using MightyGmCtrl.Controleurs;
using Core.Contexts;
using MightyGmCtrl;
using Core.Data;

namespace MightyGmWPF.Tabs {

	/// <summary>
	/// Logique d'interaction pour TabParameters.xaml
	/// </summary>
	public partial class TabParameters : UserControl {

		#region Members
		private List<string> _assemblies = new List<string>();
		private List<string> _names = new List<string>();
		private Scenario _scenario;
		private Session _sceance;
		private Rpg _jdr;
		#endregion

		#region Properties
		public Context Context { get; }
		public Rpg SelectedJdr {
			get {
				return _jdr;
			}
			set {
				_jdr = value;
				if(value == null) {
					xgbScenario.IsEnabled = false;
					SelectedScenario = null;
					return;
				}
				xgbScenario.IsEnabled = true;
				UpdateScenarioList();
			}
		}
		public Scenario SelectedScenario {
			get {
				if(_scenario == null)
					return null;
				_scenario.Name = xScenarioName.Text;
				_scenario.Synopsis = xSynopsis.Text;
				_scenario.Rpg = SelectedJdr;
				return _scenario;
			}
			set {
				_scenario = value;
				if(value == null) {
					xgbSceance.IsEnabled = false;
					SelectedSceance = null;
                    return;
				}
				xgbSceance.IsEnabled = true;
				xGmName.Text = SelectedScenario?.Gm?.ToString();
				xScenarioName.Text = value.Name;
				xSynopsis.Text = value.Synopsis;
				UpdateScenarioPlayerList();
				UpdateSceances();
			}
		}

		public Session SelectedSceance {
			get {
				if(_sceance == null)
					return null;
				return _sceance;
			}
			set {
				_sceance = value;
				if(value == null)
					return;
				xSceanceFiche.SelectedObject = value;
			}
		}
		#endregion

		#region Init
		public TabParameters( Context context ) {
			this.DataContext = this;
			InitializeComponent();
			Context = context;
			xJoueurs.Content = new EditeurListe<Player>(context.Data);
			xJoueurs.MinWidth = 250;
			UpdateScenarioList();
            xSceanceFiche.ReadOnly = true;
			SelectedJdr = null;

			SetAssemblyList(Context.Files.FindJdrModules());
			Context.ReportManager.MessageEvent += Console;
			Context.ReportManager.ProcessExceptionEvent += Console;
		}
		#endregion
		/// <summary>
		/// Affiche du texte dans la console, à la suite des messages précédents.
		/// </summary>
		/// <param name="message">Le message affiché.</param>
		public void Console(string message)
		{
			xConsole.Text += message + "\r";
		}
		public void Console( MessageType type, string message ) {
			Console(type.ToString() + " : " + message);
		}
		public void Console(Exception ex)
		{
			Console(MessageType.ERROR,ex.Message);
			Console(ex.StackTrace);
		}

		#region Assemblies & Jdr
		/// <summary>
		/// Récupère les dlls dans les répertoires indiqués.
		/// </summary>
		/// <param name="assemblies">Liste des répertoires où cercher es dlls.</param>
		public void SetAssemblyList( IEnumerable<FileInfo> assemblies ) {
			foreach(FileInfo fi in assemblies) {
				if(fi.Extension.ToLower() == ".dll") {
					_assemblies.Add(fi.FullName);
					_names.Add(fi.Name.Remove(fi.Name.Length-4,4));
				}
			}
			MajAssembliesCombo();
		}
		/// <summary>
		/// Maj la comboMox de choix des jdr
		/// </summary>
		private void MajAssembliesCombo() {
			xDlls.Items.Clear();
			foreach(string n in _names) {
				xDlls.Items.Add(n);
			}
		}
		/// <summary>
		/// Lorsqu'une assemly est sélectionnée, mettre à jour l'assembly du context.
		/// Trouver le jdr en base de donnée, et le créer si n'existe pas, puis désigner comme jdr sélectionné.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xDlls_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			ComboBox cb = sender as ComboBox;
			Context.Dll.SetAssembly(
				_assemblies[cb.SelectedIndex]
			);
			//trouver jdr avec même nom
			string jdrName = _names[cb.SelectedIndex];
			var qj = from c in Context.Data.GetTable<Rpg>()
					 where c.Name == jdrName
					 select c;
			Rpg j = qj.SingleOrDefault();
			if(j == null) {//si il n'existe pas, le créer.
				j = new Rpg
				{
					Name = _names[cb.SelectedIndex]
				};
				Context.Data.Insert<Rpg>(j);
				//récupérer pour avoir id et valeurs automatiques
				j = Context.Data.GetTable<Rpg>().SingleOrDefault(p => p.Name == _names[cb.SelectedIndex]);
			}
			SelectedJdr = j;
        }
		#endregion

		#region Maj des données affichées
		/// <summary>
		/// met à jour la liste des scénarios associés à un jdr.
		/// </summary>
		private void UpdateScenarioList() {
			xListScenario.ItemsSource = null;
			if(SelectedJdr == null)
				return;
			xListScenario.ItemsSource = from c in Context.Data.GetTable<Scenario>()
										where c.RpgId == SelectedJdr.Id
										select c;
		}
		/// <summary>
		/// Maj la liste des joueurs qui participent à un scénario.
		/// </summary>
		private void UpdateScenarioPlayerList() {
			xPlayersList.ItemsSource = null;
			if(SelectedScenario != null) {
				xPlayersList.ItemsSource = SelectedScenario.Players;
			}
		}
		/// <summary>
		/// parmi les scéances du scénario courant, trouver celle qui n'a pas de date de cloture, et maj avec date actuelle.
		/// </summary>
		private void CloseLastSceance() {
			foreach(Session sc in xListSceance.Items) {
				if(sc.EndSession == null) {
					sc.EndSession = DateTime.Now;
					Context.Data.Update<Session>(sc);
				}
			}
		}
		/// <summary>
		/// Maj la liste des scéances avec les scéances du scénario sélectionné.
		/// </summary>
		private void UpdateSceances() {
			xListSceance.ItemsSource = null;
			if(SelectedScenario != null) {
				xListSceance.ItemsSource = SelectedScenario.Chapters.Select(a=>a.PlayedSessions);
			}
		}
		#endregion

		#region Evénements Panneau Scenario
		private void ChangeGm( object sender, RoutedEventArgs e ) {
			if(SelectedScenario == null) {
				MessageBox.Show("Must Select a Scenario.");
				return;
			}
			//ListView lv = new ListView();
			//lv.ItemsSource = Context.Data.GetTable<Joueur>();
			//Window w = new Window();
			//w.Content = lv;
			//w.Title = "Players List";
			//w.ShowDialog();
			Player j = Selectors.GetOne(Context.Data.GetTable<Player>());
			SelectedScenario.Gm = j;
			if(j == null)
				xGmName.Text = "Personne";
			else
				xGmName.Text = j.ToString();
		}

		private void AddPlayerToScenario( object sender, RoutedEventArgs e ) {
			if(SelectedScenario == null) {
				MessageBox.Show("Must select a Scenario.");
				return;
			}
			//ListView lv = new ListView();
			//lv.ItemsSource = Context.Data.GetTable<Joueur>();
			//Window w = new Window();
			//w.Content = lv;
			//w.Title = "Players List";
			//w.ShowDialog();

			//Add players to scenario
			List<Player> pls = new List<Player>(Selectors.GetMany(Context.Data.GetTable<Player>()));
			pls.AddRange(SelectedScenario.Players);
			SelectedScenario.Players = pls;

			UpdateScenarioPlayerList();
		}

		private void RemovePlayerFromScenario( object sender, RoutedEventArgs e ) {
			Player j = xPlayersList.SelectedItem as Player;
			if(j == null)
				return;
			List<Player> pls = new List<Player>(SelectedScenario.Players);
			pls.Remove(j);
			SelectedScenario.Players = pls;
			UpdateScenarioPlayerList();
		}

		private void ScenarioSelected( object sender, SelectionChangedEventArgs e ) {
			SelectedScenario = (Scenario)xListScenario.SelectedItem;
		}

		private void DeleteScenario( object sender, RoutedEventArgs e ) {
			if(SelectedScenario == null) {
				MessageBox.Show("Must select a Scenario.");
				return;
			}
			Context.Data.Delete(SelectedScenario);
			SelectedScenario = null;
			UpdateScenarioPlayerList();
			UpdateScenarioList();
		}

		private void NewScenario( object sender, RoutedEventArgs e ) {
			SelectedScenario = new Scenario();
		}

		private void SaveScenario( object sender, RoutedEventArgs e ) {
			if(SelectedScenario == null) {
				MessageBox.Show("Must select or create a Scenario.");
				return;
			}
			if(SelectedScenario.Gm == null) {
				MessageBox.Show("Must select a gm.");
				return;
			}
			try {
				if(SelectedScenario.Id == 0) {
					object id = Context.Data.InsertWithIdentity<Scenario>(SelectedScenario);
					SelectedScenario.Id = Convert.ToInt32(id);

					//Add Players to scenario
					List<Player> pl = new List<Player>(SelectedScenario.Players);
					pl.AddRange(xPlayersList.Items.Cast<Player>());
					SelectedScenario.Players = pl;

					UpdateScenarioList();
                } else {
					Context.Data.Update<Scenario>(SelectedScenario);
				}
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				return;
			}
		}
		#endregion

		#region Evénements du panneau des scéances
		private void SceanceSelected( object sender, SelectionChangedEventArgs e ) {
			SelectedSceance = xListSceance.SelectedItem as Session;
		}

		private void NewSceance( object sender, RoutedEventArgs e ) {
			CloseLastSceance();
			if(SelectedScenario == null) {
				MessageBox.Show("You Must Select a Scenario.");
				return;
			}
			Session sc = new Session();
			SelectedSceance = sc;
			try {
				Context.Data.Insert<Session>(sc);
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				SelectedSceance = null;
			}
			UpdateSceances();
		}

		private void CloseSceance( object sender, RoutedEventArgs e ) {
			CloseLastSceance();
		} 
		#endregion
	}
}
