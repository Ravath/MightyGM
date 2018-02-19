using Core.Data;
using Core.Data.Schema;
using CoreWpf.Columns;
using LinqToDB.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CoreWpf.UI
{

	/// <summary>
	/// Affiche les détails de l'objet courant en utilisant la réflexion.
	/// </summary>
	public class Fiche : UserControl, IFiche<object> {

		#region Members
		private object _obj;
		private StackPanel _stackProperties = new StackPanel();
		private StackPanel _stackContent = new StackPanel();
		private Expander _descriptions = new Expander();
		private bool _hasDescription = false;
		private bool _readOnly = true;
		//private List<UIElement> _titles = new List<UIElement>();
		//private List<UIElement> _values = new List<UIElement>();
		#endregion

		#region Property
		public bool ReadOnly {
			get { return _readOnly; }
			set {
				_readOnly = value;
				foreach(Fiche f in _stackProperties.Children.OfType<Fiche>()) {
					f.ReadOnly = value;
				}
				foreach(Fiche f in ((StackPanel)_descriptions.Content).Children.OfType<Fiche>()) {
					f.ReadOnly = value;
				}
			}
		}
		public bool DisplayId { get; set; }
		public bool DisplayCollectionEditors { get; set; }
		public object SelectedObject {
			get { return _obj; }
			set {
				_obj = value;
				RefreshContent();
			}
		}
		#endregion

		#region Init
		public Fiche() : base() {
			this.HorizontalAlignment = HorizontalAlignment.Stretch;
			_stackProperties.Orientation = Orientation.Vertical;
			_stackContent.Orientation = Orientation.Vertical;
			AddChild(_stackContent);
			_stackContent.Children.Add(_stackProperties);
			_descriptions.HorizontalAlignment = HorizontalAlignment.Left	;
			_descriptions.Header = "Description";
			//_descriptions.Width = 200;
			_descriptions.Content = new StackPanel() { Orientation = Orientation.Vertical };
			DisplayId = false;
		}
		#endregion

		protected void ClearContent() {
			_stackProperties.Children.Clear();
			//_titles.Clear();
			//_values.Clear();
            _stackContent.Children.Remove(_descriptions);
			((StackPanel)_descriptions.Content).Children.Clear();
			_hasDescription = false;
		}

		public void RefreshContent() {
			ClearContent();
			if(_obj == null) { return; }
			foreach(PropertyInfo prop in _obj.GetType().GetProperties()) {
				if(!DisplayId) {
					if(null != prop.GetCustomAttribute(typeof(PrimaryKeyAttribute)))
						continue;
				}
				if(null != prop.GetCustomAttribute(typeof(HiddenPropertyAttribute)))
					continue;
				if(typeof(IDataDescription).IsAssignableFrom(prop.PropertyType)) {
					IDataDescription des = (IDataDescription)prop.GetValue(_obj);
					AddDescription(des);
					continue;
				}
				UIElement uie = null;
				if(ReadOnly && prop.GetMethod.IsPublic)
					uie = AddPropertyReadOnly(prop);
				else if(prop.SetMethod?.IsPublic == true && prop.GetMethod?.IsPublic == true) {
					uie = AddProperty(prop);
				}
				if(uie == null) { continue; }
				if(prop.Name.ToLower() == "name")
					_stackProperties.Children.Insert(0, uie);
				else
					_stackProperties.Children.Add(uie);
			}
		}

		protected virtual UIElement AddProperty( PropertyInfo prop ) {
			//conteneur ligne
			DockPanel sp = new DockPanel
			{
				DataContext = SelectedObject,
				Margin = new Thickness(3)
			};
			//sp.Orientation = Orientation.Horizontal;
			//nom propriété
			TextBlock tbName = new TextBlock
			{
				Text = prop.Name,
				Width = 100,
				FontWeight = FontWeights.Bold
			};
			sp.Children.Add(tbName);
			DockPanel.SetDock(tbName, Dock.Left);
			//value: collection
			if(typeof(IEnumerable).IsAssignableFrom(prop.PropertyType)
				&& !typeof(string).IsAssignableFrom(prop.PropertyType)) {
				if(!DisplayCollectionEditors) { return null; }
				//container
				Type tempType = GetTemplateTypeFromIEnumerable(prop.PropertyType);
				//if(typeof(IDataRelation).IsAssignableFrom(tempType)) {
				//	sp.Children.Add(new RelationColumn((Core.Data.DataObject)_obj, prop));
				if(typeof(DataModel).IsAssignableFrom(tempType)) {
					sp.Children.Add(new DefaultColumn((Core.Data.DataModel)_obj, prop));
				} else if(typeof(Core.Data.DataObject).IsAssignableFrom(tempType)) {
					sp.Children.Add(new DefaultColumn((Core.Data.DataObject)_obj, prop));
				} else {
					StackPanel liste = new StackPanel{Orientation = Orientation.Vertical};
					sp.Children.Add(liste);
					liste.Children.Add(new TextBlock() { Text = "Not Implemented:" + tempType.Name });
				}
			} else {
				//value : not collection
				//FrameworkElement ui = GetModifiableValueContaineur(prop);
				//_uiModifieurs.Add(ui, prop);
				UserControl ui = new ValueModifierControl(_obj, prop)
				{
					HorizontalAlignment = HorizontalAlignment.Left,
					Width = 100
				};
				sp.Children.Add(ui);
			}
			return sp;
		}

		private Type GetTemplateTypeFromIEnumerable( Type en ) {
			return en.GenericTypeArguments[0];
		}

		protected virtual UIElement AddPropertyReadOnly( PropertyInfo prop ) {
			//conteneur ligne
			DockPanel sp = new DockPanel
			{
				Margin = new Thickness(3)
			};
			//sp.Orientation = Orientation.Horizontal;
			//nom propriété
			TextBlock tbName = new TextBlock
			{
				Text = prop.Name,
				Width = 100,
				FontWeight = FontWeights.Bold
			};
			sp.Children.Add(tbName);
			DockPanel.SetDock(tbName, Dock.Left);
			//value: collection
			if(typeof(IEnumerable).IsAssignableFrom(prop.PropertyType)
				&& !typeof(string).IsAssignableFrom(prop.PropertyType)) {
				//container
				StackPanel liste = new StackPanel
				{
					Orientation = Orientation.Vertical
				};
				sp.Children.Add(liste);
				//add values
				foreach(object icol in (IEnumerable)prop.GetValue(_obj)) {
					string name;
					if(icol is DataModel) {
						name = ((DataModel)icol).Name;
					} else if(icol is IDataValue) {
						name = ((IDataValue)icol).Value?.ToString();
					} else if(icol is IDataRelation) {
						name = ((IDataRelation)icol).GetOther((Core.Data.DataObject)_obj)?.ToString();
					} else if(icol is Core.Data.IDataObject) {
						name = ((Core.Data.IDataObject)icol).ToString();
					} else {
						name = icol.ToString();
					}
					liste.Children.Add(new TextBlock() { Text = name });
				}
			} else {//value : not collection
				TextBlock tbVal = new TextBlock
				{
					TextWrapping = TextWrapping.Wrap
				};
				object v = prop.GetValue(_obj);
				if(v is DataModel) {
					tbVal.Text = ((DataModel)v)?.Name;
				} else
					tbVal.Text = v?.ToString();
				tbVal.HorizontalAlignment = HorizontalAlignment.Stretch;
				//tbVal.Width = Math.Max(10, Width - 100);
                sp.Children.Add(tbVal);
			}
			return sp;
		}

		private void AddDescription( IDataDescription d ) {
			if(!_hasDescription) {
				_stackContent.Children.Add(_descriptions);
				_hasDescription = true;
			}
			((StackPanel)_descriptions.Content).Children.Add(
				new Fiche {
					ReadOnly = this.ReadOnly,
					SelectedObject = d
				});
		}
	}
}
