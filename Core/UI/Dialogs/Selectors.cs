using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Core.UI.Dialogs {
	public static class Selectors {

		public static O GetOne<O>( IEnumerable<O> choice ) {
			//liste
			ListView lv = new ListView();
			lv.ItemsSource = choice;
			lv.SelectionMode = SelectionMode.Single;
			//fenetre
			Window w = new Window() { Width = 300 };
			w.Title = "Choose One";
			//buttons
			StackPanel spbts = GetCancelDoneButtons(w, lv);
			StackPanel sp = new StackPanel();
			sp.Children.Add(lv);
			sp.Children.Add(spbts);
			//done
			w.Content = sp;
			w.ShowDialog();
			return (O)lv.SelectedItem;
		}

		public static IEnumerable<O> GetMany<O>( IEnumerable<O> choice ) {
			//liste
			ListView lv = new ListView();
			lv.ItemsSource = choice;
			//fenetre
			Window w = new Window() { Width = 300 };
			w.Title = "Choose some";
			//buttons
			StackPanel spbts = GetCancelDoneButtons(w, lv);
            StackPanel sp = new StackPanel();
			sp.Children.Add(lv);
			sp.Children.Add(spbts);
			//done
			w.Content = sp;
			w.ShowDialog();
			return lv.SelectedItems.Cast<O>();
		}

		private static StackPanel GetCancelDoneButtons( Window w, ListView lv ) {
			Button bc = new Button() { Content = "Cancel", MinWidth = 80, MinHeight = 35 };
			Button bv = new Button() { Content = "Done", MinWidth = 80, MinHeight = 35 };
			bc.Click += ( object sender, RoutedEventArgs e ) => {
				lv.SelectedItem = null;
				w.Close();
			};
			bv.Click += ( object sender, RoutedEventArgs e ) => {
				w.Close();
			};
			StackPanel spbts = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment= HorizontalAlignment.Center };
			spbts.Children.Add(bc);
			spbts.Children.Add(bv);
			return spbts;
		}
		/// <summary>
		/// Return edited values from user, using a ValueList.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="initvals"></param>
		/// <returns></returns>
		public static IEnumerable<T> GetValues<T>( IEnumerable<T> initvals ) {
			//fenetre
			Window w = new Window() { Width = 300 };
			w.Title = "Edit Values";
			bool cancel = false;
			//Cancel & Done buttons
			Button bc = new Button() { Content = "Cancel", MinWidth = 80, MinHeight = 35 };
			Button bv = new Button() { Content = "Done", MinWidth = 80, MinHeight = 35 };
			bv.Click += ( object sender, RoutedEventArgs e ) => { w.Close(); };
			bc.Click += ( object sender, RoutedEventArgs e ) => {
				cancel = true;
                w.Close();
			};
			StackPanel spbts = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Center };
			spbts.Children.Add(bc);
			spbts.Children.Add(bv);
			//Content
			StackPanel sp = new StackPanel();
			ValueList<T> vl = new ValueList<T>(initvals.ToArray());
			sp.Children.Add(vl);
			sp.Children.Add(spbts);
			w.Content = sp;
			w.ShowDialog();
			if(cancel)
				return initvals;
			else
				return vl.Data;
		}
		/// <summary>
		/// Return the selection from user, using a CheckStack.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		public static IEnumerable<T> GetChecked<T> ( IEnumerable<T> list ) {
			//CheckStack
			//fenetre
			Window w = new Window() { Width = 300 };
			w.Title = "Select Values";
			bool cancel = false;
			//Cancel & Done buttons
			Button bc = new Button() { Content = "Cancel", MinWidth = 80, MinHeight = 35 };
			Button bv = new Button() { Content = "Done", MinWidth = 80, MinHeight = 35 };
			bv.Click += ( object sender, RoutedEventArgs e ) => { w.Close(); };
			bc.Click += ( object sender, RoutedEventArgs e ) => {
				cancel = true;
				w.Close();
			};
			StackPanel spbts = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Center };
			spbts.Children.Add(bc);
			spbts.Children.Add(bv);
			//Content
			StackPanel sp = new StackPanel();
			CheckStack vl = new CheckStack();
			vl.AddObjectRange(list.Cast<object>());
            sp.Children.Add(vl);
			sp.Children.Add(spbts);
			w.Content = sp;
			w.ShowDialog();
			if(cancel)
				return new List<T>();
			else
				return vl.GetSelectedObjects().Cast<T>();
		}
	}
}
