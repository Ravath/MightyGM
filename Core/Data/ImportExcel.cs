using Core.Data;
using Core.Data.Schema;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data {
	public class ImportExcel {

		public static ISheet CreateSheet( IWorkbook w, Database db, Type t ) {
			ISheet s = w.CreateSheet(t.Name);

			// * Creer le header avec nom des propriétés *
			//obtenir les types recherchés
			IRow header = s.CreateRow(0);
			var tpi = t.GetProperties()
				.Where(tp => (!tp.PropertyType.IsClass 
					&& !typeof(IEnumerable).IsAssignableFrom(tp.PropertyType))
					|| tp.PropertyType == typeof(string))
				.Reverse();//Comme les propriétés les parentes sont en dernier, en retournant, on a Id et Nom en premier.
			//créer le style de cellule du header
			ICellStyle HeaderCellStyle = w.CreateCellStyle();
			HeaderCellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey40Percent.Index;
			IFont boldFont = w.CreateFont();
			boldFont.IsBold = true;
			HeaderCellStyle.SetFont(boldFont);
			//créer le header
            for(int i = 0; i < tpi.Count(); i++) {
				NPOI.SS.UserModel.ICell cs = header.CreateCell(i);
				cs.SetCellValue(tpi.ElementAt(i).Name);
				cs.CellStyle = HeaderCellStyle;
			}
			// * ajouter les valeurs *
			IEnumerable<object> enumer = db.GetDataTable(t);
			for(int j = 0; j < enumer.Count(); j++) {
				IRow nr = s.CreateRow(j + 1);
				for(int i = 0; i < tpi.Count(); i++) {
					NPOI.SS.UserModel.ICell cs = nr.CreateCell(i);
					object o = tpi.ElementAt(i)?.GetValue(enumer.ElementAt(j)) ?? "";
					if(typeof(double).IsAssignableFrom(o.GetType())) {
						cs.SetCellValue((double)o);
					} else if(typeof(decimal).IsAssignableFrom(o.GetType())) {
						cs.SetCellValue(o.ToString());
					} else if(typeof(int).IsAssignableFrom(o.GetType())) {
						cs.SetCellValue((int)o);
					} else if(typeof(bool).IsAssignableFrom(o.GetType())) {
						cs.SetCellValue((bool)o);
					} else {
						cs.SetCellValue(o.ToString());
					}
				}
			}

			return s;
        }

		/// <summary>
		/// Une liste d'objets du type désiré, importé de la feuille excel spécifiée.
		/// La correspondance avec les données se base sur les noms de colonnes spécifiés en première ligne. Casse respectée.
		/// Ne récupére pas la description.
		/// </summary>
		/// <typeparam name="T">Type d'objet à importer.</typeparam>
		/// <param name="filepath">Chemin du fichier excel.</param>
		/// <param name="sheetName">Feuille excel à importer.</param>
		/// <returns>null si n'a pas trouvé de feuille ou si ne peux pas ouvrir le fichier.</returns>
		public static List<T> Import<T>(string filepath, string sheetName ) where T : new(){
			List<T> ret = new List<T>();
			//ouvrir le fichier
			IWorkbook workbook;
			try {
                using(FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read)) {
					workbook = WorkbookFactory.Create(file);
				}
			} catch(IOException) {
				return null;
			}
			ISheet sheet = workbook.GetSheet(sheetName);
			if(sheet == null)
				return null;
			//Faire la correspondance entre propriétés et colonnes
			Dictionary<PropertyInfo, int> correspondance = new Dictionary<PropertyInfo, int>();
			IRow firstRow = sheet.GetRow(sheet.FirstRowNum);
			foreach(PropertyInfo prop in typeof(T).GetProperties()) {
				correspondance.Add(prop, -1);
				if(prop.Name.ToLower() == "description") // ne pas faire la description
					continue;
				for(int i = 0; i < firstRow.Count(); i++) {//parcourir les noms de colonnes
					NPOI.SS.UserModel.ICell colName = firstRow.GetCell(i);
					if(prop.Name.ToLower() == colName.StringCellValue.ToLower()) {
						correspondance[prop] = i;
						break;
                    }
				}
			}
			//Extraire les données
			for(int i = sheet.FirstRowNum+1; i <= sheet.LastRowNum; i++) {//pour chaque ligne
				IRow currentRow = sheet.GetRow(i);
				if(currentRow == null)
					continue;
				T nt = new T();
				foreach(PropertyInfo pi in correspondance.Keys) {
					if(correspondance[pi] < 0)
						continue;
					NPOI.SS.UserModel.ICell currentCell = currentRow.GetCell(correspondance[pi]);
					if(currentCell == null)
						continue;
					//trouver le type de la propriété et convertir en conséquence.
					if(pi.PropertyType == typeof(int)) {
						if(currentCell.CellType == CellType.Numeric)
							pi.SetMethod.Invoke(nt, new Object[] { (int)currentCell.NumericCellValue });
						else
							pi.SetMethod.Invoke(nt, new Object[] { Int32.Parse( currentCell.StringCellValue ) });
					}
					else if(pi.PropertyType == typeof(char)) {
						if(currentCell.CellType == CellType.Numeric)
							pi.SetMethod.Invoke(nt, new Object[] { (char)currentCell.NumericCellValue });
						else
							pi.SetMethod.Invoke(nt, new Object[] { Char.Parse(currentCell.StringCellValue) });
					}
					else if(pi.PropertyType == typeof(double)) {
						if(currentCell.CellType == CellType.Numeric)
							pi.SetMethod.Invoke(nt, new Object[] { (double)currentCell.NumericCellValue });
						else
							pi.SetMethod.Invoke(nt, new Object[] { double.Parse(currentCell.StringCellValue) });
					}
					else if(pi.PropertyType == typeof(float)) {
						if(currentCell.CellType == CellType.Numeric)
							pi.SetMethod.Invoke(nt, new Object[] { (float)currentCell.NumericCellValue });
						else
							pi.SetMethod.Invoke(nt, new Object[] { float.Parse(currentCell.StringCellValue) });
					} else if(pi.PropertyType == typeof(Decimal)) {
						if(currentCell.CellType == CellType.Numeric)
							pi.SetMethod.Invoke(nt, new Object[] { (Decimal)currentCell.NumericCellValue });
						else
							pi.SetMethod.Invoke(nt, new Object[] { Decimal.Parse(currentCell.StringCellValue) });
					} else if(pi.PropertyType == typeof(string)) {
						string stringVal = currentCell.StringCellValue;
						pi.SetMethod.Invoke(nt, new Object[] { stringVal });
					} else if(pi.PropertyType.IsEnum) {
						string stringEnum = currentCell.StringCellValue;
						if(string.IsNullOrEmpty(stringEnum))
							continue;
						object enumVal = Enum.Parse(pi.PropertyType, stringEnum);
						pi.SetMethod.Invoke(nt, new Object[] { enumVal });
					} else if(pi.PropertyType == typeof(bool)) {
						bool boolVal = false;
						if(currentCell.CellType == CellType.Boolean) {
							boolVal = currentCell.BooleanCellValue;
						} else if(currentCell.CellType == CellType.String) {
							string stringBool = currentCell.StringCellValue.ToLower();
							switch(stringBool) {
								case "true": case "vrai": case "oui": case "yes": boolVal = true;
								break;
								case "false": case "faux": case "non": case "no": boolVal = false;
								break;
								default: // Console.WriteLine("Pb de conversion de la string '{0}' en bool. false par défaut.", stringBool);
								break;
							}
						} else {
							//Console.WriteLine("Pb de conversion en bool. false par défaut.");
						}	
						pi.SetMethod.Invoke(nt, new Object[] { boolVal });
					} else {
						//Console.WriteLine("Propriété non convertible.");
					}
				}
				ret.Add(nt);
			}

			return ret;
		}

		public static XWPFDocument WriteDocument( Type t, Database db ) {
			XWPFDocument doc = new XWPFDocument();

			XWPFParagraph pg;
			XWPFRun r;
            foreach(object obj in db.GetDataTable(t).ToArray()) {
				pg = doc.CreateParagraph();
				//Le nom
				PropertyInfo pname = t.GetProperty("Name");
				if(pname != null) {
					r = pg.CreateRun();
					r.IsBold = true;
					r.FontSize = 20;
					r.SetText(pname.GetValue(obj).ToString());
				}
				//Propriétés standards
                foreach(PropertyInfo pi in t.GetProperties().Reverse()) {
					if( pi.GetCustomAttribute(typeof(HiddenPropertyAttribute)) != null)
						continue;
					if(pi.Name == "Name")
						continue;
					else if(typeof(IDataDescription).IsAssignableFrom(pi.PropertyType))//paragraphe dédié pour la Description.
						continue;
					WriteParagraph(obj, pi, doc);//écrire la propriété
				}
				//la description
				PropertyInfo pdesc = t.GetProperty("Description");
				if(pdesc != null) {
					IDataDescription idesc = (IDataDescription) pdesc.GetValue(obj);
					pg = doc.CreateParagraph();
					r = pg.CreateRun();
                    r.IsBold = true;
					r.IsItalic = true;
					r.FontSize = 15;
					r.SetText("Description");
					r.AddCarriageReturn();
					foreach(PropertyInfo pi in idesc.GetType().GetProperties().Reverse()) {
						if(pi.GetCustomAttribute(typeof(HiddenPropertyAttribute)) != null)
							continue;
						WriteParagraph(idesc, pi, doc);
                    }
				}
            }
			return doc;
        }
		private static void WriteParagraph( object obj, PropertyInfo pi, XWPFDocument doc ) {
			XWPFParagraph pg = doc.CreateParagraph();
			XWPFRun r = pg.CreateRun();
			if(typeof(string).IsAssignableFrom(pi.PropertyType)) {//string
				r.IsBold = true;
				r.SetText(pi.Name + ":");
				r = pg.CreateRun();
				r.IsBold = false;
				r.SetText(pi.GetValue(obj).ToString());
			} else if(typeof(IEnumerable).IsAssignableFrom(pi.PropertyType)) {//collection
				r.IsBold = true;
				r.SetText(pi.Name + ":");
				r.AddCarriageReturn();
				foreach(var item in (IEnumerable)pi.GetValue(obj)) {
					r = pg.CreateRun();
					r.AddTab();
					r.SetText(item.ToString());
					r.AddCarriageReturn();
				}
			} else {//valeur de base
				r.IsBold = true;
				r.SetText(pi.Name + ":");
				r = pg.CreateRun();
				r.IsBold = false;
				r.SetText(pi.GetValue(obj).ToString());
			}
		}
	}
}
