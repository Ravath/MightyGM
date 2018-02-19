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
	[Table(Schema = "pathfinder",Name = "batimentroyaumemodel")]
	[CoreData]
	public partial class BatimentRoyaumeModel : DataModel {

		private BatimentRoyaumeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<BatimentRoyaumeDescription> id = GetModelReferencer<BatimentRoyaumeDescription>();
					if(id.Count() == 0) {
						_obj = new BatimentRoyaumeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _nbrLots;
		[Column(Storage = "NbrLots",Name = "nbrlots")]
		public int NbrLots{
			get{ return _nbrLots;}
			set{_nbrLots = value;}
		}

		private int _coutPC;
		[Column(Storage = "CoutPC",Name = "coutpc")]
		public int CoutPC{
			get{ return _coutPC;}
			set{_coutPC = value;}
		}

		private int _bonusEconomie;
		[Column(Storage = "BonusEconomie",Name = "bonuseconomie")]
		public int BonusEconomie{
			get{ return _bonusEconomie;}
			set{_bonusEconomie = value;}
		}

		private int _bonusLoyaute;
		[Column(Storage = "BonusLoyaute",Name = "bonusloyaute")]
		public int BonusLoyaute{
			get{ return _bonusLoyaute;}
			set{_bonusLoyaute = value;}
		}

		private int _bonusStablite;
		[Column(Storage = "BonusStablite",Name = "bonusstablite")]
		public int BonusStablite{
			get{ return _bonusStablite;}
			set{_bonusStablite = value;}
		}

		private int _bonusCorruption;
		[Column(Storage = "BonusCorruption",Name = "bonuscorruption")]
		public int BonusCorruption{
			get{ return _bonusCorruption;}
			set{_bonusCorruption = value;}
		}

		private int _bonusCriminalite;
		[Column(Storage = "BonusCriminalite",Name = "bonuscriminalite")]
		public int BonusCriminalite{
			get{ return _bonusCriminalite;}
			set{_bonusCriminalite = value;}
		}

		private int _bonusLoi;
		[Column(Storage = "BonusLoi",Name = "bonusloi")]
		public int BonusLoi{
			get{ return _bonusLoi;}
			set{_bonusLoi = value;}
		}

		private int _bonusFolklore;
		[Column(Storage = "BonusFolklore",Name = "bonusfolklore")]
		public int BonusFolklore{
			get{ return _bonusFolklore;}
			set{_bonusFolklore = value;}
		}

		private int _bonusSociete;
		[Column(Storage = "BonusSociete",Name = "bonussociete")]
		public int BonusSociete{
			get{ return _bonusSociete;}
			set{_bonusSociete = value;}
		}

		private int _bonusProductivite;
		[Column(Storage = "BonusProductivite",Name = "bonusproductivite")]
		public int BonusProductivite{
			get{ return _bonusProductivite;}
			set{_bonusProductivite = value;}
		}

		private int _bonusGloire;
		[Column(Storage = "BonusGloire",Name = "bonusgloire")]
		public int BonusGloire{
			get{ return _bonusGloire;}
			set{_bonusGloire = value;}
		}

		private int _bonusInfamie;
		[Column(Storage = "BonusInfamie",Name = "bonusinfamie")]
		public int BonusInfamie{
			get{ return _bonusInfamie;}
			set{_bonusInfamie = value;}
		}

		private int _bonusInsatisfaction;
		[Column(Storage = "BonusInsatisfaction",Name = "bonusinsatisfaction")]
		public int BonusInsatisfaction{
			get{ return _bonusInsatisfaction;}
			set{_bonusInsatisfaction = value;}
		}

		private int _objMagFaible;
		[Column(Storage = "ObjMagFaible",Name = "objmagfaible")]
		public int ObjMagFaible{
			get{ return _objMagFaible;}
			set{_objMagFaible = value;}
		}

		private int _objMagIntermediaire;
		[Column(Storage = "ObjMagIntermediaire",Name = "objmagintermediaire")]
		public int ObjMagIntermediaire{
			get{ return _objMagIntermediaire;}
			set{_objMagIntermediaire = value;}
		}

		private int _objMagPuissant;
		[Column(Storage = "ObjMagPuissant",Name = "objmagpuissant")]
		public int ObjMagPuissant{
			get{ return _objMagPuissant;}
			set{_objMagPuissant = value;}
		}

		private int _objMagAnneau;
		[Column(Storage = "ObjMagAnneau",Name = "objmaganneau")]
		public int ObjMagAnneau{
			get{ return _objMagAnneau;}
			set{_objMagAnneau = value;}
		}

		private IEnumerable<BatimentRoyaumeModel> _reduction;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Reduction",OtherKey = "BatimentRoyaumeModelReductionId")]
		public IEnumerable <BatimentRoyaumeModel> Reduction{
			get{
				if( _reduction == null ){
					_reduction = LoadFromJointure<BatimentRoyaumeModel,BatimentRoyaumeModelToBatimentRoyaumeModel_Reduction>(false);
				}
				return _reduction;
			}
			set{
				SaveToJointure<BatimentRoyaumeModel, BatimentRoyaumeModelToBatimentRoyaumeModel_Reduction> (_reduction, value,false);
				_reduction = value;
			}
		}

		private IEnumerable<BatimentRoyaumeModel> _amelioreEn;
		public IEnumerable <BatimentRoyaumeModel> AmelioreEn{
			get{
				if( _amelioreEn == null ){
					_amelioreEn = LoadFromJointure<BatimentRoyaumeModel,BatimentRoyaumeModelAmelioreDeToBatimentRoyaumeModelAmelioreEn>(true);
				}
				return _amelioreEn;
			}
			set{
				SaveToJointure<BatimentRoyaumeModel, BatimentRoyaumeModelAmelioreDeToBatimentRoyaumeModelAmelioreEn> (_amelioreEn, value,true);
				_amelioreEn = value;
			}
		}

		private IEnumerable<BatimentRoyaumeModel> _amelioreDe;
		public IEnumerable <BatimentRoyaumeModel> AmelioreDe{
			get{
				if( _amelioreDe == null ){
					_amelioreDe = LoadFromJointure<BatimentRoyaumeModel,BatimentRoyaumeModelAmelioreDeToBatimentRoyaumeModelAmelioreEn>(false);
				}
				return _amelioreDe;
			}
			set{
				SaveToJointure<BatimentRoyaumeModel, BatimentRoyaumeModelAmelioreDeToBatimentRoyaumeModelAmelioreEn> (_amelioreDe, value,false);
				_amelioreDe = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<BatimentRoyaumeModel,BatimentRoyaumeModelToBatimentRoyaumeModel_Reduction>(true);
			DeleteJoins<BatimentRoyaumeModel,BatimentRoyaumeModelAmelioreEnToBatimentRoyaumeModelAmelioreDe>(false);
			DeleteJoins<BatimentRoyaumeModel,BatimentRoyaumeModelAmelioreEnToBatimentRoyaumeModelAmelioreDe>(true);
			DeleteJoins<BatimentRoyaumeModel,BatimentRoyaumeModelAmelioreDeToBatimentRoyaumeModelAmelioreEn>(true);
			DeleteJoins<BatimentRoyaumeModel,BatimentRoyaumeModelAmelioreDeToBatimentRoyaumeModelAmelioreEn>(false);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "batimentroyaumedescription")]
	public partial class BatimentRoyaumeDescription : DataDescription<BatimentRoyaumeModel> {

		private string _special = "";
		[LargeText]
		[Column(Storage = "Special",Name = "special")]
		public string Special{
			get{ return _special;}
			set{_special = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "batimentroyaumeexemplar")]
	public partial class BatimentRoyaumeExemplar : DataExemplaire<BatimentRoyaumeModel> {
	}
}
