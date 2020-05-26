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
	[Table(Schema = "polaris",Name = "playereffectmodel")]
	[CoreData]
	public partial class PlayerEffectModel : DataModel {

		private PlayerEffectDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PlayerEffectDescription> id = GetModelReferencer<PlayerEffectDescription>();
					if(id.Count() == 0) {
						_obj = new PlayerEffectDescription();
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
	[Table(Schema = "polaris",Name = "playereffectdescription")]
	public partial class PlayerEffectDescription : DataDescription<PlayerEffectModel> {
	}
	[Table(Schema = "polaris",Name = "playereffectexemplar")]
	public partial class PlayerEffectExemplar : DataExemplaire<PlayerEffectModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
