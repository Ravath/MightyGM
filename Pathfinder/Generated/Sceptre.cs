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
	[Table(Schema = "pathfinder",Name = "sceptremodel")]
	[CoreData]
	public partial class SceptreModel : ObjectMagiqueModel {

		private SceptreDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SceptreDescription> id = GetModelReferencer<SceptreDescription>();
					if(id.Count() == 0) {
						_obj = new SceptreDescription();
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
	[Table(Schema = "pathfinder",Name = "sceptredescription")]
	public partial class SceptreDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "pathfinder",Name = "sceptreexemplar")]
	public partial class SceptreExemplar : ObjectMagiqueExemplar {
	}
}
