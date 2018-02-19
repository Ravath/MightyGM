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
	[Table(Schema = "shadowrun5",Name = "naturalweaponmodel")]
	[CoreData]
	public partial class NaturalWeaponModel : DataModel {

		private NaturalWeaponDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<NaturalWeaponDescription> id = GetModelReferencer<NaturalWeaponDescription>();
					if(id.Count() == 0) {
						_obj = new NaturalWeaponDescription();
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
	}
	[Table(Schema = "shadowrun5",Name = "naturalweapondescription")]
	public partial class NaturalWeaponDescription : DataDescription<NaturalWeaponModel> {
	}
	[Table(Schema = "shadowrun5",Name = "naturalweaponexemplar")]
	public partial class NaturalWeaponExemplar : DataExemplaire<NaturalWeaponModel> {

		private int _vD;
		[Column(Storage = "VD",Name = "vd")]
		public int VD{
			get{ return _vD;}
			set{_vD = value;}
		}

		private bool _usesForce;
		[Column(Storage = "UsesForce",Name = "usesforce")]
		public bool UsesForce{
			get{ return _usesForce;}
			set{_usesForce = value;}
		}

		private bool _stressDamages;
		[Column(Storage = "StressDamages",Name = "stressdamages")]
		public bool StressDamages{
			get{ return _stressDamages;}
			set{_stressDamages = value;}
		}

		private int _pA;
		[Column(Storage = "PA",Name = "pa")]
		public int PA{
			get{ return _pA;}
			set{_pA = value;}
		}

		private int _reach;
		[Column(Storage = "Reach",Name = "reach")]
		public int Reach{
			get{ return _reach;}
			set{_reach = value;}
		}
	}
}
