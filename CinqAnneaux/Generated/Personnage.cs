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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "personnagemodel")]
	public abstract partial class PersonnageModel : DataModel {

		private int _reflexes;
		[Column(Storage = "Reflexes",Name = "reflexes")]
		public int Reflexes{
			get{ return _reflexes;}
			set{_reflexes = value;}
		}

		private int _intuition;
		[Column(Storage = "Intuition",Name = "intuition")]
		public int Intuition{
			get{ return _intuition;}
			set{_intuition = value;}
		}

		private int _agilite;
		[Column(Storage = "Agilite",Name = "agilite")]
		public int Agilite{
			get{ return _agilite;}
			set{_agilite = value;}
		}

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _perception;
		[Column(Storage = "Perception",Name = "perception")]
		public int Perception{
			get{ return _perception;}
			set{_perception = value;}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int _volonte;
		[Column(Storage = "Volonte",Name = "volonte")]
		public int Volonte{
			get{ return _volonte;}
			set{_volonte = value;}
		}

		private int _constitution;
		[Column(Storage = "Constitution",Name = "constitution")]
		public int Constitution{
			get{ return _constitution;}
			set{_constitution = value;}
		}

		private int? _vide;
		[Column(Storage = "Vide",Name = "vide")]
		public int? Vide{
			get{ return _vide;}
			set{_vide = value;}
		}

		private decimal _status;
		[Column(Storage = "Status",Name = "status")]
		public decimal Status{
			get{ return _status;}
			set{_status = value;}
		}

		private decimal _honneur;
		[Column(Storage = "Honneur",Name = "honneur")]
		public decimal Honneur{
			get{ return _honneur;}
			set{_honneur = value;}
		}

		private decimal _gloire;
		[Column(Storage = "Gloire",Name = "gloire")]
		public decimal Gloire{
			get{ return _gloire;}
			set{_gloire = value;}
		}

		private decimal _infamie;
		[Column(Storage = "Infamie",Name = "infamie")]
		public decimal Infamie{
			get{ return _infamie;}
			set{_infamie = value;}
		}

		private decimal? _souillure;
		[Column(Storage = "Souillure",Name = "souillure")]
		public decimal? Souillure{
			get{ return _souillure;}
			set{_souillure = value;}
		}

		private int _clanId;
		[Column(Storage = "ClanId",Name = "fk_clanmodel_clan")]
		[HiddenProperty]
		public int ClanId{
			get{ return _clanId;}
			set{_clanId = value;}
		}

		private ClanModel _clan;
		public ClanModel Clan{
			get{
				if( _clan == null)
					_clan = LoadById<ClanModel>(ClanId);
				return _clan;
			} set {
				if(_clan == value){return;}
				_clan = value;
				if( value != null)
					ClanId = value.Id;
			}
		}

		private int _familleId;
		[Column(Storage = "FamilleId",Name = "fk_famillemodel_famille")]
		[HiddenProperty]
		public int FamilleId{
			get{ return _familleId;}
			set{_familleId = value;}
		}

		private FamilleModel _famille;
		public FamilleModel Famille{
			get{
				if( _famille == null)
					_famille = LoadById<FamilleModel>(FamilleId);
				return _famille;
			} set {
				if(_famille == value){return;}
				_famille = value;
				if( value != null)
					FamilleId = value.Id;
			}
		}

		private int _ancetreId;
		[Column(Storage = "AncetreId",Name = "fk_ancetremodel_ancetre")]
		[HiddenProperty]
		public int AncetreId{
			get{ return _ancetreId;}
			set{_ancetreId = value;}
		}

		private AncetreModel _ancetre;
		public AncetreModel Ancetre{
			get{
				if( _ancetre == null)
					_ancetre = LoadById<AncetreModel>(AncetreId);
				return _ancetre;
			} set {
				if(_ancetre == value){return;}
				_ancetre = value;
				if( value != null)
					AncetreId = value.Id;
			}
		}

		private IEnumerable<AvantageExemplar> _avantages;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Avantages",OtherKey = "PersonnageModelId")]
		public IEnumerable <AvantageExemplar> Avantages{
			get{
				if( _avantages == null ){
					_avantages = LoadFromJointure<AvantageExemplar,PersonnageModelToAvantageExemplar_Avantages>(false);
				}
				return _avantages;
			}
			set{
				SaveToJointure<AvantageExemplar, PersonnageModelToAvantageExemplar_Avantages> (_avantages, value,false);
				_avantages = value;
			}
		}

		private IEnumerable<DesavantageExemplar> _desavantages;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Desavantages",OtherKey = "PersonnageModelId")]
		public IEnumerable <DesavantageExemplar> Desavantages{
			get{
				if( _desavantages == null ){
					_desavantages = LoadFromJointure<DesavantageExemplar,PersonnageModelToDesavantageExemplar_Desavantages>(false);
				}
				return _desavantages;
			}
			set{
				SaveToJointure<DesavantageExemplar, PersonnageModelToDesavantageExemplar_Desavantages> (_desavantages, value,false);
				_desavantages = value;
			}
		}

		private IEnumerable<EcoleExemplar> _ecoles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Ecoles",OtherKey = "PersonnageModelId")]
		public IEnumerable <EcoleExemplar> Ecoles{
			get{
				if( _ecoles == null ){
					_ecoles = LoadFromJointure<EcoleExemplar,PersonnageModelToEcoleExemplar_Ecoles>(false);
				}
				return _ecoles;
			}
			set{
				SaveToJointure<EcoleExemplar, PersonnageModelToEcoleExemplar_Ecoles> (_ecoles, value,false);
				_ecoles = value;
			}
		}

		private IEnumerable<EcoleAvanceeExemplar> _ecolesAvancees;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "EcolesAvancees",OtherKey = "PersonnageModelId")]
		public IEnumerable <EcoleAvanceeExemplar> EcolesAvancees{
			get{
				if( _ecolesAvancees == null ){
					_ecolesAvancees = LoadFromJointure<EcoleAvanceeExemplar,PersonnageModelToEcoleAvanceeExemplar_EcolesAvancees>(false);
				}
				return _ecolesAvancees;
			}
			set{
				SaveToJointure<EcoleAvanceeExemplar, PersonnageModelToEcoleAvanceeExemplar_EcolesAvancees> (_ecolesAvancees, value,false);
				_ecolesAvancees = value;
			}
		}

		private IEnumerable<VoieAlternativeExemplar> _voieAlternatives;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "VoieAlternatives",OtherKey = "PersonnageModelId")]
		public IEnumerable <VoieAlternativeExemplar> VoieAlternatives{
			get{
				if( _voieAlternatives == null ){
					_voieAlternatives = LoadFromJointure<VoieAlternativeExemplar,PersonnageModelToVoieAlternativeExemplar_VoieAlternatives>(false);
				}
				return _voieAlternatives;
			}
			set{
				SaveToJointure<VoieAlternativeExemplar, PersonnageModelToVoieAlternativeExemplar_VoieAlternatives> (_voieAlternatives, value,false);
				_voieAlternatives = value;
			}
		}

		private IEnumerable<SortModel> _sorts;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Sorts",OtherKey = "PersonnageModelId")]
		public IEnumerable <SortModel> Sorts{
			get{
				if( _sorts == null ){
					_sorts = LoadFromJointure<SortModel,PersonnageModelToSortModel_Sorts>(false);
				}
				return _sorts;
			}
			set{
				SaveToJointure<SortModel, PersonnageModelToSortModel_Sorts> (_sorts, value,false);
				_sorts = value;
			}
		}

		private IEnumerable<MahouModel> _mahou;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Mahou",OtherKey = "PersonnageModelId")]
		public IEnumerable <MahouModel> Mahou{
			get{
				if( _mahou == null ){
					_mahou = LoadFromJointure<MahouModel,PersonnageModelToMahouModel_Mahou>(false);
				}
				return _mahou;
			}
			set{
				SaveToJointure<MahouModel, PersonnageModelToMahouModel_Mahou> (_mahou, value,false);
				_mahou = value;
			}
		}

		private IEnumerable<KataExemplar> _katas;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Katas",OtherKey = "PersonnageModelId")]
		public IEnumerable <KataExemplar> Katas{
			get{
				if( _katas == null ){
					_katas = LoadFromJointure<KataExemplar,PersonnageModelToKataExemplar_Katas>(false);
				}
				return _katas;
			}
			set{
				SaveToJointure<KataExemplar, PersonnageModelToKataExemplar_Katas> (_katas, value,false);
				_katas = value;
			}
		}

		private IEnumerable<KihoExemplar> _kihos;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Kihos",OtherKey = "PersonnageModelId")]
		public IEnumerable <KihoExemplar> Kihos{
			get{
				if( _kihos == null ){
					_kihos = LoadFromJointure<KihoExemplar,PersonnageModelToKihoExemplar_Kihos>(false);
				}
				return _kihos;
			}
			set{
				SaveToJointure<KihoExemplar, PersonnageModelToKihoExemplar_Kihos> (_kihos, value,false);
				_kihos = value;
			}
		}

		private IEnumerable<PouvoirNaturelExemplar> _pouvoirs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Pouvoirs",OtherKey = "PersonnageModelId")]
		public IEnumerable <PouvoirNaturelExemplar> Pouvoirs{
			get{
				if( _pouvoirs == null ){
					_pouvoirs = LoadFromJointure<PouvoirNaturelExemplar,PersonnageModelToPouvoirNaturelExemplar_Pouvoirs>(false);
				}
				return _pouvoirs;
			}
			set{
				SaveToJointure<PouvoirNaturelExemplar, PersonnageModelToPouvoirNaturelExemplar_Pouvoirs> (_pouvoirs, value,false);
				_pouvoirs = value;
			}
		}

		private IEnumerable<ArmeExemplar> _armes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armes",OtherKey = "PersonnageModelId")]
		public IEnumerable <ArmeExemplar> Armes{
			get{
				if( _armes == null ){
					_armes = LoadFromJointure<ArmeExemplar,PersonnageModelToArmeExemplar_Armes>(false);
				}
				return _armes;
			}
			set{
				SaveToJointure<ArmeExemplar, PersonnageModelToArmeExemplar_Armes> (_armes, value,false);
				_armes = value;
			}
		}

		private int _armureId;
		[Column(Storage = "ArmureId",Name = "fk_armureexemplar_armure")]
		[HiddenProperty]
		public int ArmureId{
			get{ return _armureId;}
			set{_armureId = value;}
		}

		private ArmureExemplar _armure;
		public ArmureExemplar Armure{
			get{
				if( _armure == null)
					_armure = LoadById<ArmureExemplar>(ArmureId);
				return _armure;
			} set {
				if(_armure == value){return;}
				_armure = value;
				if( value != null)
					ArmureId = value.Id;
			}
		}

		private IEnumerable<ObjetExemplar> _inventaire;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Inventaire",OtherKey = "PersonnageModelId")]
		public IEnumerable <ObjetExemplar> Inventaire{
			get{
				if( _inventaire == null ){
					_inventaire = LoadFromJointure<ObjetExemplar,PersonnageModelToObjetExemplar_Inventaire>(false);
				}
				return _inventaire;
			}
			set{
				SaveToJointure<ObjetExemplar, PersonnageModelToObjetExemplar_Inventaire> (_inventaire, value,false);
				_inventaire = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageModel,PersonnageModelToAvantageExemplar_Avantages>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToDesavantageExemplar_Desavantages>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToEcoleExemplar_Ecoles>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToEcoleAvanceeExemplar_EcolesAvancees>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToVoieAlternativeExemplar_VoieAlternatives>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToSortModel_Sorts>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToMahouModel_Mahou>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToKataExemplar_Katas>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToKihoExemplar_Kihos>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToPouvoirNaturelExemplar_Pouvoirs>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmeExemplar_Armes>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToObjetExemplar_Inventaire>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "personnagedescription")]
	public abstract partial class PersonnageDescription : DataDescription<PersonnageModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "personnageexemplar")]
	public abstract partial class PersonnageExemplar : DataExemplaire<PersonnageModel> {

		private int _degatsSubis;
		[Column(Storage = "DegatsSubis",Name = "degatssubis")]
		public int DegatsSubis{
			get{ return _degatsSubis;}
			set{_degatsSubis = value;}
		}

		private int _depenseVide;
		[Column(Storage = "DepenseVide",Name = "depensevide")]
		public int DepenseVide{
			get{ return _depenseVide;}
			set{_depenseVide = value;}
		}
	}
}
