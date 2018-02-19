using DataGenerator.DataModel;
using DataGenerator.CSharp;
using DataGenerator.SQL;
using DataGenerator.Parser;
using DataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.DataModel {
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
				//mainly because didn't find type
				if(table == null) {
					continue;//already send a error message
				}
				//Check for Duplicates
				if(_tables.ContainsTable(table.Name)) {
					ErrorManager.Error(table.Name + " has been found twice.");
				} else {
					_tables.AddTable(table);
				}
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
				ErrorManager.Error(table.Name+" : Can't find the table type " + table.Type);
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
					if(rAtt.Type == null) {
						ErrorManager.Error( rAtt.Name +" Has no type.");
						continue;
                    }
					ValueType vt = ValueType.ConvertToType(rAtt, tables);
					if(vt == null) {//erreur à la création du type
						ErrorManager.Error("Error when building type of : " + rAtt.Name);
						continue;
					}
					//trouver l'attribut
					ValueAttribute va;
                    try {
						va = tables.FindTable(rTab.Name.ToLower())
							.Attributes.SingleOrDefault(w => w.Name.ToLower() == rAtt.Name.ToLower()) as ValueAttribute;
					} catch(InvalidOperationException) {
						ErrorManager.Error(rAtt.Name+" has duplicate names");
						continue;
					}
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
					AbsTable par = tables.FindTable(parent);
					if(par != null)
						par.Fils = tables.FindTable(name);
				}
			}
		}

		public override bool CheckIntegrity() {
			bool integre = true;
			//aucun nom de table en double
			if(TrouverDoublons(_tables.Select(p => p.Name))) {
				integre = false;
				ErrorManager.Error("Il existe des noms de tables en double.");
			}
			//IEnumerable < string > enumnames = _tables.OfType<EnumTable>().Select(p => p.Name.ToLower());
			//intégrité des tables
			foreach(AbsTable table in _tables) {
				//vérifier que la table est ok
				if(!table.CheckIntegrity()) {
					integre = false;
					ErrorManager.Error(string.Format("La table {0} n'est pas intègre.",table.Name));
				}
				//vérifier que l'énum existe
				foreach(ValueAttribute ea in table.Attributes.OfType<ValueAttribute>().
						Where(ia=>ia.Type?.Type == AttributeTypeEnum.Enum)) {
					EnumType et = ea.Type as EnumType;
                    if(et?.EnumReference == null) {
						integre = false;
						ErrorManager.Error(string.Format("L'attribut {0} de la table {1} est d'un type d'énumération non définit.", ea.Name, table.Name));
					}
				}
			}
			return integre;
		}

	}
}
