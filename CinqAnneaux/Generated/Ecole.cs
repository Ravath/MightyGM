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
	[Table(Schema = "cinqanneaux",Name = "ecolemodel")]
	[CoreData]
	public partial class EcoleModel : DataModel {

		private EcoleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EcoleDescription> id = GetModelReferencer<EcoleDescription>();
					if(id.Count() == 0) {
						_obj = new EcoleDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
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
			get {
				if(_clan == null) {
					_clan = LoadById<ClanModel>(ClanId);
			       }
				return _clan;
			} set {
				if(value == _clan) { return; }
				_clan = value;
				if(_clan != null) {
					_clanId = _clan.Id;
				} else {
					_clanId = 0;
				}
			}
		}

		private MotClefEcole _motClef;
		[Column(Storage = "MotClef",Name = "motclef")]
		public MotClefEcole MotClef{
			get{ return _motClef;}
			set{_motClef = value;}
		}

		private TraitCompetence _bonusInitial;
		[Column(Storage = "BonusInitial",Name = "bonusinitial")]
		public TraitCompetence BonusInitial{
			get{ return _bonusInitial;}
			set{_bonusInitial = value;}
		}

		private decimal _honneur;
		[Column(Storage = "Honneur",Name = "honneur")]
		public decimal Honneur{
			get{ return _honneur;}
			set{_honneur = value;}
		}

		private decimal _argentInitial;
		[Column(Storage = "ArgentInitial",Name = "argentinitial")]
		public decimal ArgentInitial{
			get{ return _argentInitial;}
			set{_argentInitial = value;}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "EcoleModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,EcoleModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, EcoleModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private IEnumerable<AbsObjetModel> _equipement;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Equipement",OtherKey = "EcoleModelId")]
		public IEnumerable <AbsObjetModel> Equipement{
			get{
				if( _equipement == null ){
					_equipement = LoadFromJointure<AbsObjetModel,EcoleModelToAbsObjetModel_Equipement>(false);
				}
				return _equipement;
			}
			set{
				SaveToJointure<AbsObjetModel, EcoleModelToAbsObjetModel_Equipement> (_equipement, value,false);
				_equipement = value;
			}
		}

		private IEnumerable<TechniqueModel> _techniques;
		public IEnumerable <TechniqueModel> Techniques{
			get{
				if( _techniques == null ){
					_techniques = LoadByForeignKey<TechniqueModel>(p => p.EcoleId, Id);
				}
				return _techniques;
			}
			set{
				foreach( TechniqueModel item in _techniques ){
					item.Ecole = null;

				}
				_techniques = value;
				foreach( TechniqueModel item in value ){
					item.Ecole = this;
					item.SaveObject();
				}
			}
		}

		private Affinite? _affinite;
		[Column(Storage = "Affinite",Name = "affinite")]
		public Affinite? Affinite{
			get{ return _affinite;}
			set{_affinite = value;}
		}

		private Affinite? _deficience;
		[Column(Storage = "Deficience",Name = "deficience")]
		public Affinite? Deficience{
			get{ return _deficience;}
			set{_deficience = value;}
		}

		private int? _nbrSortTerre;
		[Column(Storage = "NbrSortTerre",Name = "nbrsortterre")]
		public int? NbrSortTerre{
			get{ return _nbrSortTerre;}
			set{_nbrSortTerre = value;}
		}

		private int? _nbrSortFeu;
		[Column(Storage = "NbrSortFeu",Name = "nbrsortfeu")]
		public int? NbrSortFeu{
			get{ return _nbrSortFeu;}
			set{_nbrSortFeu = value;}
		}

		private int? _nbrSortEau;
		[Column(Storage = "NbrSortEau",Name = "nbrsorteau")]
		public int? NbrSortEau{
			get{ return _nbrSortEau;}
			set{_nbrSortEau = value;}
		}

		private int? _nbrSortAir;
		[Column(Storage = "NbrSortAir",Name = "nbrsortair")]
		public int? NbrSortAir{
			get{ return _nbrSortAir;}
			set{_nbrSortAir = value;}
		}

		private int? _nbrSortVide;
		[Column(Storage = "NbrSortVide",Name = "nbrsortvide")]
		public int? NbrSortVide{
			get{ return _nbrSortVide;}
			set{_nbrSortVide = value;}
		}

		private Devotion? _devotion;
		[Column(Storage = "Devotion",Name = "devotion")]
		public Devotion? Devotion{
			get{ return _devotion;}
			set{_devotion = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<EcoleModel,EcoleModelToCompetenceExemplar_Competences>(true);
			DeleteJoins<EcoleModel,EcoleModelToAbsObjetModel_Equipement>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecoledescription")]
	public partial class EcoleDescription : DataDescription<EcoleModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "ecoleexemplar")]
	public partial class EcoleExemplar : DataExemplaire<EcoleModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
