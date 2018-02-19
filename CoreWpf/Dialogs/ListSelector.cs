using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoreWpf.Dialogs {
	public class ListSelector : UserControl {

		private ListSelectorControler _lsc = new ListSelectorControler();
		private System.Windows.Window _window;

		#region Properties
		public IEnumerable<IDataObject> SelectedModels {
			get { return _lsc.SelectedItems; }
		}
		public IEnumerable<IDataObject> ListModels {
			get { return _lsc.ItemsList; }
		}
		public Database Data {
			get { return _lsc.Data; }
			set { _lsc.Data = value; }
		}
		public bool Single { get; set; }
		#endregion

		#region Init
		/// <summary>
		/// Dafault constructor.
		/// </summary>
		public ListSelector() : base() {
			base.DataContext = this;
			//stack des boutons
			StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
			Button bcancel = new Button() { Content = "_Cancel", Margin = new System.Windows.Thickness(2, 0, 0, 0) };
			Button bdone = new Button() { Content = "_Done", Margin = new System.Windows.Thickness(2, 0, 0, 0) };
			Button bcreate = new Button() { Content = "Create", Margin = new System.Windows.Thickness(2, 0, 0, 0) };
			bcancel.Click += Cancel;
			bdone.Click += Done;
			bcreate.Click += Create;
			sp.Children.Add(bcancel);
			sp.Children.Add(bdone);
			sp.Children.Add(bcreate);
			//dockpanel général
			DockPanel dp = new DockPanel();
			DockPanel.SetDock(sp, Dock.Bottom);
			dp.Children.Add(sp);
			dp.Children.Add(_lsc);
			Content = dp;
		}
		/// <summary>
		/// Load the list of objects.
		/// </summary>
		/// <param name="t">Data list.</param>
		public void Load( Type t ) {
			_lsc.Load(t);
		}
		/// <summary>
		/// Load the list of objects and set some of them as selected.
		/// </summary>
		/// <param name="t">Data list.</param>
		/// <param name="preselected">Selected items</param>
		public void Load( Type t, IEnumerable<IDataObject> preselected ) {
			_lsc.Load(t, preselected);
		} 
		#endregion

		/// <summary>
		/// Open a window and returns the selected list at closure.
		/// </summary>
		/// <returns></returns>
		public ListSelectorResult GetSelection() {
			System.Windows.Window w = new System.Windows.Window();
			w.WindowStyle = System.Windows.WindowStyle.ToolWindow;
			w.Title = "Liste";
			w.Content = this;
			_window = w;
			w.ShowDialog();
			return new ListSelectorResult() {
				Data = _lsc.SelectedItems
			};
		}

		#region Events boutons
		private void Done( object sender, System.Windows.RoutedEventArgs e ) {
			_window.Close();
		}

		private void Cancel( object sender, System.Windows.RoutedEventArgs e ) {
			_lsc.ClearSelection();
			_window.Close();
		}

		private void Create( object sender, System.Windows.RoutedEventArgs e ) {
			//TODO : ouvrir une fenêtre pour créer un objet.
		} 
		#endregion
	}
}
