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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "ameliorationdecontrole")]
	[CoreData]
	public partial class AmeliorationDeControle : DataObject {

		private string _description;
		[LargeText]
		[Column(Storage = "Description",Name = "description")]
		public string Description{
			get{ return _description;}
			set{_description = value;}
		}
	}
}
