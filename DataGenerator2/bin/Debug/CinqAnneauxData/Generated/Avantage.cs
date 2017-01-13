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
	[Table(Schema = "cinqanneaux",Name = "avantage_model")]
	public partial class AvantageModel : AbsAvantageModel {
	}
	[Table(Schema = "cinqanneaux",Name = "avantage_exemplar")]
	public partial class AvantageExemplar : AbsAvantageExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "avantage_description")]
	public partial class AvantageDescription : AbsAvantageDescription {
	}
}
