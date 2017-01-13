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
	[Table(Schema = "cinqanneaux",Name = "clanmineur_model")]
	public partial class ClanMineurModel : AbsClanModel {
	}
	[Table(Schema = "cinqanneaux",Name = "clanmineur_exemplar")]
	public partial class ClanMineurExemplar : AbsClanExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "clanmineur_description")]
	public partial class ClanMineurDescription : AbsClanDescription {
	}
}
