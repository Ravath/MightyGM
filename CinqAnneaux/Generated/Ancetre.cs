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
	[Table(Schema = "cinqanneaux",Name = "ancetremodel")]
	[CoreData]
	public partial class AncetreModel : DataModel {

		private AncetreDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AncetreDescription> id = GetModelReferencer<AncetreDescription>();
					if(id.Count() == 0) {
						_obj = new AncetreDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
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
			get{
				if( _clan == null)
					_clan = LoadById<ClanModel>(ClanId);
				return _clan;
			} set {
				if(_clan == value){return;}
				_clan = value;
				if( value != null)
					ClanId = value.Id;
			}
		}

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ancetredescription")]
	public partial class AncetreDescription : DataDescription<AncetreModel> {

		private string _exigences = "";
		[LargeText]
		[Column(Storage = "Exigences",Name = "exigences")]
		public string Exigences{
			get{ return _exigences;}
			set{_exigences = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ancetreexemplar")]
	public partial class AncetreExemplar : DataExemplaire<AncetreModel> {
	}
}
