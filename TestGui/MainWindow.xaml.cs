using MightyGmCtrl;
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

namespace TestGui {
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			try {
				//Context c = new Context();
				//InitializeComponent();
				//this.DataContext = this;

				BitmapApp.Program.Main(new string[] { });

				//xList.Data = c.Data;
				//xList.Load(typeof(AbsclanModel));
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
        }
	}
}
