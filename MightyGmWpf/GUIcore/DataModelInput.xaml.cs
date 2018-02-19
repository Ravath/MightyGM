using Core.Data;
using CoreWpf.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using MightyGmCtrl;

namespace MightyGmWPF.GUIcore {
	/// <summary>
	/// Logique d'interaction pour DataModelInput.xaml
	/// </summary>
	public partial class DataModelInput : UserControl {

		public Type ModelType { get; set; }
		public DataModel Model { get; set; }

		public DataModelInput() {
			InitializeComponent();
		}

		private void Button_Click( object sender, RoutedEventArgs e ) {
			ListSelector ls = new ListSelector() {
				Data = Context.GlobalContext.Data,
				Single = true
			};
			ls.Load(ModelType, new DataModel[] { Model });
			ListSelectorResult lsr = ls.GetSelection();
			//maj avec nouvelle valeurs
			DataModel obj;
			if(lsr?.Data == null || lsr?.Data.Count() != 1) {
				obj = null;
			} else
				obj = (DataModel)lsr.Data.ElementAt(0);
			if(Model?.Name == obj?.Name) { return; }//si le même, pas la peine de maj
			Model = obj;
		}
	}
}
