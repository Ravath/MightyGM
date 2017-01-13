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
	[Table(Schema = "starwars",Name = "arborescencedespecialite")]
	[CoreData]
	public partial class ArborescenceDeSpecialite : Arborescence {

		private int _specialiteId;
		[Column(Storage = "SpecialiteId",Name = "fk_specialitemodel")]
		[HiddenProperty]
		public int SpecialiteId{
			get{ return _specialiteId;}
			set{_specialiteId = value;}
		}

		private SpecialiteModel _specialite;
		public SpecialiteModel Specialite{
			get {
				if(_specialite == null) {
					_specialite = LoadById<SpecialiteModel>(SpecialiteId);
			       }
				return _specialite;
			} set {
				if(value == _specialite) { return; }
				_specialite = value;
				if(_specialite != null) {
					_specialiteId = _specialite.Id;
				} else {
					_specialiteId = 0;
				}
			}
		}
	}
}
