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
	[Table(Schema = "pathfinder",Name = "classeprestigemodel")]
	[CoreData]
	public partial class ClassePrestigeModel : AbsClasseModel {

		private ClassePrestigeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ClassePrestigeDescription> id = GetModelReferencer<ClassePrestigeDescription>();
					if(id.Count() == 0) {
						_obj = new ClassePrestigeDescription();
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
	[Table(Schema = "pathfinder",Name = "classeprestigedescription")]
	public partial class ClassePrestigeDescription : AbsClasseDescription {
	}
	[Table(Schema = "pathfinder",Name = "classeprestigeexemplar")]
	public partial class ClassePrestigeExemplar : AbsClasseExemplar {
	}
}
