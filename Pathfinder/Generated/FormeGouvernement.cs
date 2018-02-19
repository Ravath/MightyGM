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
	[Table(Schema = "pathfinder",Name = "formegouvernementmodel")]
	[CoreData]
	public partial class FormeGouvernementModel : DataModel {

		private FormeGouvernementDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FormeGouvernementDescription> id = GetModelReferencer<FormeGouvernementDescription>();
					if(id.Count() == 0) {
						_obj = new FormeGouvernementDescription();
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
	[Table(Schema = "pathfinder",Name = "formegouvernementdescription")]
	public partial class FormeGouvernementDescription : DataDescription<FormeGouvernementModel> {
	}
	[Table(Schema = "pathfinder",Name = "formegouvernementexemplar")]
	public partial class FormeGouvernementExemplar : DataExemplaire<FormeGouvernementModel> {
	}
}
