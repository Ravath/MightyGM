using CinqAnneaux.Data;
using Core;
using Core.Data;
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
using CoreWpf;
using Core.Contexts;

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheAvantageDesavantage.xaml
	/// </summary>
	public partial class FicheAvantageDesavantage : UserControl, IFicheCandidate {

		#region Members
		private Database _data;
		private IEnumerable<AvantageModel> _dataAvantage;
		private IEnumerable<DesavantageModel> _dataDesavantage;
		#endregion

		#region Init
		public FicheAvantageDesavantage() {
			InitializeComponent();
		}
		#endregion

		#region Implementation Fiche Candidate
		public UserControl Control {
			get { return this; }
		}

		public string FicheName {
			get { return "Avantages"; }
		}
		public void SetData( Database data ) {
			_data = data;
			_dataAvantage = _data.GetTable<AvantageModel>().OrderBy(n => n.Name);
			_dataDesavantage = _data.GetTable<DesavantageModel>().OrderBy(n => n.Name);
			xAvantages.ItemsSource = _dataAvantage;
			xDesavantages.ItemsSource = _dataDesavantage;
		}
		public void Afficher( IGlobalContext c ) {
			SetData(c.Data);
		}
		#endregion

		private void xAvantages_Selected( object sender, RoutedEventArgs e ) {
			xAvantage.ItemsSource = xAvantages.SelectedItems;
		}

		private void xDesavantages_Selected( object sender, RoutedEventArgs e ) {
			xDesavantage.ItemsSource = xDesavantages.SelectedItems;
		}
	}
}
