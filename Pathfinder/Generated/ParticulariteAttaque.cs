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
	[Table(Schema = "pathfinder",Name = "particulariteattaquemodel")]
	[CoreData]
	public partial class ParticulariteAttaqueModel : ParticulariteModel {

		private ParticulariteAttaqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ParticulariteAttaqueDescription> id = GetModelReferencer<ParticulariteAttaqueDescription>();
					if(id.Count() == 0) {
						_obj = new ParticulariteAttaqueDescription();
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
	[Table(Schema = "pathfinder",Name = "particulariteattaquedescription")]
	public partial class ParticulariteAttaqueDescription : ParticulariteDescription {
	}
	[Table(Schema = "pathfinder",Name = "particulariteattaqueexemplar")]
	public partial class ParticulariteAttaqueExemplar : ParticulariteExemplar {
	}
}
