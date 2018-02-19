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
	[Table(Schema = "shadowrun5",Name = "grenademodel")]
	[CoreData]
	public partial class GrenadeModel : AbsGrenadeModel {

		private GrenadeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<GrenadeDescription> id = GetModelReferencer<GrenadeDescription>();
					if(id.Count() == 0) {
						_obj = new GrenadeDescription();
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
	[Table(Schema = "shadowrun5",Name = "grenadedescription")]
	public partial class GrenadeDescription : AbsGrenadeDescription {
	}
	[Table(Schema = "shadowrun5",Name = "grenadeexemplar")]
	public partial class GrenadeExemplar : AbsGrenadeExemplar {
	}
}
