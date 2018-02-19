using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoreWpf.UI {
	/// <summary>
	/// This control manages a named list, with possibility to change its values (add remove,...)
	/// </summary>
	public abstract class ModifyControlNamedList : UserControl, IReadModify, IFiche {

		#region Members
		private IFiche _afficheur;
		private INamedCollection _nc;
		private ListView _dataList = new ListView();
		private ReadModifyMode _readMode;
		#endregion

		#region Properties
		public IFiche Afficheur {
			private get { return _afficheur; }
			set { _afficheur = value; }
		}
		public INamedCollection NamedList {
			get { return _nc; }
			set {
				_dataList.Items.Remove(Afficheur);
				//remove
				if(_nc != null) {
					_nc.SelectionChanged -= NamedList_SelectionChanged;
				}
				_nc = value;
				//assign events
				if(NamedList != null)
					NamedList.SelectionChanged += NamedList_SelectionChanged;
				//refresh
				SetNamedList();
            }
		}
		public ReadModifyMode CurrentMode {
			get { return _readMode; }
		}
		public bool CanChangeMode { get; set; }

		public object SelectedObject {
			get { return NamedList; }
			set {
				NamedList = (INamedCollection)value;
            }
		}
		#endregion

		#region Init
		public ModifyControlNamedList() {
			DockPanel dp = new DockPanel();
			_dataList.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            ScrollViewer.SetHorizontalScrollBarVisibility(_dataList, ScrollBarVisibility.Disabled);
			dp.Children.Add(_dataList);
			_dataList.SelectionChanged += _dataList_SelectionChanged;
			//content
			this.Content = dp;
		}
		#endregion

		#region Events
		/// <summary>
		/// When the Named item selection in the list changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _dataList_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			ListView lv = sender as ListView;
			lv.Items.Remove(Afficheur);
			if(lv.SelectedIndex>=0)
				lv.Items.Insert(lv.SelectedIndex+1, Afficheur);
			Afficheur.SelectedObject = ((NamedListItem)lv.SelectedItem)?._item;
		}
		/// <summary>
		/// When the Named list changes.
		/// </summary>
		/// <param name="sender"></param>
		private void NamedList_SelectionChanged( INamedCollection sender ) {
			SetNamedList();
		}
		#endregion

		private void SetNamedList() {
			_dataList.SelectionChanged -= _dataList_SelectionChanged;
			//remove old
			_dataList.Items.Remove(Afficheur);
			foreach(NamedListItem item in _dataList.Items) {
				item._rmBut.Click -= _rmBut_Click;
			}
			_dataList.Items.Clear();
			//check null
			if(NamedList == null) { return; }
			//add new
			foreach(var item in NamedList.NamedCollection) {
				NamedListItem nli = new NamedListItem(item);
				_dataList.Items.Add(nli);
                nli._rmBut.Click += _rmBut_Click;
			}
			_dataList.SelectionChanged += _dataList_SelectionChanged;
		}

		private void _rmBut_Click( object sender, RoutedEventArgs e ) {
			Button b = sender as Button;
			NamedListItem nm = b.Parent as NamedListItem;
			NamedList.RemoveNamed(nm._item);
			_dataList.Items.Remove(nm);
		}

		public void SetMode( ReadModifyMode mode ) {
			if(CanChangeMode && CurrentMode != mode) {
				_readMode = mode;
				if(mode == ReadModifyMode.Read)
					foreach(NamedListItem item in _dataList.Items)
						item.SetRead();
				else if(mode == ReadModifyMode.Modify)
					foreach(NamedListItem item in _dataList.Items)
						item.SetModify();
			}
		}

		public abstract bool ValidChange();

		public void CancelChanges() {
			throw new NotImplementedException();
		}
	}
	/// <summary>
	/// It's an item of the ModifyControlNamedList.
	/// </summary>
	internal class NamedListItem : UserControl {
		internal INamed _item;
		internal Button _rmBut = new Button() { Content = "X" };
		private StackPanel _sp = new StackPanel() {
			Orientation = Orientation.Vertical,
			CanHorizontallyScroll = false,
			HorizontalAlignment = HorizontalAlignment.Stretch,
			Margin = new Thickness(1)
		};

		public NamedListItem( INamed item ) {
			_item = item;
			HorizontalAlignment = HorizontalAlignment.Stretch;
            DockPanel dp = new DockPanel();
			//add name text
			TextBlock name = new TextBlock() { Text = item.Name };
			name.FontSize = 15;
			name.VerticalAlignment = VerticalAlignment.Center;
			name.HorizontalAlignment = HorizontalAlignment.Stretch;
            dp.Children.Add(name);
			DockPanel.SetDock(name, Dock.Left);
			//add remove button
			_rmBut.Margin = new System.Windows.Thickness(1);
            dp.Children.Add(_rmBut);
			DockPanel.SetDock(_rmBut, Dock.Right);
			// Border
			Border b = new Border();
			b.BorderBrush = Brushes.Gray;
			b.BorderThickness = new Thickness(1);
			b.CornerRadius = new CornerRadius(3);
			b.HorizontalAlignment = HorizontalAlignment.Stretch;
			b.Child = _sp;
			//content
			_sp.Children.Add(dp);
			Content = b;
			//init state
			SetRead();
		}

		internal void SetModify() {
			_rmBut.Visibility = System.Windows.Visibility.Visible;
		}

		internal void SetRead() {
			_rmBut.Visibility = System.Windows.Visibility.Hidden;
		}
	}
}
