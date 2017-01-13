using StarWars.Data;
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

namespace MightyGM {
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		public Context Context { get; set; }

		public MainWindow() {
			LinqToDB.Common.Configuration.Linq.GenerateExpressionTest = true;
            Context = new Context();
			InitializeComponent();
			//onglets
			xRawData.Content = Context.TabRawData;
			xFiches.Content = Context.TabFiches;
			xCreators.Content = Context.TabCreateurs;
			xScenarii.Content = Context.TabScenarii;
			xTabletop.Content = Context.TabTabletop;
			xAudio.Content = Context.TabMusique;
			xParameters.Content = Context.TabParameters;
			xNetwork.Content = Context.TabNetwork;
		}
	}
}
