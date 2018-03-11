using CinqAnneaux.JdrCore.MassCombat;
using CoreWpf;
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
using Core.Contexts;
using Core.Data;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.JdrCore.Competences;
using Core.Engine;
using CinqAnneaux.Data;

namespace CinqAnneauxWpf.Fiches
{
	/// <summary>
	/// Logique d'interaction pour FicheMassCombat.xaml
	/// </summary>
	public partial class FicheMassCombat : UserControl, IFicheCandidate
	{
		private Database _database;
		private MassCombatCtrl _massCombat;

		public MassCombatFaction FactionA { get; set; }
		public MassCombatFaction FactionB { get; set; }
		public Competence ArtGuerreA = new Competence() { Rang = 2, Tag = MassCombatCtrl.ArtDelaGuerreTag };
		public Competence ArtGuerreB = new Competence() { Rang = 2, Tag = MassCombatCtrl.ArtDelaGuerreTag };

		public string FicheName { get { return "Mass Combats"; } }
		public UserControl Control { get { return this; } }

		public FicheMassCombat()
		{
			InitializeComponent();
			FactionA = new MassCombatFaction()
			{
				Name = "Red Fighters",
				Size = 250,
				StrategyAdvantage = 0,
				General = new Personnage()
			};
			FactionB = new MassCombatFaction()
			{
				Name = "Blue Fighters",
				Size = 250,
				StrategyAdvantage = 0,
				General = new Personnage()
			};
			FactionA.General.EtatCivil.Name = "General A";
			FactionB.General.EtatCivil.Name = "General B";
			FactionA.General.Attributs.Perception.BaseValue = 2;
			FactionB.General.Attributs.Perception.BaseValue = 2;
			FactionA.General.Competences.AddCompetence(ArtGuerreA);
			FactionB.General.Competences.AddCompetence(ArtGuerreB);
		}

		public void Refresh()
		{
			xFactB.DataContext = null;
			xFactA.DataContext = null;
			xSimulation.DataContext = null;
			xFactB.DataContext = FactionB;
			xFactA.DataContext = FactionA;
			xSimulation.DataContext = _massCombat;
			xFactA.Refresh();
			xFactB.Refresh();
		}

		public void Afficher(IGlobalContext c)
		{
			_database = c.Data;
			xOppList.ItemsSource = _database.GetTable<OpportuniteHeroiqueModel>();
			_massCombat = new MassCombatCtrl(_database);
			_massCombat.AddFaction(FactionA);
			_massCombat.AddFaction(FactionB);
			Refresh();
		}

		private void NextTurn_Click(object sender, RoutedEventArgs e)
		{
			_massCombat.NextTurn();
			Refresh();
		}

		private void NewBattle_Click(object sender, RoutedEventArgs e)
		{
			_massCombat.CurrentTurn = 0;
			Refresh();
		}

		private void Opportunity_selection(object sender, SelectionChangedEventArgs e)
		{
			xSelectedView.DataContext = xOppList.SelectedItem;
		}
	}
}
