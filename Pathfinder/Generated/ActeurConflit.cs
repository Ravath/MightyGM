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
	[Table(Schema = "pathfinder",Name = "acteurconflitmodel")]
	[CoreData]
	public partial class ActeurConflitModel : AbsOddTableModel {

		private ActeurConflitDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ActeurConflitDescription> id = GetModelReferencer<ActeurConflitDescription>();
					if(id.Count() == 0) {
						_obj = new ActeurConflitDescription();
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
	[Table(Schema = "pathfinder",Name = "acteurconflitdescription")]
	public partial class ActeurConflitDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "acteurconflitexemplar")]
	public partial class ActeurConflitExemplar : AbsOddTableExemplar {
	}
}
