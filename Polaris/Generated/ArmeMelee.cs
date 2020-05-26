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
	public partial class ArmeMeleeModel : AbsArmeModel {

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

		private string _degatsChoc = "";
		[Column(Storage = "DegatsChoc",Name = "degatschoc")]
		public string DegatsChoc{
			get{ return _degatsChoc;}
			set{_degatsChoc = value;}
		}

		private int _degatsCumulatifs;
		[Column(Storage = "DegatsCumulatifs",Name = "degatscumulatifs")]
		public int DegatsCumulatifs{
			get{ return _degatsCumulatifs;}
			set{_degatsCumulatifs = value;}
		}

		private int _penaliteCumulative;
		[Column(Storage = "PenaliteCumulative",Name = "penalitecumulative")]
		public int PenaliteCumulative{
			get{ return _penaliteCumulative;}
			set{_penaliteCumulative = value;}
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
	public partial class ArmeMeleeDescription : AbsArmeDescription {
	}
	[Table(Schema = "polaris",Name = "armemeleeexemplar")]
	public partial class ArmeMeleeExemplar : AbsArmeExemplar {
	}
}
