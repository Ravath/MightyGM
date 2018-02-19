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
	[Table(Schema = "pathfinder",Name = "circonstancesnaissancemodel")]
	[CoreData]
	public partial class CirconstancesNaissanceModel : AbsOddTableModel {

		private CirconstancesNaissanceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CirconstancesNaissanceDescription> id = GetModelReferencer<CirconstancesNaissanceDescription>();
					if(id.Count() == 0) {
						_obj = new CirconstancesNaissanceDescription();
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
	[Table(Schema = "pathfinder",Name = "circonstancesnaissancedescription")]
	public partial class CirconstancesNaissanceDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "circonstancesnaissanceexemplar")]
	public partial class CirconstancesNaissanceExemplar : AbsOddTableExemplar {
	}
}
