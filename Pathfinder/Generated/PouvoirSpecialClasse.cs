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
	[Table(Schema = "pathfinder",Name = "pouvoirspecialclassemodel")]
	[CoreData]
	public partial class PouvoirSpecialClasseModel : PouvoirSpecialModel {

		private PouvoirSpecialClasseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirSpecialClasseDescription> id = GetModelReferencer<PouvoirSpecialClasseDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirSpecialClasseDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _niveauMin;
		[Column(Storage = "NiveauMin",Name = "niveaumin")]
		public int NiveauMin{
			get{ return _niveauMin;}
			set{_niveauMin = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "pouvoirspecialclassedescription")]
	public partial class PouvoirSpecialClasseDescription : PouvoirSpecialDescription {
	}
	[Table(Schema = "pathfinder",Name = "pouvoirspecialclasseexemplar")]
	public partial class PouvoirSpecialClasseExemplar : PouvoirSpecialExemplar {
	}
}
