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
	[Table(Schema = "dd35",Name = "classemodel")]
	[CoreData]
	public partial class ClasseModel : AbsClasseModel {

		private ClasseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ClasseDescription> id = GetModelReferencer<ClasseDescription>();
					if(id.Count() == 0) {
						_obj = new ClasseDescription();
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
	[Table(Schema = "dd35",Name = "classedescription")]
	public partial class ClasseDescription : AbsClasseDescription {
	}
	[Table(Schema = "dd35",Name = "classeexemplar")]
	public partial class ClasseExemplar : AbsClasseExemplar {
	}
}
