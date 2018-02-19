using MightyGmCtrl;
using MightyGmWPF.Tabs;
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

namespace MightyGmWPF {
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		public Context Context { get; set; }

		public MainWindow() {
            Context = Context.MightyGmContext("Wpf");
			InitializeComponent();

			//création dynamique des onglets
			xRawData.Content = new TabRawData(Context);
			xFiches.Content = new TabFiches(Context);
			xCreators.Content = new TabCreateurs(Context);
			xParameters.Content = new TabParameters(Context);
			xRessources.Content = new TabRessources(Context);

			Context.ReportManager.EndOfProcessEvent += EndOfProcessReport;
		}

		public void EndOfProcessReport(string procName, bool success)
		{
			if (success)
			{
				MessageBox.Show(procName + " : Finished");
			}
			else
			{
				MessageBox.Show(procName + " : Failed");
			}
		}
	}
}
