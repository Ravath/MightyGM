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
	[Table(Schema = "starwars",Name = "armuremodel")]
	[CoreData]
	public partial class ArmureModel : ObjectModel {

		private ArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmureDescription> id = GetModelReferencer<ArmureDescription>();
					if(id.Count() == 0) {
						_obj = new ArmureDescription();
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

		private int _defense;
		[Column(Storage = "Defense",Name = "defense")]
		public int Defense{
			get{ return _defense;}
			set{_defense = value;}
		}

		private int _encaissement;
		[Column(Storage = "Encaissement",Name = "encaissement")]
		public int Encaissement{
			get{ return _encaissement;}
			set{_encaissement = value;}
		}

		private int _emplacements;
		[Column(Storage = "Emplacements",Name = "emplacements")]
		public int Emplacements{
			get{ return _emplacements;}
			set{_emplacements = value;}
		}
	}
	[Table(Schema = "starwars",Name = "armuredescription")]
	public partial class ArmureDescription : ObjectDescription {
	}
	[Table(Schema = "starwars",Name = "armureexemplar")]
	public partial class ArmureExemplar : ObjectExemplar {
	}
}
