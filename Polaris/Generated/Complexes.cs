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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "complexes")]
	[CoreData]
	public partial class Complexes : DataObject {

		private int _villeId;
		[Column(Storage = "VilleId",Name = "fk_villemodel_ville")]
		[HiddenProperty]
		public int VilleId{
			get{ return _villeId;}
			set{_villeId = value;}
		}

		private VilleModel _ville;
		public VilleModel Ville{
			get {
				if(_ville == null) {
					_ville = LoadById<VilleModel>(VilleId);
			       }
				return _ville;
			} set {
				if(value == _ville) { return; }
				_ville = value;
				if(_ville != null) {
					_villeId = _ville.Id;
				} else {
					_villeId = 0;
				}
			}
		}

		private TypeCommunaute _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeCommunaute Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _nombre;
		[Column(Storage = "Nombre",Name = "nombre")]
		public int Nombre{
			get{ return _nombre;}
			set{_nombre = value;}
		}
	}
}
