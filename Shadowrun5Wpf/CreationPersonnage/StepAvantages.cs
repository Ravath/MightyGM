using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shadowrun5.JdrCore;
using Core.UI.Dialogs;
using Shadowrun5.Data;
using System.Windows.Controls;
using System.Windows.Media;
using Shadowrun5.JdrCore.Traits;
using Shadowrun5.JdrCore.Agents;

namespace Shadowrun5Wpf.CreationPersonnage {
	public class StepAvantages : Step {

		#region Members
		private ParametresCreationPJ _args;
		private ListSelectorControler _lAvantages = new ListSelectorControler();
		private ListSelectorControler _lDesavantages = new ListSelectorControler();
		private int _karmaGagne;
		private int _karmaDepense;
		private TextBlock _tbKarmaRestant = new TextBlock();
		private TextBlock _tbKarmaDeavantages = new TextBlock();
		private List<Avantage> _avantages = new List<Avantage>();
		#endregion

		#region Properties
		public int KarmaRestant {
			get { return _args.KarmaCourant; }
			private set {
				_args.KarmaCourant = value;
				_tbKarmaRestant.Text = value.ToString();
            }
		}
		public int KarmaDesavantage {
			get { return _karmaGagne; }
			set {
				_karmaGagne = value;
				_tbKarmaDeavantages.Text = value.ToString();
				KarmaDepense = _karmaDepense;
            }
		}
		public int KarmaDepense {
			set {
				_karmaDepense = value;
				KarmaRestant = _args.Karma - value + KarmaDesavantage;
			}
		}

		#endregion

		public StepAvantages() {
			//les listes sont à droite et à gauche.
			DockPanel listes = new DockPanel();
			listes.Children.Add(_lAvantages);
			listes.Children.Add(_lDesavantages);
			DockPanel.SetDock(_lAvantages, Dock.Left);
			DockPanel.SetDock(_lDesavantages, Dock.Right);
			_lAvantages.SelectionChanged += _lAvantages_SelectionChanged;
			_lDesavantages.SelectionChanged += _lDesavantages_SelectionChanged;
			//compteurs alignés en bas
			int fontSize = 13;
			StackPanel sp = new StackPanel() {
				Orientation = Orientation.Horizontal,
				MaxHeight = 80
			};
			sp.Children.Add(new TextBlock() { Text = "Karma Restant : ", FontSize = fontSize });
			_tbKarmaRestant.FontSize = fontSize;
			_tbKarmaRestant.Foreground = Brushes.Red;
			sp.Children.Add(_tbKarmaRestant);
			sp.Children.Add(new TextBlock() { Text = "  Limite Desavantage : ", FontSize = fontSize });
			_tbKarmaDeavantages.FontSize = fontSize;
			_tbKarmaDeavantages.Foreground = Brushes.Red;
			sp.Children.Add(_tbKarmaDeavantages);
			//DockPanel
			DockPanel dp = new DockPanel();
			dp.Children.Add(sp);
			DockPanel.SetDock(sp, Dock.Bottom);
			dp.Children.Add(listes);
			this.AddChild(dp);
		}

		private void _lDesavantages_SelectionChanged( IEnumerable<global::Core.Data.IDataObject> newItems ) {
			int sum = 0;
			foreach(var item in newItems) {
				NegativeQualityModel p = (NegativeQualityModel)item;
				sum += p.Cost;
			}
			KarmaDesavantage = sum;
		}

		private void _lAvantages_SelectionChanged( IEnumerable<global::Core.Data.IDataObject> newItems ) {
			int sum = 0;
			foreach(var item in newItems) {
				PositiveQualityModel p = (PositiveQualityModel)item;
				sum += p.Cost;
			}
			KarmaDepense = sum;
		}

		#region Step Implementation
		public override bool CanProgress( out string errorMessage ) {
			errorMessage = "";
			bool errors = false;
			//début tests
			if(_args.KarmaCourant < 0) {
				errors = true;
				errorMessage += "\nVous avez dépensé trop de Karma.";
			}
			if(_karmaGagne > _args.Karma) {
				errors = true;
				errorMessage += "\nVous ne pouvez pas gagner plus de karma avec des désavantages que vous n'avez de karma de départ.";
			}
			//fin tests
			if(!errors)
				GoNext(_args.Personnage);
			return !errors;
        }

		private void GoNext( Personnage p ) {
			_avantages.Clear();
			foreach(var item in _lAvantages.SelectedItems) {
				PositiveQualityModel pqm = (PositiveQualityModel)item;
				_avantages.Add(new Avantage(pqm));
			}
			foreach(var item in _lDesavantages.SelectedItems) {
				NegativeQualityModel pqm = (NegativeQualityModel)item;
				_avantages.Add(new Avantage(pqm));
			}
			foreach(Avantage av in _avantages) {
				p.Avantages.AddTrait(av);
			}
			return;
		}

		public override void GoBack() { /*nothing*/ }

		public override void Init( IStepsArgument args ) {
			_args = (ParametresCreationPJ)args;
			_karmaGagne = 0;
			_args.KarmaCourant = _args.Karma;
			foreach(Avantage av in _avantages) {
				_args.Personnage.Avantages.RemoveTrait(av);
			}
			_lAvantages.Data = _args.Data;
			_lDesavantages.Data = _args.Data;
			_lAvantages.Load(typeof(PositiveQualityModel));
			_lDesavantages.Load(typeof(NegativeQualityModel));
		} 
		#endregion
	}
}
