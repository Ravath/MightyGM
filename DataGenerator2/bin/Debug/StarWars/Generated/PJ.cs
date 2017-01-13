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
	[Table(Schema = "starwars",Name = "pjmodel")]
	[CoreData]
	public partial class PJModel : PersonnageModel {

		private PJDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PJDescription> id = GetModelReferencer<PJDescription>();
					if(id.Count() == 0) {
						_obj = new PJDescription();
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

		private int _joueurId;
		[Column(Storage = "JoueurId",Name = "fk_joueur")]
		[HiddenProperty]
		public int JoueurId{
			get{ return _joueurId;}
			set{_joueurId = value;}
		}

		private Joueur _joueur;
		public Joueur Joueur{
			get {
				if(_joueur == null) {
					_joueur = LoadById<Joueur>(JoueurId);
			       }
				return _joueur;
			} set {
				if(value == _joueur) { return; }
				_joueur = value;
				if(_joueur != null) {
					_joueurId = _joueur.Id;
				} else {
					_joueurId = 0;
				}
			}
		}

		private int _raceId;
		[Column(Storage = "RaceId",Name = "fk_racemodel")]
		[HiddenProperty]
		public int RaceId{
			get{ return _raceId;}
			set{_raceId = value;}
		}

		private RaceModel _race;
		public RaceModel Race{
			get{
				if( _race == null)
					_race = LoadById<RaceModel>(RaceId);
				return _race;
			} set {
				if(_race == value){return;}
				_race = value;
				if( value != null)
					RaceId = value.Id;
			}
		}

		private int _carrierePrincipaleId;
		[Column(Storage = "CarrierePrincipaleId",Name = "fk_carrieremodel")]
		[HiddenProperty]
		public int CarrierePrincipaleId{
			get{ return _carrierePrincipaleId;}
			set{_carrierePrincipaleId = value;}
		}

		private CarriereModel _carrierePrincipale;
		public CarriereModel CarrierePrincipale{
			get{
				if( _carrierePrincipale == null)
					_carrierePrincipale = LoadById<CarriereModel>(CarrierePrincipaleId);
				return _carrierePrincipale;
			} set {
				if(_carrierePrincipale == value){return;}
				_carrierePrincipale = value;
				if( value != null)
					CarrierePrincipaleId = value.Id;
			}
		}

		private int _specialitePrincipaleId;
		[Column(Storage = "SpecialitePrincipaleId",Name = "fk_specialitemodel")]
		[HiddenProperty]
		public int SpecialitePrincipaleId{
			get{ return _specialitePrincipaleId;}
			set{_specialitePrincipaleId = value;}
		}

		private SpecialiteModel _specialitePrincipale;
		public SpecialiteModel SpecialitePrincipale{
			get{
				if( _specialitePrincipale == null)
					_specialitePrincipale = LoadById<SpecialiteModel>(SpecialitePrincipaleId);
				return _specialitePrincipale;
			} set {
				if(_specialitePrincipale == value){return;}
				_specialitePrincipale = value;
				if( value != null)
					SpecialitePrincipaleId = value.Id;
			}
		}

		private IEnumerable<CarriereModel> _carriereSecondaires;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "CarriereSecondaires",OtherKey = "PJModelId")]
		public IEnumerable <CarriereModel> CarriereSecondaires{
			get{
				if( _carriereSecondaires == null ){
					_carriereSecondaires = LoadFromJointure<CarriereModel,PJModelToCarriereModel>(false);
				}
				return _carriereSecondaires;
			}
			set{
				SaveToJointure<CarriereModel, PJModelToCarriereModel> (_carriereSecondaires, value,false);
				_carriereSecondaires = value;
			}
		}

		private IEnumerable<SpecialiteModel> _specialiteSecondaires;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SpecialiteSecondaires",OtherKey = "PJModelId")]
		public IEnumerable <SpecialiteModel> SpecialiteSecondaires{
			get{
				if( _specialiteSecondaires == null ){
					_specialiteSecondaires = LoadFromJointure<SpecialiteModel,PJModelToSpecialiteModel>(false);
				}
				return _specialiteSecondaires;
			}
			set{
				SaveToJointure<SpecialiteModel, PJModelToSpecialiteModel> (_specialiteSecondaires, value,false);
				_specialiteSecondaires = value;
			}
		}

		private IEnumerable<ObligationsExemplar> _obligations;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Obligations",OtherKey = "PJModelId")]
		public IEnumerable <ObligationsExemplar> Obligations{
			get{
				if( _obligations == null ){
					_obligations = LoadFromJointure<ObligationsExemplar,PJModelToObligationsExemplar>(false);
				}
				return _obligations;
			}
			set{
				SaveToJointure<ObligationsExemplar, PJModelToObligationsExemplar> (_obligations, value,false);
				_obligations = value;
			}
		}

		private int _credits;
		[Column(Storage = "Credits",Name = "credits")]
		public int Credits{
			get{ return _credits;}
			set{_credits = value;}
		}

		private int _totalXp;
		[Column(Storage = "TotalXp",Name = "totalxp")]
		public int TotalXp{
			get{ return _totalXp;}
			set{_totalXp = value;}
		}

		private int _xpDepense;
		[Column(Storage = "XpDepense",Name = "xpdepense")]
		public int XpDepense{
			get{ return _xpDepense;}
			set{_xpDepense = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<PJModel,PJModelToCarriereModel>(true);
			DeleteJoins<PJModel,PJModelToSpecialiteModel>(true);
			DeleteJoins<PJModel,PJModelToObligationsExemplar>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "starwars",Name = "pjdescription")]
	public partial class PJDescription : PersonnageDescription {

		private bool _sexeMasculin;
		[Column(Storage = "SexeMasculin",Name = "sexemasculin")]
		public bool SexeMasculin{
			get{ return _sexeMasculin;}
			set{_sexeMasculin = value;}
		}

		private int _age;
		[Column(Storage = "Age",Name = "age")]
		public int Age{
			get{ return _age;}
			set{_age = value;}
		}

		private int _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public int Taille{
			get{ return _taille;}
			set{_taille = value;}
		}

		private string _carrure = "";
		[Column(Storage = "Carrure",Name = "carrure")]
		public string Carrure{
			get{ return _carrure;}
			set{_carrure = value;}
		}

		private string _cheveux = "";
		[Column(Storage = "Cheveux",Name = "cheveux")]
		public string Cheveux{
			get{ return _cheveux;}
			set{_cheveux = value;}
		}

		private string _yeux = "";
		[Column(Storage = "Yeux",Name = "yeux")]
		public string Yeux{
			get{ return _yeux;}
			set{_yeux = value;}
		}


		private IEnumerable < string > _signesParticuliers;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "SignesParticuliers",OtherKey = "PJDescription")]
		public IEnumerable < string > SignesParticuliers{
			get{
				if( _signesParticuliers == null ){
					_signesParticuliers = LoadFromDataValue<SignesParticuliersFromPJDescription, string>();
				}
				return _signesParticuliers;
			}
			set{
				SaveDataValue<SignesParticuliersFromPJDescription, string>(_signesParticuliers, value);
			}
		}
		public override void DeleteObject() {
			DeleteDataValue<SignesParticuliersFromPJDescription>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "starwars",Name = "pjexemplar")]
	public partial class PJExemplar : PersonnageExemplar {
	}
}
