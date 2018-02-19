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
	[Table(Schema = "shadowrun5",Name = "cyberweaponmodel")]
	[CoreData]
	public partial class CyberWeaponModel : AugmentationModel {

		private CyberWeaponDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CyberWeaponDescription> id = GetModelReferencer<CyberWeaponDescription>();
					if(id.Count() == 0) {
						_obj = new CyberWeaponDescription();
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

		private int _weaponId;
		[Column(Storage = "WeaponId",Name = "fk_weaponmodel_weapon")]
		[HiddenProperty]
		public int WeaponId{
			get{ return _weaponId;}
			set{_weaponId = value;}
		}

		private WeaponModel _weapon;
		public WeaponModel Weapon{
			get{
				if( _weapon == null)
					_weapon = LoadById<WeaponModel>(WeaponId);
				return _weapon;
			} set {
				if(_weapon == value){return;}
				_weapon = value;
				if( value != null)
					WeaponId = value.Id;
			}
		}

		private int _cAmmo;
		[Column(Storage = "cAmmo",Name = "cammo")]
		public int cAmmo{
			get{ return _cAmmo;}
			set{_cAmmo = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "cyberweapondescription")]
	public partial class CyberWeaponDescription : AugmentationDescription {
	}
	[Table(Schema = "shadowrun5",Name = "cyberweaponexemplar")]
	public partial class CyberWeaponExemplar : AugmentationExemplar {
	}
}
