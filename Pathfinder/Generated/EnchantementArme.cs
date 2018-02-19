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
	[Table(Schema = "pathfinder",Name = "enchantementarmemodel")]
	[CoreData]
	public partial class EnchantementArmeModel : EnchantementObjetModel {

		private EnchantementArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EnchantementArmeDescription> id = GetModelReferencer<EnchantementArmeDescription>();
					if(id.Count() == 0) {
						_obj = new EnchantementArmeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
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
	[Table(Schema = "pathfinder",Name = "enchantementarmedescription")]
	public partial class EnchantementArmeDescription : EnchantementObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "enchantementarmeexemplar")]
	public partial class EnchantementArmeExemplar : EnchantementObjetExemplar {
	}
}
