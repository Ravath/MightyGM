using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGenerator2.SQL;
using DataGenerator2.DataModel;

namespace DataGenerator2.CSharp {

	public abstract class CSEntity {
		public string Name { get; protected set; }

		public CSEntity( string name ) {
			Name = name;
		}

		public abstract void CreateString( StringBuilder sb, IndentationCount indentation );
	}

	public class CSClass : CSEntity {
		#region members
		private CSClass _parent;
		private CSNamespace _namespace;
		private List<CSClass> _fils = new List<CSClass>();
		private List<CSAttribute> _attributes = new List<CSAttribute>();
		private CSAnnotationCollection _annotations = new CSAnnotationCollection();
		private List<string> _interface = new List<string>();
		private List<CSClass> _parentTemplate = new List<CSClass>();
		private SQLTable _sqltable;
		private List<Tuple<CSOneToManyJoint, CSClass>> _jointsReferences = new List<Tuple<CSOneToManyJoint, CSClass>>();
		private List<CSDataValueClass> _datavalReferences = new List<CSDataValueClass>();
		#endregion

		#region Properties
		public bool Abstract { get; set; }
		public bool Partial { get; set; }
		public CSNamespace Namespace {
			get { return _namespace; }
			set {
				if(_namespace == value) { return; }
				if(_namespace != null) {
					_namespace.RemoveClass(this);
				}
				_namespace = value;
				_namespace.AddClass(this);
			}
		}
		public CSClass Parent {
			get { return _parent; }
			set {
				if(_parent == value) { return; }
				if(_parent != null) {
					_parent.RemoveFils(this);
				}
				_parent = value;
				_parent.AddFils(this);
			}
		}
		public bool DefaultConstructor { get; set; }
		public CSAnnotationCollection Annotations { get { return _annotations; } }
		public SQLTable SQLTable { get { return _sqltable; } }
		#endregion

		#region Init
		public CSClass( string name ) : base(name) { }
		public CSClass( string name, SQLTable table ) : this(name) {
			AddRelationToSqlTable(table);
		}
		#endregion

		#region Collection héritage
		public bool RemoveFils( CSClass csClass ) {
			return _fils.Remove(csClass);
		}

		public void AddFils( CSClass csClass ) {
			if(!_fils.Contains(csClass)) {
				_fils.Add(csClass);
				csClass.Parent = this;
			}
		}
		public IEnumerable<CSClass> Fils {
			get {
				return _fils;
			}
		}
		#endregion

		#region Collection Attributes
		public bool RemoveAttribute( CSAttribute att ) {
			return _attributes.Remove(att);
		}
		public void AddAttribute( CSAttribute att ) {
			if(!_attributes.Contains(att)) {
				_attributes.Add(att);
				att.Class = this;
			}
		}
		public IEnumerable<CSAttribute> Attributes {
			get { return _attributes; }
		}
		#endregion

		#region Collection Interface
		public void AddInterface( string iName ) {
			_interface.Add(iName);
		}
		public IEnumerable<string> Interfaces {
			get { return _interface; }
		}
		#endregion

		#region Collection ParentTemplate
		public void AddParentTemplate( CSClass template ) {
			_parentTemplate.Add(template);
		}
		public void AddParentTemplate( CSValueEnum type ) {
			_parentTemplate.Add(new CSClass(type.ToString().ToLower()));
		}
		public IEnumerable<CSClass> ParentTemplate {
			get { return _parentTemplate; }
		}
		#endregion

		protected void AddRelationToSqlTable( SQLTable st ) {
			Annotations.AddAnnotation(new CSTableAnnotation(st.Schema.Name, st.Name));
			_sqltable = st;
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			//annotations
			Annotations.CreateString(sb, indentation);
			//tête
			sb.Append(indentation + "public ");
			if(Abstract)
				sb.Append("abstract ");
			if(Partial)
				sb.Append("partial ");
			sb.Append("class " + Name + " ");
			if(Parent != null || Interfaces.Count() > 0) {//vérifier si héritage ( de classe ou d'interface)
				sb.Append(": ");
				if(Parent != null) {//heritage
					sb.Append(Parent.Name);
					if(ParentTemplate.Count() > 0) {//template de l'héritage
						sb.Append("<");
						sb.Append(ParentTemplate.ElementAt(0).Name);
						for(int i = 1; i < ParentTemplate.Count(); i++)
							sb.Append(", " + ParentTemplate.ElementAt(i).Name);
						sb.Append(">");
					}
					sb.Append(" ");
					foreach(string interf in Interfaces) {//interfaces
						sb.Append(", " + interf);
					}
				} else {//interfaces, mais sans la classe au début de la liste
					sb.Append(Interfaces.ElementAt(0) + " ");
					for(int i = 1; i < Interfaces.Count(); i++) {
						sb.Append(", " + Interfaces.ElementAt(i) + " ");
					}
				}
			}
			//corps(propriétés) et terminaison
			sb.AppendLine("{");
			if(DefaultConstructor) {//constructeur
				sb.AppendLine(indentation + "public " + Name + "(){}");
			}//propriétés
			indentation.Count++;
			foreach(CSAttribute att in Attributes) {
				sb.AppendLine();
				att.CreateString(sb, indentation);
				sb.AppendLine();
			}
			//delete fonction
			if(_jointsReferences.Count() + _datavalReferences.Count() > 0) {
				CodeWriter cw = new CodeWriter(sb, indentation).
					AddIndLine("public override void DeleteObject() {").t();
				foreach(var item in _jointsReferences) {
					cw.AddIndLine("DeleteJoins<" + item.Item1.Class.Name + "," + item.Item2.Name + ">(" + (item.Item1.FromLeft ? "true" : "false") + ");");
				}
				foreach(var item in _datavalReferences) {
					cw.AddIndLine("DeleteDataValue<" + item.Name + ">();");
				}
				cw.AddIndLine("base.DeleteObject();").
					EndBlock().nl();
			}
			//end
			indentation.Count--;
			sb.Append(indentation + "}");
		}
		/// <summary>
		/// Ajouter une référence vers une table de jointure utilisée par la classe pour des relations many to many.
		/// </summary>
		/// <param name="csAtt"></param>
		/// <param name="joint"></param>
		public void AddJoint( CSOneToManyJoint csAtt, CSClass joint ) {
			_jointsReferences.Add(new Tuple<CSOneToManyJoint, CSClass>(csAtt, joint));
		}

		public void AddDataValue( CSDataValueClass collection ) {
			_datavalReferences.Add(collection);
        }
	}

	public class CSRelationClass : CSDataObject {
		static 
		#region members
		private CSClass _c1, _c2;
		private SQLForeignKeyAttribute _k1, _k2;
		private readonly CSClass DataRelation = new CSClass("DataRelation",CSDataObject.sqlDataObject);
		private CSDataRelationAttribute _att1, _att2;
		#endregion

		#region Properties
		public CSDataRelationAttribute Attribute1 {
			get { return _att1; }
		}
		public CSDataRelationAttribute Attribute2 {
			get { return _att2; }
		}
		#endregion
		public CSRelationClass( CSClass c1, CSClass c2, SQLSchema schema ) : base(c1.Name + "To" + c2.Name, schema) {
			//creation classe et table
			_c1 = c1;
			_c2 = c2;
			Parent = DataRelation;
			AddParentTemplate(c1);
			AddParentTemplate(c2);
			//creation des colonnes sql
			_k1 = new SQLForeignKeyAttribute(c1.Name);
			_k2 = new SQLForeignKeyAttribute(c2.Name);
			//SQLTable.AddAttribute(new SQLID());
			SQLTable.AddAttribute(_k1);
			SQLTable.AddAttribute(_k2);
			_att1 = new CSDataRelationAttribute(_c1, _k1, 1);
			_att2 = new CSDataRelationAttribute(_c2, _k2, 2);
			AddAttribute(_att1);
			AddAttribute(_att2);
		}
	}

	public class CSDataValueClass : CSDataObject {

		private static readonly CSClass rParent = new CSClass("DataValue");

		private CSClass _class;
		AbstractCSValueAttribute _att;
		CSDataValueReferenceToClass _classReference;

		public CSClass ReferedClass{get{ return _class; } }
		public AbstractCSValueAttribute ValueAttribute { get{ return _att; } }
		public CSDataValueReferenceToClass Conteneur { get { return _classReference; } }

		public CSDataValueClass( CSClass from, CSValueAttribute value, SQLAttribute sqlValue, SQLSchema schema )
				: base( value.Name + "From" + from.Name, schema ) {
			_class = from;
			_att = new CSDataValueProperty(value);
			Parent = rParent;
			AddParentTemplate(from);
			AddParentTemplate(value.Type);
			//attributs de la table sql
			SQLForeignKeyAttribute sqlForeignKey = new SQLForeignKeyAttribute(from);
			//SQLTable.AddAttribute(new SQLID());
			SQLTable.AddAttribute(sqlForeignKey);
			SQLTable.AddAttribute(sqlValue);
			//attributs de la classe C#
			//référence vers le conteneur
			CSDataValueForeignKey foreignKey = new CSDataValueForeignKey(sqlForeignKey, from.Name);
			_classReference = new CSDataValueReferenceToClass(from, foreignKey, from.Name);
			AddAttribute(_att);
			AddAttribute(foreignKey);
			AddAttribute(Conteneur);
		}
	}

	public class CSEnum : CSEntity {
		private List<string> _tags = new List<string>();

		public CSEnum(string name) : base(name) { }

		public void AddTag( string tag ) {
			_tags.Add(tag);
		}

		public IEnumerable<string> Tags {
			get { return _tags; }
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			sb.AppendLine(indentation + "public enum " + Name + "{");
			if(_tags.Count() != 0)
				sb.Append(indentation + "\t" + _tags.ElementAt(0));
			for(int i = 1; i < _tags.Count(); i++)
				sb.Append(", " + _tags.ElementAt(i));
			sb.AppendLine("}");
		}

	}

	public class CSDataObject : CSClass {
		static CSDataObject() {
			DataObject = new CSClass("DataObject");
			sqlDataObject = new SQLTable(DataObject.Name);
			sqlDataObject.AddAttribute(new SQLID());
		}
        public static readonly CSClass DataObject;
		public static readonly SQLTable sqlDataObject;
		public CSDataObject( string name, SQLSchema schema ) : base(name) {
			Parent = DataObject;
			//table sql
			SQLTable sql = new SQLTable(name);
			sql.Schema = schema;
			sql.Parent = sqlDataObject;
            AddRelationToSqlTable(sql);
		}
	}

	public class CSStruct : CSDataObject {
		public CSStruct( StructTable table, SQLSchema schema ) :base(table.Name, schema) {
			Abstract = table.IsAbstract;
			Partial = true;
			if(!table.IsAbstract)
				Annotations.AddAnnotation(new CSAnnotation() { Name = "CoreData" });
		}
	}

	public class CSDataModel : CSDataObject {
		public CSDataModel(DataTable table, SQLSchema schema ) : base(ModelGenerator.ClassNameFromTableName(table.Name, Section.Model), schema) {
			Parent = ModelClass;
			Abstract = table.IsAbstract;
			Partial = true;
			if(!table.IsAbstract)
				Annotations.AddAnnotation(new CSAnnotation() { Name = "CoreData" });
		}
		public static readonly CSClass ModelClass = new CSClass("DataModel");
	}

	public class CSDataExemplaire : CSDataObject {
		public CSDataExemplaire( DataTable table, SQLSchema schema ) : base(ModelGenerator.ClassNameFromTableName(table.Name, Section.Exemplar), schema) {
			Parent = ExemplarClass;
			Abstract = table.IsAbstract;
			Partial = true;
		}
		public static readonly CSClass ExemplarClass = new CSClass("DataExemplaire");
	}

	public class CSDataDescription : CSDataObject {
		public CSDataDescription( DataTable table, SQLSchema schema ) : base(ModelGenerator.ClassNameFromTableName(table.Name, Section.Description), schema) {
			Parent = DescriptionClass;
			Abstract = table.IsAbstract;
			Partial = true;
		}
		public static readonly CSClass DescriptionClass = new CSClass("DataDescription");
	}

	public class CSPartialClass : CSClass {
		public CSClass OtherClass { get; private set; }
		public CSPartialClass( CSClass cl ) : base(cl.Name){
			Partial = true;
			cl.Partial = true;
			OtherClass = cl;
        }
	}

}
