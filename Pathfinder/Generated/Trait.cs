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
	[Table(Schema = "pathfinder",Name = "traitmodel")]
	[CoreData]
	public partial class TraitModel : DataModel {

		private TraitDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TraitDescription> id = GetModelReferencer<TraitDescription>();
					if(id.Count() == 0) {
						_obj = new TraitDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeTrait _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeTrait Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _raceId;
		[Column(Storage = "RaceId",Name = "fk_racemodel_race")]
		[HiddenProperty]
		public int RaceId{
			get{ return _raceId;}
			set{_raceId = value;}
		}

		private RaceModel _race;
		public RaceModel Race{
			get{
				if( _race == null)
					_race = LoadById<RaceModel>(RaceId);
				return _race;
			} set {
				if(_race == value){return;}
				_race = value;
				if( value != null)
					RaceId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "traitdescription")]
	public partial class TraitDescription : DataDescription<TraitModel> {
	}
	[Table(Schema = "pathfinder",Name = "traitexemplar")]
	public partial class TraitExemplar : DataExemplaire<TraitModel> {
	}
}
