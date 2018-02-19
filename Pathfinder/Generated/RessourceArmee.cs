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
	[Table(Schema = "pathfinder",Name = "ressourcearmeemodel")]
	[CoreData]
	public partial class RessourceArmeeModel : DataModel {

		private RessourceArmeeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RessourceArmeeDescription> id = GetModelReferencer<RessourceArmeeDescription>();
					if(id.Count() == 0) {
						_obj = new RessourceArmeeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "ressourcearmeedescription")]
	public partial class RessourceArmeeDescription : DataDescription<RessourceArmeeModel> {
	}
	[Table(Schema = "pathfinder",Name = "ressourcearmeeexemplar")]
	public partial class RessourceArmeeExemplar : DataExemplaire<RessourceArmeeModel> {
	}
}
