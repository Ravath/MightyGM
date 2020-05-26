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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "fabriquantmodel")]
	[CoreData]
	public partial class FabriquantModel : DataModel {

		private FabriquantDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FabriquantDescription> id = GetModelReferencer<FabriquantDescription>();
					if(id.Count() == 0) {
						_obj = new FabriquantDescription();
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
	[Table(Schema = "polaris",Name = "fabriquantdescription")]
	public partial class FabriquantDescription : DataDescription<FabriquantModel> {
	}
	[Table(Schema = "polaris",Name = "fabriquantexemplar")]
	public partial class FabriquantExemplar : DataExemplaire<FabriquantModel> {
	}
}
