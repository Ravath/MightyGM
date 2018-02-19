using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoreWpf.UI {

	public enum ReadModifyMode {
		Read,Modify
	}

	/// <summary>
	/// A userControl able to change to readMode or ModifyMode.
	/// </summary>
	public interface IReadModify {
		void SetMode( ReadModifyMode mode );
		ReadModifyMode CurrentMode { get; }
		bool CanChangeMode { get; }
		bool ValidChange();
		void CancelChanges();
	}

	/// <summary>
	/// Wraps Read/Modify control and controls by interface the capacity to swap in read or modify mode.
	/// TODO : position buttons
	/// </summary>
	public class ModifyControlOverlay : UserControl, IReadModify {

		#region Members
		private IReadModify _ctrl;
		private Button _modButton = new Button();
		private Button _doneButton = new Button();
		private StackPanel _sp = new StackPanel();
		#endregion

		#region Properties
		public bool CanChangeMode { get; set; }
		public ReadModifyMode CurrentMode { get { return _ctrl.CurrentMode; } }
		#endregion

		#region Init
		public ModifyControlOverlay() {
			HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
			VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
			//buttons
			_modButton.Content = "Modify";
			_modButton.Margin = new System.Windows.Thickness(10, 0, 10, 10);
			_modButton.Visibility = System.Windows.Visibility.Hidden;
			_modButton.RenderSize = new System.Windows.Size(50, 30);
			_doneButton.Content = "Done";
			_doneButton.Margin = new System.Windows.Thickness(10, 10, 10, 0);
			_doneButton.Visibility = System.Windows.Visibility.Hidden;
			_doneButton.RenderSize = new System.Windows.Size(50, 30);
			//events
			this.SizeChanged += ModifyControlOverlay_SizeChanged;
			_modButton.MouseEnter += Button_MouseEnter;
			_modButton.MouseLeave += Button_MouseLeave;
			_doneButton.MouseEnter += Button_MouseEnter;
			_doneButton.MouseLeave += Button_MouseLeave;
			_modButton.Click += _modButton_Click;
			_doneButton.Click += _doneButton_Click;
			// init in rad mode
			SetMode(ReadModifyMode.Read);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rmCtrl">Must also be a UserControl.</param>
		public ModifyControlOverlay( IReadModify rmCtrl ) : this() {
			_ctrl = rmCtrl;
			UserControl uc = rmCtrl as UserControl;
			if(uc == null)
				throw new ArgumentException("rmCtrl of ModifyControlOverlay must be of usercontrolType");
			//display
			Canvas cv = new Canvas();
			cv.Children.Add(_modButton);
			cv.Children.Add(_doneButton);
			Panel.SetZIndex(cv, 10);
			//stackpanel
			_sp.Children.Add(cv);
			_sp.Children.Add(uc);
			Content = _sp;
		}
		#endregion

		#region Events
		private void Button_MouseLeave( object sender, System.Windows.Input.MouseEventArgs e ) {
			Button b = sender as Button;
			b.Visibility = System.Windows.Visibility.Hidden;
		}

		private void Button_MouseEnter( object sender, System.Windows.Input.MouseEventArgs e ) {
			Button b = sender as Button;
			b.Visibility = System.Windows.Visibility.Visible;
		}

		private void ModifyControlOverlay_SizeChanged( object sender, System.Windows.SizeChangedEventArgs e ) {
			UserControl uc = _ctrl as UserControl;
			Canvas.SetTop(_modButton, 0);
			Canvas.SetLeft(_modButton, (uc.Width + _modButton.Width) / 2);
			Canvas.SetTop(_doneButton, uc.Height - _doneButton.Height);
			Canvas.SetLeft(_doneButton, (uc.Width + _doneButton.Width) / 2);
		}

		private void _doneButton_Click( object sender, System.Windows.RoutedEventArgs e ) {
			SetMode(ReadModifyMode.Read);
		}

		private void _modButton_Click( object sender, System.Windows.RoutedEventArgs e ) {
			SetMode(ReadModifyMode.Modify);
		}
		#endregion

		#region IReadModify Impl
		public void CancelChanges() {
			_ctrl.CancelChanges();
		}

		public void SetMode( ReadModifyMode mode ) {
			//set UI
			if(mode == ReadModifyMode.Read) {
				_doneButton.IsEnabled = false;
				_modButton.IsEnabled = true;
			} else {
				_doneButton.IsEnabled = true;
				_modButton.IsEnabled = false;
			}
			//follow to wrapped
			if(CanChangeMode)
				_ctrl.SetMode(mode);
		}

		public bool ValidChange() {
			return _ctrl.ValidChange();
		} 
		#endregion
	}
}
