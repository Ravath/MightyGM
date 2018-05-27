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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "armemeleemodel")]
	[CoreData]
	public partial class ArmeMeleeModel : ObjectModel {

		private ArmeMeleeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeMeleeDescription> id = GetModelReferencer<ArmeMeleeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeMeleeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _nbrDDegats;
		[Column(Storage = "nbrDDegats",Name = "nbrddegats")]
		public int nbrDDegats{
			get{ return _nbrDDegats;}
			set{_nbrDDegats = value;}
		}

		private bool _dgtsD6;
		[Column(Storage = "dgtsD6",Name = "dgtsd6")]
		public bool dgtsD6{
			get{ return _dgtsD6;}
			set{_dgtsD6 = value;}
		}

		private int _plus;
		[Column(Storage = "Plus",Name = "plus")]
		public int Plus{
			get{ return _plus;}
			set{_plus = value;}
		}

		private bool _degatsCumulatifs;
		[Column(Storage = "DegatsCumulatifs",Name = "degatscumulatifs")]
		public bool DegatsCumulatifs{
			get{ return _degatsCumulatifs;}
			set{_degatsCumulatifs = value;}
		}

		private int? _nbrDDegatsChoc;
		[Column(Storage = "nbrDDegatsChoc",Name = "nbrddegatschoc")]
		public int? nbrDDegatsChoc{
			get{ return _nbrDDegatsChoc;}
			set{_nbrDDegatsChoc = value;}
		}

		private bool? _dgtsD6Choc;
		[Column(Storage = "dgtsD6Choc",Name = "dgtsd6choc")]
		public bool? dgtsD6Choc{
			get{ return _dgtsD6Choc;}
			set{_dgtsD6Choc = value;}
		}

		private int? _plusChoc;
		[Column(Storage = "PlusChoc",Name = "pluschoc")]
		public int? PlusChoc{
			get{ return _plusChoc;}
			set{_plusChoc = value;}
		}

		private int _penalite;
		[Column(Storage = "Penalite",Name = "penalite")]
		public int Penalite{
			get{ return _penalite;}
			set{_penalite = value;}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int _init;
		[Column(Storage = "Init",Name = "init")]
		public int Init{
			get{ return _init;}
			set{_init = value;}
		}

		private int _allonge;
		[Column(Storage = "Allonge",Name = "allonge")]
		public int Allonge{
			get{ return _allonge;}
			set{_allonge = value;}
		}

		private int _charge;
		[Column(Storage = "Charge",Name = "charge")]
		public int Charge{
			get{ return _charge;}
			set{_charge = value;}
		}

		private int _coutCharge;
		[Column(Storage = "CoutCharge",Name = "coutcharge")]
		public int CoutCharge{
			get{ return _coutCharge;}
			set{_coutCharge = value;}
		}

		private bool _chargeHoraire;
		[Column(Storage = "ChargeHoraire",Name = "chargehoraire")]
		public bool ChargeHoraire{
			get{ return _chargeHoraire;}
			set{_chargeHoraire = value;}
		}
	}
	[Table(Schema = "polaris",Name = "armemeleedescription")]
	public partial class ArmeMeleeDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "armemeleeexemplar")]
	public partial class ArmeMeleeExemplar : ObjectExemplar {
	}
}
