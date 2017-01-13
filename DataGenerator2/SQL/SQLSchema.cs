using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator2.SQL {
	public class SQLSchema {
		#region Members
		private string _name;
		private List<SQLTable> _tables = new List<SQLTable>();
		#endregion

		#region Properties
		public string Name {
			get { return _name; }
			set { _name = value.ToLower(); }
		}
		#endregion

		#region Collection tables
		public bool RemoveTable( SQLTable table ) {
			return _tables.Remove(table);
		}
		public void AddTable( SQLTable table ) {
			if(!_tables.Contains(table)) {
				_tables.Add(table);
				table.Schema = this;
			}
		}
		public IEnumerable<SQLTable> Tables {
			get {
				return _tables;
			}
		}
		#endregion
	}
}
