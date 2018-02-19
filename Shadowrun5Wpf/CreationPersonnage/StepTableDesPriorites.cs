using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Shadowrun5Wpf.CreationPersonnage {

	public class StepTableDesPriorites : Step {

		private ParametresCreationPJ _args;
		private StackPanel _stack = new StackPanel();
		private Dictionary<TypePriorite, Priorite> selections;
		private Dictionary<TypePriorite, ComboBox> comboBoxes = new Dictionary<TypePriorite, ComboBox>();

		private Dictionary<Priorite, string> dMetatypes = new Dictionary<Priorite, string>();
		private Dictionary<Priorite, string> dAttributs = new Dictionary<Priorite, string>();
		private Dictionary<Priorite, string> dPouvoirs = new Dictionary<Priorite, string>();
		private Dictionary<Priorite, string> dCompetences = new Dictionary<Priorite, string>();
		private Dictionary<Priorite, string> dRessources = new Dictionary<Priorite, string>();

		public StepTableDesPriorites() {
			this.AddChild(_stack);
			//metatypes
			dMetatypes.Add(Priorite.A,"Humain (9)\nElfe(8)\nNain(7)\nOrk(7)\nTroll(5)");
			dMetatypes.Add(Priorite.B,"Humain (7)\nElfe(6)\nNain(4)\nOrk(4)\nTroll(0)");
			dMetatypes.Add(Priorite.C,"Humain (5)\nElfe(3)\nNain(1)\nOrk(0)");
			dMetatypes.Add(Priorite.D,"Humain (3)\nElfe(0)");
			dMetatypes.Add(Priorite.E,"Humain (1)");
			//attributs
			dAttributs.Add(Priorite.A, "24");
			dAttributs.Add(Priorite.B, "20");
			dAttributs.Add(Priorite.C, "16");
			dAttributs.Add(Priorite.D, "14");
			dAttributs.Add(Priorite.E, "12");
			//Pouvoirs
			dPouvoirs.Add(Priorite.A,
				"Mage ou adepte mystique: Magie 6, 10 sorts,\n" +
				"\t2 compétences magiques indice 5.\n" +
				"Technomancien: Resonance 6, 5 formes complexes,\n" +
				"\t2 compétences de résonance indice 5.");
			dPouvoirs.Add(Priorite.B,
				"Mage ou adepte mystique: Magie 4, 7 sorts,\n" +
				"\t2 compétences magiques indice 4.\n" +
				"Technomancien: Resonance 4, 2 formes complexes,\n" +
				"\t2 compétences de résonance indice 4.\n" +
				"Adepte: Magie 6, 1 compétence active indice 4.\n" +
				"Mage spécialisé: Magie 5, un groupe de compétences Magiques 4.");
			dPouvoirs.Add(Priorite.C, 
				"Mage ou adepte mystique: Magie 3, 5 sorts.\n"+
				"Technomancien: Resonance 3, 1 Forme Complexe.\n" +
				"Adepte: Magie 4, 1 compétence active indice 2.\n" +
				"Mage spécialisé: Magie 3, un groupe de compétences Magiques 2.");
			dPouvoirs.Add(Priorite.D, "Mage spécialisé: Magie 2.\nAdepte: Magie 2.");
			dPouvoirs.Add(Priorite.E, "-");
			//competences
			dCompetences.Add(Priorite.A, "46/10");
			dCompetences.Add(Priorite.B, "36/5");
			dCompetences.Add(Priorite.C, "28/2");
			dCompetences.Add(Priorite.D, "22/0");
			dCompetences.Add(Priorite.E, "18/0");
			//ressources sont dynamiques donc gérées par Init()
			//templates
			AddTemplate("Metatype", dMetatypes, TypePriorite.Metatype);
			AddTemplate("Attributs", dAttributs, TypePriorite.Attribut);
			AddTemplate("Pouvoirs", dPouvoirs, TypePriorite.Pouvoir);
			AddTemplate("Compétences",dCompetences, TypePriorite.Competence);
			AddTemplate("Ressources", dRessources, TypePriorite.Ressource);
		}
		private void AddTemplate( string title, Dictionary<Priorite, string> descText, TypePriorite tp ) {
			DockPanel dp = new DockPanel();
			TextBlock tb = new TextBlock { Text = title.ToUpper(), FontSize = 25, FontWeight = FontWeights.Bold };
			dp.Children.Add(tb);
			DockPanel.SetDock(tb, Dock.Top);
			ComboBox cb = new ComboBox { ItemsSource = Enum.GetValues(typeof(Priorite)) };
			cb.MinWidth = 65;
			cb.MinHeight = 65;
			cb.FontSize = 40;
			dp.Children.Add(cb);
			DockPanel.SetDock(cb, Dock.Left);
			TextBlock tbdesc = new TextBlock();
			dp.Children.Add(tbdesc);
			_stack.Children.Add(dp);
			//liaison
			comboBoxes.Add(tp, cb);
            cb.SelectionChanged += ( object sender, SelectionChangedEventArgs e ) => {
				Priorite p = (Priorite)((ComboBox)sender).SelectedItem;
                tbdesc.Text = descText[p];
				selections[tp] = p;
            };
		}
		/// <summary>
		/// Vérifie qu'une priorité différente a été sélectionnée pour chaque colonne.
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public override bool CanProgress( out string errorMessage ) {
			errorMessage = "";
			bool error = false;
            int count = 0;
			foreach(Priorite pr in Enum.GetValues(typeof(Priorite))) {
				count = selections.Count(p => p.Value == pr);
				if(count != 1) {
					error = true;
					errorMessage += string.Format("\n-la priorité {0} a été choisie {1} fois.",pr,count);
				}
			}
			if(error)
				errorMessage += "\nVous devez choisir une priorité différente pour chaque ligne.";
			return !error;
        }

		public override void GoBack() { }

		public override void Init( IStepsArgument args ) {
			_args = (ParametresCreationPJ)args;
			dRessources.Clear();
			dRessources.Add(Priorite.A, _args.RessourcesA + "¥");
			dRessources.Add(Priorite.B, _args.RessourcesB + "¥");
			dRessources.Add(Priorite.C, _args.RessourcesC + "¥");
			dRessources.Add(Priorite.D, _args.RessourcesD + "¥");
			dRessources.Add(Priorite.E, _args.RessourcesE + "¥");
			selections = _args.Priorites;
			comboBoxes[TypePriorite.Metatype].SelectedValue = Priorite.A;
			comboBoxes[TypePriorite.Attribut].SelectedValue = Priorite.B;
			comboBoxes[TypePriorite.Pouvoir].SelectedValue = Priorite.C;
			comboBoxes[TypePriorite.Competence].SelectedValue = Priorite.D;
			comboBoxes[TypePriorite.Ressource].SelectedValue = Priorite.E;
		}
	}
}
