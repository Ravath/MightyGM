using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator.SQL
{
	/// <summary>
	/// The constraint on one or more SQL Attributes of a SqlTable.
	/// </summary>
	public class SQLConstraint {

		private List<SQLAttribute> _attRefs = new List<SQLAttribute>();
		/// <summary>
		/// The type name of the Constraint (unique, key,...).
		/// </summary>
		public string Name { get; private set; }

		#region Init
		/// <summary>
		/// Define the constraint by its name.
		/// </summary>
		/// <param name="name">The type name of the Constraint (unique, key,...).</param>
		public SQLConstraint(string name) {
			Name = name;
		}
		/// <summary>
		/// Define the constraint by its name and attributes.
		/// </summary>
		/// <param name="name">The type name of the Constraint (unique, key,...).</param>
		/// <param name="attributes">The Attributes affected by the constraint.</param>
		public SQLConstraint( string name , params SQLAttribute[] attributes ) : this(name) {
			AddAttributeRef(attributes);
        }
		#endregion

		#region AttributeReferences Collection
		/// <summary>
		/// Add the SQLAttribute to the list of SQLAttributes affected by the constraint, and the constraint to the constraint list of the attribute.
		/// </summary>
		/// <param name="att">The SQLAttribute to add. Nothing appends if null.</param>
		public void AddAttributeRef( SQLAttribute att ) {
			if(att == null) { return; }
			if(_attRefs.Contains(att)) { return; }
			_attRefs.Add(att);
			att.AddConstraint(this);
		}
		/// <summary>
		/// Add SQLAttributes to the list of SQLAttributes affected by the constraint, and the constraint to the constraint list of the attributes.
		/// </summary>
		/// <param name="attributes">The list of SQL Attributes to add.</param>
		public void AddAttributeRef( params SQLAttribute[] attributes ) {
			foreach(SQLAttribute item in attributes) {
				AddAttributeRef(item);
			}
		}
		/// <summary>
		/// Remove the SQLAttribute from the list of SQLAttributes affected by the constraint, and the constraint from the constraint list of the attribute.
		/// </summary>
		/// <param name="att">The SQLAttribute to remove.</param>
		public void RemoveAttributeRef( SQLAttribute att ) {
			if(_attRefs.Contains(att)) {
				_attRefs.Remove(att);
				att.RemoveConstraint(this);
			}
		}
		/// <summary>
		/// The list of the SQLAttributes the constraint affects.
		/// </summary>
		public IEnumerable<SQLAttribute> AffectedAttributes {
			get {
				return _attRefs;
            }
		}
		#endregion

		public void CreateString( StringBuilder sb ) {
			if(_attRefs.Count() == 0) { return; }
			sb.Append(Name + "(" + _attRefs.ElementAt(0).Name);
			for(int i = 1; i < _attRefs.Count(); i++)
				sb.Append(", " + _attRefs.ElementAt(i).Name);
			sb.Append(")");
		}
	}
}
