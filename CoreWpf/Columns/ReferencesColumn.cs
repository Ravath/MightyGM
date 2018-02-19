using Core.Data;
using CoreWpf.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoreWpf.Columns {
	/// <summary>
	/// Colonne affichant une liste d'objets des données, depuis la propriété d'un objet.
	/// Permet de gérer si référence unique ou collection.
	/// Avec un bouton pour pouvoir changer les valeurs.
	/// </summary>
	public class ReferencesColumn : DataObjectPropertyColumn<IDataObject> {
		public ReferencesColumn(IDataObject dataob, PropertyInfo pi, Database data) : base(dataob, pi, data) { }

		protected override void GetOne() {
			ListSelectorResult lsr = GetSelectionFromUser();
			//maj avec nouvelles valeurs
			IDataObject obj;
			if(lsr?.Data == null || lsr?.Data.Count() != 1) {
				obj = null;
			} else
				obj = (DataObject)lsr.Data.ElementAt(0);
			IDataObject old = (IDataObject)Property.GetValue(Object);
			if(old?.Id == obj?.Id) { return; }//si le même, pas la peine de maj
			ClearList();
			Add(obj);
		}
		protected override void GetMany() {
			ListSelectorResult lsr = GetSelectionFromUser();
			ClearList();
			foreach(IDataObject obj in lsr?.Data) {
				Add(obj);
			}
		}
		private ListSelectorResult GetSelectionFromUser() {
			ListSelector ls = new ListSelector() {
				Data = Database,
				Single = Single
			};
			ls.Load(DataType, Data);
			return ls.GetSelection();
		}
	}
}
