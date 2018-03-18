using CoreWpf;
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
using Core.Contexts;
using CinqAnneaux.Data;

namespace CinqAnneauxWpf.Fiches
{
	/// <summary>
	/// Logique d'interaction pour FicheListeAncetres.xaml
	/// </summary>
	public partial class FicheListeAncetres : UserControl, IFicheCandidate
	{
		public FicheListeAncetres()
		{
			InitializeComponent();
		}

		public string FicheName { get { return "Ancetres"; } }
		public UserControl Control { get { return this; } }

		public void Afficher(IGlobalContext c)
		{
			xList.ItemsSource = c.Data.GetTable<AncetreModel>();
		}

		private void Opportunity_selection(object sender, SelectionChangedEventArgs e)
		{
			xSelectedView.DataContext = xList.SelectedItem;
		}
	}
}
