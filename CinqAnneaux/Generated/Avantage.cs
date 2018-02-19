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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "avantagemodel")]
	[CoreData]
	public partial class AvantageModel : AbsAvantageModel {

		private AvantageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AvantageDescription> id = GetModelReferencer<AvantageDescription>();
					if(id.Count() == 0) {
						_obj = new AvantageDescription();
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
	[Table(Schema = "cinqanneaux",Name = "avantagedescription")]
	public partial class AvantageDescription : AbsAvantageDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "avantageexemplar")]
	public partial class AvantageExemplar : AbsAvantageExemplar {
	}
}
