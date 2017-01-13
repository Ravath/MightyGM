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

namespace MightyGM.Tabs {
	/// <summary>
	/// Logique d'interaction pour TabTabletop.xaml
	/// </summary>
	public partial class TabTabletop : UserControl {
		public Context Context { get; }
		public TabTabletop( Context context ) {
			InitializeComponent();
			Context = context;
		}
	}
}
