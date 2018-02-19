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
	[Table(Schema = "pathfinder",Name = "pnjmodel")]
	[CoreData]
	public partial class PNJModel : PersonnageModel {

		private PNJDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PNJDescription> id = GetModelReferencer<PNJDescription>();
					if(id.Count() == 0) {
						_obj = new PNJDescription();
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
	[Table(Schema = "pathfinder",Name = "pnjdescription")]
	public partial class PNJDescription : PersonnageDescription {
	}
	[Table(Schema = "pathfinder",Name = "pnjexemplar")]
	public partial class PNJExemplar : PersonnageExemplar {
	}
}
