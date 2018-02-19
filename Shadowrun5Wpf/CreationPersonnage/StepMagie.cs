using CoreWpf.UI;
using Core.UI.Dialogs;
using Shadowrun5.JdrCore;
using Shadowrun5.JdrCore.Agents;
using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Shadowrun5.JdrCore.FormesComplexes;
using Shadowrun5.JdrCore.Sorts;

namespace Shadowrun5Wpf.CreationPersonnage {
	/// <summary>
	/// todo : choix des competences et des sorts.
	/// </summary>
	public class StepMagie : Step {

		/// <summary>
		/// Classe encapsulant une option choisisable par un joueur, et les données qui en découlent.
		/// </summary>
		private class OptionPratiquant {
			public OptionPratiquant( Priorite pr, PratiquantMagie pm, string name, int puissance ) {
				Priorite = pr;
				Type = pm;
				Name = name;
				Puissance = puissance;
            }
			public Priorite Priorite { get; set; }
			public PratiquantMagie Type { get; set; }
			/// <summary>
			/// La spécialité si mage spécialisé.
			/// </summary>
			public SpecialiteMage Specialite { get; set; }
			public int Puissance { get; set; }
			public string Name { get; set; }
			/// <summary>
			/// Nombe de sorts connus si Mage.
			/// Nombre de formes complexes connues si Technomancien.
			/// </summary>
			public int NbrSorts { get; set; }
			/// <summary>
			/// le nombre de compétences à choisir.
			/// Le nombre de groupe de compétences si mage spé.
			/// (a priori tjrs 1 ou 0 pour adeptes et mage spé)
			/// </summary>
			public int NbrCompetences { get; set; }
			/// <summary>
			/// L'indice des compétences choisies.
			/// </summary>
			public int IndiceCompetences { get; set; }

			public OptionPratiquant Clone() {
				OptionPratiquant c = new OptionPratiquant(Priorite, Type, Name, Puissance);
				c.NbrSorts = NbrSorts;
				c.NbrCompetences = NbrCompetences;
				c.IndiceCompetences = IndiceCompetences;
				return c;
            }
		}

		#region Members
		private List<OptionPratiquant> _Options = new List<OptionPratiquant>();
		private ParametresCreationPJ _args;
		/// <summary>
		/// Sert pour retenir combien le personnage avait en puissance avant de gagner des points de magie gratuits.
		/// </summary>
		private int _anciennePuissance;
		private ComboBox cbOption;
		private ComboBox cbSpecialite;
		private StackPanel _middleStack = new StackPanel() { Orientation = Orientation.Horizontal };
		private ListSelectorControler lsSorts;
		private ListSelectorControler lsComplexes;
		private TextBlock _compteurLabel = new TextBlock();
		private TextBlock _compteurNbr = new TextBlock();
		#endregion

		#region Properties
		private IEnumerable<OptionPratiquant> Options {
			get {
				if(_args == null) { return new List<OptionPratiquant>(); }
				return _Options.Where(op => op.Priorite == _args.Priorites[TypePriorite.Pouvoir]);
			}
		}
		private OptionPratiquant SelectedOption {
			get {
				return (OptionPratiquant)cbOption.SelectedItem;
			}
		}
		private SpecialiteMage SelectedSpeciality {
			get {
				return (SpecialiteMage)cbSpecialite.SelectedItem;
			}
		}
		#endregion

		#region Init
		public StepMagie() {
			InitOptions();
			//listes de sorts et de formes complexes
			lsSorts = new ListSelectorControler();
			lsSorts.SelectionChanged += LsSorts_SelectionChanged;
			lsComplexes = new ListSelectorControler();
			lsComplexes.SelectionChanged += LsSorts_SelectionChanged;
			//ComboBox générale
			cbOption = new ComboBox() {
				ItemsSource = Options,
				DisplayMemberPath = "Name",
				SelectedIndex = 0,
				MaxHeight = 25
			};
			cbOption.SelectionChanged += OptionCB_SelectionChanged;
			//ComboBox pour mages spécialisés
			cbSpecialite = new ComboBox() {
				ItemsSource = Enum.GetValues(typeof(SpecialiteMage)),
				SelectedIndex = 0,
				Visibility = System.Windows.Visibility.Hidden,
				Margin = new System.Windows.Thickness(10,0,0,0),
				MaxHeight = 25
			};
			//stack panel for both comboboxes
			StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
			sp.Children.Add(new TextBlock() { Text = "Choisissez une catégorie de mage:" });
			sp.Children.Add(cbOption);
			sp.Children.Add(cbSpecialite);
			sp.MaxHeight = 80;
			sp.VerticalAlignment = System.Windows.VerticalAlignment.Top;
			//DockPanel général
			DockPanel dp = new DockPanel();
			dp.Children.Add(sp);
			DockPanel.SetDock(sp, Dock.Top);
			//middle content
			DockPanel dpMiddle = new DockPanel();
            dp.Children.Add(dpMiddle);
			StackPanel spellStack = new StackPanel();//compteurs de sorts
			spellStack.Children.Add(_compteurLabel);
			spellStack.Children.Add(_compteurNbr);
			dpMiddle.Children.Add(spellStack);
			DockPanel.SetDock(spellStack, Dock.Top);
			dpMiddle.Children.Add(_middleStack);
            this.AddChild(dp);
		}

		private void OptionCB_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            if(SelectedOption.Type == PratiquantMagie.MageSpecialise) {
				cbSpecialite.Visibility = System.Windows.Visibility.Visible;
			} else {
				cbSpecialite.Visibility = System.Windows.Visibility.Hidden;
			}
			_middleStack.Children.Clear();
			switch(SelectedOption.Type) {
				case PratiquantMagie.Non:
				break;
				case PratiquantMagie.Technomancien:
				_compteurLabel.Text = "Nombre de Formes Complexes:  ";
                _middleStack.Children.Add(lsComplexes);
                break;
				case PratiquantMagie.Magicien:
				case PratiquantMagie.AdepteMystique:
				_compteurLabel.Text = "Nombre de Sorts:  ";
				_middleStack.Children.Add(lsSorts);
				break;
				case PratiquantMagie.Adepte:
				case PratiquantMagie.MageSpecialise:
				default:
				break;
			}
			RefreshSpellNumbers();
		}
		/// <summary>
		/// Initialise les données différentes options.
		/// </summary>
		private void InitOptions() {
			string MageName = "Magicien";
			string AdepteMystiqueName = "Adepte Mystique";
			string TechnomancienName = "Technomancien";
			string AdepteName = "Adepte";
			string MageSpeName = "Magicien Spécialisé";
			//priorité A
			OptionPratiquant optMageA = new OptionPratiquant(Priorite.A, PratiquantMagie.Magicien, MageName, 6) {
				NbrCompetences = 2,
				IndiceCompetences = 5,
				NbrSorts = 10
			};
			OptionPratiquant optAdepteMA = optMageA.Clone();
			optAdepteMA.Name = AdepteMystiqueName;
			optAdepteMA.Type = PratiquantMagie.AdepteMystique;
			OptionPratiquant optTechA = new OptionPratiquant(Priorite.A, PratiquantMagie.Technomancien, TechnomancienName, 6) {
				NbrCompetences = 2,
				IndiceCompetences = 5,
				NbrSorts = 5
			};
			//priorite B
			OptionPratiquant optMageB = new OptionPratiquant(Priorite.B, PratiquantMagie.Magicien, MageName, 4) {
				NbrSorts = 7,
				NbrCompetences = 2,
				IndiceCompetences = 4
			};
			OptionPratiquant optAdepteMB = optMageB.Clone();
			optAdepteMB.Name = AdepteMystiqueName;
			optAdepteMB.Type = PratiquantMagie.AdepteMystique;
			OptionPratiquant optTechB = new OptionPratiquant(Priorite.B, PratiquantMagie.Technomancien, TechnomancienName, 4) {
				NbrSorts = 2,
				NbrCompetences = 2,
				IndiceCompetences = 4
			};
			OptionPratiquant optAdepteB = new OptionPratiquant(Priorite.B, PratiquantMagie.Adepte, AdepteName, 6) {
				IndiceCompetences = 4
			};
			OptionPratiquant optMageSpeB = new OptionPratiquant(Priorite.B, PratiquantMagie.MageSpecialise, MageSpeName, 5) {
				IndiceCompetences = 4
			};
			//priorite C
			OptionPratiquant optMageC = new OptionPratiquant(Priorite.C, PratiquantMagie.Magicien, MageName, 3) {
				NbrSorts = 5
			};
			OptionPratiquant optAdepteMC = optMageC.Clone();
			optAdepteMC.Name = AdepteMystiqueName;
			optAdepteMC.Type = PratiquantMagie.AdepteMystique;
			OptionPratiquant optTechC = new OptionPratiquant(Priorite.C, PratiquantMagie.Technomancien, TechnomancienName, 3) {
				NbrSorts = 1
			};
			OptionPratiquant optAdepteC = new OptionPratiquant(Priorite.C, PratiquantMagie.Adepte, AdepteName, 4) {
				IndiceCompetences = 2
			};
			OptionPratiquant optMageSpeC = new OptionPratiquant(Priorite.C, PratiquantMagie.MageSpecialise, MageSpeName, 3) {
				IndiceCompetences = 2
			};
			//priorite D
			OptionPratiquant optAdepteD = new OptionPratiquant(Priorite.D, PratiquantMagie.Adepte, AdepteName, 2);
			OptionPratiquant optMageSpeD = new OptionPratiquant(Priorite.D, PratiquantMagie.MageSpecialise, MageSpeName, 2);
			//ajouter à la liste des options.
			_Options.Add(optMageA);
			_Options.Add(optMageB);
			_Options.Add(optMageC);
			_Options.Add(optAdepteMA);
			_Options.Add(optAdepteMB);
			_Options.Add(optAdepteMC);
			_Options.Add(optAdepteB);
			_Options.Add(optAdepteC);
			_Options.Add(optAdepteD);
			_Options.Add(optMageSpeB);
			_Options.Add(optMageSpeC);
			_Options.Add(optMageSpeD);
			_Options.Add(optTechA);
			_Options.Add(optTechB);
			_Options.Add(optTechC);
		}
		/// <summary>
		/// met à jour les valeurs d'affichage du nombre de sorts qu'il faut choisir.
		/// </summary>
		private void RefreshSpellNumbers() {
			if(SelectedOption == null)
				_compteurLabel.Text = "None";
			else if(SelectedOption.Type == PratiquantMagie.Technomancien)
				_compteurLabel.Text = ( SelectedOption.NbrSorts - lsComplexes.SelectedItems.Count()) .ToString();
			else
				_compteurLabel.Text = (SelectedOption.NbrSorts - lsSorts.SelectedItems.Count()).ToString();
		}

		private void LsSorts_SelectionChanged( IEnumerable<global::Core.Data.IDataObject> newItems ) {
			RefreshSpellNumbers();
        }
		#endregion

		#region Step Implementation
		public override bool CanProgress( out string errorMessage ) {
			errorMessage = "";
			bool errors = false;
			//si E, passer sans s'arrêter
			if(_args.Priorites[TypePriorite.Pouvoir] == Priorite.E) {

			} //sinon, doit selectionner un type de mage
			else if(SelectedOption == null) {//apriori, impossible avec interface, mais on sait jamais.
				errorMessage += "\nVous devez choisir un type de mage.";
				errors = true;
			}
			//vérifier nombre de sorts
			switch(SelectedOption.Type) {
				case PratiquantMagie.Non:
				case PratiquantMagie.Adepte:
				case PratiquantMagie.MageSpecialise:
				break;
				case PratiquantMagie.Technomancien:
				if(SelectedOption.NbrSorts - lsComplexes.SelectedItems.Count() < 0) {
					errorMessage += "\nVous devez choisir moins de formes complexes";
					errors = true;
				}else if(SelectedOption.NbrSorts - lsComplexes.SelectedItems.Count() > 0) {
					errorMessage += "\nVous devez choisir plus de formes complexes";
					errors = true;
				}
				break;
				case PratiquantMagie.AdepteMystique:
				case PratiquantMagie.Magicien:
				if(SelectedOption.NbrSorts - lsSorts.SelectedItems.Count() < 0) {
					errorMessage += "\nVous devez choisir moins de sorts";
					errors = true;
				} else if(SelectedOption.NbrSorts - lsSorts.SelectedItems.Count() > 0) {
					errorMessage += "\nVous devez choisir plus de sorts";
					errors = true;
				}
				break;
				default:
				break;
			}
			 //passer les valeurs
			if(!errors)
				GoNext(_args.Personnage);
			return !errors;
		}

		public void GoNext( Personnage p ) {
			if(_args.Priorites[TypePriorite.Pouvoir] == Priorite.E) {
				p.SpecialiteMage = null;
				p.Pratiquant = PratiquantMagie.Non;
				p.Caracteristiques.Puissance.BaseValue = 0;
				return;
			}
			//indiquer type de pratiquant et de spécialité
			p.Pratiquant = SelectedOption.Type;
			if(p.Pratiquant == PratiquantMagie.MageSpecialise) {
				p.SpecialiteMage = SelectedSpeciality;
			} else {
				p.SpecialiteMage = null;
			}
			//augmenter la puissance
			p.Caracteristiques.Puissance.BaseValue = 
				Math.Min(
					p.Caracteristiques.Puissance.BaseValue + SelectedOption.Puissance,
					p.Caracteristiques.Puissance.MaximumBaseAttribut);
			//ajouter liste de sorts
			p.ClearFormeComplexeList();
			p.ClearSpellList();
			switch(SelectedOption.Type) {
				case PratiquantMagie.Non:
				case PratiquantMagie.Adepte:
				case PratiquantMagie.MageSpecialise:
				break;
				case PratiquantMagie.Technomancien:
				foreach(ComplexFormModel item in lsComplexes.SelectedItems) {
					p.AddFormeComplexe(new FormeComplexe(item));
				}
				break;
				case PratiquantMagie.AdepteMystique:
				case PratiquantMagie.Magicien:
				foreach(SpellModel item in lsComplexes.SelectedItems) {
					p.AddSpell(new Sort(item));
				}
				break;
				default:
				break;
			}
		}

		public override void GoBack() {
			//reinitialiser ancienne valeur de puissance
			_args.Personnage.Caracteristiques.Puissance.BaseValue = _anciennePuissance;
		}

		public override void Init( IStepsArgument args ) {
			_args = (ParametresCreationPJ)args;
			_anciennePuissance = _args.Personnage.Caracteristiques.Puissance.BaseValue;
			cbOption.ItemsSource = null;
			if(_args.Priorites[TypePriorite.Pouvoir] != Priorite.E)
				cbOption.ItemsSource = Options;
			lsSorts.ClearSelection();
			lsComplexes.ClearSelection();
			RefreshSpellNumbers();
			lsSorts.Data = _args.Data;
			lsComplexes.Data = _args.Data;
			lsSorts.Load(typeof(SpellModel));
			lsComplexes.Load(typeof(ComplexFormModel));
		} 
		#endregion
	}
}
