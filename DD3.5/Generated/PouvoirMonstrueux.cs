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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "pouvoirmonstrueuxmodel")]
	public abstract partial class PouvoirMonstrueuxModel : DataModel {

		private TypePouvoir _type;
		[Column(Storage = "Type",Name = "type")]
		public TypePouvoir Type{
			get{ return _type;}
			set{_type = value;}
		}
	}
	[Table(Schema = "dd35",Name = "pouvoirmonstrueuxdescription")]
	public abstract partial class PouvoirMonstrueuxDescription : DataDescription<PouvoirMonstrueuxModel> {
	}
	[Table(Schema = "dd35",Name = "pouvoirmonstrueuxexemplar")]
	public abstract partial class PouvoirMonstrueuxExemplar : DataExemplaire<PouvoirMonstrueuxModel> {
	}
}
