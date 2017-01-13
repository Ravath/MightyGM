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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "vehiculemodel")]
	[CoreData]
	public partial class VehiculeModel : DataModel {

		private VehiculeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<VehiculeDescription> id = GetModelReferencer<VehiculeDescription>();
					if(id.Count() == 0) {
						_obj = new VehiculeDescription();
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

		private int _gabarit;
		[Column(Storage = "Gabarit",Name = "gabarit")]
		public int Gabarit{
			get{ return _gabarit;}
			set{_gabarit = value;}
		}

		private int _vitesse;
		[Column(Storage = "Vitesse",Name = "vitesse")]
		public int Vitesse{
			get{ return _vitesse;}
			set{_vitesse = value;}
		}

		private int _maniabilite;
		[Column(Storage = "Maniabilite",Name = "maniabilite")]
		public int Maniabilite{
			get{ return _maniabilite;}
			set{_maniabilite = value;}
		}

		private int _defenseAvant;
		[Column(Storage = "DefenseAvant",Name = "defenseavant")]
		public int DefenseAvant{
			get{ return _defenseAvant;}
			set{_defenseAvant = value;}
		}

		private int _defenseArriere;
		[Column(Storage = "DefenseArriere",Name = "defensearriere")]
		public int DefenseArriere{
			get{ return _defenseArriere;}
			set{_defenseArriere = value;}
		}

		private int? _defenseBabord;
		[Column(Storage = "DefenseBabord",Name = "defensebabord")]
		public int? DefenseBabord{
			get{ return _defenseBabord;}
			set{_defenseBabord = value;}
		}

		private int? _defenseTribord;
		[Column(Storage = "DefenseTribord",Name = "defensetribord")]
		public int? DefenseTribord{
			get{ return _defenseTribord;}
			set{_defenseTribord = value;}
		}

		private int _blindage;
		[Column(Storage = "Blindage",Name = "blindage")]
		public int Blindage{
			get{ return _blindage;}
			set{_blindage = value;}
		}

		private int _seuilDommage;
		[Column(Storage = "SeuilDommage",Name = "seuildommage")]
		public int SeuilDommage{
			get{ return _seuilDommage;}
			set{_seuilDommage = value;}
		}

		private int _seuilStressMecanique;
		[Column(Storage = "SeuilStressMecanique",Name = "seuilstressmecanique")]
		public int SeuilStressMecanique{
			get{ return _seuilStressMecanique;}
			set{_seuilStressMecanique = value;}
		}

		private TypeVehicule _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeVehicule Type{
			get{ return _type;}
			set{_type = value;}
		}

		private string _modele;
		[Column(Storage = "Modele",Name = "modele")]
		public string Modele{
			get{ return _modele;}
			set{_modele = value;}
		}

		private string _constructeur;
		[Column(Storage = "Constructeur",Name = "constructeur")]
		public string Constructeur{
			get{ return _constructeur;}
			set{_constructeur = value;}
		}

		private Portee _porteeSenseurs;
		[Column(Storage = "PorteeSenseurs",Name = "porteesenseurs")]
		public Portee PorteeSenseurs{
			get{ return _porteeSenseurs;}
			set{_porteeSenseurs = value;}
		}

		[Column(Name="chargeutile_min", Storage="ChargeUtileMin")]
		[HiddenProperty]
		public int ChargeUtileMin{
			get{
				return ChargeUtile.Min;
			}
			set{
				ChargeUtile.Min = value;
			}
		}

		[Column(Name="chargeutile_max", Storage="ChargeUtileMax")]
		[HiddenProperty]
		public int ChargeUtileMax{
			get{
				return ChargeUtile.Max;
			}
			set{
				ChargeUtile.Max = value;
			}
		}

		private Range _chargeUtile = new Range();
		public Range ChargeUtile{
			get{
				return _chargeUtile;
			}
			set{
				_chargeUtile = value;
			}
		}



		[Column(Name = "provisions_val", Storage="ProvisionsVal")]
		[HiddenProperty]
		public int ProvisionsVal{
			get{
				return Provisions.Value;
			}
			set{
				Provisions.Value = value;
			}
		}

		[Column(Name = "provisions_unit", Storage="ProvisionsUnit")]
		[HiddenProperty]
		public TimeUnity ProvisionsUnit{
			get{
				return Provisions.Unity;
			}
			set{
				Provisions.Unity = value;
			}
		}

		private TimePeriod _provisions = new TimePeriod();
		public TimePeriod Provisions{
			get{
				return _provisions;
			}
			set{
				_provisions = value;
			}
		}



		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}

		private int _rarete;
		[Column(Storage = "Rarete",Name = "rarete")]
		public int Rarete{
			get{ return _rarete;}
			set{_rarete = value;}
		}

		private bool _interdit;
		[Column(Storage = "Interdit",Name = "interdit")]
		public bool Interdit{
			get{ return _interdit;}
			set{_interdit = value;}
		}

		private int _emplacements;
		[Column(Storage = "Emplacements",Name = "emplacements")]
		public int Emplacements{
			get{ return _emplacements;}
			set{_emplacements = value;}
		}

		private IEnumerable<VehiculeModelToArmeDeVehiculeExemplar> _armement;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armement",OtherKey = "VehiculeModelId")]
		public IEnumerable <VehiculeModelToArmeDeVehiculeExemplar> Armement{
			get{
				if( _armement == null ){
					_armement = LoadByForeignKey<VehiculeModelToArmeDeVehiculeExemplar>(p => p.VehiculeModelId, Id);
				}
				return _armement;
			}
			set{
				foreach( VehiculeModelToArmeDeVehiculeExemplar item in _armement ){
					item.VehiculeModel = null;
				}
				_armement = value;
				foreach( VehiculeModelToArmeDeVehiculeExemplar item in value ){
					item.VehiculeModel = this;
				}
			}
		}

		private IEnumerable<VehiculeModelToEquipageExemplar> _equipage;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Equipage",OtherKey = "VehiculeModelId")]
		public IEnumerable <VehiculeModelToEquipageExemplar> Equipage{
			get{
				if( _equipage == null ){
					_equipage = LoadByForeignKey<VehiculeModelToEquipageExemplar>(p => p.VehiculeModelId, Id);
				}
				return _equipage;
			}
			set{
				foreach( VehiculeModelToEquipageExemplar item in _equipage ){
					item.VehiculeModel = null;
				}
				_equipage = value;
				foreach( VehiculeModelToEquipageExemplar item in value ){
					item.VehiculeModel = this;
				}
			}
		}
	}
	[Table(Schema = "starwars",Name = "vehiculedescription")]
	public partial class VehiculeDescription : DataDescription<VehiculeModel> {
	}
	[Table(Schema = "starwars",Name = "vehiculeexemplar")]
	public partial class VehiculeExemplar : DataExemplaire<VehiculeModel> {
	}
}
