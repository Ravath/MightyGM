using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Attributs;
using CinqAnneaux.JdrCore.Competences;
using Core;
using Core.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheCandidateCompetences.xaml
	/// </summary>
	public partial class FicheCandidateCompetences : UserControl, IFicheCandidate {
		private Database _data;

		public FicheCandidateCompetences() {
			InitializeComponent();
		}

		public UserControl Control {
			get { return this; }
		}

		public string FicheName {
			get { return "Competences"; }
		}

		public void Afficher( IGlobalContext c ) {
			_data = c.Data;
			List<ModelCompetence> cp = new List<ModelCompetence>();
			foreach(CompetenceModel item in _data.GetTable<CompetenceModel>().ToArray()) {
				ModelCompetence ic = new ModelCompetence();
				ic.SetCompetence(item);
				cp.Add(ic);
			}
			xCompetences.ItemsSource = cp.OrderBy(n => n.Groupe).ThenBy(n => n.Name);
		}

		private void xCompetences_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			ModelCompetence c = (ModelCompetence)xCompetences.SelectedItem;
			if(c == null) {
				xCompetenceView.Visibility = Visibility.Hidden;
			} else {
				xCompetenceView.Visibility = Visibility.Visible;
				xCompetenceView.DataContext = c;
				//traits
				if(c.TraitAlternatif == null) {
					xTrait.Text = c.Trait.ToString();
				} else {
					xTrait.Text = c.Trait+"/"+c.TraitAlternatif;
				}
				//mots-clefs
				xNoble.Visibility = c.Noble ? Visibility.Visible : Visibility.Collapsed;
				xDegradante.Visibility = c.Degradante ? Visibility.Visible : Visibility.Collapsed;
				xSociale.Visibility = c.Sociale ? Visibility.Visible : Visibility.Collapsed;
				xMartiale.Visibility = c.Martiale ? Visibility.Visible : Visibility.Collapsed;
				//maitrises
				xListeMaitrises.Visibility = c.Maitrises.Count() > 0 ? Visibility.Visible : Visibility.Collapsed;
				xMaitrises.Children.Clear();
				foreach(var im in c.Maitrises) {
					xMaitrises.Children.Add(new TextBlock() { Text = im.Rang + " - "+im.Description, TextWrapping = TextWrapping.Wrap });
				}
				//Expertises
				xListeExpertises.Visibility = c.Specialisations.Count() > 0 ? Visibility.Visible : Visibility.Collapsed;
				xExpertises.Children.Clear();
				foreach(Specialisation im in c.Specialisations) {
					StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
					sp.Children.Add(new TextBlock() { Text = im.Nom + " " });
					if(im.Degradante)
						sp.Children.Add(new TextBlock() { Text = "[Degradante]" });
					xExpertises.Children.Add(sp);
				}
			}
		}
		class ModelCompetence {

			#region Members
			private string _nom;
			private List<CinqAnneaux.JdrCore.Competences.Specialisation> _specialite = new List<CinqAnneaux.JdrCore.Competences.Specialisation>();
			private List<Maitrise> _maitrise = new List<Maitrise>();
			private GroupeCompetence _groupe;
			#endregion

			#region Properties
			public bool Degradante { get; protected set; }
			public bool Noble { get; protected set; }
			public bool Sociale { get; protected set; }
			public bool Martiale { get; protected set; }

			public string Name {
				get { return _nom; }
				protected set {
					TextInfo info = CultureInfo.CurrentCulture.TextInfo;
					_nom = info.ToTitleCase(value);
				}
			}
			public string Description { get; set; }
			public GroupeCompetence Groupe {
				get { return _groupe; }
				set {
					_groupe = value;
					if(_groupe == GroupeCompetence.Noble)
						Noble = true;
					if(_groupe == GroupeCompetence.Degradante)
						Degradante = true;
				}
			}
			public TraitCompetence Trait { get; protected set; }
			public TraitCompetence? TraitAlternatif { get; protected set; }
			public IEnumerable<CinqAnneaux.JdrCore.Competences.Specialisation> Specialisations {
				get { return _specialite; }
			}
			public IEnumerable<Maitrise> Maitrises {
				get { return _maitrise; }
			}
			#endregion

			#region Model Setters
			public void SetCompetence( CompetenceModel model ) {
				/* val de base */
				if (model.Global != null)
				{
					Name = model.Global.Name + "(" + model.Name + ")";
				}
				else
				{
					Name = model.Name;
				}
				Degradante = model.Degradante;
				Sociale = model.Sociale;
				Martiale = model.Martiale;
				Groupe = model.Groupe;
				Description = model.Description.Description;
				/* attributs */
				Trait = model.TraitAssocie;
				TraitAlternatif = model.TraitAlternatif;
				/* ajouter les maitrise */
				_maitrise.Clear();
				foreach(MaitriseModel maitrise in model.Maitrises.OrderBy(m => m.RangRequis)) {
					_maitrise.Add(MaitriseInstanciator.Instanciate(maitrise));
				}
				/* ajouter les spécialités */
				_specialite.Clear();
				foreach(var item in model.Specialisations) {
					CinqAnneaux.JdrCore.Competences.Specialisation spe = new CinqAnneaux.JdrCore.Competences.Specialisation();
					spe.SetSpecialisation(item);
					_specialite.Add(spe);
                }
            }
			#endregion
		}
	}
}
