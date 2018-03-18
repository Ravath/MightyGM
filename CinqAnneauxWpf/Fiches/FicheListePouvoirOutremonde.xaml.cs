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
	/// Logique d'interaction pour FicheListePouvoirOutremonde.xaml
	/// </summary>
	public partial class FicheListePouvoirOutremonde : UserControl, IFicheListe<PouvoirOutremondeModel> {
		public FicheListePouvoirOutremonde() {
			InitializeComponent();
		}

		public IEnumerable<PouvoirOutremondeModel> Items {
			get { return xPouvoirs.ItemsSource.Cast<PouvoirOutremondeModel>(); }

			set { xPouvoirs.ItemsSource = value; }
		}

		public IEnumerable<PouvoirOutremondeModel> SelectedItems {
			get { return xPouvoirs.SelectedItems.Cast<PouvoirOutremondeModel>(); }
		}

		private void xPouvoirs_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			PouvoirOutremondeModel pouvoir = (PouvoirOutremondeModel)xPouvoirs.SelectedItem;
			if(pouvoir == null) {
				xPouvoirView.Visibility = Visibility.Hidden;
			} else {
				xPouvoirView.Visibility = Visibility.Visible;
				xPouvoirView.DataContext = pouvoir;
			}
		}
	}
}
