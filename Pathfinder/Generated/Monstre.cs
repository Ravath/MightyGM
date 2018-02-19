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
	[Table(Schema = "pathfinder",Name = "monstremodel")]
	[CoreData]
	public partial class MonstreModel : PersonnageModel {

		private MonstreDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MonstreDescription> id = GetModelReferencer<MonstreDescription>();
					if(id.Count() == 0) {
						_obj = new MonstreDescription();
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
	[Table(Schema = "pathfinder",Name = "monstredescription")]
	public partial class MonstreDescription : PersonnageDescription {
	}
	[Table(Schema = "pathfinder",Name = "monstreexemplar")]
	public partial class MonstreExemplar : PersonnageExemplar {
	}
}
