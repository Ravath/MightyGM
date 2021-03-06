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
	[Table(Schema = "dd35",Name = "encharmemodel")]
	[CoreData]
	public partial class EnchArmeModel : EnchantementObjetModel {

		private EnchArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EnchArmeDescription> id = GetModelReferencer<EnchArmeDescription>();
					if(id.Count() == 0) {
						_obj = new EnchArmeDescription();
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

		private bool _armeMelee;
		[Column(Storage = "ArmeMelee",Name = "armemelee")]
		public bool ArmeMelee{
			get{ return _armeMelee;}
			set{_armeMelee = value;}
		}

		private bool _armeDistance;
		[Column(Storage = "ArmeDistance",Name = "armedistance")]
		public bool ArmeDistance{
			get{ return _armeDistance;}
			set{_armeDistance = value;}
		}
	}
	[Table(Schema = "dd35",Name = "encharmedescription")]
	public partial class EnchArmeDescription : EnchantementObjetDescription {
	}
	[Table(Schema = "dd35",Name = "encharmeexemplar")]
	public partial class EnchArmeExemplar : EnchantementObjetExemplar {
	}
}
