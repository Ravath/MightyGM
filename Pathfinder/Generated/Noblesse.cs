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
	[Table(Schema = "pathfinder",Name = "noblessemodel")]
	[CoreData]
	public partial class NoblesseModel : AbsOddTableModel {

		private NoblesseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<NoblesseDescription> id = GetModelReferencer<NoblesseDescription>();
					if(id.Count() == 0) {
						_obj = new NoblesseDescription();
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
	[Table(Schema = "pathfinder",Name = "noblessedescription")]
	public partial class NoblesseDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "noblesseexemplar")]
	public partial class NoblesseExemplar : AbsOddTableExemplar {
	}
}
