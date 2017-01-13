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
	[Table(Schema = "starwars",Name = "moddegatmodel")]
	[CoreData]
	public partial class ModDegatModel : ModModel {

		private ModDegatDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ModDegatDescription> id = GetModelReferencer<ModDegatDescription>();
					if(id.Count() == 0) {
						_obj = new ModDegatDescription();
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

		private int _degats;
		[Column(Storage = "Degats",Name = "degats")]
		public int Degats{
			get{ return _degats;}
			set{_degats = value;}
		}
	}
	[Table(Schema = "starwars",Name = "moddegatdescription")]
	public partial class ModDegatDescription : ModDescription {
	}
	[Table(Schema = "starwars",Name = "moddegatexemplar")]
	public partial class ModDegatExemplar : ModExemplar {
	}
}
