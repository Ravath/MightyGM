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
	[Table(Schema = "cinqanneaux",Name = "desavantagemodel")]
	[CoreData]
	public partial class DesavantageModel : AbsAvantageModel {

		private DesavantageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DesavantageDescription> id = GetModelReferencer<DesavantageDescription>();
					if(id.Count() == 0) {
						_obj = new DesavantageDescription();
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
	[Table(Schema = "cinqanneaux",Name = "desavantagedescription")]
	public partial class DesavantageDescription : AbsAvantageDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "desavantageexemplar")]
	public partial class DesavantageExemplar : AbsAvantageExemplar {
	}
}
