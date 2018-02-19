using CinqAnneaux.JdrCore;
using CoreWpf.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinqAnneauxWpf.Fiches {
	public class RKPoolControleur : UserControl {

		private AbsRKPool _pool;
		private ValueControler _vcr = new ValueControler();
		private ValueControler _vck = new ValueControler();

		public RKPoolControleur() {
			StackPanel sp = new StackPanel() {
				Orientation = Orientation.Horizontal
			};
			sp.Children.Add(_vcr);
			sp.Children.Add(new TextBlock() { Text = "g" });
			sp.Children.Add(_vck);

			Content = sp;
		}

		public void SetRKPool( AbsRKPool pool ) {
			_pool = pool;
			_vcr.Value = pool.NumberIValue;
			_vck.Value = pool.KeepIValue;
		}

		public AbsRKPool RkPool {
			get { return _pool; }
			set { SetRKPool(value); }
		}
	}
}
