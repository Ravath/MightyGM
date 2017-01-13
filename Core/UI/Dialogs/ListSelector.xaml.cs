using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Core.UI.Dialogs {

	/// <summary>
	/// Logique d'interaction pour ListSelector.xaml
	/// </summary>
	public partial class ListSelector : AbsListSelector {

		#region Members
		private List<IDataObject> _init = new List<IDataObject>();
		private List<IDataObject> _selected = new List<IDataObject>();
		private List<IDataObject> _list = new List<IDataObject>();
		private Database _context;
		private System.Windows.Window _window;
		#endregion

		#region Properties
		public IEnumerable<IDataObject> SelectedModels {
			get { return _selected; }
		}
		public IEnumerable<IDataObject> ListModels {
			get { return _list; }
		}
		public Database Data {
			get { return _context; }
			set { _context = value; }
		}
		public bool Single { get; set; }
		#endregion

		#region Init
		/// <summary>
		/// Dafault constructor.
		/// </summary>
		public ListSelector( ) : base() {
			InitializeComponent();
			base.DataContext = this;
			xFiche.ReadOnly = true;
			xFiche.DisplayId = false;
        }
		/// <summary>
		/// Load the list of objects.
		/// </summary>
		/// <param name="t">Data list.</param>
		public void Load( Type t ) {
			_selected.Clear();
			_list.Clear();
			IEnumerable<object> ds = Data.GetDataTable(t);
			_list.AddRange(ds.Cast<IDataObject>());
            MajLists();
		}
		/// <summary>
		/// Load the list of objects and set some of them as selected.
		/// </summary>
		/// <param name="t">Data list.</param>
		/// <param name="preselected">Selected items</param>
		public void Load( Type t, IEnumerable<IDataObject> preselected ) {
			Load(t);
			_selected.AddRange(preselected);
			_init.AddRange(preselected);
			foreach(IDataObject data in preselected) {
				_list.RemoveAll(p => p.Id == data.Id);
			}
			MajLists();
		}
		#endregion

		#region Events
		protected void Add_Click( object sender, System.Windows.RoutedEventArgs e ) {
			AddSelectedItemsToSelection();
		}

		protected void Remove_Click( object sender, System.Windows.RoutedEventArgs e ) {
			RemoveSelectedItemsFromSelection();
		}

		private void xUnselectedList_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			xFiche.SelectedObject = ((ListView)sender).SelectedItem;
		}
		private void SelectedList_MouseDoubleClick( object sender, MouseButtonEventArgs e ) {
			RemoveSelectedItemsFromSelection();
		}

		private void List_MouseDoubleClick( object sender, MouseButtonEventArgs e ) {
			AddSelectedItemsToSelection();
		}
		#endregion

		#region Collections
		protected void AddToSelected( IDataObject dm ) {
			_selected.Add(dm);
			_list.Remove(dm);
		}
		protected void RemoveFromSelected( IDataObject dm ) {
			_selected.Remove(dm);
			_list.Add(dm);
		}
		#endregion

		protected virtual void AddSelectedItemsToSelection() {
			if(Single) {
				IDataObject dm = (IDataObject)xUnselectedList.SelectedValue;
				if(dm == null) { return; }
				ClearSelection();
				AddToSelected(dm);
			} else {
				IDataObject[] dm = xUnselectedList.SelectedItems.Cast<IDataObject>().ToArray();
				foreach(IDataObject data in dm) {
					AddToSelected(data);
				}
			}
			MajLists();
		}
		protected virtual void RemoveSelectedItemsFromSelection() {
			IDataObject[] dm = xSelectedList.SelectedItems.Cast<IDataObject>().ToArray();
			foreach(IDataObject data in dm) {
				RemoveFromSelected(data);
			}
			MajLists();
		}
		/// <summary>
		/// Met à jour l'affichage des listes.
		/// </summary>
		protected virtual void MajLists() {
			xSelectedList.ItemsSource = null;
			xUnselectedList.ItemsSource = null;
			xSelectedList.ItemsSource = SelectedModels;
			xUnselectedList.ItemsSource = ListModels;
		}
		protected void ClearSelection() {
			IDataObject[] dm = _selected.ToArray();
			foreach(IDataObject data in dm) {
				RemoveFromSelected(data);
			}
		}
		/// <summary>
		/// Open a window and returns the selected list at closure.
		/// </summary>
		/// <returns></returns>
		public ListSelectorResult GetSelection() {
			System.Windows.Window w = new System.Windows.Window();
			w.Content = this;
			w.WindowStyle = System.Windows.WindowStyle.ToolWindow;
			w.Title = "Liste";
			_window = w;
            w.ShowDialog();
			return new ListSelectorResult() {
				Data = _selected
			};
		}

		private void Done( object sender, System.Windows.RoutedEventArgs e ) {
			_window.Close();
        }

		private void Cancel( object sender, System.Windows.RoutedEventArgs e ) {
			_selected = _init;
			_window.Close();
		}

		private void Create( object sender, System.Windows.RoutedEventArgs e ) {
			//TODO : ouvrir une fenêtre pour créer un objet.
		}
	}
}
