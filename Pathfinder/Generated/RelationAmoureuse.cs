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
	[Table(Schema = "pathfinder",Name = "relationamoureusemodel")]
	[CoreData]
	public partial class RelationAmoureuseModel : AbsOddTableModel {

		private RelationAmoureuseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RelationAmoureuseDescription> id = GetModelReferencer<RelationAmoureuseDescription>();
					if(id.Count() == 0) {
						_obj = new RelationAmoureuseDescription();
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
	[Table(Schema = "pathfinder",Name = "relationamoureusedescription")]
	public partial class RelationAmoureuseDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "relationamoureuseexemplar")]
	public partial class RelationAmoureuseExemplar : AbsOddTableExemplar {
	}
}
