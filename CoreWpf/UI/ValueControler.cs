using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;

namespace CoreWpf.UI {
	/// <summary>
	/// User control to track and display a value.
	/// </summary>
	public class ValueControler : UserControl{

		private TextBlock _tb = new TextBlock();
		private TextBlock _tip = new TextBlock();
		private IValue _val;

		public ValueControler() {
			Content = _tb;
			_tb.ToolTip = _tip;
        }
		/// <summary>
		/// The value to display and track.
		/// </summary>
		public IValue Value {
			get { return _val; }
			set {
				if(value == Value) { return; }
				if(Value != null) {
					value.ValueChanged -= Value_ValueChanged;
				}
				_val = value;
				value.ValueChanged += Value_ValueChanged;
				setText();
			}
		}
		/// <summary>
		/// Builds the tooltip text.
		/// </summary>
		private void setText() {
			_tb.Text = Value.TotalValue.ToString();
			string ret = Value.Label + ": "+Value.BaseValue;
			if(Value.Modifiers.Count() > 0) {
				foreach(IValue v in Value.Modifiers) {
					ret += string.Format("\n + {0} : {1}", v.TotalValue,v.Label);
				}
			}
			_tip.Text = ret;
		}
		/// <summary>
		/// Called when the tracked value has changed.
		/// </summary>
		/// <param name="ival"></param>
		/// <param name="newValue"></param>
		/// <param name="oldValue"></param>
		private void Value_ValueChanged( IValue ival, int newValue, int oldValue ) {
			setText();
		}
	}

	/// <summary>
	/// User controler used to display and change a value.
	/// </summary>
	public class ValueModifier : UserControl {

		private IntegerUpDown _tb = new IntegerUpDown();

		public ValueModifier() {
			Content = _tb;
			_tb.ValueChanged += _tb_ValueChanged;
		}

		private void _tb_ValueChanged( object sender, RoutedPropertyChangedEventArgs<object> e ) {
			Value.BaseValue = (int)e.NewValue;
        }

		private Value val;

		public Value Value {
			get { return val; }
			set {
				val = value;
				_tb.Value = value.BaseValue;
            }
		}
	}
}
