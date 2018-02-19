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
	[Table(Schema = "dd35",Name = "encharmuremodel")]
	[CoreData]
	public partial class EnchArmureModel : EnchantementObjetModel {

		private EnchArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EnchArmureDescription> id = GetModelReferencer<EnchArmureDescription>();
					if(id.Count() == 0) {
						_obj = new EnchArmureDescription();
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

		private int? _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int? Prix{
			get{ return _prix;}
			set{_prix = value;}
		}
	}
	[Table(Schema = "dd35",Name = "encharmuredescription")]
	public partial class EnchArmureDescription : EnchantementObjetDescription {
	}
	[Table(Schema = "dd35",Name = "encharmureexemplar")]
	public partial class EnchArmureExemplar : EnchantementObjetExemplar {
	}
}
