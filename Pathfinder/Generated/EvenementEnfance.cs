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
	[Table(Schema = "pathfinder",Name = "evenementenfancemodel")]
	[CoreData]
	public partial class EvenementEnfanceModel : AbsOddTableModel {

		private EvenementEnfanceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EvenementEnfanceDescription> id = GetModelReferencer<EvenementEnfanceDescription>();
					if(id.Count() == 0) {
						_obj = new EvenementEnfanceDescription();
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
	[Table(Schema = "pathfinder",Name = "evenementenfancedescription")]
	public partial class EvenementEnfanceDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "evenementenfanceexemplar")]
	public partial class EvenementEnfanceExemplar : AbsOddTableExemplar {
	}
}
