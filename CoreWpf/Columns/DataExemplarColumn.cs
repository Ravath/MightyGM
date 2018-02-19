using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Core.Data;
using System.Windows.Controls;
using CoreWpf.Dialogs;

namespace CoreWpf.Columns {
	public class DataExemplarColumn : DataObjectPropertyColumn<IDataExemplaire> {

		public DataExemplarColumn( Core.Data.IDataObject dataob, PropertyInfo pi, Database data ) : base(dataob, pi, data) {
			/* type of the property should be Ienumerable, and we check if the generic data is abstract */
			if(pi.PropertyType.GenericTypeArguments[0].IsAbstract) {
				/* Forbid modifications */
				this.SetChangeEnabled(false);
				/*TODO : load abstract instead of not being able to load anything
				 * The exact problem is that <DataExemplarCreator?> is not able to determine the exemplar class to instanciate.
				 * (but it can totaly load abstract models from database)
				 * + bonus : solve problem of Model not being of the exact right type, but the one of parent instead.
				*/
			}
		}

		protected override void GetMany() {
			DataExemplarCreator de = new DataExemplarCreator(DataType, Database) {
				Single = Single
			};
			ListSelectorResult lsr = new ListSelectorResult() {
				Data = de.GetExemplars()
			};
			ClearList();
			foreach(IDataExemplaire obj in lsr?.Data) {
				if(obj.Model!=null)
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
				IDataExemplaire ex = (IDataExemplaire)lsr.Data.ElementAt(0);
				if(ex.Model!=null)
                    Add(ex);
			}
		}
	}
}
