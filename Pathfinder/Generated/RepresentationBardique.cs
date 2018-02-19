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
	[Table(Schema = "pathfinder",Name = "representationbardiquemodel")]
	[CoreData]
	public partial class RepresentationBardiqueModel : PouvoirSpecialClasseModel {

		private RepresentationBardiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RepresentationBardiqueDescription> id = GetModelReferencer<RepresentationBardiqueDescription>();
					if(id.Count() == 0) {
						_obj = new RepresentationBardiqueDescription();
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
	[Table(Schema = "pathfinder",Name = "representationbardiquedescription")]
	public partial class RepresentationBardiqueDescription : PouvoirSpecialClasseDescription {
	}
	[Table(Schema = "pathfinder",Name = "representationbardiqueexemplar")]
	public partial class RepresentationBardiqueExemplar : PouvoirSpecialClasseExemplar {
	}
}
