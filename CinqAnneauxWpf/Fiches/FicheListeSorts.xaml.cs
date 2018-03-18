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
	/// Logique d'interaction pour FicheListeSorts.xaml
	/// </summary>
	public partial class FicheListeSorts : UserControl, IFicheListe<AbsSortModel> {
		public FicheListeSorts() {
			InitializeComponent();
		}

		public IEnumerable<AbsSortModel> Items {
			get {
				return xSorts.ItemsSource.Cast<AbsSortModel>();
			}

			set {
				xSorts.ItemsSource = value.OrderBy(s=>s.Maitrise);
            }
		}

		public IEnumerable<AbsSortModel> SelectedItems {
			get {
				return xSorts.SelectedItems.Cast<AbsSortModel>();
			}
		}

		private void xSorts_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			//xViewSort.ItemsSource = xSorts.SelectedItems;
			if(xSorts.SelectedItem == null) {
				xViewSort.Visibility = Visibility.Collapsed;
			} else {
				xViewSort.Visibility = Visibility.Visible;
				xViewSort.DataContext = xSorts.SelectedItem;
				AbsSortModel asm = (AbsSortModel)xSorts.SelectedItem;
				//rank affects range
				if(asm.PorteeXRang) {
					xRgPortee.Visibility = Visibility.Visible;
                }else {
					xRgPortee.Visibility = Visibility.Collapsed;
				}
				//rank affects duration
				if(asm.DureeXRang) {
					xRgDuree.Visibility = Visibility.Visible;
				} else {
					xRgDuree.Visibility = Visibility.Collapsed;
				}
				//rank affects area of effect
				if(asm.ZoneXRang) {
					xRgZone.Visibility = Visibility.Visible;
				} else {
					xRgZone.Visibility = Visibility.Collapsed;
				}
				//uses concentration
				if(asm.Concentration) {
					xRgConcentration.Visibility = Visibility.Visible;
					if(asm.Duree == Duree.Instantane) {
						xDuree.Visibility = Visibility.Collapsed;
						xDureeAndConcentation.Visibility = Visibility.Collapsed;
                    } else {
						xDuree.Visibility = Visibility.Visible;
						xDureeAndConcentation.Visibility = Visibility.Visible;
					}
                } else {
					xRgConcentration.Visibility = Visibility.Collapsed;
					xDuree.Visibility = Visibility.Visible;
					xDureeAndConcentation.Visibility = Visibility.Collapsed;
				}
			}
		}
	}
}
