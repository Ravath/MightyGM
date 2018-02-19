using CoreWpf.UI;
using Shadowrun5.JdrCore;
using Shadowrun5.JdrCore.Traits;
using Shadowrun5.Data;
using Shadowrun5.JdrCore.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace Shadowrun5Wpf.CreationPersonnage {
	/// <summary>
	/// Etape de sélection du métatype et de répartition des attributs.
	/// </summary>
	public class StepAttributs : Step {

		private class ValueRow {
			#region Members
			private int _vBase = 1;
			private int _vCurrent = 0;
			#endregion
			#region Properties
			public int vBase {
				get {
					if(_vBase < 1)
						return 1;
					return _vBase;
				}
				set {
					if(_vBase == value+1)
						return;
					_vBase = value+1;
					MajText();
                }
			}
			public int vMax { get { return AttributExceptionnel ? _vBase + 6 : _vBase + 5; } }
			public int vCurrent {
				get { return _vCurrent; }
				set {
					_vCurrent = value;
					tbTotal.Text = vTotal.ToString();
				}
			}
			public int vTotal { get { return vBase + _vCurrent; } }
			public bool AttributExceptionnel {
				get {
					return (bool)cbExceptionnel.IsChecked;
			} }
			#endregion
			public TextBlock tbBase = new TextBlock();
			public TextBlock tbTotal = new TextBlock();
			public IntegerUpDown tbCurrent = new IntegerUpDown();
			public RadioButton cbExceptionnel = new RadioButton();

			public ValueRow() {
				tbBase.DataContext = this;
				tbTotal.DataContext = this;
				tbCurrent.DataContext = this;
				tbCurrent.SetBinding(IntegerUpDown.ValueProperty, "vCurrent");
				cbExceptionnel.Checked += CbExceptionnel_Checked;
				cbExceptionnel.Unchecked += CbExceptionnel_Checked;
				cbExceptionnel.Checked += RB_Checked;
				cbExceptionnel.Click += RB_Clicked;
                tbCurrent.ValueChanged += TbCurrent_ValueChanged;
				tbCurrent.Height = 25;
				tbBase.HorizontalAlignment = HorizontalAlignment.Center;
				tbCurrent.HorizontalAlignment = HorizontalAlignment.Center;
				tbTotal.HorizontalAlignment = HorizontalAlignment.Center;
				cbExceptionnel.HorizontalAlignment = HorizontalAlignment.Center;
				tbBase.VerticalAlignment = VerticalAlignment.Center;
				tbCurrent.VerticalAlignment = VerticalAlignment.Center;
				cbExceptionnel.VerticalAlignment = VerticalAlignment.Center;
				tbTotal.VerticalAlignment = VerticalAlignment.Center;
				cbExceptionnel.VerticalAlignment = VerticalAlignment.Center;
				MajText();
			}

			private bool JustChecked;
			private void RB_Checked( object sender, RoutedEventArgs e ) {
				RadioButton s = (RadioButton)sender;
				// Action on Check...
				JustChecked = true;
			}

			private void RB_Clicked( object sender, RoutedEventArgs e ) {
				if(JustChecked) {
					JustChecked = false;
					e.Handled = true;
					return;
				}
				RadioButton s = (RadioButton)sender;
				if(s.IsChecked == true)
					s.IsChecked = false;
			}

			private void TbCurrent_ValueChanged( object sender, RoutedPropertyChangedEventArgs<object> e ) {
				if( (int)e.NewValue < 0 ) {
					tbCurrent.Value = 0;
				} else if((int)e.NewValue > 5) {
					tbCurrent.Value = 5;
				} else if (vTotal > vMax) {
					tbCurrent.Value = (int)e.OldValue;
				}
			}

			private void MajText() {
				tbBase.Text = vBase + "/" + vMax;
				tbTotal.Text = vTotal.ToString();
			}

			private void CbExceptionnel_Checked( object sender, RoutedEventArgs e ) {
				MajText();
			}
		}

		#region Members
		private ParametresCreationPJ _args;
		private int _attributs;
		private int _attributsSpeciaux;
		private ValueRow[] _values = new ValueRow[8];
		private string[] _noms = new string[8];
		private Attribut[] _attribut = new Attribut[8];
		private ValueRow _chance = new ValueRow();
		private ValueRow _puissance = new ValueRow();
		private ListeFiche<MetatypeModel> _listeMetatypes = new ListeFiche<MetatypeModel>();
		private TextBlock tbPoints, tbPointsSpeciaux;
		#endregion

		#region Properties
		public int PointsAttributs {
			get { return _attributs; }
			set {
				_attributs = value;
				tbPoints.Text = value.ToString();
			}
		}
		public int PointsAttributsSpeciaux {
			get { return _attributsSpeciaux; }
			set {
				_attributsSpeciaux = value;
				tbPointsSpeciaux.Text = value.ToString();
			}
		}
		#endregion

		public StepAttributs() {
			Grid grid = new Grid() { HorizontalAlignment = HorizontalAlignment.Center };
			grid.ColumnDefinitions.Add(new ColumnDefinition() { MaxWidth = 100 });//nom val
			grid.ColumnDefinitions.Add(new ColumnDefinition() { MaxWidth = 75 });//base
			grid.ColumnDefinitions.Add(new ColumnDefinition() { MaxWidth = 75 });//modif
			grid.ColumnDefinitions.Add(new ColumnDefinition() { MaxWidth = 75 });//total
			grid.ColumnDefinitions.Add(new ColumnDefinition() { MaxWidth = 75 });//AttributExceptionnel
			//grid.ColumnDefinitions.Add(new ColumnDefinition());//remplissage
			int rowHeight = 30;
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// [En-tête]
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// constitution
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// agilite
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// reaction
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// force
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// volonté
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// logique
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// intuition
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// charisme
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// [intercalaire]
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// chance
			grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = rowHeight });// Magie/Resonance
			//insertion dans un dockPanel
			DockPanel dp = new DockPanel();
			//fiche des métatypes
			_listeMetatypes.Afficheur = new Fiche();
			dp.Children.Add(_listeMetatypes);
			DockPanel.SetDock(_listeMetatypes, Dock.Left);
			_listeMetatypes.SelectionChanged += _listeMetatypes_SelectionChanged;
			//les points à dépenser
			int pointsFontSize = 15;
			StackPanel vsp = new StackPanel() { Orientation = Orientation.Horizontal };
			vsp.Children.Add(new TextBlock { Text = "Points d'attributs:  " , FontSize = pointsFontSize });
			tbPoints = new TextBlock() { DataContext = this, FontSize = pointsFontSize, Foreground = Brushes.Red};
			//tbpa.SetBinding(TextBlock.TagProperty, "PointsAttributs");
			tbPointsSpeciaux = new TextBlock() { DataContext = this, FontSize = pointsFontSize, Foreground = Brushes.Red };
			//tbpa.SetBinding(TextBlock.TagProperty, "PointsAttributsSpeciaux");
			vsp.Children.Add(tbPoints);
			vsp.Children.Add(new TextBlock { Text = "   Points d'attributs spéciaux:  ", FontSize = pointsFontSize });
			vsp.Children.Add(tbPointsSpeciaux);
			dp.Children.Add(vsp);
			DockPanel.SetDock(vsp, Dock.Bottom);
			//ajouter la Grid
			dp.Children.Add(grid);
			this.AddChild(dp);
			//noms de colonnes
			int titleSize = 13;
			AddToGrid(grid, new TextBlock { Text = "Attribut", FontSize = titleSize }, 0, 0);
			AddToGrid(grid, new TextBlock { Text = "Base", FontSize = titleSize }, 1, 0);
			AddToGrid(grid, new TextBlock { Text = "Rang", FontSize = titleSize }, 2, 0);
			AddToGrid(grid, new TextBlock { Text = "Tot.", FontSize = titleSize }, 3, 0);
			AddToGrid(grid, new TextBlock { Text = "Excep.", FontSize = titleSize }, 4, 0);
			//noms attributs
			_noms[0] = "Constitution";
			_noms[1] = "Agilite";
			_noms[2] = "Reaction";
			_noms[3] = "Force";
			_noms[4] = "Volonte";
			_noms[5] = "Logique";
			_noms[6] = "Intuition";
			_noms[7] = "Charisme";
			_attribut[0] = Attribut.Body;
			_attribut[1] = Attribut.Agility;
			_attribut[2] = Attribut.Reaction;
			_attribut[3] = Attribut.Strength;
			_attribut[4] = Attribut.Willpower;
			_attribut[5] = Attribut.Logic;
			_attribut[6] = Attribut.Intuition;
			_attribut[7] = Attribut.Charisma;
			//valeurs lignes
			for(int i = 0; i < 8; i++) {
				_values[i] = new ValueRow();
				AddToGrid(grid, new TextBlock { Text = _noms[i], VerticalAlignment = VerticalAlignment.Center }, 0, i + 1);
				AddToGrid(grid, _values[i].tbBase, 1, i + 1);
				AddToGrid(grid, _values[i].tbCurrent, 2, i + 1);
				AddToGrid(grid, _values[i].tbTotal, 3, i + 1);
				AddToGrid(grid, _values[i].cbExceptionnel, 4, i + 1);
				_values[i].tbCurrent.ValueChanged += TbCurrent_ValueChanged;
			}
			//Attributs spéciaux
			AddToGrid(grid, new TextBlock { Text = "Attributs Spéciaux", FontSize = 13 }, 0, 9,5);
			AddToGrid(grid, new TextBlock { Text = "Chance", VerticalAlignment = VerticalAlignment.Center }, 0, 10);
			AddToGrid(grid, new TextBlock { Text = "Pouvoir", VerticalAlignment = VerticalAlignment.Center }, 0, 11);
			int irow = 10;
			foreach(var item in new ValueRow[]{ _chance, _puissance} ) {
				AddToGrid(grid, item.tbBase, 1, irow);
				AddToGrid(grid, item.tbCurrent, 2, irow);
				AddToGrid(grid, item.tbTotal, 3, irow);
				AddToGrid(grid, item.cbExceptionnel, 4, irow);
				item.tbCurrent.ValueChanged += TbCurrent_ValueChangedSpecial;
				irow++;
            }

		}

		private void TbCurrent_ValueChangedSpecial( object sender, RoutedPropertyChangedEventArgs<object> e ) {
			int diff = (int)e.NewValue - (int)e.OldValue;
			PointsAttributsSpeciaux -= diff;
		}
		private void TbCurrent_ValueChanged( object sender, RoutedPropertyChangedEventArgs<object> e ) {
			int diff = (int)e.NewValue - (int)e.OldValue;
			PointsAttributs -= diff;
		}

		private void _listeMetatypes_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			if(_listeMetatypes.SelectedItem == null)
				return;
			_values[0].vBase = _listeMetatypes.SelectedItem.Body;
			_values[1].vBase = _listeMetatypes.SelectedItem.Agility;
			_values[2].vBase = _listeMetatypes.SelectedItem.Reaction;
			_values[3].vBase = _listeMetatypes.SelectedItem.Strength;
			_values[4].vBase = _listeMetatypes.SelectedItem.Willpower;
			_values[5].vBase = _listeMetatypes.SelectedItem.Logic;
			_values[6].vBase = _listeMetatypes.SelectedItem.Intuition;
			_values[7].vBase = _listeMetatypes.SelectedItem.Charisma;
			_chance.vBase = _listeMetatypes.SelectedItem.Edge;
			_puissance.vBase = 0;
			_chance.vCurrent = 0;
			_puissance.vCurrent = 0;
			/*TODO:pour le moment, les valeurs pour un humain.
			  Et on verra quand on les différents types auront été implémentés*/
			switch(_args.Priorites[TypePriorite.Metatype]) {
				case Priorite.A:
				PointsAttributsSpeciaux = _listeMetatypes.SelectedItem.SpeA;
				break;
				case Priorite.B:
				PointsAttributsSpeciaux = _listeMetatypes.SelectedItem.SpeB;
				break;
				case Priorite.C:
				PointsAttributsSpeciaux = _listeMetatypes.SelectedItem.SpeC;
				break;
				case Priorite.D:
				PointsAttributsSpeciaux = _listeMetatypes.SelectedItem.SpeD;
				break;
				case Priorite.E:
				PointsAttributsSpeciaux = _listeMetatypes.SelectedItem.SpeE;
				break;
				default:
				break;
			}
		}

		private void AddToGrid( Grid g, UIElement element, int column, int row, int colSpan=1 ) {
			g.Children.Add(element);
			Grid.SetRow(element,row);
			Grid.SetColumn(element, column);
			Grid.SetColumnSpan(element, colSpan);
		}

		public override bool CanProgress( out string errorMessage ) {
			errorMessage = "";
			int maxCount = 0;
			bool errors = false;
			if(_listeMetatypes.SelectedItem == null) {
				errorMessage += "\nVous devez choisir un métatype.";
				errors = true;
			}
			if(PointsAttributs < 0) {
				errors = true;
				errorMessage += "\nVous avez dépensé trop de points d'attribut.";
			} else if(PointsAttributs > 0) {
				errors = true;
				errorMessage += "\nVous devez dépenser tous vos points d'attribut.";
			}
			if(PointsAttributsSpeciaux < 0) {
				errors = true;
				errorMessage += "\nVous avez dépensé trop de points d'attribut spéciaux.";
			} else if(PointsAttributsSpeciaux > 0) {
				errors = true;
				errorMessage += "\nVous devez dépenser tous vos points d'attribut spéciaux.";
			}
			for(int i = 0; i < 8; i++) {
				if(_values[i].vTotal > _values[i].vMax) {
					errorMessage += string.Format("\n{0} est supérieur au maximum autorisé.", _noms[i]);
					errors = true;
                } else if(_values[i].vTotal == _values[i].vMax) {
					maxCount++;
                }
			}
			if(maxCount > 1) {
				errorMessage += "\nVous ne pouvez atteindre le maximum que pour une seule valeur.";
				errors = true;
            }
			if(!errors) {
				_args.Personnage.Caracteristiques.Constitution.BaseValue = _values[0].vCurrent+1;
				_args.Personnage.Caracteristiques.Agilite.BaseValue = _values[1].vCurrent+1;
				_args.Personnage.Caracteristiques.Reaction.BaseValue = _values[2].vCurrent+1;
				_args.Personnage.Caracteristiques.Force.BaseValue = _values[3].vCurrent+1;
				_args.Personnage.Caracteristiques.Volonte.BaseValue = _values[4].vCurrent+1;
				_args.Personnage.Caracteristiques.Logique.BaseValue = _values[5].vCurrent+1;
				_args.Personnage.Caracteristiques.Intuition.BaseValue = _values[6].vCurrent+1;
				_args.Personnage.Caracteristiques.Charisme.BaseValue = _values[7].vCurrent+1;
				_args.Personnage.Caracteristiques.MaxChance.BaseValue = _chance.vCurrent+1;
				_args.Personnage.Caracteristiques.Puissance.BaseValue = _puissance.vCurrent+1;
				_args.Personnage.Metatype = new Metatype(_listeMetatypes.SelectedItem);
				for(int i = 0; i < _values.Length; i++) {
					if(_values[i].AttributExceptionnel) {
						_args.Personnage.DefaultTraits.AddTrait(new AttributExceptionnel(_attribut[i]));
						break;
					}
				}
				if(_chance.AttributExceptionnel) {
					_args.Personnage.DefaultTraits.AddTrait(new Chanceux());
				}
				if(_puissance.AttributExceptionnel)
					_args.Personnage.DefaultTraits.AddTrait(new AttributExceptionnel(Attribut.Magic));
			}
            return !errors;
		}

		public override void GoBack() { /*nothing*/ }

		public override void Init( IStepsArgument args ) {
			_args = (ParametresCreationPJ)args;
			//charger uniquement les races accessibles pour la priorité choisie.
			IQueryable<MetatypeModel> q;
			switch(_args.Priorites[TypePriorite.Metatype]) {
				case Priorite.A:
				q = from c in _args.Data.GetTable<MetatypeModel>()
					where c.SpeA >= 0
					select c;
				break;
				case Priorite.B:
				q = from c in _args.Data.GetTable<MetatypeModel>()
					where c.SpeB >= 0
					select c;
				break;
				case Priorite.C:
				q = from c in _args.Data.GetTable<MetatypeModel>()
					where c.SpeC >= 0
					select c;
				break;
				case Priorite.D:
				q = from c in _args.Data.GetTable<MetatypeModel>()
					where c.SpeD >= 0
					select c;
				break;
				case Priorite.E:
				q = from c in _args.Data.GetTable<MetatypeModel>()
					where c.SpeE >= 0
					select c;
				break;
				default:
				q = null;
				break;
			}
			_listeMetatypes.SetDataSource(q);
			//nombre de points d'attribut
            switch(_args.Priorites[TypePriorite.Attribut]) {
				case Priorite.A:
				PointsAttributs = 24;
				break;
				case Priorite.B:
				PointsAttributs = 20;
				break;
				case Priorite.C:
				PointsAttributs = 16;
				break;
				case Priorite.D:
				PointsAttributs = 14;
				break;
				case Priorite.E:
				PointsAttributs = 12;
				break;
				default:
				PointsAttributs = 0;
				break;
			}
			foreach(var item in _values) {
				item.vCurrent = 0;
				item.cbExceptionnel.IsChecked = false;
			}_chance.vCurrent = 0;
			_chance.cbExceptionnel.IsChecked = false;
            _puissance.vCurrent = 0;
			_puissance.cbExceptionnel.IsChecked = false;
		}
	}
}
