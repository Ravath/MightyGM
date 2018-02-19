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
	[Table(Schema = "pathfinder",Name = "pouvoirragemodel")]
	[CoreData]
	public partial class PouvoirRageModel : PouvoirSpecialClasseModel {

		private PouvoirRageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirRageDescription> id = GetModelReferencer<PouvoirRageDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirRageDescription();
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
	[Table(Schema = "pathfinder",Name = "pouvoirragedescription")]
	public partial class PouvoirRageDescription : PouvoirSpecialClasseDescription {
	}
	[Table(Schema = "pathfinder",Name = "pouvoirrageexemplar")]
	public partial class PouvoirRageExemplar : PouvoirSpecialClasseExemplar {
	}
}
