using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.JdrCore.Competences;
using CinqAnneaux.JdrCore.MassCombat;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CinqAnneauxWpf.Fiches
{
	/// <summary>
	/// Logique d'interaction pour FichemassCombatFaction.xaml
	/// </summary>
	public partial class FicheMassCombatFaction : UserControl
	{
		private List<MassCombatFighter> _fighters = new List<MassCombatFighter>();

		public FicheMassCombatFaction()
		{
			InitializeComponent();
			xFightersList.ItemsSource = _fighters;
			xcbTurnAdvantage.ItemsSource = System.Enum.GetValues(typeof(TurnAvantage));
		}

		private void AddFighter_Click(object sender, RoutedEventArgs e)
		{
			//create new character
			Personnage newCharacter = new Personnage();
			newCharacter.EtatCivil.Name = "New Fighter";
			Competence artDelaGuerre = new Competence() { Tag = MassCombatCtrl.ArtDelaGuerreTag, Rang = 2 };
			newCharacter.Competences.AddCompetence(artDelaGuerre);
			MassCombatFaction faction = (MassCombatFaction)DataContext;
			var f = faction.AddFighter(newCharacter);
			f.Implication = FighterImplication.PREMIERE_LIGNE;
			_fighters.Add(f);
			Refresh();
		}

		public void Refresh()
		{
			xFightersList.ItemsSource = null;
			xFightersList.ItemsSource = _fighters;
		}
	}
}
