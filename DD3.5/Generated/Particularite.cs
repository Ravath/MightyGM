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
	[Table(Schema = "dd35",Name = "particularitemodel")]
	[CoreData]
	public partial class ParticulariteModel : PouvoirMonstrueuxModel {

		private ParticulariteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ParticulariteDescription> id = GetModelReferencer<ParticulariteDescription>();
					if(id.Count() == 0) {
						_obj = new ParticulariteDescription();
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
	[Table(Schema = "dd35",Name = "particularitedescription")]
	public partial class ParticulariteDescription : PouvoirMonstrueuxDescription {
	}
	[Table(Schema = "dd35",Name = "particulariteexemplar")]
	public partial class ParticulariteExemplar : PouvoirMonstrueuxExemplar {
	}
}
