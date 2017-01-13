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
	[Table(Schema = "mushroom",Name = "specialitemodel")]
	[CoreData]
	public partial class SpecialiteModel : DataObject {

		private IEnumerable<CarriereModel> _carriere;
		public IEnumerable<CarriereModel> Carriere{
			get {
				if(_Carriere == null) {
					_Carriere = LoadByForeignKey<CarriereModel>(p => p.SpecialiteId, Id);
			    }
				return _Carriere;
			}
			set {
				foreach(CarriereModel item in _Carriere) {
					item.Specialite = null;
				}
				_Carriere = value;
				foreach(CarriereModel item in value) {
					item.Specialite = this;
				}
			}
		}

	}
	[Table(Schema = "mushroom",Name = "specialitedescription")]
	public partial class SpecialiteDescription : DataObject<SpecialiteModel> {
	}
	[Table(Schema = "mushroom",Name = "specialiteexemplaire")]
	public partial class SpecialiteExemplaire : DataObject<SpecialiteModel> {
	}
}
