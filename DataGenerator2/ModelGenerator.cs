using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator2.Parser;
using DataGenerator2.CSharp;
using DataGenerator2.SQL;
using DataGenerator2.DataModel;

namespace DataGenerator2 {
	public class ModelGenerator {
		#region Members
		private Dictionary<string, CSEntity> _annuaireCs = new Dictionary<string, CSEntity>();
		private Dictionary<string, SQLTable> _annuaireSql = new Dictionary<string, SQLTable>();
		private SQLSchema _sql = new SQLSchema();
		private CSNamespace _csNamespace = new CSNamespace();
		private SQLSchema _schema = new SQLSchema();
		private DetailedTables _tabs;
		private Repertory _repRoot,_repGenerated, _repUser, _repSql;
		private CsFile _enumFile, _relFile;
		private SqlFile _sqlFile;
		//References delayed because we have to wait for the classes to be created
		private Dictionary<CSClass, List<ValueAttribute>> _creationAttributeStep = new Dictionary<CSClass, List<ValueAttribute>>();
		private List<Tuple<CSReferenceAttribute, ValueAttribute>> _creationReferencesStep = new List<Tuple<CSReferenceAttribute, ValueAttribute>>();
		#endregion

		#region Properties
		public SQLSchema Schema {
			get { return _schema; }
		}
		public CSNamespace Namespace {
			get { return _csNamespace; }
		}
		#endregion

		#region Init
		public ModelGenerator() { }
		#endregion

		#region Collection tables, classes et fichiers
		public void AddToSql( SQLTable ts ) {
			_sqlFile.Database.AddTable(ts);
			_annuaireSql.Add(ts.Name.ToLower(), ts);
		}

		public void AddToUserMade( CsFile file ) {
			_repUser.AddFile(file);
			file.Namespace = _csNamespace;
			//Ne pas ajouter sinon doublon avec le dossier generated
			//foreach(CSEntity cs in file.Classes) {
			//	_annuaireCs.Add(cs.Name.ToLower(), cs);
			//}
		}

		public void AddToGenerated( CsFile file ) {
			_repGenerated.AddFile(file);
			file.Namespace = _csNamespace;
			foreach(CSEntity cs in file.Classes) {
				_annuaireCs.Add(cs.Name.ToLower(), cs);
			}
		}

		public void AddToEnumFile( CSEnum csEnum ) {
			_enumFile.AddClasse(csEnum);
			_annuaireCs.Add(csEnum.Name.ToLower(), csEnum);
		}

		public void AddToJointure( CSClass cs ) {
			_relFile.AddClasse(cs);
		}

		public CSEntity GetClass( string name ) {
			return _annuaireCs[name.ToLower()];
		}
		public SQLTable GetTable( string name ) {
			return _annuaireSql[name.ToLower()];
		} 
		#endregion

		public void GenererProjet( DetailedTables tabs ) {
			_tabs = tabs;
			_repRoot = new Repertory() { Name = tabs.DatabaseName };
			_repGenerated = new Repertory() { Name = "Generated" };
			_repUser = new Repertory() { Name = "UserMade" };
			_repSql = new Repertory() { Name = "SQL" };
			_repRoot.AddRepertory(_repGenerated);
			_repRoot.AddRepertory(_repUser);
			_repRoot.AddRepertory(_repSql);
			_csNamespace.Name = tabs.DatabaseName + ".Data";
			_schema.Name = tabs.DatabaseName;
			_enumFile = new CsFile("Enum", _csNamespace);
			_relFile = new CsFile("Jointures", _csNamespace);
			_relFile.AddUsing("Core.Data");
            _relFile.AddUsing("Core.Data.Schema");
            _relFile.AddUsing("LinqToDB.Mapping");
			_repGenerated.AddFile(_enumFile);
            _repGenerated.AddFile(_relFile);
			_sqlFile = new SqlFile("SqlGeneration", _schema);
			_sqlFile.Database.AddTable(CSDataObject.sqlDataObject);
            _repSql.AddFile(_sqlFile);
			//generation
			GenerateModel();
			//écriture
			_repRoot.GenerateRepertory();
		}

		private void GenerateModel() {
			//créer classes
			foreach(AbsTable tab in _tabs.Tables.OrderBy(t => t.NombreParents)) {
				GenerateTable(tab);
			}
			//créer attributs
			foreach(CSClass cl in _creationAttributeStep.Keys) {
				foreach(ValueAttribute va in _creationAttributeStep[cl]) {
					GenerateAttribute( cl, va);
                }
			}
			//jointures
			foreach(var item in _creationReferencesStep) {
				LinkReference(item.Item1, item.Item2);
			}
		}

		#region Creation des tables
		private void GenerateTable( AbsTable table ) {
			if(table is DiceTable) {
				GenerateDiceTable((DiceTable)table);
			} else if(table is EnumTable) {
				GenerateEnumTable((EnumTable)table);
            } else if (table is DataTable) {
				GenerateDataTable((DataTable)table);
			} else if (table is StructTable) {
				GenerateStructTable((StructTable)table);
			} else {
				ErrorManager.Error("le type de table " + table.GetType().Name + " n'est pas implémenté.");
			}
		}
		private void GenerateDiceTable( DiceTable table ) {
			GenerateEnumTable((EnumTable)table);
        }
		private void GenerateEnumTable( EnumTable table ) {
			CSEnum et = new CSEnum(table.Name);
			foreach(EnumAttribute tag in table.Attributes) {
				et.AddTag(tag.Name);
			}
			AddToEnumFile(et);
		}
		private void GenerateDataTable( DataTable table ) {
			//fichiers CS
			CsFile genFile = new CsFile(table.Name);
			CsFile userFile = new CsFile(table.Name);
			AddUsings(genFile);
			AddUsings(userFile);
			//classes
			Dictionary<Section, CSClass> classes = new Dictionary<Section, CSClass>();//classes partielles générées
			classes.Add(Section.Model, new CSDataModel(table, Schema));
			classes.Add(Section.Description, new CSDataDescription(table, Schema));
			classes.Add(Section.Exemplar, new CSDataExemplaire(table, Schema));
			//Link avec les fichiers
			foreach(CSClass cs in classes.Values) { 
				genFile.AddClasse(cs);
				userFile.AddClasse(new CSPartialClass(cs));
			}
			//heritage & valeurs de base
			if(table.Parent == null) {
				classes[Section.Exemplar].AddParentTemplate(classes[Section.Model]);
				classes[Section.Description].AddParentTemplate(classes[Section.Model]);
				classes[Section.Model].SQLTable.AddAttribute(new SQLUniqueName());
				classes[Section.Description].SQLTable.AddAttribute(new SQLDescription());
				classes[Section.Description].SQLTable.AddAttribute(new SQLForeignKeyAttribute("model"));
				classes[Section.Exemplar].SQLTable.AddAttribute(new SQLForeignKeyAttribute("model"));
				//foreach(Section sec in classes.Keys)//ajouter id aux tables sql
				//	classes[sec].SQLTable.AddAttribute(new SQLID());
			} else {//Parent existe
				foreach(Section sec in classes.Keys) {
					//lier à la table parente
					classes[sec].Parent = (CSClass)this.GetClass(
						ModelGenerator.ClassNameFromTableName(table.Parent.Name, sec));
					classes[sec].SQLTable.Parent = classes[sec].Parent.SQLTable;
                    classes[sec].SQLTable.AddConstraint(new SQLPrimaryKey(new SQLID()));
				}
			}
			//ajouter Propriete description
			if(!table.IsAbstract) {
				CSDescriptionAttribute cd = new CSDescriptionAttribute(classes[Section.Description], "Description");
				classes[Section.Model].AddAttribute(cd);
            }
			if(table.PJTag) {//tag PJ : ajouter propriété JoueurModel
				SQLForeignKeyAttribute sfk = new SQLForeignKeyAttribute("Joueur");
                CSForeignKey fg = new CSForeignKey(sfk, "Joueur");
                classes[Section.Model].AddAttribute( fg );
                classes[Section.Model].AddAttribute(
					new CSOneToOne(new CSClass("Joueur"), "Joueur")
				);
				classes[Section.Model].SQLTable.AddAttribute(sfk
					);
            }
			foreach(Section sec in classes.Keys) {
				//ajouter la table au modèle. faire avant appariation car link aussi la table au schéma
				this.AddToSql(classes[sec].SQLTable);
			}
			//attributs
			foreach(ValueAttribute vatt in table.Attributes) {
				Section sec = vatt.Section;
				RegisterAttribute(classes[vatt.Section], vatt);
			}
			//ajouter les fichiers de classes au modèle
			AddToUserMade(userFile);
			AddToGenerated(genFile);
		}
		private void GenerateStructTable( StructTable table ) {
			//creation classe
			CSStruct cs = new CSStruct(table, Schema);
			CsFile gen = new CsFile(cs.Name);
			if(table.Parent != null) {
				try {
					CSClass cl = this.GetClass(table.Parent.Name) as CSClass;
					cs.Parent = cl;
					cs.SQLTable.Parent = cl.SQLTable;
					cs.SQLTable.AddConstraint(new SQLPrimaryKey(new SQLID()));
				} catch(KeyNotFoundException) {
					throw new KeyNotFoundException("Can't find the table "+table.Parent.Name+" within the generated tables. Notice structables can't inherits from datatables.");
				}
			}
			//else
			//	cs.SQLTable.AddAttribute(new SQLID());
			gen.AddClasse(cs);
			AddToSql(cs.SQLTable);
			foreach(ValueAttribute vatt in table.Attributes) {
				RegisterAttribute(cs, vatt);
			}
			//fichier et classe partielle.
			AddToGenerated(gen);
			CsFile user = new CsFile(table.Name);
			user.AddClasse(new CSPartialClass(cs));
			AddUsings(gen);
			AddUsings(user);
			AddToUserMade(user);
		}
		public void AddUsings( CsFile file ) {
			file.AddUsing("System");
			file.AddUsing("System.Collections");
			file.AddUsing("System.Collections.Generic");
			file.AddUsing("System.IO");
			file.AddUsing("System.Linq");
			file.AddUsing("System.Data.Linq");
			file.AddUsing("Core.Types");
			file.AddUsing("Core.Data");
			file.AddUsing("Core.Data.Schema");
            file.AddUsing("LinqToDB.Mapping");
		}
		#endregion

		#region Creation des Attributs premier passage
		/// <summary>
		/// Conserver les relations entre classe et attributs pour pouvoir les créer une  fois toutes les classes créées.
		/// </summary>
		/// <param name="cl"></param>
		/// <param name="va"></param>
		private void RegisterAttribute(CSClass cl, ValueAttribute va ) {
			if(!_creationAttributeStep.ContainsKey(cl))
				_creationAttributeStep.Add(cl, new List<ValueAttribute>());
			_creationAttributeStep[cl].Add(va);
        }
		/// <summary>
		/// conserver les références qui ont besoin d'un attribut pour les linker entre eux plus tard, lorsque tous les attributs seront créés.
		/// </summary>
		/// <param name="ra"></param>
		private void RegisterReference( CSReferenceAttribute ra , ValueAttribute va) {
			_creationReferencesStep.Add(new Tuple<CSReferenceAttribute, ValueAttribute>(ra, va));
		}
		/// <summary>
		/// Convert the valueAttribute and add it to the CSClass, and his SQLtable.
		/// </summary>
		/// <param name="cl"></param>
		/// <param name="vatt"></param>
		/// <param name="modelGenerator"></param>
		public void GenerateAttribute( CSClass cl, ValueAttribute vatt ) {
			CSAttribute csAtt;
			SQLAttribute sqlAtt;
			if(vatt.IsReference) {//référence
				GenerateReferenceAttribute(cl, vatt);
			} else if(vatt.Type.Type == AttributeTypeEnum.Range) {//val spé : Range
					CreateRange(cl, vatt);
			} else if(vatt.Type.Type == AttributeTypeEnum.Distance//val spé : Distance ou Time
				|| vatt.Type.Type == AttributeTypeEnum.Time) { 
					CreateUnitValue(cl, vatt);
			} else {//valeur de base
				if(vatt.IsEnum) {//Enumeration
					csAtt = new CSEnumAttribute(
						vatt,
						(CSEnum)this.GetClass(((EnumType)vatt.Type).EnumReference.Name)
					);
				} else {//valeur de base
					csAtt = new CSValueAttribute(vatt);
				}
				sqlAtt = new SQLAttribute(vatt);
				csAtt.AddRelationToSQLAttribute(sqlAtt);
				if(vatt.CardMax == Number.Many) {//collection => créer une table des valeurs
					CreateCollectionValueTable(cl, csAtt, sqlAtt);
				} else {
					cl.AddAttribute(csAtt);
					cl.SQLTable.AddAttribute(sqlAtt);
				}
			}
		}

		private void CreateRange( CSClass cl, ValueAttribute vatt ) {
			CSRangeAttribute csAtt = new CSRangeAttribute(vatt);
			if(csAtt.IsCollection) {
				CSDataValueClass cvc = CreateCollectionValueTable(cl, csAtt,csAtt.SqlMaxAttribute);
				cvc.SQLTable.AddAttribute(csAtt.SqlMinAttribute);
			} else {
				cl.AddAttribute(csAtt);
				cl.SQLTable.AddAttribute(csAtt.SqlMaxAttribute);
				cl.SQLTable.AddAttribute(csAtt.SqlMinAttribute);
			}
		}

		private void CreateUnitValue( CSClass cl, ValueAttribute vatt ) {
			CSUnityValueAttribute cua;
			//creation attribut
			if(vatt.Type.Type == AttributeTypeEnum.Distance) {
				cua = new CSDistanceAttribute(vatt);
			} else {
				cua = new CSTimeAttribute(vatt);
			}
			//creation table si collection de plusieurs valeurs
			if(vatt.CardMax == Number.Many) {//collection => créer une table des valeurs
				CSDataValueClass cvc = CreateCollectionValueTable(cl, cua, cua.SqlUnitAttribute);
				cvc.SQLTable.AddAttribute(cua.SqlValueAttribute);
			} else {
				cl.AddAttribute(cua);
				cl.SQLTable.AddAttribute(cua.SqlUnitAttribute);
				cl.SQLTable.AddAttribute(cua.SqlValueAttribute);
			}
		}

		private CSDataValueClass CreateCollectionValueTable( CSClass from, CSAttribute csAtt, SQLAttribute sqlAtt ) {
			//la valeur à collectionner
			csAtt.IsCollection = false;
			csAtt.IsNullable = false;
			//créer une table et classe des valeurs
			CSDataValueClass collectionClass = new CSDataValueClass(from, (CSValueAttribute)csAtt, sqlAtt, Schema);
			//ajouter aux listes
			AddToSql(collectionClass.SQLTable);
			AddToJointure(collectionClass);
			//attribut de collection du conteneur
			CSDataValueCollectionReference collection = new CSDataValueCollectionReference(collectionClass, csAtt.Name);
			from.AddAttribute(collection);
			from.AddDataValue(collectionClass);
			return collectionClass;
        }

		private void GenerateReferenceAttribute( CSClass cl, ValueAttribute vatt ) {
			ReferenceType rt = (ReferenceType)vatt.Type;
			CSClass refer = (CSClass)GetClassByReference(rt);//only cs classes : enums already done
			if(rt.ReferencedAttribute == null) {
				if(vatt.CardMax == Number.Many) {//Reference To Many
					CSOneToManyJoint csAtt = new CSOneToManyJoint(refer, vatt.Name);
					cl.AddAttribute(csAtt);
					CreateIndirectiontable(csAtt);
				} else {//Reference To One => have an Id to the reference
					SQLForeignKeyAttribute sfk = new SQLForeignKeyAttribute(refer);
					CSForeignKey fk = new CSForeignKey(sfk, vatt.Name);
					CSReferenceToUniqueClass refo = new CSReferenceToUniqueClass(refer, fk, vatt.Name);
					cl.SQLTable.AddAttribute(sfk);
					cl.AddAttribute(fk);
					cl.AddAttribute(refo);
				}
			} else {
				CSReferenceAttribute cra;
				if(vatt.CardMax == Number.Many) {
					if(rt.ReferencedAttribute.CardMax == Number.Many) {//Many to Many
						cra = new CSOneToManyJoint(refer, vatt.Name);
					} else {//One To Many
						cra = new CSOneToMany(refer, vatt.Name);
					}
				} else {
					if(rt.ReferencedAttribute.CardMax == Number.Many) {//Many To One
						cra = new CSManyToOne(refer, vatt.Name);
						SQLForeignKeyAttribute sk = new SQLForeignKeyAttribute(refer);
						CSForeignKey cf = new CSForeignKey(sk, vatt.Name);
						cl.AddAttribute(cf);
						cl.SQLTable.AddAttribute(sk);
					} else {//One to One
						cra = new CSOneToOne(refer, vatt.Name);
						SQLForeignKeyAttribute sk = new SQLForeignKeyAttribute(refer);
						CSForeignKey cf = new CSForeignKey(sk, vatt.Name);
						cl.AddAttribute(cf);
						cl.SQLTable.AddAttribute(sk);
					}
				}
				cl.AddAttribute(cra);
				RegisterReference(cra, vatt);
            }
		}
		#endregion

		private void LinkReference( CSReferenceAttribute csAtt, ValueAttribute va ) {
			//vérifier si pas déjà fait.
			if(csAtt.ReferencedAttribute != null) { return; }
			//trouver l'attribut référencé et linker
			ReferenceType rt = (ReferenceType)va.Type;

			CSReferenceAttribute refer = (CSReferenceAttribute)csAtt.ReferencedClass.Attributes.OfType<CSReferenceAttribute>().
                SingleOrDefault(a => a.Name == rt.ReferencedAttribute.Name);
			if(refer == null) {
				//Cette erreur n'est pas suposée arriver, car cette vérification est censée avoir été effectuée par le parseur.
				ErrorManager.Error("Can't link the attribute " + csAtt.Name + " of class " + csAtt.ReferencedClass.Name + " because the attribute " + rt.ReferencedAttribute.Name + " c'ant be fond. It may not exist or not be of CSReferenceAttribute (It has to link to an attribute).");
				return;
			}

			if(csAtt is CSOneToOne) {
				if(refer is CSOneToOne) {
					csAtt.ReferencedAttribute = refer;
					return;
				} else
					ErrorManager.Error(csAtt.Name + " is supossed to be a OneToOne relationship.");
			}
			if(csAtt is CSManyToOne) {
				if(refer is CSOneToMany) { 
					csAtt.ReferencedAttribute = refer;
					return;
				} else
					ErrorManager.Error(csAtt.Name + " is supossed to be a OneToMany relationship.");
			}
			if(csAtt is CSOneToMany) {
				if(refer is CSManyToOne) {
					csAtt.ReferencedAttribute = refer;
					return;
				} else if(refer is CSOneToMany) {
					CSClass joint = CreateJointTable((CSOneToMany)csAtt, (CSOneToMany)refer);
					csAtt.Class.AddJoint( (CSOneToManyJoint)csAtt, joint );
					refer.Class.AddJoint( (CSOneToManyJoint)refer, joint );
				} else
					ErrorManager.Error(csAtt.Name + " is supossed to be a ManyToOne or ManyToMany relationship.");
			}
		}

		private CSEntity GetClassByReference( ReferenceType rt ) {
			if(rt.Type == AttributeTypeEnum.Refex) {//pointe sur une classe DataModel.Exemplar
				return GetClass(ClassNameFromTableName(rt.ReferencedTable.Name, Section.Exemplar));
			} else if(rt.Type == AttributeTypeEnum.Ref) {
				if(rt.ReferencedTable is DataTable) {//pointe sur une classe DataModel.Model
					return GetClass(ClassNameFromTableName(rt.ReferencedTable.Name, Section.Model));
				} else {//pointe sur une classe DataObject
					return GetClass(ClassNameFromTableName(rt.ReferencedTable.Name, Section.None));
				}
			} else {
				throw new Exception("Type de référence d'un type inconnu. Doit etre Ref ou Refex.");
			}
		}

		private void CreateIndirectiontable( CSOneToManyJoint ra ) {
			CSRelationClass csRel = new CSRelationClass( ra.Class, ra.ReferencedClass, Schema);
			AddToSql(csRel.SQLTable);
			AddToJointure(csRel);
			ra.Joint = csRel;
            ra.FromLeft = true;
			ra.Class.AddJoint(ra, csRel);
			//ra.ReferencedClass = csRel;
			//ra.ReferencedAttribute = csRel.Attribute1;
			ra.Annotations.AddAnnotation(new CSAssociationAnnotation("Id", ra.Name, csRel.Attribute1.PublicIdName, false));
		}

		private CSClass CreateJointTable( CSOneToMany ra, CSOneToMany rb ) {
			CSRelationClass csRel = new CSRelationClass(ra.Class, rb.Class, Schema);
			AddToJointure(csRel);
			AddToSql(csRel.SQLTable);
			CSOneToManyJoint left = ra as CSOneToManyJoint;
			CSOneToManyJoint right = rb as CSOneToManyJoint;
			left.FromLeft = true;
			right.FromLeft = false;
			left.Joint = csRel;
			right.Joint = csRel;
			//ra.ReferencedClass = csRel;
			//ra.ReferencedAttribute = csRel.Attribute1;
			//rb.ReferencedClass = csRel;
			//rb.ReferencedAttribute = csRel.Attribute2;
			return csRel;
        }

		public static string ClassNameFromTableName(string name, Section ct ) {
			switch(ct) {
				case Section.None:
				return name;
				case Section.Model:
				return name+"Model";
				case Section.Exemplar:
				return name + "Exemplar";
				case Section.Description:
				return name + "Description";
				default:
				return "Nope";
			}
		}

		public static string SQLTableNameFromTableName( string name, Section ct ) {
			switch(ct) {
				case Section.None:
				return name;
				case Section.Model:
				return name + "_model";
				case Section.Exemplar:
				return name + "_exemplar";
				case Section.Description:
				return name + "_description";
				default:
				return "Nope";
			}
		}
	}
}
