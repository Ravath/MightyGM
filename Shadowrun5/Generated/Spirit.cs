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
	[Table(Schema = "shadowrun5",Name = "spiritmodel")]
	[CoreData]
	public partial class SpiritModel : AbsCritterModel {

		private SpiritDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpiritDescription> id = GetModelReferencer<SpiritDescription>();
					if(id.Count() == 0) {
						_obj = new SpiritDescription();
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
	[Table(Schema = "shadowrun5",Name = "spiritdescription")]
	public partial class SpiritDescription : AbsCritterDescription {
	}
	[Table(Schema = "shadowrun5",Name = "spiritexemplar")]
	public partial class SpiritExemplar : AbsCritterExemplar {

		private int _power;
		[Column(Storage = "Power",Name = "power")]
		public int Power{
			get{ return _power;}
			set{_power = value;}
		}
		private bool _free;
		public bool Free {
			get { return _free; }
			set { _free = value; }
		}
	}
}
