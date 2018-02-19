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
	/// Logique d'interaction pour FicheAttaques.xaml
	/// Fiche pour les attaques
	/// </summary>
	public partial class FicheAttaques : UserControl, IFiche {
		public FicheAttaques() {
			InitializeComponent();
		}

		public object SelectedObject {
			get {
				// todo
				throw new NotImplementedException();
			}

			set {
				throw new NotImplementedException();
			}
		}
	}
}
