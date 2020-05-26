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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "objecteffectmodel")]
	[CoreData]
	public partial class ObjectEffectModel : DataModel {

		private ObjectEffectDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ObjectEffectDescription> id = GetModelReferencer<ObjectEffectDescription>();
					if(id.Count() == 0) {
						_obj = new ObjectEffectDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "polaris",Name = "objecteffectdescription")]
	public partial class ObjectEffectDescription : DataDescription<ObjectEffectModel> {
	}
	[Table(Schema = "polaris",Name = "objecteffectexemplar")]
	public partial class ObjectEffectExemplar : DataExemplaire<ObjectEffectModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
