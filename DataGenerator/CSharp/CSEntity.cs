using DataGenerator.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator.CSharp
{

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
		private List<CSEntity> _parentTemplate = new List<CSEntity>();
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
		public void AddParentTemplate(CSEntity template ) {
			_parentTemplate.Add(template);
		}
		public void AddParentTemplate( string typeName ) {
			_parentTemplate.Add(new CSClass(typeName));
		}
		public IEnumerable<CSEntity> ParentTemplate {
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
}
