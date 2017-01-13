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
	[Table(Schema = "starwars",Name = "casearborescencedespecialite")]
	[CoreData]
	public partial class CaseArborescenceDeSpecialite : CaseArborescence {

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
}
