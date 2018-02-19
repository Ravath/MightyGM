using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Ecoles;
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
	/// Logique d'interaction pour FicheClan.xaml
	/// </summary>
	public partial class FicheClan : UserControl, IFiche {

		private Clan clan;

		public FicheClan() {
			InitializeComponent();
		}

		public Clan SelectedClan {
			get { return clan; }
			set {
				clan = value;
				Refresh();
            }
		}

		public object SelectedObject {
			get {
				return SelectedClan;
			}

			set {
				if(value is ClanModel) {
					Clan e = new Clan();
					e.SetModel((ClanModel)value);
					SelectedClan = e;
				} else if(value is Clan) {
					SelectedClan = (Clan)value;
				} else {
					if(value == null) { SelectedClan = null; }
					else
						throw new ArgumentException("Can't handle argument of type " + value.GetType());
				}
			}
		}

		internal void Refresh() {
			xName.Text = SelectedClan?.Name;
			xDescription.Text = SelectedClan?.Description;
		}
	}
}
