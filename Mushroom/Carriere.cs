using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Mushroom.Data {
	[CoreData]
	[Table(Schema = "mushroom",Name = "carriere_model")]
	public partial class CarriereModel : DataModel {
	}
	[Table(Schema = "mushroom",Name = "carriere_exemplar")]
	public partial class CarriereExemplar : DataExemplaire<CarriereModel> {
	}
	[Table(Schema = "mushroom",Name = "carriere_description")]
	public partial class CarriereDescription : DataDescription<CarriereModel> {
	}
}
