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
	[Table(Schema = "pathfinder",Name = "relationaveccompagnonsmodel")]
	[CoreData]
	public partial class RelationAvecCompagnonsModel : AbsOddTableModel {

		private RelationAvecCompagnonsDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RelationAvecCompagnonsDescription> id = GetModelReferencer<RelationAvecCompagnonsDescription>();
					if(id.Count() == 0) {
						_obj = new RelationAvecCompagnonsDescription();
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
	[Table(Schema = "pathfinder",Name = "relationaveccompagnonsdescription")]
	public partial class RelationAvecCompagnonsDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "relationaveccompagnonsexemplar")]
	public partial class RelationAvecCompagnonsExemplar : AbsOddTableExemplar {
	}
}
