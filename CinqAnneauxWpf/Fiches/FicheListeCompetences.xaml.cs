using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Competences;
using CoreWpf.UI;
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

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheCompetences.xaml
	/// </summary>
	public partial class FicheListeCompetences : UserControl, IFiche {
		private ListeCompetences _liste;

		public ListeCompetences Liste {
			get {
				return _liste;
			}
			set {
				if(_liste == value) { return; }
                _liste = value;
            }
		}

		public FicheListeCompetences() {
			InitializeComponent();
			xCompetenceTree = new TreeView();
			Content = xCompetenceTree;
		}

		public object SelectedObject {
			get {
				return Liste;
            }

			set {
				if(value is ListeCompetences) {
					Liste = (ListeCompetences)value;
				}
			}
		}
		public void SetCompetences() {
			xCompetenceTree.Items.Clear();
			if(_liste == null) { return; }
			List<Competence> lc = new List<Competence>();
			/* trier les compétences par catégories */
			foreach(GroupeCompetence sc in Enum.GetValues(typeof(GroupeCompetence))) {
				/* Initialize lc with all the skills of the category */
				lc.AddRange(_liste.Competences.Where(c => c.Groupe == sc));
				if(lc.Count() == 0) { continue; }
				/* Initialize the category node */
				TreeViewItem catNode = new TreeViewItem
				{
					Header = sc.ToString()
				};
				xCompetenceTree.Items.Add(catNode);
				/* Ajouter toutes les compétences au Node */
				foreach(Competence cpt in lc) {
					AddCompetence(catNode, cpt);
				}
				catNode.IsExpanded = true;
				lc.Clear();
			}
		}
		private void AddCompetence( TreeViewItem tv, Competence cp ) {
			TreeViewItem competenceNode = new TreeViewItem();
			StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
			tv.Items.Add(competenceNode);
			competenceNode.Header = sp;
			/* name */
			TextBlock cpName = new TextBlock() { Text = cp.Nom, MinWidth = 120 };
			/* name : ajouter '*' ou '#' si dégradante ou noble */
			if(cp.Noble)
				cpName.Text += "^";
			if(cp.Degradante)
				cpName.Text += "*";
			sp.Children.Add(cpName);
			/* attribut */
			sp.Children.Add(new TextBlock() {
				Text = cp.Trait.ToString(),
				Width = 60,
				Margin = new Thickness(5, 0, 5, 0),
				HorizontalAlignment = HorizontalAlignment.Center
			});
			/* dice pool */
			sp.Children.Add(new ValueControler() { Value = cp.Pool.RollValue });
			sp.Children.Add(new TextBlock() { Text = "g" });
			sp.Children.Add(new ValueControler() { Value = cp.Pool.KeepValue });
			// todo : spécialisations
			// todo : maitrises
			foreach(Maitrise m in cp.CurrentMaitrises) {
				competenceNode.Items.Add(new TextBlock() {
					Text = string.Format("{0}: {1}", m.Rang, m.Description)
				});
			}
		}
	}
}
