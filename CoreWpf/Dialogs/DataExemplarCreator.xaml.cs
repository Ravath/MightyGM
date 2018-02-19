using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Core.Data;
using System.Reflection;

namespace CoreWpf.Dialogs {
	/// <summary>
	/// Controleur permettant de créer un DataExemplaire en éditant les valeurs  de l'exemplaireet en choisisant  un modèle.
	/// </summary>
	public partial class DataExemplarCreator : UserControl {

		#region Members
		private List<IDataExemplaire> _created = new List<IDataExemplaire>();
		private List<IDataObject> _list = new List<IDataObject>();
		private Database _context;
		private System.Windows.Window _window;
		private Type _exemplarType;
		private Type _modelType;
		#endregion

		#region Properties
		public IEnumerable<IDataObject> ListModels {
			get { return _list; }
		}
		public Database Data {
			get { return _context; }
			set { _context = value; }
		}
		public IDataObject SelectedModel {
			get {
				return (IDataObject) xModel.SelectedObject;
			}
			set {
				xModel.SelectedObject = value;	
			}
		}
		public bool Single { get; set; }
		#endregion

		#region Init
		/// <summary>
		/// Constructeur par défaut.
		/// <param name="t">The DataEmplar Type we want to create.</param>
		/// </summary>
		public DataExemplarCreator( Type t, Database context ) {
			InitializeComponent();
			_context = context;
			xExemplar.ReadOnly = false;
			if(!typeof(IDataExemplaire).IsAssignableFrom(t))
				throw new ArgumentException("t is supposed to be a subtype of IDataExemplar");
			Type parType = t;
			while(parType != null && parType.Name != "DataExemplaire`1") {
				parType = parType.BaseType;
			}
			_modelType = parType.GetGenericArguments()[0];
			_exemplarType = t;
			Load(_modelType);
			MajLists();
			AddNewExemplar();
		}
		/// <summary>
		/// Load the list of objects.
		/// </summary>
		/// <param name="t">Data list.</param>
		private void Load( Type t ) {
			_list.Clear();
			IEnumerable<object> ds = Data.GetDataTable(t);
			_list.AddRange(ds.Cast<IDataObject>());
			MajLists();
		}
		private void AddNewExemplar() {
			ConstructorInfo ci = _exemplarType.GetConstructor(Type.EmptyTypes);
			IDataExemplaire ie =  (IDataExemplaire)ci.Invoke(new Object[] { });
            xExemplar.SelectedObject = ie;
		}
		#endregion

		#region Boutons
		private void Cancel( object sender, System.Windows.RoutedEventArgs e ) {
			_created.Clear();
			_window.Close();
		}

		private void Done( object sender, System.Windows.RoutedEventArgs e ) {
			_created.Add((IDataExemplaire)xExemplar.SelectedObject);
			_window.Close();
		}

		private void Create( object sender, System.Windows.RoutedEventArgs e ) {
			_created.Add((IDataExemplaire)xExemplar.SelectedObject);
			AddNewExemplar();
		}
		#endregion
		
		/// <summary>
		/// Met à jour l'affichage des listes.
		/// </summary>
		protected virtual void MajLists() {
			xListModels.ItemsSource = ListModels;
		}
		/// <summary>
		/// Open a window and returns a list of new exemplars at closure.
		/// </summary>
		/// <returns>A list of DataExemplars.</returns>
		public IEnumerable<IDataExemplaire> GetExemplars() {
			_window = new System.Windows.Window
			{
				Content = this,
				WindowStyle = System.Windows.WindowStyle.ToolWindow,
				Title = "Exemplar List"
			};
			_window.ShowDialog();//show the window and returns here whent it's closed.
			foreach(IDataObject item in _created) {
				Data.Insert(item);
			}
			return _created;
		}

		private void xListModels_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			ListView lv = sender as ListView;
			//((IDataExemplaire)xExemplar.SelectedObject).Model = (Core.Data.IDataModel)sender;
			xModel.SelectedObject = lv.SelectedItem;
			PropertyInfo pi = _exemplarType.GetProperty("Model");
			pi.SetValue(xExemplar.SelectedObject, lv.SelectedItem);
			xExemplar.RefreshContent();
        }
	}
}
