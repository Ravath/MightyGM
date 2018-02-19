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
	[Table(Schema = "starwars",Name = "modspecialmodel")]
	[CoreData]
	public partial class ModSpecialModel : ModModel {

		private ModSpecialDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ModSpecialDescription> id = GetModelReferencer<ModSpecialDescription>();
					if(id.Count() == 0) {
						_obj = new ModSpecialDescription();
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

		private int _specialId;
		[Column(Storage = "SpecialId",Name = "fk_capacitemodel")]
		[HiddenProperty]
		public int SpecialId{
			get{ return _specialId;}
			set{_specialId = value;}
		}

		private CapaciteModel _special;
		public CapaciteModel Special{
			get{
				if( _special == null)
					_special = LoadById<CapaciteModel>(SpecialId);
				return _special;
			} set {
				if(_special == value){return;}
				_special = value;
				if( value != null)
					SpecialId = value.Id;
			}
		}
	}
	[Table(Schema = "starwars",Name = "modspecialdescription")]
	public partial class ModSpecialDescription : ModDescription {
	}
	[Table(Schema = "starwars",Name = "modspecialexemplar")]
	public partial class ModSpecialExemplar : ModExemplar {
	}
}
