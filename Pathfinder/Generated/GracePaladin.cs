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
	[Table(Schema = "pathfinder",Name = "gracepaladinmodel")]
	[CoreData]
	public partial class GracePaladinModel : PouvoirSpecialClasseModel {

		private GracePaladinDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<GracePaladinDescription> id = GetModelReferencer<GracePaladinDescription>();
					if(id.Count() == 0) {
						_obj = new GracePaladinDescription();
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
	[Table(Schema = "pathfinder",Name = "gracepaladindescription")]
	public partial class GracePaladinDescription : PouvoirSpecialClasseDescription {
	}
	[Table(Schema = "pathfinder",Name = "gracepaladinexemplar")]
	public partial class GracePaladinExemplar : PouvoirSpecialClasseExemplar {
	}
}
