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
	[Table(Schema = "shadowrun5",Name = "crittermodel")]
	[CoreData]
	public partial class CritterModel : AbsCritterModel {

		private CritterDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CritterDescription> id = GetModelReferencer<CritterDescription>();
					if(id.Count() == 0) {
						_obj = new CritterDescription();
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
	[Table(Schema = "shadowrun5",Name = "critterdescription")]
	public partial class CritterDescription : AbsCritterDescription {
	}
	[Table(Schema = "shadowrun5",Name = "critterexemplar")]
	public partial class CritterExemplar : AbsCritterExemplar {
	}
}
