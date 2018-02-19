using CoreWpf.UI;
using Shadowrun5.Data;
using Shadowrun5.JdrCore.Agents;
using Shadowrun5.JdrCore.Competences;
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

namespace Shadowrun5Wpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheCollectionCompetences.xaml
	/// </summary>
	public partial class FicheCollectionCompetences : UserControl, IFiche {
		private TreeView _tv;
		private CompetencesCollection _col;

		public object SelectedObject {
			get {
				return _col;
            }

			set {
				CompetencesCollection _temp = null;
				if(value is ShadowrunAgent) {
					_temp = ((ShadowrunAgent)value).Competences;
                } else if (value is CompetencesCollection) {
					_temp = (CompetencesCollection)value;
				}
				if(_col == _temp) { return; }
				_col = _temp;
				SetCompetences(_col);
			}
		}

		public FicheCollectionCompetences() {
			InitializeComponent();
			_tv = new TreeView();
			Content = _tv;
		}

		private void SetCompetences( CompetencesCollection cc ) {
			_tv.Items.Clear();
			if(cc == null) { return; }
			List<Competence> lc = new List<Competence>();
			List<Competence> lg = new List<Competence>();
			/* trier les compétences par catégories */
			foreach(SkillCategory sc in Enum.GetValues(typeof(SkillCategory))) {
				/* Initialize lc with all the skills of the category */
				lc.Clear();
				lc.AddRange(cc.Competences.Where(c => c.Category == sc));
				if(lc.Count() == 0) { continue; }
				/* Initialize the category node */
				TreeViewItem catNode = new TreeViewItem();
				catNode.Header = sc.ToString();
				_tv.Items.Add(catNode);
				/* Ajouter toues les compétences au Node */
				while(lc.Count() > 0) {
					/* Choisir un groupe de compétences au hasard */
					Competence fgc = lc.FirstOrDefault(c => c.Group != null);
					if(fgc != null) {
						/* Ajouter le groupe de compétence dans un sous-node */
						lg.AddRange(lc.Where(c => c.Group == fgc.Group));
						TreeViewItem groupNode = new TreeViewItem();
						groupNode.Header = fgc.Group.ToString();
						catNode.Items.Add(groupNode);
                        foreach(Competence cpt in lg) {
							AddCompetence(groupNode, cpt);
							lc.Remove(cpt);
						}
						lg.Clear();
					} else {
						/* ajouter toutes compétences restantes au node */
						TreeViewItem groupNode = new TreeViewItem();
						groupNode.Header = "Autres";
						catNode.Items.Add(groupNode);
						foreach(Competence cpt in lc) {
							AddCompetence(groupNode, cpt);
						}
						lc.Clear();
					}
				}
            }
		}
		private void AddCompetence( TreeViewItem tv, Competence cp ) {
			StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
			sp.Children.Add(new TextBlock() { Text = cp.Nom, MinWidth = 100 });
			sp.Children.Add(new TextBlock() {
				Text = cp.Attribut.ToString(),
				Width = 50,
				Margin = new Thickness(5,0,5,0),
				HorizontalAlignment = HorizontalAlignment.Center });
			sp.Children.Add(new ValueControler() { Value = cp.Rang });
			tv.Items.Add(sp);
		}
	}
}
