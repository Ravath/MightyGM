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
	[Table(Schema = "mushroom",Name = "specialite_model")]
	public partial class SpecialiteModel : DataModel {

		private CarriereModel _Carriere;
		[Association(ThisKey = "CarriereId",CanBeNull = false,Storage = "Carriere",OtherKey = "Id")]
		public CarriereModel Carriere{
			get{ return _Carriere;}
			set{_Carriere = value;}
		}

		private int _carriereId;
		[Column(Storage = "CarriereId",Name = "fk_carriere")]
		public int CarriereId{
			get{ return _carriereId}
			set{_carriereId = value;}
		}
	}
	[Table(Schema = "mushroom",Name = "specialite_exemplar")]
	public partial class SpecialiteExemplar : DataExemplaire<SpecialiteModel> {
	}
	[Table(Schema = "mushroom",Name = "specialite_description")]
	public partial class SpecialiteDescription : DataDescription<SpecialiteModel> {
	}
}
