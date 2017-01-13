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
	[Table(Schema = "cinqanneaux",Name = "desavantage_model")]
	public partial class DesavantageModel : AbsAvantageModel {
	}
	[Table(Schema = "cinqanneaux",Name = "desavantage_exemplar")]
	public partial class DesavantageExemplar : AbsAvantageExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "desavantage_description")]
	public partial class DesavantageDescription : AbsAvantageDescription {
	}
}
