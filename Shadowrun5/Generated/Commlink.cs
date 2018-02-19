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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "commlinkmodel")]
	[CoreData]
	public partial class CommlinkModel : ElectronicModel {

		private CommlinkDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CommlinkDescription> id = GetModelReferencer<CommlinkDescription>();
					if(id.Count() == 0) {
						_obj = new CommlinkDescription();
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
	[Table(Schema = "shadowrun5",Name = "commlinkdescription")]
	public partial class CommlinkDescription : ElectronicDescription {
	}
	[Table(Schema = "shadowrun5",Name = "commlinkexemplar")]
	public partial class CommlinkExemplar : ElectronicExemplar {
	}
}
