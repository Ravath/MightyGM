using Core.Data;
using System.Reflection;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CoreWpf.Columns {

	public abstract class PropertyColumnOfDataObject<T> : AbsDetailColumn<Core.Data.IDataObject, T> {
		public Database Database { get; set; }
		public PropertyColumnOfDataObject( Core.Data.IDataObject obj, PropertyInfo pi, Database data ) : base(obj, pi) {
			Database = data;
        }
		public override void Save() {
			base.Save();
			Object.SaveObject();
		}
	}

	public abstract class DataObjectPropertyColumn<T> : PropertyColumnOfDataObject<T> where T : Core.Data.IDataObject {

		private Button _changeButton;

		public DataObjectPropertyColumn( Core.Data.IDataObject obj, PropertyInfo pi, Database data ) : base(obj, pi, data) {
			_changeButton = new Button() { Content = "Change" };
			_changeButton.Click += OnClick;
			BeforeList.Children.Add(_changeButton);
		}

		protected void SetChangeEnabled(bool isEnabled ) {
			_changeButton.IsEnabled = isEnabled;
		}

		protected override UIElement Display( T obj ) {
			return new TextBlock(){ Text = obj.ToString() };
		}

		//public override void Save() {
			//base.Save();
			//foreach(T item in Data.Union(PreviousData)) {
			//	item.SaveObject();
			//}
		//}
		/// <summary>
		/// Action when the "change" button is pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClick( object sender, RoutedEventArgs e ) {
			if(Single) {
				GetOne();
			} else {
				GetMany();
			}
			if(AutoSave) {
				Save();
			}
		}
		/// <summary>
		/// Procédure à exécuter lorsque l'on veut changer le contenu de la liste pour ne récupérer qu'un élément.
		/// </summary>
		protected abstract void GetOne();
		/// <summary>
		/// Procédure à exécuter lorsque l'on veut changer le contenu de la liste pour récupérer une collection d'éléments.
		/// </summary>
		protected abstract void GetMany();
	}
}
