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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "specialobjet")]
	[CoreData]
	public partial class SpecialObjet : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private string _description = "";
		[LargeText]
		[Column(Storage = "Description",Name = "description")]
		public string Description{
			get{ return _description;}
			set{_description = value;}
		}
	}
}
