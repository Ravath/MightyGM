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
	/// Logique d'interaction pour FicheListeKatas.xaml
	/// </summary>
	public partial class FicheListeKatas : UserControl, IFicheListe<KataModel> {
		public FicheListeKatas() {
			InitializeComponent();
		}

		public IEnumerable<KataModel> Items {
			get { return xKatas.ItemsSource.Cast<KataModel>(); }

			set { xKatas.ItemsSource = value; }
		}

		public IEnumerable<KataModel> SelectedItems {
			get { return xKatas.SelectedItems.Cast<KataModel>(); }
		}

		private void xKatas_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			KataModel kata = (KataModel)xKatas.SelectedItem;
			if(kata == null) {
				xKataView.Visibility = Visibility.Hidden;
				return;
			}
			xKataView.Visibility = Visibility.Visible;
            xKataView.DataContext = kata;
			xEcoles.Children.Clear();
			if(kata.Ecoles.Count() == 0) {
				xEcoles.Children.Add(new TextBlock() { Text = "Toutes" });
            } else {
				foreach(EcoleModel ecole in kata.Ecoles) {
					xEcoles.Children.Add(new TextBlock() { Text = ecole.Name });
				}
			}
        }
	}
}
