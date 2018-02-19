using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "organisationsociale")]
	[CoreData]
	public partial class OrganisationSociale : DataObject {

		private int _nombre;
		[Column(Storage = "nombre",Name = "nombre")]
		public int nombre{
			get{ return _nombre;}
			set{_nombre = value;}
		}

		private string _typeGroupe = "";
		[Column(Storage = "TypeGroupe",Name = "typegroupe")]
		public string TypeGroupe{
			get{ return _typeGroupe;}
			set{_typeGroupe = value;}
		}

		private int _p_nonCombatants;
		[Column(Storage = "p_nonCombatants",Name = "p_noncombatants")]
		public int p_nonCombatants{
			get{ return _p_nonCombatants;}
			set{_p_nonCombatants = value;}
		}
	}
}
