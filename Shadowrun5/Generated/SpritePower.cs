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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "spritepowermodel")]
	[CoreData]
	public partial class SpritePowerModel : DataModel {

		private SpritePowerDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpritePowerDescription> id = GetModelReferencer<SpritePowerDescription>();
					if(id.Count() == 0) {
						_obj = new SpritePowerDescription();
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
	}
	[Table(Schema = "shadowrun5",Name = "spritepowerdescription")]
	public partial class SpritePowerDescription : DataDescription<SpritePowerModel> {
	}
	[Table(Schema = "shadowrun5",Name = "spritepowerexemplar")]
	public partial class SpritePowerExemplar : DataExemplaire<SpritePowerModel> {
	}
}
