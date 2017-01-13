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
	[Table(Schema = "cinqanneaux",Name = "famille_model")]
	public partial class FamilleModel : DataModel {

		private Trait _BonusInitial;
		[Column(Storage = "BonusInitial",Name = "bonusinitial")]
		public Trait BonusInitial{
			get{ return _BonusInitial;}
			set{_BonusInitial = value;}
		}

		private AbsClanModel _clan;
		public AbsClanModel Clan{
			get {
				if(_clan == null) {
					_clan = LoadById<AbsClanModel>(ClanId);
			       }
				return _clan;
			} set {
				if(value == _clan) { return; }
				_clan = value;
				if(_clan != null) {
					_clanId = _clan.Id;
				} else {
					_clanId = 0;
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "famille_exemplar")]
	public partial class FamilleExemplar : DataExemplaire<FamilleModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "famille_description")]
	public partial class FamilleDescription : DataDescription<FamilleModel> {
	}
}
