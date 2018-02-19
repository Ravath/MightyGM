using Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MightyGmCtrl;

namespace MightyGmWPF.Tabs {
	/// <summary>
	/// Logique d'interaction pour TabRawData.xaml
	/// La fenetre contient une grille de lecture des objets et une fiche pour lire ou éditer en détail.
	/// </summary>
	public partial class TabRawData : UserControl {
		#region members
		private Context _context;
		#endregion
		#region Proprietes
		public Context Context {
			get { return _context; }
			private set { _context = value; }
		}
		public Type CurrentType {
			get {
				return xDataList.SelectedItem as Type;
			}
		}
		#endregion
		#region Init
		public TabRawData( Context context ) {
			InitializeComponent();
			Context = context;
			xFiche.ReadOnly = true;
			xFiche.DisplayId = false;
			ToReadObjectMode();

			Context.Dll.OnAssemblyChanged += InitTypeList;
		}

		private void InitTypeList(DllData sender, Assembly newAssembly)
		{
			xDataList.InitData(sender.RawDataTables);
		}
		#endregion
		/// <summary>
		/// Recharger la table.
		/// </summary>
		public void RefreshTable() {
			if (xDataList.SelectedItem is Type selected)
				LoadTable(selected);
		}
		/// <summary>
		/// Charge la table du type spécifié.
		/// </summary>
		/// <param name="selectedType">Type de donnée chargée.</param>
		public void LoadTable( Type selectedType ) {
			try {
				if(selectedType == null) {
					xDataGrid.ItemsSource = null;
				} else {
					//Load data.
					IEnumerable enumer = Context.Data.GetDataTable(selectedType);
					//ajoute dans une liste pour permettre edition
					List<Object> l = new List<object>();
					foreach(object v in enumer) {
						l.Add(v);
					}
					xDataGrid.ItemsSource = l;
				}
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ReportException(ex);
			}
		}
		/// <summary>
		/// Evénement déclenché par le choix d'une table de données.
		/// </summary>
		/// <param name="sender">Une ComboBox</param>
		/// <param name="e">Evénement</param>
		private void OnTableChoosed( Type selectedType, SelectionChangedEventArgs e ) {
			LoadTable(selectedType);
			ToReadObjectMode();
			xFiche.SelectedObject = null;
		}
		/// <summary>
		/// Rafraichit la table de donnée.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRefreshButtonClick( object sender, RoutedEventArgs e ) {
			RefreshTable();
        }
		/// <summary>
		/// Lorsqu'une ligne a fini d'être modifiée, enregistrer l'objet.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RowEditEnding( object sender, DataGridRowEditEndingEventArgs e ) {
			Core.Data.DataObject obj = (Core.Data.DataObject)e.Row.Item;
			bool newItem = e.Row.IsNewItem;
			//Commit les modifications
			(sender as DataGrid).RowEditEnding -= RowEditEnding;
			(sender as DataGrid).CommitEdit();
			(sender as DataGrid).RowEditEnding += RowEditEnding;
			//insérer par réflexion
			try {
				if(newItem) {
					AddObjectToDatabase(obj);
                }
				else
					Context.Data.Update(obj);
			} catch(TargetInvocationException tie) {
				MessageBox.Show(tie.InnerException.Message);
				Context.ReportException(tie);
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ReportException(ex);
			}
		}
		/// <summary>
		/// Supprime les items sélectionnés dans le tableau.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDeleteButtonClick( object sender, RoutedEventArgs e ) {
			//supprimer par réflexion
			try {
				foreach(Core.Data.DataObject obj in xDataGrid.SelectedItems.OfType<Core.Data.DataObject>()) {//tous les items sélectionnés
					obj.DeleteObject();
					//Context.Data.Delete(obj);
				}
			} catch(TargetInvocationException tie) {
				MessageBox.Show(tie.InnerException.Message);
			}
			RefreshTable();
		}
		/// <summary>
		/// When the selection changes, remember the item, and set it to the fiche reader.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xDataGrid_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
			DataGrid dg = (DataGrid)sender;
			Core.Data.IDataObject id = dg.SelectedItem as Core.Data.IDataObject;
			SetSelectedObject(id);
		}
		/// <summary>
		/// Collapse the side bar for reading or creating objects.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xFicheExpander_Collapsed( object sender, RoutedEventArgs e ) {
			xFicheExpander.Header = "";
			xFicheExpander.MinWidth = 10;
		}
		/// <summary>
		/// Expand the side bar for reading or creating objects.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xFicheExpander_Expanded( object sender, RoutedEventArgs e ) {
			xFicheExpander.Header = "Fiche";
			xFicheExpander.MinWidth = 220;
        }
		/// <summary>
		/// Assigne l'objet à la fiche de détails
		/// </summary>
		/// <param name="obj"></param>
		private void SetSelectedObject( Core.Data.IDataObject obj ) {
			if(xFiche.ReadOnly) {
				xFiche.SelectedObject = obj;
			} else {
				if(obj == null || xFiche.SelectedObject == null)
					return;
				//copie les valeurs dans la fiche
				if(xFiche.SelectedObject.GetType() != obj.GetType())
					return;
				foreach(PropertyInfo pi in obj.GetType().GetProperties()) {
					if(typeof(IEnumerable).IsAssignableFrom(pi.PropertyType)
						&&! typeof(string).IsAssignableFrom(pi.PropertyType))//ne pas faire les collections
						continue;
					if(pi.GetMethod == null || pi.SetMethod == null)
						continue;
					pi.SetValue(xFiche.SelectedObject, pi.GetValue(obj));
				}
				((Core.Data.DataObject)xFiche.SelectedObject).Id = 0;
				xFiche.RefreshContent();
			}
		}

		/// <summary>
		/// Insère par réflexion l'objet à la base de donnée.
		/// </summary>
		/// <param name="dtobject">object à insérer.</param>
		/// <returns>true is successfull.</returns>
		private bool AddObjectToDatabase(Core.Data.IDataObject dtobject) {
			if(dtobject == null) {
				MessageBox.Show("Can't create a null object.");
				return false;
			}
			try {
				if (dtobject is Core.Data.DataModel dataMod)
				{//est un DataModel
					if (string.IsNullOrWhiteSpace(dataMod.Name))
					{
						MessageBox.Show("This objet must have a name.");
						return false;
					}
					if (Context.Data.Contains(CurrentType, dataMod))
					{
						MessageBox.Show("The database already contains an object with this name.");
						return false;
					}
					dataMod.SaveObject();
				}
				else
				{//bidule aléatoire
					dtobject.SaveObject();
				}
			} catch(TargetInvocationException tie) {
				MessageBox.Show(tie.InnerException.Message);
				return false;
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ReportException(ex);
				return false;
			}
			RefreshTable();
			return true;
        }
		/// <summary>
		/// Créé une nouvelle instance et l'ajoute à la fiche pour édition
		/// </summary>
		private void CreateNewInstance() {
			if(CurrentType == null)
				xFiche.SelectedObject = null;
			else {
				//Creer une instance et assigner à la property grid.
				ConstructorInfo ci = CurrentType.GetConstructor(Type.EmptyTypes);
				if(ci == null) {
					MessageBox.Show("Impossible de créer une instance de cet objet.");
					return;
				}
				xFiche.SelectedObject = (Core.Data.DataObject)ci.Invoke(new Object[] { });
			}
		}
		/// <summary>
		/// State for creating objects : the buttons and fiche reader change.
		/// </summary>
		private void ToCreateObjectMode() {
			xEditModeCtrls.Visibility = Visibility.Visible;
			xReadModeCtrls.Visibility = Visibility.Collapsed;
			xFiche.ReadOnly = false;
		}
		/// <summary>
		/// State for reading objects : the fiche is read only and there is only the button 'new' for entering createMode..
		/// </summary>
		private void ToReadObjectMode() {
			xEditModeCtrls.Visibility = Visibility.Collapsed;
			xReadModeCtrls.Visibility = Visibility.Visible;
			xFiche.ReadOnly = true;
		}
		/// <summary>
		/// Start the craetion of a new object.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NewObject( object sender, RoutedEventArgs e ) {
			ToCreateObjectMode();
			CreateNewInstance();
        }
		/// <summary>
		/// Cancel the creation of a new object.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelNewObject( object sender, RoutedEventArgs e ) {
			ToReadObjectMode();
			xFiche.SelectedObject = null;
		}
		/// <summary>
		/// Add the created object to the database.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddNewObject( object sender, RoutedEventArgs e ) {
			if(AddObjectToDatabase((Core.Data.IDataObject)xFiche.SelectedObject))
				CancelNewObject(sender, e);
        }
		/// <summary>
		/// Add the created object to the database and start the creation of a another object.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddNewObjectAndNewObject( object sender, RoutedEventArgs e ) {
			if(AddObjectToDatabase((Core.Data.IDataObject)xFiche.SelectedObject))
				CreateNewInstance();
		}
		/// <summary>
		/// This wrapper around Convert.ChangeType was done to handle nullable types.
		/// See original authors work here: http://aspalliance.com/852
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="conversionType">The type to convert to.</param>
		/// <returns></returns>
		public static object ChangeType( object value, Type conversionType ) {
			if(conversionType == null) {
				throw new ArgumentNullException("conversionType");
			}
			if(conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) {
				if(value == null) {
					return null;
				}
				NullableConverter nullableConverter = new NullableConverter(conversionType);
				conversionType = nullableConverter.UnderlyingType;
			}
			return Convert.ChangeType(value, conversionType);
		}

		#region Imports&Exports
		/// <summary>
		/// Export the current type data to word format.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnWordExport(object sender, RoutedEventArgs e)
		{
			if (Context.Files.GetWordFile(out string outMessage, false))
			{
				Context.DataExport.ExportModeleDataToWord(CurrentType, outMessage);
			}
			else
			{
				MessageBox.Show(Context.GetMessageRessource("CANT_OPEN_FILE"));
			}
		}

		/// <summary>
		/// Importe les données de la feuille Excel qui correspont au type courant.
		/// Utilise pour cela la feuille de données qui a le nom du type courant.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnWholeExcelImport(object sender, RoutedEventArgs e)
		{
			if (Context.Files.GetExcelFile(out string outMessage, true))
			{
				Context.DataImport.ExcelImport(outMessage, Context.Dll.RawDataTables);
			}
			else
			{
				MessageBox.Show(Context.GetMessageRessource("CANT_OPEN_FILE"));
			}
			RefreshTable();
		}

		/// <summary>
		/// Importe les données de la feuille Excel qui correspont au type courant.
		/// Utilise pour cela la feuille de données qui a le nom du type courant.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnExcelImport(object sender, RoutedEventArgs e)
		{
			if (Context.Files.GetExcelFile(out string outMessage, true))
			{
				Context.DataImport.ExcelImport(outMessage, new List<Type>() { CurrentType });
			}
			else
			{
				MessageBox.Show(Context.GetMessageRessource("CANT_OPEN_FILE"));
			}
			RefreshTable();
		}

		/// <summary>
		/// Export the whole database to the selected file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnExcelExport(object sender, RoutedEventArgs e)
		{
			if (Context.Files.GetExcelFile(out string outMessage, false))
			{
				Context.DataExport.ExportDataToExcel(outMessage, Context.Dll.RawDataTables);
			}
			else
			{
				MessageBox.Show(Context.GetMessageRessource("CANT_OPEN_FILE"));
			}
		}

		private void OnExcelCheck(object sender, RoutedEventArgs e)
		{
			if (Context.Files.GetExcelFile(out string outMessage, true))
			{
				Context.DataImport.CheckExcelData(outMessage);
			}
			else
			{
				MessageBox.Show(Context.GetMessageRessource("CANT_OPEN_FILE"));
			}
		}

		private void OnExportModelJoints(object sender, RoutedEventArgs e)
		{
			if (Context.Files.GetExcelFile(out string outMessage, false))
			{
				Context.DataExport.ExportDataToExcel(outMessage, Context.Dll.JointDataTables);
			}
			else
			{
				MessageBox.Show(Context.GetMessageRessource("CANT_OPEN_FILE"));
			}
		}

		private void OnImportModelJoints(object sender, RoutedEventArgs e)
		{
			//TODO
			MessageBox.Show(Context.GetMessageRessource("NOT_IMPLEMENTED"));
		}
		#endregion
	}
}
