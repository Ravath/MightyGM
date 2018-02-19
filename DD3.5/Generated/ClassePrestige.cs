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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "classeprestigemodel")]
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
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}
	}
	[Table(Schema = "dd35",Name = "classeprestigedescription")]
	public partial class ClassePrestigeDescription : AbsClasseDescription {
	}
	[Table(Schema = "dd35",Name = "classeprestigeexemplar")]
	public partial class ClassePrestigeExemplar : AbsClasseExemplar {
	}
}
