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
	[Table(Schema = "cinqanneaux",Name = "maitrise_model")]
	public partial class MaitriseModel : DataModel {

		private int _rangRequis;
		[Column(Storage = "RangRequis",Name = "rangrequis")]
		public int RangRequis{
			get{ return _rangRequis;}
			set{_rangRequis = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "maitrise_exemplar")]
	public partial class MaitriseExemplar : DataExemplaire<MaitriseModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "maitrise_description")]
	public partial class MaitriseDescription : DataDescription<MaitriseModel> {
	}
}
