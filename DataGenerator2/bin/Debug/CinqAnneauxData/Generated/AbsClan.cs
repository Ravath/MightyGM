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
	[Table(Schema = "cinqanneaux",Name = "absclan_model")]
	public partial class AbsClanModel : DataModel {

		private IEnumerable<FamilleModel> _Familles;
		public IEnumerable<FamilleModel> Familles{
			get {
				if(_Familles == null) {
					_Familles = LoadByForeignKey<FamilleModel>(p => p.ClanId, Id);
			    }
				return _Familles;
			}
			set {
				foreach(FamilleModel item in _Familles) {
					item.Clan = null;
				}
				_Familles = value;
				foreach(FamilleModel item in value) {
					item.Clan = this;
				}
			}
		}


		private IEnumerable<EcoleModel> _Ecoles;
		public IEnumerable<EcoleModel> Ecoles{
			get {
				if(_Ecoles == null) {
					_Ecoles = LoadByForeignKey<EcoleModel>(p => p.ClanId, Id);
			    }
				return _Ecoles;
			}
			set {
				foreach(EcoleModel item in _Ecoles) {
					item.Clan = null;
				}
				_Ecoles = value;
				foreach(EcoleModel item in value) {
					item.Clan = this;
				}
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "absclan_exemplar")]
	public partial class AbsClanExemplar : DataExemplaire<AbsClanModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "absclan_description")]
	public partial class AbsClanDescription : DataDescription<AbsClanModel> {
	}
}
