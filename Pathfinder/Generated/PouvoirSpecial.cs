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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "pouvoirspecialmodel")]
	public abstract partial class PouvoirSpecialModel : DataModel {

		private TypePouvoir _type;
		[Column(Storage = "Type",Name = "type")]
		public TypePouvoir Type{
			get{ return _type;}
			set{_type = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "pouvoirspecialdescription")]
	public abstract partial class PouvoirSpecialDescription : DataDescription<PouvoirSpecialModel> {
	}
	[Table(Schema = "pathfinder",Name = "pouvoirspecialexemplar")]
	public abstract partial class PouvoirSpecialExemplar : DataExemplaire<PouvoirSpecialModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
