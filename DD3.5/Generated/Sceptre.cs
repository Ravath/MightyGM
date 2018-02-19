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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "sceptremodel")]
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
	[Table(Schema = "dd35",Name = "sceptredescription")]
	public partial class SceptreDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "dd35",Name = "sceptreexemplar")]
	public partial class SceptreExemplar : ObjectMagiqueExemplar {
	}
}
