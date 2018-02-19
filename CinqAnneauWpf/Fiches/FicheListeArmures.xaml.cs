using CinqAnneaux.Data;
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
	/// Logique d'interaction pour FicheListeArmures.xaml
	/// </summary>
	public partial class FicheListeArmures : UserControl, IFicheListe<ArmureModel> {
		public FicheListeArmures() {
			InitializeComponent();
		}
		public IEnumerable<ArmureModel> Items {
			get {
				return xArmures.ItemsSource.Cast<ArmureModel>();
			}
			set {
				xArmures.ItemsSource = value;
			}
		}
		public IEnumerable<ArmureModel> SelectedItems {
			get { return xArmures.SelectedItems.Cast<ArmureModel>(); }
		}

		private void xArmures_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			xArmuresView.ItemsSource = xArmures.SelectedItems;
		}
	}
}
