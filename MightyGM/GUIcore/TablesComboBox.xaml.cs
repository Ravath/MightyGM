using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MightyGM.GUIcore {
	/// <summary>
	/// Logique d'interaction pour TablesComboBox.xaml
	/// </summary>
	public partial class TablesComboBox : UserControl {
		#region Properties
		/// <summary>
		/// Le type de donnée séletionné dans la Combo.
		/// </summary>
		public Type SelectedItem { get {
				TypeListHandler cb = (TypeListHandler)xCombo.SelectedItem;
				return (Type)cb.Type; } }
		#endregion
		#region Init
		/// <summary>
		/// Constructeur par défaut.
		/// </summary>
		public TablesComboBox() {
			InitializeComponent();
			xCombo.DisplayMemberPath = "Name";
			xCombo.SelectedValuePath = "Type";
		}
		#endregion
		#region Events
		/// <summary>
		/// Délégés de SelectedTypeChangedEventHandler.
		/// </summary>
		/// <param name="selectedType"></param>
		/// <param name="e"></param>
		public delegate void SelectedTypeChangedEventHandler( Type selectedType, SelectionChangedEventArgs e );
		/// <summary>
		/// Evénement lancé lorsqu'un type est  désigné parmi la liste.
		/// </summary>
		public event SelectedTypeChangedEventHandler SelectedTypeChanged;
		/// <summary>
		/// Fais suivre l'évènement de changement de type sélectionné.
		/// </summary>
		/// <param name="sender">ComboBox de types</param>
		/// <param name="e"></param>
		private void FireChangedEvent( object sender, SelectionChangedEventArgs e ) {
			if(SelectedTypeChanged != null) {
				SelectedTypeChanged(SelectedItem,e);
            }
		}
		#endregion
		/// <summary>
		/// Initialise la liste des choix de table de données avec les classes marquées de l'attribut 'TableAttribute'.
		/// </summary>
		/// <param name="sender"></param>
		public void InitData( IEnumerable<Type> types ) {
			xCombo.Items.Clear();
			//ajouter les DataModel en enlevant le "Model" de la fin
			foreach(var tca in types.Where(t=>typeof(Core.Data.DataModel).IsAssignableFrom(t))) {
				TypeListHandler tl = new TypeListHandler {
					Type = tca,
                    Name = tca.Name.Remove(tca.Name.Length - 5, 5)//enlever "*Model" du nom
				};
                xCombo.Items.Add(tl);
			}
			//ajouter un sééparateur
			xCombo.Items.Add(new Separator());
			//ajouter tout le reste (les structtable sous la forme de DataObject)
			foreach(var tca in types.Where(t => !typeof(Core.Data.DataModel).IsAssignableFrom(t))) {
				TypeListHandler tl = new TypeListHandler {
					Type = tca,
					Name = tca.Name
				};
				xCombo.Items.Add(tl);
			}
		}

		public class TypeListHandler {
			public Type Type { get; set; }
			public string Name { get; set; }
		}
	}
}
