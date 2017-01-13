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
	[Table(Schema = "cinqanneaux",Name = "objet_model")]
	public partial class ObjetModel : AbsObjetModel {
	}
	[Table(Schema = "cinqanneaux",Name = "objet_exemplar")]
	public partial class ObjetExemplar : AbsObjetExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "objet_description")]
	public partial class ObjetDescription : AbsObjetDescription {
	}
}
