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
	[Table(Schema = "starwars",Name = "modtalentmodel")]
	[CoreData]
	public partial class ModTalentModel : ModModel {

		private ModTalentDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ModTalentDescription> id = GetModelReferencer<ModTalentDescription>();
					if(id.Count() == 0) {
						_obj = new ModTalentDescription();
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

		private int _talentId;
		[Column(Storage = "TalentId",Name = "fk_talentmodel")]
		[HiddenProperty]
		public int TalentId{
			get{ return _talentId;}
			set{_talentId = value;}
		}

		private TalentModel _talent;
		public TalentModel Talent{
			get{
				if( _talent == null)
					_talent = LoadById<TalentModel>(TalentId);
				return _talent;
			} set {
				if(_talent == value){return;}
				_talent = value;
				if( value != null)
					TalentId = value.Id;
			}
		}
	}
	[Table(Schema = "starwars",Name = "modtalentdescription")]
	public partial class ModTalentDescription : ModDescription {
	}
	[Table(Schema = "starwars",Name = "modtalentexemplar")]
	public partial class ModTalentExemplar : ModExemplar {
	}
}
