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
	[Table(Schema = "pathfinder",Name = "handicapmodel")]
	[CoreData]
	public partial class HandicapModel : AbsOddTableModel {

		private HandicapDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<HandicapDescription> id = GetModelReferencer<HandicapDescription>();
					if(id.Count() == 0) {
						_obj = new HandicapDescription();
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
	[Table(Schema = "pathfinder",Name = "handicapdescription")]
	public partial class HandicapDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "handicapexemplar")]
	public partial class HandicapExemplar : AbsOddTableExemplar {
	}
}
