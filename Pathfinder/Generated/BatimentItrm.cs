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
	[Table(Schema = "pathfinder",Name = "batimentitrmmodel")]
	[CoreData]
	public partial class BatimentItrmModel : ConstructibleItrmModel {

		private BatimentItrmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<BatimentItrmDescription> id = GetModelReferencer<BatimentItrmDescription>();
					if(id.Count() == 0) {
						_obj = new BatimentItrmDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<SalleBatimentItrmExemplar> _salles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Salles",OtherKey = "BatimentItrmModelId")]
		public IEnumerable <SalleBatimentItrmExemplar> Salles{
			get{
				if( _salles == null ){
					_salles = LoadFromJointure<SalleBatimentItrmExemplar,BatimentItrmModelToSalleBatimentItrmExemplar_Salles>(false);
				}
				return _salles;
			}
			set{
				SaveToJointure<SalleBatimentItrmExemplar, BatimentItrmModelToSalleBatimentItrmExemplar_Salles> (_salles, value,false);
				_salles = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<BatimentItrmModel,BatimentItrmModelToSalleBatimentItrmExemplar_Salles>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "batimentitrmdescription")]
	public partial class BatimentItrmDescription : ConstructibleItrmDescription {
	}
	[Table(Schema = "pathfinder",Name = "batimentitrmexemplar")]
	public partial class BatimentItrmExemplar : ConstructibleItrmExemplar {
	}
}
