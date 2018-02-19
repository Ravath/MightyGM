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
	[Table(Schema = "shadowrun5",Name = "toxinmodel")]
	[CoreData]
	public partial class ToxinModel : SubstanceModel {

		private ToxinDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ToxinDescription> id = GetModelReferencer<ToxinDescription>();
					if(id.Count() == 0) {
						_obj = new ToxinDescription();
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

		private int _power;
		[Column(Storage = "Power",Name = "power")]
		public int Power{
			get{ return _power;}
			set{_power = value;}
		}

		private int _penetration;
		[Column(Storage = "Penetration",Name = "penetration")]
		public int Penetration{
			get{ return _penetration;}
			set{_penetration = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "toxindescription")]
	public partial class ToxinDescription : SubstanceDescription {
	}
	[Table(Schema = "shadowrun5",Name = "toxinexemplar")]
	public partial class ToxinExemplar : SubstanceExemplar {
	}
}
