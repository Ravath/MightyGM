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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "talentmodel")]
	[CoreData]
	public partial class TalentModel : DataModel {

		private TalentDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TalentDescription> id = GetModelReferencer<TalentDescription>();
					if(id.Count() == 0) {
						_obj = new TalentDescription();
		_obj.Model = this;
		_obj.SaveObject();
		return _obj;
	} else {
		return id.ElementAt(0);
	}
} else {
	return _obj;
}
			}
		}

		private bool _rangs;
		[Column(Storage = "Rangs",Name = "rangs")]
		public bool Rangs{
			get{ return _rangs;}
			set{_rangs = value;}
		}

		private Action _action;
		[Column(Storage = "Action",Name = "action")]
		public Action Action{
			get{ return _action;}
			set{_action = value;}
		}

		private IEnumerable<TalentModelToArborescenceDeSpecialite> _arborescences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Arborescences",OtherKey = "TalentModelId")]
		public IEnumerable <TalentModelToArborescenceDeSpecialite> Arborescences{
			get{
				if( _arborescences == null ){
					_arborescences = LoadByForeignKey<TalentModelToArborescenceDeSpecialite>(p => p.TalentModelId, Id);
				}
				return _arborescences;
			}
			set{
				foreach( TalentModelToArborescenceDeSpecialite item in _arborescences ){
					item.TalentModel = null;
				}
				_arborescences = value;
				foreach( TalentModelToArborescenceDeSpecialite item in value ){
					item.TalentModel = this;
				}
			}
		}
	}
	[Table(Schema = "starwars",Name = "talentdescription")]
	public partial class TalentDescription : DataDescription<TalentModel> {
	}
	[Table(Schema = "starwars",Name = "talentexemplar")]
	public partial class TalentExemplar : DataExemplaire<TalentModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
