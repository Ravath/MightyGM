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
	[Table(Schema = "pathfinder",Name = "classemodel")]
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
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _classePNJ;
		[Column(Storage = "ClassePNJ",Name = "classepnj")]
		public bool ClassePNJ{
			get{ return _classePNJ;}
			set{_classePNJ = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "classedescription")]
	public partial class ClasseDescription : AbsClasseDescription {
	}
	[Table(Schema = "pathfinder",Name = "classeexemplar")]
	public partial class ClasseExemplar : AbsClasseExemplar {
	}
}
