using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[CoreData]
	[Table(Schema = "cinqanneaux",Name = "absobjet_model")]
	public partial class AbsObjetModel : DataModel {

		private int _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int Prix{
			get{ return _prix;}
			set{_prix = value;}
		}

		private Monnaie _Unite;
		[Column(Storage = "Unite",Name = "unite")]
		public Monnaie Unite{
			get{ return _Unite;}
			set{_Unite = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "absobjet_exemplar")]
	public partial class AbsObjetExemplar : DataExemplaire<AbsObjetModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "absobjet_description")]
	public partial class AbsObjetDescription : DataDescription<AbsObjetModel> {
	}
}
