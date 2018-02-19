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
	[Table(Schema = "pathfinder",Name = "armemagiquemodel")]
	[CoreData]
	public partial class ArmeMagiqueModel : ObjectMagiqueModel {

		private ArmeMagiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeMagiqueDescription> id = GetModelReferencer<ArmeMagiqueDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeMagiqueDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _armeId;
		[Column(Storage = "ArmeId",Name = "fk_armeexemplar_arme")]
		[HiddenProperty]
		public int ArmeId{
			get{ return _armeId;}
			set{_armeId = value;}
		}

		private ArmeExemplar _arme;
		public ArmeExemplar Arme{
			get{
				if( _arme == null)
					_arme = LoadById<ArmeExemplar>(ArmeId);
				return _arme;
			} set {
				if(_arme == value){return;}
				_arme = value;
				if( value != null)
					ArmeId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "armemagiquedescription")]
	public partial class ArmeMagiqueDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "pathfinder",Name = "armemagiqueexemplar")]
	public partial class ArmeMagiqueExemplar : ObjectMagiqueExemplar {
	}
}
