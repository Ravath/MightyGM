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
	/// Logique d'interaction pour FicheListeObjets.xaml
	/// </summary>
	public partial class FicheListeObjets : UserControl, IFicheListe<ObjetModel> {
		public FicheListeObjets() {
			InitializeComponent();
		}
		public IEnumerable<ObjetModel> Items {
			get {
				return xObjets.ItemsSource.Cast<ObjetModel>();
			}
			set {
				xObjets.ItemsSource = value;
            }
		}
		public IEnumerable<ObjetModel> SelectedItems {
			get { return xObjets.SelectedItems.Cast<ObjetModel>(); }
		}

		private void xObjets_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			xObjetView.ItemsSource = xObjets.SelectedItems;
		}
	}
}
