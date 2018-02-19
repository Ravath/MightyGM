using Core;
using Core.Contexts;
using Core.Data;
using CoreWpf;
using LinqToDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using MightyGmCtrl;

namespace MightyGmWPF.Tabs {
	/// <summary>
	/// Interaction Logic for TabFiches.xaml.
	/// Displays Every Card in a list, and the selected card for use.
	/// </summary>
	public partial class TabFiches : UserControl {

		#region Members
		private Context _context; 
		#endregion

		#region Properties
		public Context Context {
			get { return _context; }
			set { _context = value; }
		}
		#endregion

		#region Init
		/// <summary>
		/// Default Constructor.
		/// </summary>
		/// <param name="context">MightyGM's global context.</param>
		public TabFiches( Context context ) {
			InitializeComponent();
			Context = context;
			DataContext = this;

			//Events
			context.Contexts.JdrChanged += Context_LocalContextChanged;
		}

		/// <summary>
		/// Refresh The list of Jdr Cards, when a Jdr Dll have been loaded.
		/// </summary>
		/// <param name="jdr"></param>
		/// <param name="jdrUi"></param>
		private void Context_LocalContextChanged( IJdrContext jdr, IJdrContextUI jdrUi ) {
			if(jdrUi == null)
				xTypeList.ItemsSource = null;
			else {
				List<ListItem> l = new List<ListItem>();
				foreach(IFicheCandidate ifc in jdrUi.FicheCandidates) {
					l.Add(new ListItem(ifc.FicheName, ifc));
				}
				xTypeList.ItemsSource = l;
			}
			xTypeList.SelectedItem = null;
		}

		/// <summary>
		/// Class used to manipulate cards in the list.
		/// </summary>
		private class ListItem {
			public string Name { get; set; }
			public IFicheCandidate Fiche { get; set; }
			public ListItem(string name, IFicheCandidate f) {
				Name = name;
				Fiche = f;
            }
			public override string ToString() {
				return Name;
			}
		}
		#endregion

		/// <summary>
		/// Displays the selected Card.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TypeList_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			ListItem fc =  (ListItem)xTypeList.SelectedItem;
			if(fc == null) {
				xContainer.Content = null;
            } else {
				xContainer.Content = fc.Fiche.Control;
				fc.Fiche.Afficher(Context);
			}
        }

	}
}
