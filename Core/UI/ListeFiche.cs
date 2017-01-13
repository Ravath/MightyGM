using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Core.UI {
	public class ListeFiche<T> : UserControl {

		private IFiche _afficheur;
		private ScrollViewer _ficheContainer;
		private ListView _dataList;

		public event SelectionChangedEventHandler SelectionChanged;

		public IFiche Afficheur {
			private get { return _afficheur; }
			set {
				_afficheur = value;
				_ficheContainer.Content = value;
            }
		}

		public T SelectedItem {
			get { return (T)_dataList.SelectedItem; }
		}

		public IEnumerable<T> SelectedItems {
			get { return _dataList.SelectedItems.Cast<T>(); }
		}

		public ListeFiche() {
			DockPanel dp = new DockPanel();
			_dataList = new ListView();
			_ficheContainer = new ScrollViewer();
			_ficheContainer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			dp.Children.Add(_dataList);
			dp.Children.Add(_ficheContainer);
			DockPanel.SetDock(_dataList, Dock.Left);
			this.Content = dp;
			//évènements
			_dataList.SelectionChanged += _dataList_SelectionChanged;
        }

		private void _dataList_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			Afficheur.SelectedObject = SelectedItem;
			if(SelectionChanged != null)
				SelectionChanged(this, e);
        }

		public void SetDataSource( IEnumerable<T> data ) {
			_dataList.ItemsSource = data;
        }
	}
}
