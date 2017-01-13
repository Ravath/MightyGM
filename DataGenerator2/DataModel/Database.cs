using DataGenerator2.DataModel;
using DataGenerator2.CSharp;
using DataGenerator2.SQL;
using DataGenerator2.Parser;
using DataGenerator2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator2.DataModel {
	public class Database : DataConstructor {
		#region Members
		//private TableList _tables = new TableList();
		private string dataNamespace;
		private DetailedTables _tables = new DetailedTables();
		#endregion
		
		#region Properties
		public IEnumerable<AbsTable> Tables { get { return _tables.Tables; } }

		public bool UseSQLForeignKeys { get; set; }

		public string DataBaseName	{ get; private set; }
		public string RepoRoot		{ get; private set; }
		public string RepoGenerated { get; private set; }
		public string RepoSpecific	{ get; private set; }
		public string RepoSQL		{ get; private set; } 
		public DetailedTables FinalTables { get { return _tables; } }
		#endregion

		public Database( RawData data ) {
			if(string.IsNullOrWhiteSpace(data.DatabaseName))
				ErrorManager.Error("you don't Have a database name.");
			DataBaseName = Pascalise(data.DatabaseName);
			dataNamespace = DataBaseName + ".Data";
			//Creation et organisation des dossiers
			RepoRoot = DataBaseName + "Data";
			RepoGenerated = RepoRoot + "\\Generated";
			RepoSpecific = RepoRoot + "\\UserMade";
			RepoSQL = RepoGenerated + "\\SQL";
			//create tables
			_tables.DatabaseName = Pascalise(data.DatabaseName);
			foreach(RawTable rw in data.RawTables) {
				AbsTable table = CreateTable(rw);
                _tables.AddTable(table);
            }
			CreateParentHierarchy(data.RawTables, _tables);
			CreateTypes(data.RawTables, _tables);
			//ComputeJointTables();
		}

		public override void ToConsole() {
			Console.WriteLine("Database : " + DataBaseName);
			foreach(AbsTable tab in _tables) {
				tab.ToConsole();
			}
		}

		private AbsTable CreateTable ( RawTable table ) {
			switch(table.Type.ToLower()) {
				case "enumtable":
				return new EnumTable(table);
				case "datatable":
				return new DataTable(table);
				case "dicetable":
				return new DiceTable(table);
				case "structtable":
				return new StructTable(table);
				default:
				ErrorManager.Error("Can't find the table type " + table.Type);
				return null;
			}
		}
		/// <summary>
		/// Parcours les RawAttributs des strucTables (et DataTables) et les convertit en AbsAttribute.
		/// </summary>
		/// <param name="rTables"></param>
		/// <param name="tables"></param>
		private void CreateTypes( IEnumerable<RawTable> rTables, DetailedTables tables ) {
			foreach(RawTable rTab in rTables) {//pour chaque table
				//uniquement des structTable (et donc des datatable aussi)
				if(!(tables.FindTable(rTab.Name.ToLower()) is StructTable))
					continue;
				//pour chaque attribut
				foreach(RawAttribute rAtt in rTab.Attributes) {
					//créer le type
					ValueType vt = ValueType.ConvertToType(rAtt, tables);
					if(vt == null) {//erreur à la création du type
						ErrorManager.Error("Error when building type of : " + rAtt.Name);
						continue;
					}
					//trouver l'attribut
					ValueAttribute va = tables.FindTable(rTab.Name.ToLower())
						.Attributes.SingleOrDefault(w => w.Name.ToLower() == rAtt.Name.ToLower()) as ValueAttribute;
					if(va!=null)//assigner son type
						va.Type = vt;
					else {//erreur : l'attribut n'existe pas
						ErrorManager.Error("Can't find the attribute:" + rAtt.Name + " in table " + rTab.Name);
					}
					if(va.Type is ReferenceType && !string.IsNullOrWhiteSpace(rAtt.Target)) {
						ReferenceType rt = (ReferenceType)va.Type;
						//trouver attribut ds la table référencée
						AbsAttribute retAtt = rt.ReferencedTable.Attributes.SingleOrDefault(
							r=>r.Name.ToLower() == rAtt.Target.ToLower()
						);if(retAtt == null) {
							ErrorManager.Error(string.Format("{0}({1}) can't find his conterpart {2}({3})"
								,rTab.Name, rAtt.Name, rt.ReferencedTable.Name, rAtt.Target));
						}
                        foreach(AbsAttribute refAtt in rt.ReferencedTable.Attributes) {
							if(refAtt.Name.ToLower() == rAtt.Target.ToLower()) {
								rt.ReferencedAttribute = (ValueAttribute)refAtt;//linker
                                break;
							}
						}
					}
				}
			}
		}

		private void CreateParentHierarchy( IEnumerable<RawTable> rtables, DetailedTables tables ) {
			foreach(RawTable rt in rtables) {
				if(string.IsNullOrWhiteSpace(rt.MajorTag)) { continue; }
				string parent = rt.MajorTag.ToLower();
				string name = rt.Name.ToLower();
				if(name == parent) {
					ErrorManager.Error("Une table ne peux être sa propre parente: " + name);
					continue;
				}
				if(parent != "") {
					tables.FindTable(parent).Fils = tables.FindTable(name);
				}
			}
		}

		public override bool CheckIntegrity() {
			bool integre = true;
			//aucun nom de table en double
			integre = TrouverDoublons(_tables.Select(p => p.Name)) ? false : integre;
			//intégrité des tables
			foreach(AbsTable table in _tables) {
				integre = table.CheckIntegrity() ? integre : false;
			}
			return integre;
		}

	}
}
