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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheFamille.xaml
	/// </summary>
	public partial class FicheFamille : UserControl, IFiche {

		private Famille famille;

		public FicheFamille() {
			InitializeComponent();
		}

		public Famille SelectedFamille {
			get { return famille; }
			set {
				famille = value;
				Refresh();
			}
        }

		public object SelectedObject {
			get {
				return SelectedFamille;
			}

			set {
				if(value is FamilleModel) {
					Famille e = new Famille();
					e.SetModel((FamilleModel)value);
					SelectedFamille = e;
				} else if(value is Famille) {
					SelectedFamille = (Famille)value;
				} else {
					if(value == null) { SelectedFamille = null; } 
					else
						throw new ArgumentException("Can't handle argument of type " + value.GetType());
				}
			}
		}

		internal void Refresh() {
			xName.Text = famille?.Name;
			xDescription.Text = famille?.Description;
			xBonus.Text = famille?.BonusTrait.ToString();
		}
	}
}
