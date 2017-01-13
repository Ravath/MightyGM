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
	[Table(Schema = "cinqanneaux",Name = "sort_model")]
	public partial class SortModel : AbsSortModel {
	}
	[Table(Schema = "cinqanneaux",Name = "sort_exemplar")]
	public partial class SortExemplar : AbsSortExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "sort_description")]
	public partial class SortDescription : AbsSortDescription {
	}
}
