using CoreWpf.UI;
using Shadowrun5.JdrCore.Agents;
using Shadowrun5.Data;
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

namespace Shadowrun5Wpf.Fiches {
	/// <summary>
	/// Logique d'interaction pour FicheEsprit.xaml
	/// </summary>
	public partial class FicheEsprit : UserControl, IFiche {

		public FicheEsprit() {
			InitializeComponent();
			DataContext = this;
		}

		private Esprit _esprit;

		public Esprit Esprit {
			get { return _esprit; }
			set { _esprit = value;
				SetAffichage(value);
            }
		}

		private void SetAffichage(Esprit es ) {
			xName.Text = "Type d'esprit: " + es.Name;
			xPuissance.Value = es.PuissanceEsprit;
		}

		public object SelectedObject {
			get {
				return Esprit;
            }

			set {
				if(value is Esprit)
					Esprit = (Esprit)value ;
				else if(value is SpiritModel || value is SpiritExemplar) {
					if(Esprit == null)
						Esprit = new Esprit();
					if(value is SpiritModel)
						Esprit.SetModel((SpiritModel)value);
					else
						Esprit.SetExemplaire((SpiritExemplar)value);
					SetAffichage(Esprit);
				}
				if(cfAttributs.SelectedObject == null)
					cfAttributs.SelectedObject = Esprit.Caracteristiques;
				cfCompetences.SelectedObject = null;
                cfCompetences.SelectedObject = Esprit.Competences;
            }
		}
	}
}
