using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[CoreData]
	[Table(Schema = "cinqanneaux",Name = "armure_model")]
	public partial class ArmureModel : AbsObjetModel {

		private int _bonusND;
		[Column(Storage = "BonusND",Name = "bonusnd")]
		public int BonusND{
			get{ return _bonusND;}
			set{_bonusND = value;}
		}

		private int _reduction;
		[Column(Storage = "Reduction",Name = "reduction")]
		public int Reduction{
			get{ return _reduction;}
			set{_reduction = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "armure_exemplar")]
	public partial class ArmureExemplar : AbsObjetExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "armure_description")]
	public partial class ArmureDescription : AbsObjetDescription {

		private IEnumerable<SpecialFromArmureDescription> _Special;
		[Association(ThisKey = "Id",CanBeNull = "true",Storage = "Special",OtherKey = "Armure")]
		public IEnumerable<SpecialFromArmureDescription> Special{
			get {
				if(_Special == null) {
					_Special = LoadByForeignKey<SpecialFromArmureDescription>(p => p.ArmureDescriptionId, Id);
			    }
				return _Special;
			}
			set {
				foreach(SpecialFromArmureDescription item in _Special) {
					item.ArmureDescription = null;
				}
				_Special = value;
				foreach(SpecialFromArmureDescription item in value) {
					item.ArmureDescription = this;
				}
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "specialfromarmuredescription")]
	public class SpecialFromArmureDescription : DataObject {

		private string _special;
		[LargeText]
		[Column(Storage = "Special",Name = "special")]
		public string Special{
			get{ return _special;}
			set{_special = value;}
		}

		private int _armureId;
		[Column(Storage = "ArmureId",Name = "fk_armure")]
		public int ArmureId{
			get{ return _armureId}
			set{_armureId = value;}
		}

		private ArmureDescription _armureDescription;
		[Association(ThisKey = "ArmureId",CanBeNull = "false",Storage = "ArmureDescription",OtherKey = "Id")]
		public ArmureDescription ArmureDescription{
			get {
				if(_armureDescription == null) {
					_armureDescription = LoadById<ArmureDescription>(ArmureDescriptionId);
			       }
				return _armureDescription;
			} set {
				if(value == _armureDescription) { return; }
				_armureDescription = value;
				if(_armureDescription != null) {
					_armureDescriptionId = _armureDescription.Id;
				} else {
					_armureDescriptionId = 0;
				}
			}
		}
	}
}
