using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Ecoles;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheEcole.xaml
	/// </summary>
	public partial class FicheEcole : UserControl, IFiche {

		private Ecole ecole;

		public FicheEcole() {
			InitializeComponent();
		}

		public Ecole SelectedEcole {
			get { return ecole; }
			set {
				ecole = value;
				Refresh();
			}
		}

		public object SelectedObject {
			get {
				return SelectedEcole;
            }
			set {
				if (value is EcoleModel) {
					Ecole e = new Ecole();
					e.SetModel((EcoleModel)value);
					SelectedEcole = e;
                } else if (value is Ecole) {
					SelectedEcole = (Ecole)value;
                } else {
					if(value == null) { SelectedEcole = null; } 
					else
						throw new ArgumentException("Can't handle argument of type " + value.GetType());
				}
			}
		}

		public void Refresh() {
			xName.Text = ecole?.Name;
			xDescription.Text = ecole?.Description;
			xBonusTrait.Text = ecole?.BonusTrait.ToString();
            xTechniques.ItemsSource = ecole?.Techniques;
			xType.Text = String.Format("[{0}]",ecole?.MotClef);
			//moine
			if(ecole?.MotClef == MotClefEcole.Moine) {
				xMoine.Visibility = Visibility.Visible;
				xDevotion.Text = ecole?.Devotion.ToString();
			} else {
				xMoine.Visibility = Visibility.Collapsed;
			}
			//shugenja
			if(ecole?.MotClef == MotClefEcole.Shugenja) {
				xShugenja.Visibility = Visibility.Visible;
				xAffinite.Text = ecole?.Affinite.ToString();
				xDeficience.Text = ecole?.Deficience.ToString();
			} else {
				xShugenja.Visibility = Visibility.Collapsed;
			}
		}
	}
}
