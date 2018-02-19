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
	[Table(Schema = "shadowrun5",Name = "combatspellmodel")]
	[CoreData]
	public partial class CombatSpellModel : SpellModel {

		private CombatSpellDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CombatSpellDescription> id = GetModelReferencer<CombatSpellDescription>();
					if(id.Count() == 0) {
						_obj = new CombatSpellDescription();
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

		private bool _directSpell;
		[Column(Storage = "DirectSpell",Name = "directspell")]
		public bool DirectSpell{
			get{ return _directSpell;}
			set{_directSpell = value;}
		}

		private bool _stressDamage;
		[Column(Storage = "StressDamage",Name = "stressdamage")]
		public bool StressDamage{
			get{ return _stressDamage;}
			set{_stressDamage = value;}
		}

		private WeaponDamageType _damage;
		[Column(Storage = "Damage",Name = "damage")]
		public WeaponDamageType Damage{
			get{ return _damage;}
			set{_damage = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "combatspelldescription")]
	public partial class CombatSpellDescription : SpellDescription {
	}
	[Table(Schema = "shadowrun5",Name = "combatspellexemplar")]
	public partial class CombatSpellExemplar : SpellExemplar {
	}
}
