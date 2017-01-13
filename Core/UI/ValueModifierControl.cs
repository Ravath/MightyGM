using Core.Data.Schema;
using Core.Types;
using Core.UI.Columns;
using MightyGM.GUIcore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;

namespace Core.UI {
	public class ValueModifierControl : UserControl {

		private object _obj;
		private PropertyInfo _prop;

		public ValueModifierControl( Object obj, PropertyInfo pi ) {
			_obj = obj;
			_prop = pi;
			DataContext = _obj;
			FrameworkElement fe = GetModifiableValueContaineur(pi);
			fe.HorizontalAlignment = HorizontalAlignment.Stretch;
			this.AddChild(fe);
        }

		private FrameworkElement GetModifiableValueContaineur( PropertyInfo pi ) {
			Type type = pi.PropertyType;
			FrameworkElement ret = null;
			if(null != pi.GetCustomAttribute(typeof(LargeTextAttribute))) {
				MultiLineTextEditor m = new MultiLineTextEditor();
				m.TextWrapping = TextWrapping.Wrap;
				ret = m;
				ret.SetBinding(MultiLineTextEditor.TextProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(string).IsAssignableFrom(type)) {
				ret = new TextBox();
				ret.SetBinding(TextBox.TextProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(byte).IsAssignableFrom(type) || typeof(byte?).IsAssignableFrom(type)) {
				ret = new ByteUpDown();
				ret.SetBinding(ByteUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(short).IsAssignableFrom(type) || typeof(short?).IsAssignableFrom(type)) {
				ret = new ShortUpDown();
				ret.SetBinding(ShortUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(int).IsAssignableFrom(type) || typeof(int?).IsAssignableFrom(type)) {
				ret = new IntegerUpDown();
				ret.SetBinding(IntegerUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(long).IsAssignableFrom(type) || typeof(long?).IsAssignableFrom(type)) {
				ret = new LongUpDown();
				ret.SetBinding(LongUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(double).IsAssignableFrom(type) || typeof(double?).IsAssignableFrom(type)) {
				ret = new DoubleUpDown();
				ret.SetBinding(DoubleUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(float).IsAssignableFrom(type) || typeof(float?).IsAssignableFrom(type)) {
				ret = new DoubleUpDown();
				ret.SetBinding(DoubleUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(char).IsAssignableFrom(type) || typeof(char?).IsAssignableFrom(type)) {
				ret = new ShortUpDown();
				ret.SetBinding(ShortUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
				ShortUpDown su = new ShortUpDown();
			} else if(type.IsEnum || type.IsNullableEnum()) {
				ComboBox cb = new ComboBox();
				if(type.IsNullableEnum()) {
					NullEnumVal[] vals = NullableEnumExtensions.GetVals(type);
					cb.ItemsSource = vals;
					cb.DisplayMemberPath = "Name";
					cb.SelectedValuePath = "Val";
				} else {
					foreach(string item in Enum.GetNames(type)) {
						cb.Items.Add(item);
					}
				}
				cb.SetBinding(ComboBox.SelectedItemProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
				object val = pi.GetValue(_obj);
				cb.SelectedValue = val.ToString();
				ret = cb;
			} else if(typeof(bool).IsAssignableFrom(type)) {
				ret = new CheckBox();
				ret.SetBinding(CheckBox.IsCheckedProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(decimal).IsAssignableFrom(type) || typeof(decimal?).IsAssignableFrom(type)) {
				ret = new DecimalUpDown();
				ret.SetBinding(DecimalUpDown.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else if(typeof(Core.Data.DataModel).IsAssignableFrom(type)) {
				ret = new Fiche() {
					ReadOnly = false,
					SelectedObject = pi.GetValue(_obj)
				};
				//ret = new ReferencesColumn((Core.Data.DataObject)_obj, pi);
			} else if(typeof(Core.Data.IDataDescription).IsAssignableFrom(type)) {
				ret = new Fiche() {
					ReadOnly = false,
					SelectedObject = pi.GetValue(_obj)
				};
			} else if(typeof(Core.Data.IDataExemplaire).IsAssignableFrom(type)) {
				ret = new Fiche() {
					ReadOnly = false,
					SelectedObject = pi.GetValue(_obj)
				};
			}
			 //should never be, because always in collections
			 //else if(typeof(Core.Data.IDataRelation).IsAssignableFrom(type)) {
			 //	ret = new RelationColumn((Core.Data.DataObject)_obj, pi);
			 //}
			 else if(typeof(Core.Data.DataObject).IsAssignableFrom(type)) {
				ret = new Fiche() {
					ReadOnly = false,
					SelectedObject = pi.GetValue(_obj)
				};
				//ret = new ReferencesColumn((Core.Data.DataObject)_obj, pi);
			} else if(typeof(Range).IsAssignableFrom(type)) {
				Range rg = (Range)pi.GetValue(_obj);
				DockPanel sp = new DockPanel();
				ValueModifierControl vm = new ValueModifierControl(rg, rg.GetType().GetProperty("Min"));
				sp.Children.Add(vm);
				DockPanel.SetDock(vm, Dock.Left);
				ValueModifierControl vt = new ValueModifierControl(rg, rg.GetType().GetProperty("Max"));
				sp.Children.Add(vt);
				DockPanel.SetDock(vt, Dock.Right);
				ret = sp;
			} else if(typeof(IUnitValue).IsAssignableFrom(type)) {
				IUnitValue uv = (IUnitValue)pi.GetValue(_obj);
				DockPanel sp = new DockPanel();
				ValueModifierControl vm = new ValueModifierControl(uv, uv.GetType().GetProperty("Value"));
				sp.Children.Add(vm);
				DockPanel.SetDock(vm, Dock.Left);
				ValueModifierControl vt = new ValueModifierControl(uv, uv.GetType().GetProperty("Unity"));
				sp.Children.Add(vt);
				DockPanel.SetDock(vt, Dock.Right);
				ret = sp;
			} else if(typeof(DateTime).IsAssignableFrom(type)) {
				ret = new DateTimePicker();
				ret.SetBinding(DateTimePicker.ValueProperty, new Binding(pi.Name) { Mode = BindingMode.TwoWay });
			} else {//Si autre chose
				TextBlock tb = new TextBlock();
				tb.Text = "Default:" + type.ToString();
				ret = tb;
			}
			return ret;
		}
	}
}
