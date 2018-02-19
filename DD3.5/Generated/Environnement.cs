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
	[Table(Schema = "dd35",Name = "environnementmodel")]
	[CoreData]
	public partial class EnvironnementModel : DataModel {

		private EnvironnementDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EnvironnementDescription> id = GetModelReferencer<EnvironnementDescription>();
					if(id.Count() == 0) {
						_obj = new EnvironnementDescription();
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
	[Table(Schema = "dd35",Name = "environnementdescription")]
	public partial class EnvironnementDescription : DataDescription<EnvironnementModel> {
	}
	[Table(Schema = "dd35",Name = "environnementexemplar")]
	public partial class EnvironnementExemplar : DataExemplaire<EnvironnementModel> {
	}
}
