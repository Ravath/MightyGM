using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "relationarborescenceforce")]
	[CoreData]
	public partial class RelationArborescenceForce : DataObject {

		private bool _horizontal;
		[Column(Storage = "horizontal",Name = "horizontal")]
		public bool horizontal{
			get{ return _horizontal;}
			set{_horizontal = value;}
		}

		private int _ligne;
		[Column(Storage = "ligne",Name = "ligne")]
		public int ligne{
			get{ return _ligne;}
			set{_ligne = value;}
		}

		private int _colonne;
		[Column(Storage = "colonne",Name = "colonne")]
		public int colonne{
			get{ return _colonne;}
			set{_colonne = value;}
		}
	}
}
