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
	[Table(Schema = "pathfinder",Name = "foyerinhabituelmodel")]
	[CoreData]
	public partial class FoyerInhabituelModel : AbsOddTableModel {

		private FoyerInhabituelDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FoyerInhabituelDescription> id = GetModelReferencer<FoyerInhabituelDescription>();
					if(id.Count() == 0) {
						_obj = new FoyerInhabituelDescription();
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
	[Table(Schema = "pathfinder",Name = "foyerinhabitueldescription")]
	public partial class FoyerInhabituelDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "foyerinhabituelexemplar")]
	public partial class FoyerInhabituelExemplar : AbsOddTableExemplar {
	}
}
