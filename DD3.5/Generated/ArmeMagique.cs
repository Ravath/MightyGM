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
	[Table(Schema = "dd35",Name = "armemagiquemodel")]
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
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private int _armeId;
		[Column(Storage = "ArmeId",Name = "fk_armemodel_arme")]
		[HiddenProperty]
		public int ArmeId{
			get{ return _armeId;}
			set{_armeId = value;}
		}

		private ArmeModel _arme;
		public ArmeModel Arme{
			get{
				if( _arme == null)
					_arme = LoadById<ArmeModel>(ArmeId);
				return _arme;
			} set {
				if(_arme == value){return;}
				_arme = value;
				if( value != null)
					ArmeId = value.Id;
			}
		}

		private int _alteration;
		[Column(Storage = "Alteration",Name = "alteration")]
		public int Alteration{
			get{ return _alteration;}
			set{_alteration = value;}
		}
	}
	[Table(Schema = "dd35",Name = "armemagiquedescription")]
	public partial class ArmeMagiqueDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "dd35",Name = "armemagiqueexemplar")]
	public partial class ArmeMagiqueExemplar : ObjectMagiqueExemplar {
	}
}
