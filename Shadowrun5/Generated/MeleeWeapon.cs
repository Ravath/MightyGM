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
	[Table(Schema = "shadowrun5",Name = "meleeweaponmodel")]
	[CoreData]
	public partial class MeleeWeaponModel : WeaponModel {

		private MeleeWeaponDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MeleeWeaponDescription> id = GetModelReferencer<MeleeWeaponDescription>();
					if(id.Count() == 0) {
						_obj = new MeleeWeaponDescription();
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

		private int _reach;
		[Column(Storage = "Reach",Name = "reach")]
		public int Reach{
			get{ return _reach;}
			set{_reach = value;}
		}

		private bool _doesntUsesSTR;
		[Column(Storage = "DoesntUsesSTR",Name = "doesntusesstr")]
		public bool DoesntUsesSTR{
			get{ return _doesntUsesSTR;}
			set{_doesntUsesSTR = value;}
		}

		private bool _accuracyIsPhysicalThreshold;
		[Column(Storage = "AccuracyIsPhysicalThreshold",Name = "accuracyisphysicalthreshold")]
		public bool AccuracyIsPhysicalThreshold{
			get{ return _accuracyIsPhysicalThreshold;}
			set{_accuracyIsPhysicalThreshold = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "meleeweapondescription")]
	public partial class MeleeWeaponDescription : WeaponDescription {
	}
	[Table(Schema = "shadowrun5",Name = "meleeweaponexemplar")]
	public partial class MeleeWeaponExemplar : WeaponExemplar {
	}
}
