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
	[Table(Schema = "pathfinder",Name = "professionparentsmodel")]
	[CoreData]
	public partial class ProfessionParentsModel : AbsOddTableModel {

		private ProfessionParentsDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ProfessionParentsDescription> id = GetModelReferencer<ProfessionParentsDescription>();
					if(id.Count() == 0) {
						_obj = new ProfessionParentsDescription();
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
	[Table(Schema = "pathfinder",Name = "professionparentsdescription")]
	public partial class ProfessionParentsDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "professionparentsexemplar")]
	public partial class ProfessionParentsExemplar : AbsOddTableExemplar {
	}
}
