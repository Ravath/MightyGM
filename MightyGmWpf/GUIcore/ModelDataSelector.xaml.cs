//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace MightyGM.GUIcore {
//	/// <summary>
//	/// Logique d'interaction pour ModelDataSelector.xaml
//	/// </summary>
//	public partial class ModelDataSelector : UserControl {

//		#region Members
//		private List<IDataObject> _init = new List<IDataObject>();
//		private List<IDataObject> _selected = new List<IDataObject>();
//		private List<IDataObject> _list = new List<IDataObject>();
//		private Context _context;
//		private System.Windows.Window _window;
//		#endregion

//		public ModelDataSelector() {
//			InitializeComponent();
//		}
//		/// <summary>
//		/// Load the list of objects.
//		/// </summary>
//		/// <param name="t">Data list.</param>
//		public void Load( Type t ) {
//			_selected.Clear();
//			_list.Clear();
//			IEnumerable<object> ds = _context.Data.GetDataTable(t);
//			_list.AddRange(ds.Cast<IDataObject>());
//			MajLists();
//		}
//	}
//}
