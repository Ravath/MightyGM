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
	[Table(Schema = "cinqanneaux",Name = "gaingloire")]
	[CoreData]
	public partial class GainGloire : DataObject {

		private string _nom = "";
		[Column(Storage = "Nom",Name = "nom")]
		public string Nom{
			get{ return _nom;}
			set{_nom = value;}
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
