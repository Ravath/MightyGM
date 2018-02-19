using CinqAnneaux.JdrCore.Agent;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinqAnneauxWpf.Fiches {
	/// <summary>
	/// Affiche les attaques d'un agent.
	/// </summary>
	public class FicheListeAttaques : UserControl, IFiche {

		private StackPanel _spAttaques = new StackPanel();
		private Agent _agent;

		public FicheListeAttaques() {
			Content = _spAttaques;
		}
		/// <summary>
		/// Traite un agent.
		/// </summary>
		public object SelectedObject {
			get {
				throw new NotImplementedException();
			}

			set {
				SelectedAgent = value as Agent;
            }
		}
		public Agent SelectedAgent {
			get {
				return _agent;
			}
			set {
				if(value == _agent) { return; }
				_agent = value;
				RefreshList();
            }
		}
		public void RefreshList() {
			_spAttaques.Children.Clear();
			if(_agent == null) { return; }

			foreach(var att in _agent.Attaques) {
				//create ItemDisplay
				StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
				RKPoolControleur jatt = new RKPoolControleur() {
					RkPool = att.JetAttaque,
					Margin = new System.Windows.Thickness(5, 0, 5, 0)
				};
				RKPoolControleur datt = new RKPoolControleur() {
					RkPool = att.Degats,
					Margin = new System.Windows.Thickness(5, 0, 5, 0)
				};
				sp.Children.Add(new TextBlock() {
					Text = att.Name,
					Margin = new System.Windows.Thickness(5, 0, 5, 0)
				});
				sp.Children.Add(new TextBlock() { Text = att.Action.ToString() });
				sp.Children.Add(jatt);
				sp.Children.Add(new TextBlock() { Text = "Degats:" });
				sp.Children.Add(datt);
				//add to list
				_spAttaques.Children.Add(sp);
            }
		}
	}
}
