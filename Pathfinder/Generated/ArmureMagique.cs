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
	[Table(Schema = "pathfinder",Name = "armuremagiquemodel")]
	[CoreData]
	public partial class ArmureMagiqueModel : ObjectMagiqueModel {

		private ArmureMagiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmureMagiqueDescription> id = GetModelReferencer<ArmureMagiqueDescription>();
					if(id.Count() == 0) {
						_obj = new ArmureMagiqueDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _armureId;
		[Column(Storage = "ArmureId",Name = "fk_armureexemplar_armure")]
		[HiddenProperty]
		public int ArmureId{
			get{ return _armureId;}
			set{_armureId = value;}
		}

		private ArmureExemplar _armure;
		public ArmureExemplar Armure{
			get{
				if( _armure == null)
					_armure = LoadById<ArmureExemplar>(ArmureId);
				return _armure;
			} set {
				if(_armure == value){return;}
				_armure = value;
				if( value != null)
					ArmureId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "armuremagiquedescription")]
	public partial class ArmureMagiqueDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "pathfinder",Name = "armuremagiqueexemplar")]
	public partial class ArmureMagiqueExemplar : ObjectMagiqueExemplar {
	}
}
