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
	[Table(Schema = "shadowrun5",Name = "weaponmodel")]
	public abstract partial class WeaponModel : ProductModel {

		private WeaponCategory _category;
		[Column(Storage = "Category",Name = "category")]
		public WeaponCategory Category{
			get{ return _category;}
			set{_category = value;}
		}

		private int _accuracy;
		[Column(Storage = "Accuracy",Name = "accuracy")]
		public int Accuracy{
			get{ return _accuracy;}
			set{_accuracy = value;}
		}

		private int _damages;
		[Column(Storage = "Damages",Name = "damages")]
		public int Damages{
			get{ return _damages;}
			set{_damages = value;}
		}

		private bool _stressDamage;
		[Column(Storage = "StressDamage",Name = "stressdamage")]
		public bool StressDamage{
			get{ return _stressDamage;}
			set{_stressDamage = value;}
		}

		private WeaponDamageType? _weaponDamageType;
		[Column(Storage = "WeaponDamageType",Name = "weapondamagetype")]
		public WeaponDamageType? WeaponDamageType{
			get{ return _weaponDamageType;}
			set{_weaponDamageType = value;}
		}

		private int _aP;
		[Column(Storage = "AP",Name = "ap")]
		public int AP{
			get{ return _aP;}
			set{_aP = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "weapondescription")]
	public abstract partial class WeaponDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "weaponexemplar")]
	public abstract partial class WeaponExemplar : ProductExemplar {
	}
}
