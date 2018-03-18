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
	/// Logique d'interaction pour FicheListeArmes.xaml
	/// </summary>
	public partial class FicheListeArmes : UserControl, IFicheListe<ArmeModel> {
		private IEnumerable<ArmeModel> _data;
		public FicheListeArmes() {
			InitializeComponent();
		}
		public IEnumerable<ArmeModel> Items {
			get {
				return _data;
            }
			set {
				_data = value;
				SetTree(xArmes,value);
			}
		}
		public IEnumerable<ArmeModel> SelectedItems {
			get { yield return xArmes.SelectedItem as ArmeModel; }
		}

		private void xArmes_SelectedItemChanged( object sender, RoutedPropertyChangedEventArgs<object> e ) {
			ArmeModel arme = xArmes.SelectedItem as ArmeModel;
			if(arme == null) {
				xArmeView.Visibility = Visibility.Collapsed;
            } else {
				xArmeView.Visibility = Visibility.Visible;
				xArmeView.DataContext = arme;
				//cas particulier cout
				if(arme.CoutVal == -1) {
					xCout.Text = "Cout: Undefined";
					xMonnaie.Visibility = Visibility.Collapsed;
				} else {
					xCout.Text = "Cout: " + arme.Cout;
					xMonnaie.Visibility = Visibility.Visible;
				}
				//mots clefs
				xMcPaysan.Visibility = arme.Paysan ? Visibility.Visible : Visibility.Collapsed;
				xMcSamurai.Visibility = arme.Samurai ? Visibility.Visible : Visibility.Collapsed;
				//cas arc, portee,...
				xDegats.Visibility = (arme.Type == TypeArme.Arc) ? Visibility.Collapsed : Visibility.Visible;
				xForce.Visibility = (arme.Force == 0) || (arme.Force == null) ? Visibility.Collapsed : Visibility.Visible;
				xPortee.Visibility = (arme.Portee == 0) || (arme.Portee == null) ? Visibility.Collapsed : Visibility.Visible;
				xForceReq.Visibility = (arme.ForceRequise == 0) ? Visibility.Collapsed : Visibility.Visible;
				//cas spécificités
				xSpecList.Visibility = (arme.Special.Count() > 0) ? Visibility.Visible : Visibility.Collapsed;
			}
		}
		private void SetTree( TreeView tr, IEnumerable<ArmeModel> armes ) {
			tr.ItemsSource = null;
			tr.Items.Clear();
			List<ArmesParCategories> ac = new List<ArmesParCategories>();
			foreach(var catArmes in armes.GroupBy<ArmeModel, TypeArme>(a => a.Type)) {
				ac.Add(new ArmesParCategories(catArmes));
			}
			tr.ItemsSource = ac;
		}
	}
	public class ArmesParCategories {
		public TypeArme Type { get; set; }
		public IEnumerable<ArmeModel> Armes { get; set; }
		public ArmesParCategories( IGrouping<TypeArme, ArmeModel> group ) {
			Type = group.Key;
			Armes = group;
		}
	}
}
