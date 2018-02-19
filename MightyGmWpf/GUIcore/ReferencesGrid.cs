using Core.Data;
using CoreWpf.UI;
using CoreWpf.Columns;
using MightyGmCtrl.Controleurs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Core.Contexts;
using MightyGmCtrl;
using MightyGmCtrl.GUIcore;

namespace MightyGmWPF.GUIcore {
	/// <summary>
	/// La ligne des détails dans le tableau des données.
	/// N'affiche pas les propriétés de type basique (int, string,...)
	/// Affiche en colonne : 
	///  - les collections de types basiques
	///	 - Les références vers une autre table
	///  - Les collections de références vers une autre table
	/// </summary>
	public class ReferencesGrid : UserControl {

		#region Members
		private StackPanel _stackPanel;
		#endregion

		#region Properties
		public object Data {
			get { return (object)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		public int ColomnWidth { get; set; }
		protected Database Database {
			get {
				return Context.GlobalContext.Data;
			}
		}
		#endregion

		#region Init
		public ReferencesGrid( ) {
			//creation stackPanel général
			_stackPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal
			};
			Content = _stackPanel;
			//Params
			ColomnWidth = 120;
        }
		#endregion

		#region Static
		/// <summary>
		/// dependency property for shown Data.
		/// </summary>
		public static readonly System.Windows.DependencyProperty DataProperty =
			System.Windows.DependencyProperty.Register("Data", typeof(object), typeof(ReferencesGrid), 
			new System.Windows.FrameworkPropertyMetadata(null, OnCurrentTimePropertyChanged));
		/// <summary>
		/// When the DataProperty changes.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private static void OnCurrentTimePropertyChanged( System.Windows.DependencyObject source,
				System.Windows.DependencyPropertyChangedEventArgs e ) {
			ReferencesGrid rg = (ReferencesGrid)source;
			rg.RefreshContent();
        }
		#endregion

		public void ClearContent() {
			_stackPanel.Children.Clear();
		}

		public void RefreshContent() {
			ClearContent();
			//add details
			Core.Data.DataObject dm = Data as Core.Data.DataObject;
			if(dm==null) { return; }
			foreach(PropertyInfo pi in dm.GetType().GetProperties()) {
				Type t = pi.PropertyType;
				if(LetItBe(t))
					continue;
				else if(IsTOrCollectionOfT<Core.Data.DataModel>(t)) {
					_stackPanel.Children.Add(new ReferencesColumn(dm, pi, Database) { ColumnWidth = ColomnWidth });
				} else if(IsTOrCollectionOfT<IDataExemplaire>(t)) {
					_stackPanel.Children.Add(new DataExemplarColumn(dm, pi, Database) { ColumnWidth = ColomnWidth });
					//} else if(IsTOrCollectionOfT<IDataRelation>(t)) {
					//	_stackPanel.Children.Add(new RelationColumn(dm, pi) { ColumnWidth = ColomnWidth });
					//} else if(IsTOrCollectionOfT<IDataValue>(t)) {
					//	_stackPanel.Children.Add(new ValueColumn(dm, pi) { ColumnWidth = ColomnWidth });
				} else if(typeof(IDataDescription).IsAssignableFrom(t)) {//Si DataDescription
					Fiche f = new Fiche() {
						ReadOnly = false,
						SelectedObject = pi.GetValue(dm)
					};
					f.LostFocus += DescriptionFiche_LostFocus;
					_stackPanel.Children.Add(f);
				} else if(typeof(Core.Data.DataObject).IsAssignableFrom(t)) {//Si DataObject
					_stackPanel.Children.Add(new ReferencesColumn(dm, pi, Database) { ColumnWidth = ColomnWidth });
					//StackPanel ver = new StackPanel() { Orientation = Orientation.Vertical };
					//ver.Children.Add(new TextBlock() { Text = pi.Name, FontWeight = FontWeights.Bold });
					//Fiche f = new Fiche() { ReadOnly = true, SelectedObject = pi.GetValue(dm) };
					//ver.Children.Add(f);
					//_stackPanel.Children.Add(ver);
				} else if(typeof(IEnumerable).IsAssignableFrom(t) ) {//collection de valeurs de base
					Type gen = t.GetGenericArguments()[0];
					if(typeof(string).IsAssignableFrom(gen))
						_stackPanel.Children.Add(new ValueColumn<string>(dm, pi));
					else if(gen.IsEnum)
						_stackPanel.Children.Add(ValueColumn<int>.GetEnumValueColumn(dm, pi, gen));
					else if(typeof(int).IsAssignableFrom(gen))
						_stackPanel.Children.Add(new ValueColumn<int>(dm, pi));
					else if(typeof(double).IsAssignableFrom(gen))
						_stackPanel.Children.Add(new ValueColumn<double>(dm, pi));
					else if(typeof(float).IsAssignableFrom(gen))
						_stackPanel.Children.Add(new ValueColumn<float>(dm, pi));
					else
						_stackPanel.Children.Add(new DefaultColumn(dm, pi));
                } else {//Si autre chose
					StackPanel ver = new StackPanel() { Orientation = Orientation.Vertical };
					ver.Children.Add(new TextBlock() { Text = pi.Name, FontWeight = FontWeights.Bold });
					Fiche f = new Fiche() { ReadOnly = true, SelectedObject = pi.GetValue(dm)};
					ver.Children.Add(f);
					_stackPanel.Children.Add(ver);
				}
			}
		}

		/// <summary>
		/// When focus is lost, save the description
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DescriptionFiche_LostFocus( object sender, RoutedEventArgs e ) {
			try {
				Fiche f = sender as Fiche;
				IDataDescription des = f.SelectedObject as IDataDescription;
				if(des.Id == 0)
					Context.GlobalContext.Data.Insert(des);
				else
					des.SaveObject();
			} catch(Exception ex) {
				Context.GlobalContext.ReportMessage(MessageType.WARNING,ex.Message);
				Context.GlobalContext.ReportException(ex);
			}
        }

		/// <summary>
		/// True if the type is assignable from T, or is a collection from types assignable from T.
		/// </summary>
		/// <typeparam name="T">The Type to Compare t with.</typeparam>
		/// <param name="t">The type to check.</param>
		/// <returns>True is assignable or collection of.</returns>
		private bool IsTOrCollectionOfT<T>(Type t ) {
			return (typeof(IEnumerable).IsAssignableFrom(t) && typeof(T).IsAssignableFrom(t.GetGenericArguments()[0]))
                    || typeof(T).IsAssignableFrom(t);
        }

		/// <summary>
		/// Vérifie que le type est d'un type que l'on ne veut pas afficher d'une manière spécifique.
		/// </summary>
		/// <param name="t"></param>
		/// <returns>True si laisser la DataGrid gérer le type elle-même. (ne pas s'en occuper)</returns>
		private bool LetItBe(Type t ) {
			return typeof(string).IsAssignableFrom(t)
					|| typeof(int).IsAssignableFrom(t)
					|| typeof(int?).IsAssignableFrom(t)
					|| typeof(double).IsAssignableFrom(t)
					|| typeof(double?).IsAssignableFrom(t)
					|| typeof(decimal).IsAssignableFrom(t)
					|| typeof(decimal?).IsAssignableFrom(t)
					|| typeof(bool).IsAssignableFrom(t)
					|| typeof(bool?).IsAssignableFrom(t)
					|| t.IsEnum
					|| t.IsNullableEnum();
        }

		/// <summary>
		/// Entoure l'élément avec un cadre.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		private UIElement WrapInBorder( UIElement e ) {
			Border b = new Border() {
				BorderBrush = Brushes.Black,
				BorderThickness = new Thickness(0, 0, 1, 0),
				Padding = new Thickness(2)
			};
			b.Child = e;
			return b;
		}
	}
}
