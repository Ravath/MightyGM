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
	[Table(Schema = "pathfinder",Name = "enchantementarmuremodel")]
	[CoreData]
	public partial class EnchantementArmureModel : EnchantementObjetModel {

		private EnchantementArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EnchantementArmureDescription> id = GetModelReferencer<EnchantementArmureDescription>();
					if(id.Count() == 0) {
						_obj = new EnchantementArmureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _armure;
		[Column(Storage = "Armure",Name = "armure")]
		public bool Armure{
			get{ return _armure;}
			set{_armure = value;}
		}

		private bool _bouclier;
		[Column(Storage = "Bouclier",Name = "bouclier")]
		public bool Bouclier{
			get{ return _bouclier;}
			set{_bouclier = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "enchantementarmuredescription")]
	public partial class EnchantementArmureDescription : EnchantementObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "enchantementarmureexemplar")]
	public partial class EnchantementArmureExemplar : EnchantementObjetExemplar {
	}
}
