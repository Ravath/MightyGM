using DataGenerator.DataModel;
using DataGenerator.Parser;
using DataGenerator.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator.SQL {
	public class SQLAttribute {
		#region Members
		private string _name;
		private SQLTable _table;
		private List<SQLConstraint> _constr = new List<SQLConstraint>();
		#endregion
		
		#region Properties
		public string Name {
			get { return _name; }
			set { _name = value.ToLower(); }
		}
		public bool CanBeNull { get; set; }
		public bool IsPrimaryKey { get; set; }
		public bool IsForeignKey { get; set; }
		public bool Unique { get; set; }
		public SQLTypeEnum Type { get; set; }
		public int Varying { get; set; }
		public SQLTable Table {
			get {
				return _table;
			}
			set {
				if(_table == value) { return; }
				if(_table != null) {
					_table.RemoveAttribute(this);
				}
				_table = value;
				_table.AddAttribute(this);
			}
		}
		#endregion

		#region Init
		public SQLAttribute() { }
		public SQLAttribute( ValueAttribute att ) {
			Name = att.Name;
			CanBeNull = att.CardMin == Number.Opt;
			Type = ConvertAttributeType(att.Type.Type);
			if(Type == SQLTypeEnum.Char)
				Varying = ((StringType)att.Type).Length;
			IsForeignKey = att.IsReference;
		}
		#endregion

		#region Constraint Collection
		public void AddConstraint( SQLConstraint cont ) {
			if(_constr.Contains(cont)) { return; }
			_constr.Add(cont);
			cont.AddAttributeRef(this);
		}
		public void RemoveConstraint( SQLConstraint cont ) {
			if(_constr.Contains(cont)) {
				_constr.Remove(cont);
				cont.RemoveAttributeRef(this);
			}
		}
		public IEnumerable<SQLConstraint> Constraint {
			get { return _constr; }
		}
		#endregion

		public string TypeToString() {
			switch(Type) {
				case SQLTypeEnum.Int:
				return "integer";
				case SQLTypeEnum.Char:
				return "character varying(" + Varying + ")";
				case SQLTypeEnum.Serial:
				return "serial";
				case SQLTypeEnum.Text:
				return "text";
				case SQLTypeEnum.Deci:
				return "decimal";
				case SQLTypeEnum.Real:
				return "double precision";
				case SQLTypeEnum.Bool:
				return "bool";
				default:
				return "Not Implemented";
			}
		}

		public virtual void WriteAttribute( StringBuilder sb ) {
			sb.Append(Name);
			sb.Append(" ");
			sb.Append(TypeToString());
			if(Unique)
				sb.Append(" UNIQUE");
			if(!CanBeNull)
				sb.Append(" NOT NULL");
		}

		public static SQLTypeEnum ConvertAttributeType( AttributeTypeEnum type ) {
			switch(type) {
				case AttributeTypeEnum.Int:
				return SQLTypeEnum.Int;
				case AttributeTypeEnum.Text:
				return SQLTypeEnum.Text;
				case AttributeTypeEnum.Varchar:
				return SQLTypeEnum.Char;
				case AttributeTypeEnum.Bool:
				return SQLTypeEnum.Bool;
				case AttributeTypeEnum.Enum:
				return SQLTypeEnum.Int;
				case AttributeTypeEnum.Real:
				return SQLTypeEnum.Real;
				case AttributeTypeEnum.Decimal:
				return SQLTypeEnum.Deci;
				case AttributeTypeEnum.Refex:
				return SQLTypeEnum.Int;
				case AttributeTypeEnum.Ref:
				return SQLTypeEnum.Int;
				default:
				return SQLTypeEnum.Int;
			}
		}
	}
}
