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
	[Table(Schema = "pathfinder",Name = "sortmodel")]
	[CoreData]
	public partial class SortModel : DataModel {

		private SortDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SortDescription> id = GetModelReferencer<SortDescription>();
					if(id.Count() == 0) {
						_obj = new SortDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<ListeSortClasseModel> _classes;
		public IEnumerable <ListeSortClasseModel> Classes{
			get{
				if( _classes == null ){
					_classes = LoadByForeignKey<ListeSortClasseModel>(p => p.SortId, Id);
				}
				return _classes;
			}
			set{
				foreach( ListeSortClasseModel item in _classes ){
					item.Sort = null;

				}
				_classes = value;
				foreach( ListeSortClasseModel item in value ){
					item.Sort = this;
					item.SaveObject();
				}
			}
		}

		private EcoleMagie _ecole;
		[Column(Storage = "Ecole",Name = "ecole")]
		public EcoleMagie Ecole{
			get{ return _ecole;}
			set{_ecole = value;}
		}

		private BrancheMagie _branche;
		[Column(Storage = "Branche",Name = "branche")]
		public BrancheMagie Branche{
			get{ return _branche;}
			set{_branche = value;}
		}


		private IEnumerable < int > _registres;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Registres",OtherKey = "SortModel")]
		public IEnumerable < int > Registres{
			get{
				if( _registres == null ){
					_registres = LoadFromDataValue<RegistresFromSortModel, int>();
				}
				return _registres;
			}
			set{
				SaveDataValue<RegistresFromSortModel, int>(_registres, value);
			}
		}

		private Sauvegarde? _testSauvegarde;
		[Column(Storage = "TestSauvegarde",Name = "testsauvegarde")]
		public Sauvegarde? TestSauvegarde{
			get{ return _testSauvegarde;}
			set{_testSauvegarde = value;}
		}

		private EffetSauvegarde _typeTestSauvegarde;
		[Column(Storage = "TypeTestSauvegarde",Name = "typetestsauvegarde")]
		public EffetSauvegarde TypeTestSauvegarde{
			get{ return _typeTestSauvegarde;}
			set{_typeTestSauvegarde = value;}
		}

		private bool _rM;
		[Column(Storage = "RM",Name = "rm")]
		public bool RM{
			get{ return _rM;}
			set{_rM = value;}
		}

		private bool _compVerbale;
		[Column(Storage = "CompVerbale",Name = "compverbale")]
		public bool CompVerbale{
			get{ return _compVerbale;}
			set{_compVerbale = value;}
		}

		private bool _compGestuelle;
		[Column(Storage = "CompGestuelle",Name = "compgestuelle")]
		public bool CompGestuelle{
			get{ return _compGestuelle;}
			set{_compGestuelle = value;}
		}

		private bool _compFocalisateurDivin;
		[Column(Storage = "CompFocalisateurDivin",Name = "compfocalisateurdivin")]
		public bool CompFocalisateurDivin{
			get{ return _compFocalisateurDivin;}
			set{_compFocalisateurDivin = value;}
		}

		private int _compMaterielleId;
		[Column(Storage = "CompMaterielleId",Name = "fk_composantematerielle_compmaterielle")]
		[HiddenProperty]
		public int CompMaterielleId{
			get{ return _compMaterielleId;}
			set{_compMaterielleId = value;}
		}

		private ComposanteMaterielle _compMaterielle;
		public ComposanteMaterielle CompMaterielle{
			get {
				if(_compMaterielle == null) {
					_compMaterielle = LoadById<ComposanteMaterielle>(CompMaterielleId);
			       }
				return _compMaterielle;
			} set {
				if(value == _compMaterielle) { return; }
				_compMaterielle = value;
				if(_compMaterielle != null) {
					_compMaterielleId = _compMaterielle.Id;
				} else {
					_compMaterielleId = 0;
				}
			}
		}

		private int _compFocalisateurId;
		[Column(Storage = "CompFocalisateurId",Name = "fk_composantefocalisateur_compfocalisateur")]
		[HiddenProperty]
		public int CompFocalisateurId{
			get{ return _compFocalisateurId;}
			set{_compFocalisateurId = value;}
		}

		private ComposanteFocalisateur _compFocalisateur;
		public ComposanteFocalisateur CompFocalisateur{
			get {
				if(_compFocalisateur == null) {
					_compFocalisateur = LoadById<ComposanteFocalisateur>(CompFocalisateurId);
			       }
				return _compFocalisateur;
			} set {
				if(value == _compFocalisateur) { return; }
				_compFocalisateur = value;
				if(_compFocalisateur != null) {
					_compFocalisateurId = _compFocalisateur.Id;
				} else {
					_compFocalisateurId = 0;
				}
			}
		}

		private TempsIncantation _tempsIncantation;
		[Column(Storage = "TempsIncantation",Name = "tempsincantation")]
		public TempsIncantation TempsIncantation{
			get{ return _tempsIncantation;}
			set{_tempsIncantation = value;}
		}

		private int _facteurTempsIncantation;
		[Column(Storage = "FacteurTempsIncantation",Name = "facteurtempsincantation")]
		public int FacteurTempsIncantation{
			get{ return _facteurTempsIncantation;}
			set{_facteurTempsIncantation = value;}
		}

		private PorteeSort _portee;
		[Column(Storage = "Portee",Name = "portee")]
		public PorteeSort Portee{
			get{ return _portee;}
			set{_portee = value;}
		}

		private int _facteurPortee;
		[Column(Storage = "FacteurPortee",Name = "facteurportee")]
		public int FacteurPortee{
			get{ return _facteurPortee;}
			set{_facteurPortee = value;}
		}

		private CibleSort _cibles;
		[Column(Storage = "Cibles",Name = "cibles")]
		public CibleSort Cibles{
			get{ return _cibles;}
			set{_cibles = value;}
		}

		private int _facteurCible;
		[Column(Storage = "FacteurCible",Name = "facteurcible")]
		public int FacteurCible{
			get{ return _facteurCible;}
			set{_facteurCible = value;}
		}

		private bool _facteurCiblerParNiveau;
		[Column(Storage = "FacteurCiblerParNiveau",Name = "facteurciblerparniveau")]
		public bool FacteurCiblerParNiveau{
			get{ return _facteurCiblerParNiveau;}
			set{_facteurCiblerParNiveau = value;}
		}

		private EffetKeyWord? _effetType;
		[Column(Storage = "EffetType",Name = "effettype")]
		public EffetKeyWord? EffetType{
			get{ return _effetType;}
			set{_effetType = value;}
		}

		private int _facteurEffet;
		[Column(Storage = "FacteurEffet",Name = "facteureffet")]
		public int FacteurEffet{
			get{ return _facteurEffet;}
			set{_facteurEffet = value;}
		}

		private bool _facteurEffetParNiveau;
		[Column(Storage = "FacteurEffetParNiveau",Name = "facteureffetparniveau")]
		public bool FacteurEffetParNiveau{
			get{ return _facteurEffetParNiveau;}
			set{_facteurEffetParNiveau = value;}
		}

		private bool _faconnable;
		[Column(Storage = "Faconnable",Name = "faconnable")]
		public bool Faconnable{
			get{ return _faconnable;}
			set{_faconnable = value;}
		}

		private string _descriptionCibles = "";
		[Column(Storage = "DescriptionCibles",Name = "descriptioncibles")]
		public string DescriptionCibles{
			get{ return _descriptionCibles;}
			set{_descriptionCibles = value;}
		}

		private string _descriptionZoneEffet = "";
		[Column(Storage = "DescriptionZoneEffet",Name = "descriptionzoneeffet")]
		public string DescriptionZoneEffet{
			get{ return _descriptionZoneEffet;}
			set{_descriptionZoneEffet = value;}
		}

		private DureeSort _duree;
		[Column(Storage = "Duree",Name = "duree")]
		public DureeSort Duree{
			get{ return _duree;}
			set{_duree = value;}
		}

		private int _facteurDuree;
		[Column(Storage = "FacteurDuree",Name = "facteurduree")]
		public int FacteurDuree{
			get{ return _facteurDuree;}
			set{_facteurDuree = value;}
		}

		private bool _terminaison;
		[Column(Storage = "Terminaison",Name = "terminaison")]
		public bool Terminaison{
			get{ return _terminaison;}
			set{_terminaison = value;}
		}

		private bool _facteurParNiveau;
		[Column(Storage = "FacteurParNiveau",Name = "facteurparniveau")]
		public bool FacteurParNiveau{
			get{ return _facteurParNiveau;}
			set{_facteurParNiveau = value;}
		}

		private string _dureePrecision;
		[Column(Storage = "DureePrecision",Name = "dureeprecision")]
		public string DureePrecision{
			get{ return _dureePrecision;}
			set{_dureePrecision = value;}
		}
		public override void DeleteObject() {
			DeleteDataValue<RegistresFromSortModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "sortdescription")]
	public partial class SortDescription : DataDescription<SortModel> {

		private string _descriptionCourte = "";
		[LargeText]
		[Column(Storage = "DescriptionCourte",Name = "descriptioncourte")]
		public string DescriptionCourte{
			get{ return _descriptionCourte;}
			set{_descriptionCourte = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "sortexemplar")]
	public partial class SortExemplar : DataExemplaire<SortModel> {

		private bool _pouvoirMagique;
		[Column(Storage = "PouvoirMagique",Name = "pouvoirmagique")]
		public bool PouvoirMagique{
			get{ return _pouvoirMagique;}
			set{_pouvoirMagique = value;}
		}

		private FrequencePouvoirMagique _frequence;
		[Column(Storage = "Frequence",Name = "frequence")]
		public FrequencePouvoirMagique Frequence{
			get{ return _frequence;}
			set{_frequence = value;}
		}

		private int _niveauEmpacement;
		[Column(Storage = "NiveauEmpacement",Name = "niveauempacement")]
		public int NiveauEmpacement{
			get{ return _niveauEmpacement;}
			set{_niveauEmpacement = value;}
		}

		private int _classeId;
		[Column(Storage = "ClasseId",Name = "fk_classemodel_classe")]
		[HiddenProperty]
		public int ClasseId{
			get{ return _classeId;}
			set{_classeId = value;}
		}

		private ClasseModel _classe;
		public ClasseModel Classe{
			get{
				if( _classe == null)
					_classe = LoadById<ClasseModel>(ClasseId);
				return _classe;
			} set {
				if(_classe == value){return;}
				_classe = value;
				if( value != null)
					ClasseId = value.Id;
			}
		}

		private int _nombreUtilisations;
		[Column(Storage = "NombreUtilisations",Name = "nombreutilisations")]
		public int NombreUtilisations{
			get{ return _nombreUtilisations;}
			set{_nombreUtilisations = value;}
		}

		private IEnumerable<DonModel> _metamagie;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Metamagie",OtherKey = "SortExemplarId")]
		public IEnumerable <DonModel> Metamagie{
			get{
				if( _metamagie == null ){
					_metamagie = LoadFromJointure<DonModel,SortExemplarToDonModel_Metamagie>(false);
				}
				return _metamagie;
			}
			set{
				SaveToJointure<DonModel, SortExemplarToDonModel_Metamagie> (_metamagie, value,false);
				_metamagie = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<SortExemplar,SortExemplarToDonModel_Metamagie>(true);
			base.DeleteObject();
		}
	}
}
