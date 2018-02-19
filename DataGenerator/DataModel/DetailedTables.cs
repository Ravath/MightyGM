using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator.DataModel {
	/// <summary>
	/// Conteneur des tables à traiter, sous une forme travaillée.
	/// </summary>
	public class DetailedTables : IEnumerable<AbsTable>{
		#region Members
		private List<AbsTable> _tables = new List<AbsTable>();
		private Dictionary<string, AbsTable> _dictionnary = new Dictionary<string, AbsTable>();
		#endregion

		#region Properties
		public string DatabaseName { get; set; }
		public IEnumerable<AbsTable> Tables {
			get { return _tables; }
		}
		public IEnumerable<EnumTable> EnumTables {
			get { return _tables.Where(t => t is EnumTable).Cast<EnumTable>(); }
		}
		public IEnumerable<DiceTable> DiceTables {
			get { return _tables.Where(t => t is DiceTable).Cast<DiceTable>(); }
		}
		public IEnumerable<StructTable> StructTables {
			get { return _tables.Where(t => t is StructTable).Cast<StructTable>(); }
		}
		public IEnumerable<DataTable> DataTables {
			get { return _tables.Where(t => t is DataTable).Cast<DataTable>(); }
		}
		#endregion

		#region Tables Collection
		public void AddTable( AbsTable tab ) {
			_tables.Add(tab);
			_dictionnary.Add(tab.Name.ToLower(), tab);
		}

		public AbsTable FindTable( string name ) {
			name = name.ToLower();
			if(_dictionnary.ContainsKey(name))
				return _dictionnary[name];
			ErrorManager.Error("can't find the table: " + name);
			return null;
		}

		public bool ContainsTable( string name ) {
			name = name.ToLower();
			return _dictionnary.ContainsKey(name);
        }

		public IEnumerator<AbsTable> GetEnumerator() {
			return _tables.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _tables.GetEnumerator();
		} 
		#endregion
	}
}
