using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoreWpf.Dialogs {
	public abstract class AbsListSelector : UserControl {
	}
	/// <summary>
	/// The result returned from the ListSelector controleur.
	/// </summary>
	public class ListSelectorResult {
		/// <summary>
		/// The list of selected Items.
		/// </summary>
		public IEnumerable<IDataObject> Data { get; internal set; }
	}
}
