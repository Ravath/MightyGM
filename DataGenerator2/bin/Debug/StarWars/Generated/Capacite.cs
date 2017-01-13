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
	[Table(Schema = "starwars",Name = "capacitemodel")]
	[CoreData]
	public partial class CapaciteModel : DataModel {

		private CapaciteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CapaciteDescription> id = GetModelReferencer<CapaciteDescription>();
					if(id.Count() == 0) {
						_obj = new CapaciteDescription();
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
	}
	[Table(Schema = "starwars",Name = "capacitedescription")]
	public partial class CapaciteDescription : DataDescription<CapaciteModel> {
	}
	[Table(Schema = "starwars",Name = "capaciteexemplar")]
	public partial class CapaciteExemplar : DataExemplaire<CapaciteModel> {
	}
}
