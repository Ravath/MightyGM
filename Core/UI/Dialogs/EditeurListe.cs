using Core.Data;
using Core.UI;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Core.UI.Dialogs {
	/// <summary>
	/// Control loading data from the database, and permiting to edit, to add or to delete.
	/// </summary>
	/// <typeparam name="D">Type of the edited data.</typeparam>
	public class EditeurListe<D> : UserControl where D : class, new(){

		private bool _editingNew = false;
		private D _new;
		private Fiche xFiche;
		private ListView xList;
		private List<D> _items;
		private Database _db;

		public D Selected {
			get {
				return xList.SelectedItem as D;
            }
		}

		public EditeurListe( Database db ) {
			_db = db;
			//init
			DockPanel dp = new DockPanel();
			xList = new ListView();
			xList.MinWidth = 100;
			StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
			Button xDelete = new Button() { Content = "Delete" };
			Button xNew = new Button() { Content = "New", Margin = new System.Windows.Thickness(10,0,0,0) };
			Button xSave = new Button() { Content = "Save", Margin = new System.Windows.Thickness(5, 0, 0, 0) };
			xFiche = new Fiche();
			xFiche.ReadOnly = false;
			//construction
			sp.Children.Add(xDelete);
			sp.Children.Add(xNew);
			sp.Children.Add(xSave);
			DockPanel.SetDock(xList, Dock.Left);
			DockPanel.SetDock(sp, Dock.Bottom);
			dp.Children.Add(xList);
			dp.Children.Add(sp);
			dp.Children.Add(xFiche);
			this.Content = dp;
			//énénements
			xNew.Click += XNew_Click;
			xSave.Click += XSave_Click;
			xDelete.Click += XDelete_Click;
			xList.SelectionChanged += Lv_SelectionChanged;
			//récupérer items
			RefreshData();
        }

		private void XDelete_Click( object sender, System.Windows.RoutedEventArgs e ) {
			if(_editingNew) {
				_new = null;
				xFiche.SelectedObject = null;
				_editingNew = false;
			} else {
				D s = Selected;
				_items.Remove(s);
				xFiche.SelectedObject = null;
				xList.ItemsSource = null;
				xList.ItemsSource = _items;
				_db.Delete<D>(s);
			}
		}

		private void Lv_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			_editingNew = false;
			xFiche.SelectedObject = Selected;
		}

		private void XSave_Click( object sender, System.Windows.RoutedEventArgs e ) {
			try {
				if(_editingNew) {
					_db.Insert<D>(_new);
					_editingNew = false;
					/* refreshing is the only way to have accurate data
					 * because we don't now if there are serial id, ...
					*/
					RefreshData();
				} else {
					_db.Update<D>(Selected);
				}
			} catch(Exception ex) {
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
		}

		private void XNew_Click( object sender, System.Windows.RoutedEventArgs e ) {
			_editingNew = true;
			_new = new D();
			xFiche.SelectedObject = _new;
		}

		public void RefreshData() {
			_items = _db.GetTable<D>().ToList();
			if(_items == null)
				_items = new List<D>();
			xList.ItemsSource = _items;
		}
	}
}
