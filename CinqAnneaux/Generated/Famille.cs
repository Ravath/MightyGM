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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "famillemodel")]
	[CoreData]
	public partial class FamilleModel : DataModel {

		private FamilleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FamilleDescription> id = GetModelReferencer<FamilleDescription>();
					if(id.Count() == 0) {
						_obj = new FamilleDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TraitCompetence _bonusInitial;
		[Column(Storage = "BonusInitial",Name = "bonusinitial")]
		public TraitCompetence BonusInitial{
			get{ return _bonusInitial;}
			set{_bonusInitial = value;}
		}

		private int _clanId;
		[Column(Storage = "ClanId",Name = "fk_clanmodel_clan")]
		[HiddenProperty]
		public int ClanId{
			get{ return _clanId;}
			set{_clanId = value;}
		}

		private ClanModel _clan;
		public ClanModel Clan{
			get {
				if(_clan == null) {
					_clan = LoadById<ClanModel>(ClanId);
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

		private bool _familleDisparue;
		[Column(Storage = "FamilleDisparue",Name = "familledisparue")]
		public bool FamilleDisparue{
			get{ return _familleDisparue;}
			set{_familleDisparue = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "familledescription")]
	public partial class FamilleDescription : DataDescription<FamilleModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "familleexemplar")]
	public partial class FamilleExemplar : DataExemplaire<FamilleModel> {
	}
}
