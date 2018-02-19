using Core.Data;
using CoreWpf.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CoreWpf.Columns {

	public class ValueColumn<T> : PropertyColumnOfDataObject<T> {

		public ValueColumn( Core.Data.IDataObject obj, PropertyInfo pi) : base(obj, pi, null) {
			Button button = new Button() { Content = "Change" };
			button.Click += OnClick;
			BeforeList.Children.Add(button);
		}

		private void OnClick( object sender, RoutedEventArgs e ) {
			IEnumerable<T> objs = Selectors.GetValues<T>(Data);
			ClearList();
			foreach(T obj in objs) {
				Add(obj);
			}
			if(AutoSave) {
				Save();
			}
		}

		protected override UIElement Display( T data ) {
			return new TextBlock() { Text = data.ToString() };
		}

		public static UIElement GetEnumValueColumn( Core.Data.IDataObject obj, PropertyInfo pi, Type enumType ) {
			Type t = typeof(ValueColumn<>);
			t = t.MakeGenericType(enumType);
            ConstructorInfo ci = t.GetConstructor(new Type[] { typeof(Core.Data.IDataObject), typeof(PropertyInfo) });
			return (UIElement) ci.Invoke(new Object[] { obj, pi });
		}
    }
}
