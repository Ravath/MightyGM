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
	[Table(Schema = "polaris",Name = "maladiemodel")]
	[CoreData]
	public partial class MaladieModel : AbsPoisonModel {

		private MaladieDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MaladieDescription> id = GetModelReferencer<MaladieDescription>();
					if(id.Count() == 0) {
						_obj = new MaladieDescription();
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
	[Table(Schema = "polaris",Name = "maladiedescription")]
	public partial class MaladieDescription : AbsPoisonDescription {
	}
	[Table(Schema = "polaris",Name = "maladieexemplar")]
	public partial class MaladieExemplar : AbsPoisonExemplar {
	}
}
