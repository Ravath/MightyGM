using Cinqanneaux.Data;
using Core.Data;
using Core.Data.Schema;
using Core.Engine;
using Core.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xml;

namespace MightyGM.GUIcore {
	public class MgDataGrid : DataGrid {

		public MgDataGrid() {
			//Définir le controleur qui affiche les détails de la ligne
			Binding binding = new Binding() {  };
			FrameworkElementFactory textFactory = new FrameworkElementFactory(typeof(ReferencesGrid));
			textFactory.SetBinding(ReferencesGrid.DataProperty, binding);
			DataTemplate dt = new DataTemplate() { VisualTree = textFactory };
			this.RowDetailsTemplate = dt;
		}

		protected override void OnAutoGeneratingColumn( DataGridAutoGeneratingColumnEventArgs e ) {
			// * Gestion des colonnes d'identifiants de DataModel. *
			// placer les colonnes name et id à gauche.
			if(e.PropertyName.ToLower() == "id") {
				e.Column.Visibility = Visibility.Collapsed;
				e.Column.DisplayIndex = 0;
				return;
			} else if(e.PropertyName.ToLower() == "name") {
				if(Columns.Count>0 && Columns[0].Header.ToString().ToLower() == "id")
					e.Column.DisplayIndex = 1;
				else
					e.Column.DisplayIndex = 0;
				return;
			}
			// * Laisser les types par défaut tels quels *
			if(typeof(string).IsAssignableFrom(e.PropertyType)
				|| typeof(int).IsAssignableFrom(e.PropertyType)
				|| typeof(int?).IsAssignableFrom(e.PropertyType)
				|| typeof(double).IsAssignableFrom(e.PropertyType)
				|| typeof(double?).IsAssignableFrom(e.PropertyType)
				|| typeof(decimal).IsAssignableFrom(e.PropertyType)
				|| typeof(decimal?).IsAssignableFrom(e.PropertyType)
				|| typeof(bool).IsAssignableFrom(e.PropertyType)
				|| typeof(bool?).IsAssignableFrom(e.PropertyType)
				|| e.PropertyType.IsEnum
				) {
				return;
			}// * ComboBox specifique pour les enums qui acceptent les valeurs nulles. *
			else if(e.PropertyType.IsNullableEnum()) {
				BindingBase binding = e.Column.ClipboardContentBinding;
				//creer la colonne template
				e.Column = new DataGridComboBoxColumn() {
					Header = e.Column.Header,
					//binding
					SelectedValueBinding = binding,
					ClipboardContentBinding = binding,
					SortMemberPath = e.PropertyName,
					//items d'enum
					ItemsSource = NullableEnumExtensions.GetVals(e.PropertyType),
                    SelectedValuePath = "Val",
					DisplayMemberPath = "Name"
				};
				return;
			} // * types gérés par l'encart de détail. *
			else if(typeof(ICollection).IsAssignableFrom(e.PropertyType)
					|| typeof(IEnumerable).IsAssignableFrom(e.PropertyType)
					|| typeof(Core.Data.DataObject).IsAssignableFrom(e.PropertyType)
					|| typeof(IDataDescription).IsAssignableFrom(e.PropertyType)) {
				e.Cancel = true;
			} // * Types non gérés et prévus *
			else if(typeof(Type).IsAssignableFrom(e.PropertyType)
				|| typeof(Range).IsAssignableFrom(e.PropertyType)
				|| typeof(XPaPoints).IsAssignableFrom(e.PropertyType)
				|| typeof(IUnitValue).IsAssignableFrom(e.PropertyType)
				|| null != e.PropertyType.GetCustomAttribute(typeof(HiddenPropertyAttribute))) {
				e.Cancel = true;
			}
			else { // * Types non gérés et imprévus *
				e.Cancel = true;
				throw new NotImplementedException(string.Format("The datagrid can't convert the column {0} of type {1}", e.PropertyName, e.PropertyType.Name));
			}
		}
	}
}
