using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CoreWpf.UI;

namespace CoreWpf.Dialogs {
	/// <summary>
	/// A short list of editable values
	/// </summary>
	public class ValueList<T> : UserControl {
		#region Members
		private PropertyInfo _valProperty = typeof(ValueWrapper<T>).GetProperty("Value");
		private StackPanel _stack;//main stack
		private StackPanel _list;//List of values
		private StackPanel _before, _after;
		private List<ValueWrapper<T>> _data = new List<ValueWrapper<T>>();//the list of values
		private Dictionary<Button, UIElement> _buttonLink = new Dictionary<Button, UIElement>();
		private Dictionary<UIElement,ValueWrapper<T>> _dataDisplayLink = new Dictionary<UIElement, ValueWrapper<T>>();
		private int _columnWidth;
		#endregion

		#region Properties
		public int ColumnWidth {
			get { return _columnWidth; }
			set { _columnWidth = value; }
		}

		public IEnumerable<T> Data {
			get {
				return _data.Select(d => d.Value);
			}
		}

		#endregion

		#region Init
		public ValueList( params T[] initVals ) : base() {
			ColumnWidth = 120;
			//Creation du controleur
			_stack = new StackPanel() { MinWidth = ColumnWidth };
			_list = new StackPanel() { Margin = new Thickness(2) };
			_before = new StackPanel() { MinWidth = ColumnWidth };
			_after = new StackPanel() { MinWidth = ColumnWidth };
			_stack.Children.Add(_before);
			_stack.Children.Add(_list);
			_stack.Children.Add(_after);
			this.Content = WrapInBorder(_stack);
			//ajouter un bouton add
			Button button = new Button() { Content = "Add" };
			button.Click += AddOnClick;
			_before.Children.Add(button);
			InitList(initVals);
        }
		private UIElement WrapInBorder( UIElement e ) {
			Border b = new Border() {
				BorderBrush = Brushes.Black,
				BorderThickness = new Thickness(0, 0, 1, 0),
				Padding = new Thickness(2)
			};
			b.Child = e;
			return b;
		}
		#endregion
		#region Collection
		/// <summary>
		/// Ajouter des éléments à la liste de la DetailColumn.
		/// </summary>
		/// <param name="newElements">Liste des éléments à ajouter</param>
		protected void InitList( params T[] newElements ) {
			if(newElements == null) { return; }
			foreach(T item in newElements) {
				ValueWrapper<T> w = new ValueWrapper<T>(item);
				Add(w);
            }
		}
		protected void Add(ValueWrapper<T> w ) {
			_data.Add(w);
			UIElement disp = Display(w);
			_list.Children.Add(disp);
			_dataDisplayLink.Add(disp, w);
		}
		#endregion

		protected UIElement Display( ValueWrapper<T> data ) {
			Button erase = new Button() { Content = "X" };
			erase.Click += EraseElement;
			erase.HorizontalAlignment = HorizontalAlignment.Right;
			Grid grd = new Grid();
			ValueModifierControl vm = new ValueModifierControl(data, _valProperty)
			{
				HorizontalAlignment = HorizontalAlignment.Stretch
			};
			grd.Children.Add(vm);
			grd.Children.Add(erase);
			_buttonLink.Add(erase, grd);
			return grd;
		}
		/// <summary>
		/// Lorsque clic sur bouton 'x', supprime la valeur correspondante.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EraseElement( object sender, RoutedEventArgs e ) {
			UIElement dv = _buttonLink[(Button)sender];
			ValueWrapper<T> w = _dataDisplayLink[dv];
			_data.Remove(w);
			_list.Children.Remove(dv);
		}
		protected void AddOnClick( object sender, RoutedEventArgs e ) {
			ValueWrapper<T> w = new ValueWrapper<T>();
			Add(w);
		}
		/// <summary>
		/// Wrap de la valeur afin d'utiliser un ValueModifier.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		protected class ValueWrapper<U> {
			private U v;

			public U Value {
				get { return v; }
				set { v = value; }
			}
			public ValueWrapper() { }
			public ValueWrapper( U val ) {
				v = val;
			}
		}
	}
}
