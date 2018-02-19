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
	[Table(Schema = "pathfinder",Name = "anneauxmodel")]
	[CoreData]
	public partial class AnneauxModel : ObjectMagiqueModel {

		private AnneauxDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AnneauxDescription> id = GetModelReferencer<AnneauxDescription>();
					if(id.Count() == 0) {
						_obj = new AnneauxDescription();
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
	[Table(Schema = "pathfinder",Name = "anneauxdescription")]
	public partial class AnneauxDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "pathfinder",Name = "anneauxexemplar")]
	public partial class AnneauxExemplar : ObjectMagiqueExemplar {
	}
}
