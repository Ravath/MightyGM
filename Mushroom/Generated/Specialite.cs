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
	//[CoreData]
	//[Table(Schema = "mushroom",Name = "specialite_model")]
	//public partial class SpecialiteModel : DataModel {

	//	private CarriereModel _Carriere;

	//	public CarriereModel Carriere {
	//		get { return _Carriere; }
	//		set {
	//			if(_Carriere == value) { return; }
	//			if(_Carriere != null) {
	//				_Carriere.Specialite = null;
	//			}
	//			_Carriere = value;
	//			_Carriere.Specialite = this;
	//		}
	//	}
	//}
	//[Table(Schema = "mushroom",Name = "specialite_exemplar")]
	//public partial class SpecialiteExemplar : DataExemplaire<SpecialiteModel> {
	//}
	//[Table(Schema = "mushroom",Name = "specialite_description")]
	//public partial class SpecialiteDescription : DataDescription<SpecialiteModel> {
	//}
}
