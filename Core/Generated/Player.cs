using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "player")]
	[CoreData]
	public partial class Player : DataObject {

		private string _forename = "";
		[Column(Storage = "Forename",Name = "forename")]
		public string Forename{
			get{ return _forename;}
			set{_forename = value;}
		}

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private string _pseudo = "";
		[Column(Storage = "Pseudo",Name = "pseudo")]
		public string Pseudo{
			get{ return _pseudo;}
			set{_pseudo = value;}
		}
	}
}
