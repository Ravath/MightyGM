using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Core.Data;
using System.Windows.Controls;
using Core.UI.Dialogs;

namespace Core.UI.Columns {
	public class DataExemplarColumn : DataObjectPropertyColumn<IDataExemplaire> {

		public DataExemplarColumn( Core.Data.IDataObject dataob, PropertyInfo pi, Database data ) : base(dataob, pi, data) { }

		protected override void GetMany() {
			DataExemplarCreator de = new DataExemplarCreator(DataType, Database) {
				Single = Single
			};
			ListSelectorResult lsr = new ListSelectorResult() {
				Data = de.GetExemplars()
			};
			ClearList();
			foreach(IDataExemplaire obj in lsr?.Data) {
				Add(obj);
			}
		}

		protected override void GetOne() {
			DataExemplarCreator de = new DataExemplarCreator(DataType, Database) {
				Single = Single
			};
			ListSelectorResult lsr = new ListSelectorResult() {
				Data = de.GetExemplars()
			};
			ClearList();
			if(lsr != null && lsr.Data.Count() > 0 ) {
					Add((IDataExemplaire)lsr.Data.ElementAt(0));
			}
		}
	}
}
