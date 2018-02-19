using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NPOI.XWPF.UserModel;
using Core.Data;
using Core.Data.Schema;

namespace MightyGmCtrl.ImportExport
{
	public class ExportWord
	{
		/// <summary>
		/// Write a Word Document whith the data of the given Type stored in DB.
		/// </summary>
		/// <param name="t"></param>
		/// <param name="db"></param>
		/// <returns></returns>
		public static XWPFDocument WriteDocument(Type t, Database db)
		{
			XWPFDocument doc = new XWPFDocument();

			XWPFParagraph pg;
			XWPFRun r;
			foreach (object obj in db.GetDataTable(t).ToArray())
			{
				pg = doc.CreateParagraph();
				//Le nom
				PropertyInfo pname = t.GetProperty("Name");
				if (pname != null)
				{
					r = pg.CreateRun();
					r.IsBold = true;
					r.FontSize = 20;
					r.SetText(pname.GetValue(obj).ToString());
				}
				//Propriétés standards
				foreach (PropertyInfo pi in t.GetProperties().Reverse())
				{
					if (pi.GetCustomAttribute(typeof(HiddenPropertyAttribute)) != null)
						continue;
					if (pi.Name == "Name")
						continue;
					else if (typeof(IDataDescription).IsAssignableFrom(pi.PropertyType))//paragraphe dédié pour la Description.
						continue;
					WriteParagraph(obj, pi, doc);//écrire la propriété
				}
				//la description
				PropertyInfo pdesc = t.GetProperty("Description");
				if (pdesc != null)
				{
					IDataDescription idesc = (IDataDescription)pdesc.GetValue(obj);
					pg = doc.CreateParagraph();
					r = pg.CreateRun();
					r.IsBold = true;
					r.IsItalic = true;
					r.FontSize = 15;
					r.SetText("Description");
					foreach (PropertyInfo pi in idesc.GetType().GetProperties().Reverse())
					{
						if (pi.GetCustomAttribute(typeof(HiddenPropertyAttribute)) != null)
							continue;
						WriteParagraph(idesc, pi, doc);
					}
					pg = doc.CreateParagraph();
					r = pg.CreateRun();
				}
			}
			return doc;
		}

		private static void WriteParagraph(object obj, PropertyInfo pi, XWPFDocument doc)
		{
			XWPFParagraph pg = doc.CreateParagraph();
			XWPFRun r = pg.CreateRun();
			if (typeof(string).IsAssignableFrom(pi.PropertyType))
			{//string
				r.IsBold = true;
				r.SetText(pi.Name + ":");
				r = pg.CreateRun();
				r.IsBold = false;
				r.SetText(pi.GetValue(obj).ToString());
			}
			else if (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType))
			{//collection
				r.IsBold = true;
				r.SetText(pi.Name + ":");
				r.AddCarriageReturn();
				foreach (var item in (IEnumerable)pi.GetValue(obj))
				{
					r = pg.CreateRun();
					r.AddTab();
					r.SetText(item.ToString());
					r.AddCarriageReturn();
				}
			}
			else
			{//valeur de base
				r.IsBold = true;
				r.SetText(pi.Name + ":");
				r = pg.CreateRun();
				r.IsBold = false;
				object val = pi.GetValue(obj);
				if (val == null)
					r.SetText("Null");
				else
					r.SetText(val.ToString());
			}
		}
	}
}
