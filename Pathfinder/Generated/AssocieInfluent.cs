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
	[Table(Schema = "pathfinder",Name = "associeinfluentmodel")]
	[CoreData]
	public partial class AssocieInfluentModel : AbsOddTableModel {

		private AssocieInfluentDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AssocieInfluentDescription> id = GetModelReferencer<AssocieInfluentDescription>();
					if(id.Count() == 0) {
						_obj = new AssocieInfluentDescription();
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
	[Table(Schema = "pathfinder",Name = "associeinfluentdescription")]
	public partial class AssocieInfluentDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "associeinfluentexemplar")]
	public partial class AssocieInfluentExemplar : AbsOddTableExemplar {
	}
}
