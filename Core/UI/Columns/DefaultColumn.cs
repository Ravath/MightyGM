using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Core.UI.Columns {
	/// <summary>
	/// Iplémetation la plus générale de AbsDetailsColumn. Le bouton n'est pas implémenté.
	/// </summary>
	public class DefaultColumn : AbsDetailColumn<Object, Object> {
		#region Init
		public DefaultColumn( Object obj, PropertyInfo pi ) : base(obj, pi) {
			AutoSave = false;
			TextBlock tb = new TextBlock() { Text = "UnexpectedType" };
			AfterList.Children.Add(tb);
		}
		#endregion

		protected override UIElement Display( Object data ) {
			return new TextBlock() { Text = data.ToString() };
		}
	}
}
