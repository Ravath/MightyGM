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
using Core.Gestion;
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "pjmodel")]
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
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _joueurId;
		[Column(Storage = "JoueurId",Name = "fk_joueur_id")]
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

		private int _vide;
		[Column(Storage = "Vide",Name = "vide")]
		public int Vide{
			get{ return _vide;}
			set{_vide = value;}
		}

		private IEnumerable<CompetenceExemplar> _armes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armes",OtherKey = "PJModelId")]
		public IEnumerable <CompetenceExemplar> Armes{
			get{
				if( _armes == null ){
					_armes = LoadFromJointure<CompetenceExemplar,PJModelToCompetenceExemplar_Armes>(false);
				}
				return _armes;
			}
			set{
				SaveToJointure<CompetenceExemplar, PJModelToCompetenceExemplar_Armes> (_armes, value,false);
				_armes = value;
			}
		}

		private int _armureId;
		[Column(Storage = "ArmureId",Name = "fk_competenceexemplar_armure")]
		[HiddenProperty]
		public int ArmureId{
			get{ return _armureId;}
			set{_armureId = value;}
		}

		private CompetenceExemplar _armure;
		public CompetenceExemplar Armure{
			get{
				if( _armure == null)
					_armure = LoadById<CompetenceExemplar>(ArmureId);
				return _armure;
			} set {
				if(_armure == value){return;}
				_armure = value;
				if( value != null)
					ArmureId = value.Id;
			}
		}

		private IEnumerable<ObjetExemplar> _inventaire;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Inventaire",OtherKey = "PJModelId")]
		public IEnumerable <ObjetExemplar> Inventaire{
			get{
				if( _inventaire == null ){
					_inventaire = LoadFromJointure<ObjetExemplar,PJModelToObjetExemplar_Inventaire>(false);
				}
				return _inventaire;
			}
			set{
				SaveToJointure<ObjetExemplar, PJModelToObjetExemplar_Inventaire> (_inventaire, value,false);
				_inventaire = value;
			}
		}

		private IEnumerable<EcoleExemplar> _ecoles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Ecoles",OtherKey = "PJModelId")]
		public IEnumerable <EcoleExemplar> Ecoles{
			get{
				if( _ecoles == null ){
					_ecoles = LoadFromJointure<EcoleExemplar,PJModelToEcoleExemplar_Ecoles>(false);
				}
				return _ecoles;
			}
			set{
				SaveToJointure<EcoleExemplar, PJModelToEcoleExemplar_Ecoles> (_ecoles, value,false);
				_ecoles = value;
			}
		}

		private IEnumerable<AvantageExemplar> _avantages;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Avantages",OtherKey = "PJModelId")]
		public IEnumerable <AvantageExemplar> Avantages{
			get{
				if( _avantages == null ){
					_avantages = LoadFromJointure<AvantageExemplar,PJModelToAvantageExemplar_Avantages>(false);
				}
				return _avantages;
			}
			set{
				SaveToJointure<AvantageExemplar, PJModelToAvantageExemplar_Avantages> (_avantages, value,false);
				_avantages = value;
			}
		}

		private IEnumerable<DesavantageExemplar> _desavantages;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Desavantages",OtherKey = "PJModelId")]
		public IEnumerable <DesavantageExemplar> Desavantages{
			get{
				if( _desavantages == null ){
					_desavantages = LoadFromJointure<DesavantageExemplar,PJModelToDesavantageExemplar_Desavantages>(false);
				}
				return _desavantages;
			}
			set{
				SaveToJointure<DesavantageExemplar, PJModelToDesavantageExemplar_Desavantages> (_desavantages, value,false);
				_desavantages = value;
			}
		}

		private IEnumerable<SortModel> _sorts;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Sorts",OtherKey = "PJModelId")]
		public IEnumerable <SortModel> Sorts{
			get{
				if( _sorts == null ){
					_sorts = LoadFromJointure<SortModel,PJModelToSortModel_Sorts>(false);
				}
				return _sorts;
			}
			set{
				SaveToJointure<SortModel, PJModelToSortModel_Sorts> (_sorts, value,false);
				_sorts = value;
			}
		}

		private IEnumerable<MahouModel> _mahou;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Mahou",OtherKey = "PJModelId")]
		public IEnumerable <MahouModel> Mahou{
			get{
				if( _mahou == null ){
					_mahou = LoadFromJointure<MahouModel,PJModelToMahouModel_Mahou>(false);
				}
				return _mahou;
			}
			set{
				SaveToJointure<MahouModel, PJModelToMahouModel_Mahou> (_mahou, value,false);
				_mahou = value;
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

		private IEnumerable<EcoleAvanceeExemplar> _ecolesAvancees;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "EcolesAvancees",OtherKey = "PJModelId")]
		public IEnumerable <EcoleAvanceeExemplar> EcolesAvancees{
			get{
				if( _ecolesAvancees == null ){
					_ecolesAvancees = LoadFromJointure<EcoleAvanceeExemplar,PJModelToEcoleAvanceeExemplar_EcolesAvancees>(false);
				}
				return _ecolesAvancees;
			}
			set{
				SaveToJointure<EcoleAvanceeExemplar, PJModelToEcoleAvanceeExemplar_EcolesAvancees> (_ecolesAvancees, value,false);
				_ecolesAvancees = value;
			}
		}

		private IEnumerable<VoieAlternativeExemplar> _voieAlternatives;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "VoieAlternatives",OtherKey = "PJModelId")]
		public IEnumerable <VoieAlternativeExemplar> VoieAlternatives{
			get{
				if( _voieAlternatives == null ){
					_voieAlternatives = LoadFromJointure<VoieAlternativeExemplar,PJModelToVoieAlternativeExemplar_VoieAlternatives>(false);
				}
				return _voieAlternatives;
			}
			set{
				SaveToJointure<VoieAlternativeExemplar, PJModelToVoieAlternativeExemplar_VoieAlternatives> (_voieAlternatives, value,false);
				_voieAlternatives = value;
			}
		}

		private IEnumerable<KataExemplar> _katas;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Katas",OtherKey = "PJModelId")]
		public IEnumerable <KataExemplar> Katas{
			get{
				if( _katas == null ){
					_katas = LoadFromJointure<KataExemplar,PJModelToKataExemplar_Katas>(false);
				}
				return _katas;
			}
			set{
				SaveToJointure<KataExemplar, PJModelToKataExemplar_Katas> (_katas, value,false);
				_katas = value;
			}
		}

		private IEnumerable<KihoExemplar> _kihos;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Kihos",OtherKey = "PJModelId")]
		public IEnumerable <KihoExemplar> Kihos{
			get{
				if( _kihos == null ){
					_kihos = LoadFromJointure<KihoExemplar,PJModelToKihoExemplar_Kihos>(false);
				}
				return _kihos;
			}
			set{
				SaveToJointure<KihoExemplar, PJModelToKihoExemplar_Kihos> (_kihos, value,false);
				_kihos = value;
			}
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
		public override void DeleteObject() {
			DeleteJoins<PJModel,PJModelToCompetenceExemplar_Armes>(true);
			DeleteJoins<PJModel,PJModelToObjetExemplar_Inventaire>(true);
			DeleteJoins<PJModel,PJModelToEcoleExemplar_Ecoles>(true);
			DeleteJoins<PJModel,PJModelToAvantageExemplar_Avantages>(true);
			DeleteJoins<PJModel,PJModelToDesavantageExemplar_Desavantages>(true);
			DeleteJoins<PJModel,PJModelToSortModel_Sorts>(true);
			DeleteJoins<PJModel,PJModelToMahouModel_Mahou>(true);
			DeleteJoins<PJModel,PJModelToEcoleAvanceeExemplar_EcolesAvancees>(true);
			DeleteJoins<PJModel,PJModelToVoieAlternativeExemplar_VoieAlternatives>(true);
			DeleteJoins<PJModel,PJModelToKataExemplar_Katas>(true);
			DeleteJoins<PJModel,PJModelToKihoExemplar_Kihos>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjdescription")]
	public partial class PJDescription : PersonnageDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "pjexemplar")]
	public partial class PJExemplar : PersonnageExemplar {

		private int _depenseVide;
		[Column(Storage = "DepenseVide",Name = "depensevide")]
		public int DepenseVide{
			get{ return _depenseVide;}
			set{_depenseVide = value;}
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
	}
}
