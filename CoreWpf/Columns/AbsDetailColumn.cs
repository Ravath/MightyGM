using Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoreWpf.Columns {
	/// <summary>
	/// Un control affichant les valeurs d'une propriété en colonne.
	/// </summary>
	/// <typeparam name="T">The type of data of the property.</typeparam>
	/// <typeparam name="O">The type of the object holding the property.</typeparam>
	public abstract class AbsDetailColumn<O,T> : UserControl {
		#region Members
		private Type _dataType;
		private StackPanel _stack;
		private StackPanel _list;
		private TextBlock _title;
		private StackPanel _before, _after;
		private List<T> _data = new List<T>();
		private List<T> _prevData = new List<T>();
		private int _columnWidth;
		private PropertyInfo _property;
		private bool _single;
		private Dictionary<T, UIElement> _dataDisplayLink = new Dictionary<T, UIElement>();
		// A delegate type for hooking up clearList event.
		public delegate void ClearListEventHandler( object sender, EventArgs e );
		public event ClearListEventHandler ListCleared;
		#endregion

		#region Properties
		protected StackPanel BeforeList { get {return  _before; } }
		protected StackPanel AfterList { get {return  _after; } }
		protected List<T> Data { get { return _data; } }
		protected List<T> PreviousData { get { return _prevData; } }
		/// <summary>
		/// La largeur de la colonne.
		/// </summary>
		public int ColumnWidth {
			get { return _columnWidth; }
			set {
				_columnWidth = value;
				_stack.MinWidth = value;
			}
		}
		/// <summary>
		/// Le type de données de la collection.
		/// </summary>
		public Type DataType {
			get { return _dataType; }
			private set {
				_dataType = value;
				_title.Text = Title(value, _property);
            }
		}
		/// <summary>
		/// L'objet dont on affiche la propriété.
		/// </summary>
		public O Object { get; private set; }
		/// <summary>
		/// La propriété de l'objet qui est affichée.
		/// </summary>
		public PropertyInfo Property {
			get { return _property; }
			private set {
				if(_property == value) { return; }
				_property = value;
				Type t = _property.PropertyType;
				if(typeof(IEnumerable).IsAssignableFrom(t)) {
					Single = false;
					DataType = t.GetGenericArguments()[0];
				} else {
					Single = true;
					DataType = t;
				}
			}
		}
		/// <summary>
		/// Définit la cardinalité de la référence : 1 ou *.
		/// </summary>
		public bool Single {
			get { return _single; }
			private set {
				if(_single == value) { return; }
				_single = value;
			}
		}
		/// <summary>
		/// Pour sauvegarder automatiquement l'Objet lors d'un changement des valeurs de la propriété.
		/// </summary>
		public bool AutoSave { get; set; }
		#endregion

		#region Init
		public AbsDetailColumn(O obj, PropertyInfo pi) : base() {
			//Creation du controleur
			_stack = new StackPanel() { MinWidth = ColumnWidth };
			_list = new StackPanel() { Margin = new Thickness(2) };
			_title = new TextBlock() { FontWeight = FontWeights.Bold };
			_before = new StackPanel() { MinWidth = ColumnWidth };
			_after = new StackPanel() { MinWidth = ColumnWidth };
            _stack.Children.Add(_title);
			_stack.Children.Add(_before);
			_stack.Children.Add(_list);
			_stack.Children.Add(_after);
			this.Content = WrapInBorder(_stack);
			AutoSave = true;
			ColumnWidth = 120;
			InitListe(obj, pi);
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
		/// <summary>
		/// Met à jour les propriétés de l'objet avec les valeurs de la liste.
		/// </summary>
		public virtual void Save() {
			if(Single) {
				if(_data.Count()>=1)
					Property.SetValue(Object, _data[0]);
				else
					Property.SetValue(Object, null);
			} else {
				//Construire IEnumerable de type compatible
				Type constr = typeof(List<>).MakeGenericType(new Type[] { DataType });
				IList il = (IList)Activator.CreateInstance(constr);
				foreach(T obj in Data) {
					il.Add(obj);
				}
				Property.SetValue(Object, il);
			}
		}
		/// <summary>
		/// Initialiser la liste avec les valeurs de a propriété de l'objet.
		/// </summary>
		/// <param name="obj">L'objet inspecté.</param>
		/// <param name="pi">La propriété à récupérer</param>
		public void InitListe( O obj, PropertyInfo pi ) {
			//ne pas mettre à jour l'objet qui nous donne ses valeurs
			bool save = AutoSave;
			AutoSave = false;
			//maj
			ClearList();
            Object = obj;
			Property = pi;
			if(Single) {
				Add((T)pi.GetValue(obj));
			} else {
				Add(((IEnumerable<T>)pi.GetValue(obj)).ToArray());
			}
			//remettre ancienne valeur
			AutoSave = save;
		}
		/// <summary>
		/// Vide la liste de la colonne.
		/// </summary>
		public void ClearList() {
			if(ListCleared!=null)
				ListCleared(this, null);
            _prevData.Clear();
			_prevData.AddRange(_data);
			_data.Clear();
			_list.Children.Clear();
			_dataDisplayLink.Clear();
		}
		/// <summary>
		/// Ajouter des éléments à la liste de la DetailColumn.
		/// </summary>
		/// <param name="newElements">Liste des éléments à ajouter</param>
		protected void Add( params T[] newElements ) {
			foreach(T item in newElements) {
				if(item == null) { return; }
				_data.Add(item);
				UIElement disp = Display(item);
                _list.Children.Add(disp);
				_dataDisplayLink.Add(item, disp);
            }
		}
		protected void Remove( T dataValue ) {
			_data.Remove(dataValue);
			_list.Children.Remove(_dataDisplayLink[dataValue]);
		}
		/// <summary>
		/// Définit la manière dont un objet de la liste est affiché.
		/// </summary>
		/// <param name="data">L'objet à afficher.</param>
		/// <returns>Le label de l'objet.</returns>
		protected abstract UIElement Display( T data );
		/// <summary>
		/// Returns the title of the column
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		protected virtual string Title( Type dataType, PropertyInfo pi ) {
			return pi.Name;
		}
	}
}
