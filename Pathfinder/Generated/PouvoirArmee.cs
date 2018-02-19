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
	[Table(Schema = "pathfinder",Name = "pouvoirarmeemodel")]
	[CoreData]
	public partial class PouvoirArmeeModel : DataModel {

		private PouvoirArmeeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirArmeeDescription> id = GetModelReferencer<PouvoirArmeeDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirArmeeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _pouvoirOrigineId;
		[Column(Storage = "PouvoirOrigineId",Name = "fk_pouvoirspecialmodel_pouvoirorigine")]
		[HiddenProperty]
		public int PouvoirOrigineId{
			get{ return _pouvoirOrigineId;}
			set{_pouvoirOrigineId = value;}
		}

		private PouvoirSpecialModel _pouvoirOrigine;
		public PouvoirSpecialModel PouvoirOrigine{
			get{
				if( _pouvoirOrigine == null)
					_pouvoirOrigine = LoadById<PouvoirSpecialModel>(PouvoirOrigineId);
				return _pouvoirOrigine;
			} set {
				if(_pouvoirOrigine == value){return;}
				_pouvoirOrigine = value;
				if( value != null)
					PouvoirOrigineId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "pouvoirarmeedescription")]
	public partial class PouvoirArmeeDescription : DataDescription<PouvoirArmeeModel> {
	}
	[Table(Schema = "pathfinder",Name = "pouvoirarmeeexemplar")]
	public partial class PouvoirArmeeExemplar : DataExemplaire<PouvoirArmeeModel> {
	}
}
