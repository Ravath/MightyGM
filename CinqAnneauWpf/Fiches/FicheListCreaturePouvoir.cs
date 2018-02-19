using CinqAnneaux.JdrCore.Traits;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinqAnneauxWpf.Fiches {
	public class FicheListCreaturePouvoir : ModifyControlNamedList {

		#region Init
		public FicheListCreaturePouvoir() {
			Afficheur = new pFichePouvoirCreature();
        }

		//public object SelectedObject {
		//	get { return _traits; }

		//	set {
		//		_traits = (ListeTraitsCreature)value;
		//	}
		//}
		#endregion

		public override bool ValidChange() {
			return true;
		}
	}

	internal class pFichePouvoirCreature : UserControl, IFiche {
		private TraitCreature _pc;
		private TextBlock _tb = new TextBlock() {
			TextWrapping = System.Windows.TextWrapping.Wrap,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
			Margin = new System.Windows.Thickness(5, 0, 0, 5),
			FontSize = 12
		};

		public object SelectedObject {
			get { return _pc; }
			set {
				_pc = (TraitCreature)value;
				Refresh();
            }
		}

		public pFichePouvoirCreature() {
			Content = _tb;
		}

		private void Refresh() {
			_tb.Text = _pc?.Description ?? "";
		}
	}
}
