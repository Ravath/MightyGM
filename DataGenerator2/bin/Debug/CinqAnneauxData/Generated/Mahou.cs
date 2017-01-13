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
	[Table(Schema = "cinqanneaux",Name = "mahou_model")]
	public partial class MahouModel : AbsSortModel {
	}
	[Table(Schema = "cinqanneaux",Name = "mahou_exemplar")]
	public partial class MahouExemplar : AbsSortExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "mahou_description")]
	public partial class MahouDescription : AbsSortDescription {
	}
}
