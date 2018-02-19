using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoreWpf.UI {
	/// <summary>
	/// Affiche une liste d'objets (avec ToString) en vis à vis d'une check box, et renvoie les objets cochés.
	/// </summary>
	public class CheckStack : UserControl {

		private StackPanel xStack;
		private Dictionary<CheckBox, object> _links;

		public CheckStack() {
			_links = new Dictionary<CheckBox, object>();
			xStack = new StackPanel();
			Content = xStack;
        }

		public void ClearList() {
			xStack.Children.Clear();
			_links.Clear();
		}

		public void AddObjectRange( IEnumerable<Object> os ) {
			foreach(object o in os) {
				AddObject(o);
			}
		}

		public void AddObject( object o ) {
			StackPanel st = new StackPanel();
			st.Orientation = Orientation.Horizontal;
			CheckBox cb = new CheckBox();
			TextBlock tb = new TextBlock() { Text = o.ToString() };
			st.Children.Add(cb);
			st.Children.Add(tb);
			_links.Add(cb, tb);
			xStack.Children.Add(st);
		}

		public IEnumerable<object> GetSelectedObjects() {
			return _links.Where(p => (bool)p.Key.IsChecked).Select(p => p.Value);
		}
	}
}
