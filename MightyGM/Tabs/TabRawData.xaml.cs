using Core.Data;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MightyGM.Tabs {
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
        }
		
		public void InitTypeList(IEnumerable<Type> tl ) {
			xDataList.InitData(tl);
		}
		#endregion
		/// <summary>
		/// Recharger la table.
		/// </summary>
		public void RefreshTable() {
			Type selected = xDataList.SelectedItem as Type;
			if(selected != null)
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
			} catch(NpgsqlException ex) {
				MessageBox.Show(ex.Message);
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ExceptionMessage(ex);
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
				Context.ExceptionMessage(tie);
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ExceptionMessage(ex);
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
				foreach(Core.Data.DataObject obj in xDataGrid.SelectedItems) {//tous les items sélectionnés
					Context.Data.Delete(obj); 
				}
			} catch(TargetInvocationException tie) {
				MessageBox.Show(tie.InnerException.Message);
			}
			RefreshTable();
		}
		/// <summary>
		/// Importe les données de la feuille Excel qui correspont au type courant.
		/// Utilise pour cela la feuille de données qui a le nom du type courant.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnExcelImport( object sender, RoutedEventArgs e ) {
			// Create an instance of the open file dialog box.
			System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			// Set filter options and filter index.
			openFileDialog1.Filter = "Text Files (.xl)|*.xlsx;*.xls";
			openFileDialog1.Multiselect = false;
			// Show the dialog and get result.
			System.Windows.Forms.DialogResult result = openFileDialog1.ShowDialog();
			if(result == System.Windows.Forms.DialogResult.OK) { // Test result.
				//demander nom de la feuille excel
				//string nomFeuille = Prompt.ShowDialog("Nom de la feuille:", "");
				//Le nom de la feuille est celui du type
				string nomFeuille = CurrentType.Name;
				//extraire données
				MethodInfo mi = typeof(ImportExcel).GetMethod("Import");
				MethodInfo mg = mi.MakeGenericMethod(new Type[] { CurrentType });
				IList liste = (IList)mg.Invoke(null, new object[] { openFileDialog1.FileName, nomFeuille });
				if(liste == null) {
					MessageBox.Show("Echec d'importation. N'a peut-être pas trouvé la feuille Excel '"+nomFeuille+"', ou le fichier est utilisé par une autre application.");
					return;
				}
				int i = 0;
				try {
					foreach(object temp in liste) {
						Core.Data.DataModel dataMod = temp as Core.Data.DataModel;
						if(dataMod != null) {//est un DataModel
							if(string.IsNullOrWhiteSpace(dataMod.Name)) {
								Context.Message("DataModel object found without name.");
								continue;
							}
							if(Context.Data.Contains(CurrentType, dataMod.Name)) {
								Context.Message("The database already contains a DataModel: "+ dataMod.Name);
								continue;
							}
							dataMod.Id = 0;
							dataMod.SaveObject();
						} else {//bidule aléatoire
							Core.Data.IDataObject dtobject = (Core.Data.IDataObject)temp;
							dtobject.Id = 0;
							dtobject.SaveObject();
						}
					}
				} catch(TargetInvocationException tie) {
					i++;
					Context.Message(tie.Message);
				}
				if(i > 0)
					MessageBox.Show(string.Format("{0} insertions ont levé une Exception.", i.ToString()));
				RefreshTable();
			}
		}
		/// <summary>
		/// Export the whole database to the selected file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnExcelExport( object sender, RoutedEventArgs e ) {
			try { 
				//Select the file
				var dialog = new System.Windows.Forms.SaveFileDialog();
				dialog.Filter = "Excel|*.xlsx";
				System.Windows.Forms.DialogResult result = dialog.ShowDialog();
				if(result == System.Windows.Forms.DialogResult.OK
					|| result == System.Windows.Forms.DialogResult.Yes)
					//If ok, try to export.
					if(Context.Dll.ExportModeleDataToExcel(Context.Data, dialog.FileName))
						MessageBox.Show("Export completed");
					else
						MessageBox.Show("Export aborted");
			}catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ExceptionMessage(ex);
			}
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
				Core.Data.DataModel dataMod = dtobject as Core.Data.DataModel;
				if(dataMod != null) {//est un DataModel
					if(string.IsNullOrWhiteSpace(dataMod.Name)) {
						MessageBox.Show("This objet must have a name.");
						return false;
					}
					if(Context.Data.Contains(CurrentType, dataMod.Name)) {
						MessageBox.Show("The database already contains an object with this name.");
						return false;
					}
					Context.Data.Insert(dataMod);
					dataMod.Description.Model = dataMod;
					Context.Data.Insert(dataMod.Description);
				} else {//bidule aléatoire
					Context.Data.Insert(dtobject);
				}
			} catch(TargetInvocationException tie) {
				MessageBox.Show(tie.InnerException.Message);
				return false;
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ExceptionMessage(ex);
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
		/// <summary>
		/// Export the current type data to word format.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnWordExport( object sender, RoutedEventArgs e ) {
			try {
				//Select the file
				var dialog = new System.Windows.Forms.SaveFileDialog();
				dialog.Filter = "DocumentWord|*.docx";
				System.Windows.Forms.DialogResult result = dialog.ShowDialog();
				if(result == System.Windows.Forms.DialogResult.OK
					|| result == System.Windows.Forms.DialogResult.Yes)
					//If ok, try to export.
					if(Context.Dll.ExportModeleDataToWord(CurrentType, Context.Data, dialog.FileName))
						MessageBox.Show("Export completed");
					else
						MessageBox.Show("Export aborted");
			} catch(Exception ex) {
				MessageBox.Show(ex.Message);
				Context.ExceptionMessage(ex);
			}
		}
	}
}
