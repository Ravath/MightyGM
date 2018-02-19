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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "organisationsociale")]
	[CoreData]
	public partial class OrganisationSociale : DataObject {

		private int _nombreMin;
		[Column(Storage = "NombreMin",Name = "nombremin")]
		public int NombreMin{
			get{ return _nombreMin;}
			set{_nombreMin = value;}
		}

		private int _nombreMax;
		[Column(Storage = "NombreMax",Name = "nombremax")]
		public int NombreMax{
			get{ return _nombreMax;}
			set{_nombreMax = value;}
		}

		private string _nomGroupe = "";
		[Column(Storage = "NomGroupe",Name = "nomgroupe")]
		public string NomGroupe{
			get{ return _nomGroupe;}
			set{_nomGroupe = value;}
		}

		private int _p_nonCombatants;
		[Column(Storage = "p_nonCombatants",Name = "p_noncombatants")]
		public int p_nonCombatants{
			get{ return _p_nonCombatants;}
			set{_p_nonCombatants = value;}
		}
	}
}
