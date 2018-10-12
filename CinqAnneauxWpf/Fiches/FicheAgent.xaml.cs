using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.JdrCore.Objets;
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
	/// Logique d'interaction pour FicheAgent.xaml
	/// </summary>
	public partial class FicheAgent : UserControl, IFiche {
		private Agent _agent;
		private FicheListCreaturePouvoir xPouvoirsCreature = new FicheListCreaturePouvoir();

		public Agent Agent {
			get { return _agent; }
			set {
				if(_agent == value) { return; }
				_agent = value;
				xAttributs.Attributs = value.Attributs;
				xCompetences.Liste = value.Competences;
                xPouvoirsCreature.SelectedObject = value.TraitsCreature;
				xInitiative.SetRollPool( value.Initiative );
				xVie.Vie = Agent.Vie;
				xAttaques.SelectedAgent = value;
            }
		}
		public FicheAgent() {
			InitializeComponent();
			//Agent = new Agent();
			//Liste pouvoirs
			ModifyControlOverlay mco = new ModifyControlOverlay(xPouvoirsCreature) {
				MinHeight = 100,
				HorizontalAlignment = HorizontalAlignment.Stretch
			};
			//ajouter au stackpanel
			xPouvoirsPanel.Children.Add(mco);
        }

		public object SelectedObject {
			get {
				return Agent;
			}

			set {
				if(value is Agent) {
					Agent = (Agent)value;
				} else if (value is PersonnageModel) {
					Agent ag = Agent;
					if(value is CreatureModel cm) {
						if(!(ag is Figurant)) {
							ag = new Figurant(cm);
						}
						else
						{
							ag.SetPersonnage(cm);
						}
					} else {//value is PJModel
						PJModel perso = (PJModel)value;
						if (!(ag is Personnage)) {
							ag = new Personnage(perso);
						}
						else
						{
							ag.SetPersonnage(perso);
						}
					}
					Agent = ag;
					xCompetences.SetCompetences();
					xVie.Vie = Agent.Vie;
					xAttaques.RefreshList();
					RefreshArmure();
					// Description
					xDescription.Text = Agent.EtatCivil.Description;
				}
			}
		}
		private void RefreshArmure() {
			xArmure.Children.Clear();
			if(_agent == null) { return; }
			//add the armor stats
			Armure arm = _agent.Armures.Equiped.FirstOrDefault();
			if(arm == null) {
				xArmure.Children.Add(new TextBlock() { Text = "none" });
			} else {
				xArmure.Children.Add(new TextBlock() { Text = arm.Name });
				xArmure.Children.Add(new TextBlock() { Text = "ND:", Margin = new Thickness(5,0,1,0) });
				xArmure.Children.Add(new TextBlock() { Text = arm.ND.TotalValue.ToString() });
				xArmure.Children.Add(new TextBlock() { Text = "Reduction:", Margin = new Thickness(5, 0, 1, 0) });
				xArmure.Children.Add(new TextBlock() { Text = arm.Reduction.TotalValue.ToString() });
			}

        }
	}
}
