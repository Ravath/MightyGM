using Core;
using Core.Data;
using Core.UI;
using LinqToDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace MightyGM.Tabs {
	/// <summary>
	/// Logique d'interaction pour TabFiches.xaml
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
		/// Constructeur par défaut.
		/// </summary>
		/// <param name="context">Le contexte global de MightyGM</param>
		public TabFiches( Context context ) {
			InitializeComponent();
			Context = context;
			this.DataContext = this;
			context.LocalContextChanged += Context_LocalContextChanged;
		}

		private void Context_LocalContextChanged( ILocalContext local ) {
			if(local == null)
				xTypeList.ItemsSource = null;
			else {
				List<ListItem> l = new List<ListItem>();
				foreach(IFicheCandidate ifc in local.FicheCandidates) {
					l.Add(new ListItem(ifc.Name, ifc));
				}
				xTypeList.ItemsSource = l;
			}
			xTypeList.SelectedItem = null;
		}

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

		private void xTypeList_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
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
