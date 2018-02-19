using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator.SQL {
	public class SQLTable {
		#region Members
		private string _name;
		private SQLTable _parent;
		private SQLSchema _schema;
		private List<SQLTable> _fils = new List<SQLTable>();
		private List<SQLAttribute> _attributes = new List<SQLAttribute>();
		private List<SQLConstraint> _constr = new List<SQLConstraint>();
		#endregion
		
		#region Properties
		public string Name {
			get { return _name; }
			private set { _name = value.ToLower(); }
		}
		public SQLSchema Schema {
			get { return _schema; }
			set {
				if(_schema == value) { return; }
				if(_schema != null) {
					_schema.RemoveTable(this);
				}
				_schema = value;
				_schema.AddTable(this);
			}
		}
		public SQLTable Parent {
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
		public int ParentNumber {
			get {
				if(_parent == null) { return 1; }
				return _parent.ParentNumber + 1;
			}
		}
		public IEnumerable<SQLConstraint> Constraints {
			get {
				return (Attributes.SelectMany(a => a.Constraint).Union(_constr)).Distinct();
			}
		}
		#endregion

		#region Init
		public SQLTable(string name) {
			Name = name;
		}
		#endregion

		#region Collection héritage
		public bool RemoveFils( SQLTable table ) {
			return _fils.Remove(table);
		}
		public void AddFils( SQLTable table ) {
			if(!_fils.Contains(table)) {
				_fils.Add(table);
				table.Parent = this;
			}
		}
		public IEnumerable<SQLTable> Fils {
			get { return _fils; }
		}
		#endregion

		#region Collection Attributes
		public bool RemoveAttribute( SQLAttribute att ) {
			return _attributes.Remove(att);
		}
		public void AddAttribute( SQLAttribute att ) {
			if(!_attributes.Contains(att)) {
				_attributes.Add(att);
				att.Table = this;
			}
		}

		public IEnumerable<SQLAttribute> Attributes {
			get { return _attributes; }
		}
		#endregion

		#region Collection Constraints
		public void AddConstraint( SQLConstraint ct ) {
			_constr.Add(ct);
        }
		public bool RemoveConstraint(SQLConstraint ct ) {
			return _constr.Remove(ct);
        }
		#endregion

		public void WriteTable( StringBuilder sb ) {
			//DEBUT CREATION TABLE
			sb.AppendFormat("create table {0}.{1}(\n\t", Schema.Name, Name);
			//VALUES
			if(Attributes.Count() > 0)
				Attributes.ElementAt(0).WriteAttribute(sb);
            for(int ia = 1; ia < Attributes.Count(); ia++) {
				sb.Append(",\n\t");
				Attributes.ElementAt(ia).WriteAttribute(sb);
			}
			//primary keys
			IEnumerable<SQLConstraint> constr = Constraints;
			if(constr.Count() > 0) {
				if(Attributes.Count() > 0) {
					sb.AppendLine(",");
					sb.Append("\t");
				}
				constr.ElementAt(0).CreateString(sb);
				for(int i = 1; i < constr.Count(); i++) {
					sb.AppendLine(",");
					sb.Append("\t");
					constr.ElementAt(i).CreateString(sb);
				}
			}
			//heritage
			if(Parent == null)
				sb.Append(");");
			else
				sb.AppendFormat(")INHERITS({0}.{1});", Schema.Name, Parent.Name);
		}

	}

}
