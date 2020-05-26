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
	[Table(Schema = "polaris",Name = "playerconditionmodel")]
	[CoreData]
	public partial class PlayerConditionModel : DataModel {

		private PlayerConditionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PlayerConditionDescription> id = GetModelReferencer<PlayerConditionDescription>();
					if(id.Count() == 0) {
						_obj = new PlayerConditionDescription();
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
	[Table(Schema = "polaris",Name = "playerconditiondescription")]
	public partial class PlayerConditionDescription : DataDescription<PlayerConditionModel> {
	}
	[Table(Schema = "polaris",Name = "playerconditionexemplar")]
	public partial class PlayerConditionExemplar : DataExemplaire<PlayerConditionModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
