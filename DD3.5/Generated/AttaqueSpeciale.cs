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
	[Table(Schema = "dd35",Name = "attaquespecialemodel")]
	[CoreData]
	public partial class AttaqueSpecialeModel : PouvoirMonstrueuxModel {

		private AttaqueSpecialeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AttaqueSpecialeDescription> id = GetModelReferencer<AttaqueSpecialeDescription>();
					if(id.Count() == 0) {
						_obj = new AttaqueSpecialeDescription();
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
	[Table(Schema = "dd35",Name = "attaquespecialedescription")]
	public partial class AttaqueSpecialeDescription : PouvoirMonstrueuxDescription {
	}
	[Table(Schema = "dd35",Name = "attaquespecialeexemplar")]
	public partial class AttaqueSpecialeExemplar : PouvoirMonstrueuxExemplar {
	}
}
