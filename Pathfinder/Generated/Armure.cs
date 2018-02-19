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
	[Table(Schema = "pathfinder",Name = "armuremodel")]
	[CoreData]
	public partial class ArmureModel : ObjetModel {

		private ArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmureDescription> id = GetModelReferencer<ArmureDescription>();
					if(id.Count() == 0) {
						_obj = new ArmureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _bonusCA;
		[Column(Storage = "BonusCA",Name = "bonusca")]
		public int BonusCA{
			get{ return _bonusCA;}
			set{_bonusCA = value;}
		}

		private int _malusTests;
		[Column(Storage = "MalusTests",Name = "malustests")]
		public int MalusTests{
			get{ return _malusTests;}
			set{_malusTests = value;}
		}

		private int _dexMax;
		[Column(Storage = "DexMax",Name = "dexmax")]
		public int DexMax{
			get{ return _dexMax;}
			set{_dexMax = value;}
		}

		private int _echecSorts;
		[Column(Storage = "EchecSorts",Name = "echecsorts")]
		public int EchecSorts{
			get{ return _echecSorts;}
			set{_echecSorts = value;}
		}

		private CategorieArmure _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieArmure Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "armuredescription")]
	public partial class ArmureDescription : ObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "armureexemplar")]
	public partial class ArmureExemplar : ObjetExemplar {

		private bool _armureDeMaitre;
		[Column(Storage = "ArmureDeMaitre",Name = "armuredemaitre")]
		public bool ArmureDeMaitre{
			get{ return _armureDeMaitre;}
			set{_armureDeMaitre = value;}
		}

		private int _alteration;
		[Column(Storage = "Alteration",Name = "alteration")]
		public int Alteration{
			get{ return _alteration;}
			set{_alteration = value;}
		}

		private IEnumerable<EnchantementArmureExemplar> _enchantements;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Enchantements",OtherKey = "ArmureExemplarId")]
		public IEnumerable <EnchantementArmureExemplar> Enchantements{
			get{
				if( _enchantements == null ){
					_enchantements = LoadFromJointure<EnchantementArmureExemplar,ArmureExemplarToEnchantementArmureExemplar_Enchantements>(false);
				}
				return _enchantements;
			}
			set{
				SaveToJointure<EnchantementArmureExemplar, ArmureExemplarToEnchantementArmureExemplar_Enchantements> (_enchantements, value,false);
				_enchantements = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmureExemplar,ArmureExemplarToEnchantementArmureExemplar_Enchantements>(true);
			base.DeleteObject();
		}
	}
}
