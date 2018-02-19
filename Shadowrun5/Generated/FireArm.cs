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
	[Table(Schema = "shadowrun5",Name = "firearmmodel")]
	[CoreData]
	public partial class FireArmModel : WeaponModel {

		private FireArmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FireArmDescription> id = GetModelReferencer<FireArmDescription>();
					if(id.Count() == 0) {
						_obj = new FireArmDescription();
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

		private bool _sS;
		[Column(Storage = "SS",Name = "ss")]
		public bool SS{
			get{ return _sS;}
			set{_sS = value;}
		}

		private bool _sA;
		[Column(Storage = "SA",Name = "sa")]
		public bool SA{
			get{ return _sA;}
			set{_sA = value;}
		}

		private bool _bF;
		[Column(Storage = "BF",Name = "bf")]
		public bool BF{
			get{ return _bF;}
			set{_bF = value;}
		}

		private bool _fA;
		[Column(Storage = "FA",Name = "fa")]
		public bool FA{
			get{ return _fA;}
			set{_fA = value;}
		}

		private bool _canUseFlechette;
		[Column(Storage = "CanUseFlechette",Name = "canuseflechette")]
		public bool CanUseFlechette{
			get{ return _canUseFlechette;}
			set{_canUseFlechette = value;}
		}

		private int _rC;
		[Column(Storage = "RC",Name = "rc")]
		public int RC{
			get{ return _rC;}
			set{_rC = value;}
		}

		private int _ammo;
		[Column(Storage = "Ammo",Name = "ammo")]
		public int Ammo{
			get{ return _ammo;}
			set{_ammo = value;}
		}

		private AmmoLoader _loader;
		[Column(Storage = "Loader",Name = "loader")]
		public AmmoLoader Loader{
			get{ return _loader;}
			set{_loader = value;}
		}

		private IEnumerable<FirearmAccessoryExemplar> _accessories;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Accessories",OtherKey = "FireArmModelId")]
		public IEnumerable <FirearmAccessoryExemplar> Accessories{
			get{
				if( _accessories == null ){
					_accessories = LoadFromJointure<FirearmAccessoryExemplar,FireArmModelToFirearmAccessoryExemplar_Accessories>(false);
				}
				return _accessories;
			}
			set{
				SaveToJointure<FirearmAccessoryExemplar, FireArmModelToFirearmAccessoryExemplar_Accessories> (_accessories, value,false);
				_accessories = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<FireArmModel,FireArmModelToFirearmAccessoryExemplar_Accessories>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "shadowrun5",Name = "firearmdescription")]
	public partial class FireArmDescription : WeaponDescription {
	}
	[Table(Schema = "shadowrun5",Name = "firearmexemplar")]
	public partial class FireArmExemplar : WeaponExemplar {

		private IEnumerable<FirearmAccessoryExemplar> _customAccessories;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "CustomAccessories",OtherKey = "FireArmExemplarId")]
		public IEnumerable <FirearmAccessoryExemplar> CustomAccessories{
			get{
				if( _customAccessories == null ){
					_customAccessories = LoadFromJointure<FirearmAccessoryExemplar,FireArmExemplarToFirearmAccessoryExemplar_CustomAccessories>(false);
				}
				return _customAccessories;
			}
			set{
				SaveToJointure<FirearmAccessoryExemplar, FireArmExemplarToFirearmAccessoryExemplar_CustomAccessories> (_customAccessories, value,false);
				_customAccessories = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<FireArmExemplar,FireArmExemplarToFirearmAccessoryExemplar_CustomAccessories>(true);
			base.DeleteObject();
		}
	}
}
