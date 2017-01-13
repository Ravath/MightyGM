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
	[Table(Schema = "mushroom",Name = "carrieremodel")]
	[CoreData]
	public partial class CarriereModel : DataObject {

		private int _specialiteId;
		[Column(Storage = "SpecialiteId",Name = "fk_specialitemodel")]
		public int SpecialiteId{
			get{ return _specialiteId;}
			set{_specialiteId = value;}
		}

		private SpecialiteModel _specialite;
		public SpecialiteModel Specialite{
			get {
				if(_specialite == null) {
					_specialite = LoadById<SpecialiteModel>(SpecialiteId);
			       }
				return _specialite;
			} set {
				if(value == _specialite) { return; }
				_specialite = value;
				if(_specialite != null) {
					_specialiteId = _specialite.Id;
				} else {
					_specialiteId = 0;
				}
			}
		}
	}
	[Table(Schema = "mushroom",Name = "carrieredescription")]
	public partial class CarriereDescription : DataObject<CarriereModel> {
	}
	[Table(Schema = "mushroom",Name = "carriereexemplaire")]
	public partial class CarriereExemplaire : DataObject<CarriereModel> {
	}
}
