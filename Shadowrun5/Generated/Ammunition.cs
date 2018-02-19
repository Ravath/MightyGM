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
	[Table(Schema = "shadowrun5",Name = "ammunitionmodel")]
	[CoreData]
	public partial class AmmunitionModel : ProductModel {

		private AmmunitionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AmmunitionDescription> id = GetModelReferencer<AmmunitionDescription>();
					if(id.Count() == 0) {
						_obj = new AmmunitionDescription();
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

		private int _damageModifier;
		[Column(Storage = "DamageModifier",Name = "damagemodifier")]
		public int DamageModifier{
			get{ return _damageModifier;}
			set{_damageModifier = value;}
		}

		private int _aPModifier;
		[Column(Storage = "APModifier",Name = "apmodifier")]
		public int APModifier{
			get{ return _aPModifier;}
			set{_aPModifier = value;}
		}

		private bool _stressDamage;
		[Column(Storage = "StressDamage",Name = "stressdamage")]
		public bool StressDamage{
			get{ return _stressDamage;}
			set{_stressDamage = value;}
		}

		private WeaponDamageType? _damageType;
		[Column(Storage = "DamageType",Name = "damagetype")]
		public WeaponDamageType? DamageType{
			get{ return _damageType;}
			set{_damageType = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "ammunitiondescription")]
	public partial class AmmunitionDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "ammunitionexemplar")]
	public partial class AmmunitionExemplar : ProductExemplar {
	}
}
