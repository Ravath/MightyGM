using CoreWpf.UI;
using Shadowrun5.JdrCore.Attributs;
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
	/// Logique d'interaction pour FicheAgent.xaml
	/// </summary>
	public partial class FicheAttributs : UserControl, IFiche {
		public FicheAttributs() {
			InitializeComponent();
			DataContext = this;
		}
		private Caracteristiques _agent;
		public Caracteristiques Agent {
			get { return _agent; }
			set {
				if(_agent == value) { return; }
				_agent = value;
                xConstitution.Value = value.Constitution;
				xForce.Value = value.Force;
				xReaction.Value = value.Reaction;
				xAgilite.Value = value.Agilite;
				xIntuition.Value = value.Intuition;
				xLogique.Value = value.Logique;
				xCharisme.Value = value.Charisme;
				xVolonte.Value = value.Volonte;
				xEssence.Value = value.Essence;
				xChance.Value = value.Chance.Max;
				xMagie.Value = value.Puissance;
				xLimMen.Value = value.LimiteMentale;
				xLimPhi.Value = value.LimitePhysique;
				xLimSoc.Value = value.LimiteSociale;
				xIni.Value = value.Initiative;
				xInitAst.Value = value.InitiativeAstrale;
				xInitmat.Value = value.InitiativeMatricielle;
				if(value.Agent.Pratiquant == Data.PratiquantMagie.Technomancien) {
					SetResonance();
				} else {
					SetMagie();
				}
			}
		}

		public object SelectedObject {
			get {
				return Agent;
			}

			set {
				Agent = (Caracteristiques)value;
			}
		}

		public void SetMagie() {
			xMag.Text = "Mag";
		}
		public void SetResonance() {
			xMag.Text = "Res";
		}
	}
}
