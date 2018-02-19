using CinqAnneaux.JdrCore.Agent;
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
	/// Logique d'interaction pour FicheVie.xaml
	/// </summary>
	public partial class FicheVie : UserControl, IFiche {

		private SeuilVie _vie;

		public FicheVie() {
			InitializeComponent();
		}

		public object SelectedObject {
			get {
				return _vie;
            }
			set {
				Vie = value as SeuilVie;
            }
		}

		public SeuilVie Vie {
			get {
				return _vie;
			}
			set {
				if(value == _vie) { return; }
				if(_vie!=null)
					_vie.DegatsValue.ValueChanged -= DegatsValue_ValueChanged;
				_vie = value;
				//valeurs
				_vie.DegatsValue.ValueChanged += DegatsValue_ValueChanged;
				xBlessures.Value = _vie.DegatsValue;
				xBlessuresMax.Value = _vie.DeathThresholdValue;
				xMalus.Text = "(" + _vie.Malus + ")";
				//tableau
				xSpMalus.Children.Clear();
				xSpPaliers.Children.Clear();
				foreach(var item in _vie.Seuils) {
					xSpPaliers.Children.Add(new TextBlock() { Text = item.Item1.ToString() });
					xSpMalus.Children.Add(new TextBlock() { Text = item.Item2.ToString() });
                }
				if(value is SeuilVieCreature)
					xEtats.Visibility = Visibility.Hidden;
				else
					xEtats.Visibility = Visibility.Visible;
            }
		}

		private void DegatsValue_ValueChanged( Core.Engine.IValue ival, int newValue, int oldValue ) {
			xMalus.Text = "(" + _vie.Malus + ")";
		}
	}
}
