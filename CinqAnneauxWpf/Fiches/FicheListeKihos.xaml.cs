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
	/// Logique d'interaction pour FicheListeKihos.xaml
	/// </summary>
	public partial class FicheListeKihos : UserControl, IFicheListe<KihoModel> {
		public FicheListeKihos() {
			InitializeComponent();
		}

		public IEnumerable<KihoModel> Items {
			get { return xKihos.ItemsSource.Cast<KihoModel>(); }

			set { xKihos.ItemsSource = value; }
		}

		public IEnumerable<KihoModel> SelectedItems {
			get { return xKihos.SelectedItems.Cast<KihoModel>(); }
		}

		private void xKihos_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			KihoModel kiho = (KihoModel)xKihos.SelectedItem;
			if(kiho == null) {
				xKihoView.Visibility = Visibility.Hidden;
				return;
			}
			xKihoView.Visibility = Visibility.Visible;
			xKihoView.DataContext = kiho;
			xAtemiLabel.Visibility = kiho.UseAtemi ? Visibility.Visible:Visibility.Collapsed;
        }
	}
}
