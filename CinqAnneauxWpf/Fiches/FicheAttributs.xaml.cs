using CinqAnneaux.JdrCore.Attributs;
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
	/// Logique d'interaction pour FicheAttributs.xaml
	/// </summary>
	public partial class FicheAttributs : UserControl, IFiche {

		private Attributs _attributs;

		public Attributs Attributs {
			get { return _attributs; }
			set {
				if(_attributs == value) { return; }
				_attributs = value;
				//attributs
				xAgilite.Value = value.Agilite;
				xConstitution.Value = value.Constitution;
				xReflexes.Value = value.Reflexes;
				xForce.Value = value.Force;
				xIntelligence.Value = value.Intelligence;
				xIntuition.Value = value.Intuition;
				xPerception.Value = value.Perception;
				xVolonte.Value = value.Volonte;
				//anneaux
				xAir.Value = value.Air;
				xTerre.Value = value.Terre;
				xFeu.Value = value.Feu;
				xEau.Value = value.Eau;
				//vide
				// TODO zazd
			}
		}

		public FicheAttributs() {
			InitializeComponent();
		}

		public object SelectedObject {
			get {
				return Attributs;
            }

			set {
				if(value is Attributs) {
					Attributs = (Attributs)value;
				}
			}
		}
	}
}
