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
	[Table(Schema = "dd35",Name = "armuremagiquemodel")]
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
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private int _armureId;
		[Column(Storage = "ArmureId",Name = "fk_armuremodel_armure")]
		[HiddenProperty]
		public int ArmureId{
			get{ return _armureId;}
			set{_armureId = value;}
		}

		private ArmureModel _armure;
		public ArmureModel Armure{
			get{
				if( _armure == null)
					_armure = LoadById<ArmureModel>(ArmureId);
				return _armure;
			} set {
				if(_armure == value){return;}
				_armure = value;
				if( value != null)
					ArmureId = value.Id;
			}
		}

		private int _alteration;
		[Column(Storage = "Alteration",Name = "alteration")]
		public int Alteration{
			get{ return _alteration;}
			set{_alteration = value;}
		}
	}
	[Table(Schema = "dd35",Name = "armuremagiquedescription")]
	public partial class ArmureMagiqueDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "dd35",Name = "armuremagiqueexemplar")]
	public partial class ArmureMagiqueExemplar : ObjectMagiqueExemplar {
	}
}
