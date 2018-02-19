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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "monstremodel")]
	[CoreData]
	public partial class MonstreModel : DataModel {

		private MonstreDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MonstreDescription> id = GetModelReferencer<MonstreDescription>();
					if(id.Count() == 0) {
						_obj = new MonstreDescription();
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

		private int _typeId;
		[Column(Storage = "TypeId",Name = "fk_typecreaturemodel_type")]
		[HiddenProperty]
		public int TypeId{
			get{ return _typeId;}
			set{_typeId = value;}
		}

		private TypeCreatureModel _type;
		public TypeCreatureModel Type{
			get{
				if( _type == null)
					_type = LoadById<TypeCreatureModel>(TypeId);
				return _type;
			} set {
				if(_type == value){return;}
				_type = value;
				if( value != null)
					TypeId = value.Id;
			}
		}

		private IEnumerable<TypeCreatureModel> _sousType;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SousType",OtherKey = "MonstreModelId")]
		public IEnumerable <TypeCreatureModel> SousType{
			get{
				if( _sousType == null ){
					_sousType = LoadFromJointure<TypeCreatureModel,MonstreModelToTypeCreatureModel_SousType>(false);
				}
				return _sousType;
			}
			set{
				SaveToJointure<TypeCreatureModel, MonstreModelToTypeCreatureModel_SousType> (_sousType, value,false);
				_sousType = value;
			}
		}

		private CategorieTaille _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public CategorieTaille Taille{
			get{ return _taille;}
			set{_taille = value;}
		}

		private IEnumerable<Deplacement> _deplacements;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Deplacements",OtherKey = "MonstreModelId")]
		public IEnumerable <Deplacement> Deplacements{
			get{
				if( _deplacements == null ){
					_deplacements = LoadFromJointure<Deplacement,MonstreModelToDeplacement_Deplacements>(false);
				}
				return _deplacements;
			}
			set{
				SaveToJointure<Deplacement, MonstreModelToDeplacement_Deplacements> (_deplacements, value,false);
				_deplacements = value;
			}
		}

		private int _dV;
		[Column(Storage = "DV",Name = "dv")]
		public int DV{
			get{ return _dV;}
			set{_dV = value;}
		}

		private IEnumerable<ClasseExemplar> _classes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Classes",OtherKey = "MonstreModelId")]
		public IEnumerable <ClasseExemplar> Classes{
			get{
				if( _classes == null ){
					_classes = LoadFromJointure<ClasseExemplar,MonstreModelToClasseExemplar_Classes>(false);
				}
				return _classes;
			}
			set{
				SaveToJointure<ClasseExemplar, MonstreModelToClasseExemplar_Classes> (_classes, value,false);
				_classes = value;
			}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int _dexterite;
		[Column(Storage = "Dexterite",Name = "dexterite")]
		public int Dexterite{
			get{ return _dexterite;}
			set{_dexterite = value;}
		}

		private int _constitution;
		[Column(Storage = "Constitution",Name = "constitution")]
		public int Constitution{
			get{ return _constitution;}
			set{_constitution = value;}
		}

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _sagesse;
		[Column(Storage = "Sagesse",Name = "sagesse")]
		public int Sagesse{
			get{ return _sagesse;}
			set{_sagesse = value;}
		}

		private int _charisme;
		[Column(Storage = "Charisme",Name = "charisme")]
		public int Charisme{
			get{ return _charisme;}
			set{_charisme = value;}
		}

		private int _armureNaturelle;
		[Column(Storage = "ArmureNaturelle",Name = "armurenaturelle")]
		public int ArmureNaturelle{
			get{ return _armureNaturelle;}
			set{_armureNaturelle = value;}
		}

		private int _rM;
		[Column(Storage = "RM",Name = "rm")]
		public int RM{
			get{ return _rM;}
			set{_rM = value;}
		}

		private IEnumerable<ArmeNaturelleExemplar> _attaquesNaturelles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "AttaquesNaturelles",OtherKey = "MonstreModelId")]
		public IEnumerable <ArmeNaturelleExemplar> AttaquesNaturelles{
			get{
				if( _attaquesNaturelles == null ){
					_attaquesNaturelles = LoadFromJointure<ArmeNaturelleExemplar,MonstreModelToArmeNaturelleExemplar_AttaquesNaturelles>(false);
				}
				return _attaquesNaturelles;
			}
			set{
				SaveToJointure<ArmeNaturelleExemplar, MonstreModelToArmeNaturelleExemplar_AttaquesNaturelles> (_attaquesNaturelles, value,false);
				_attaquesNaturelles = value;
			}
		}

		private IEnumerable<ArmeExemplar> _armes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armes",OtherKey = "MonstreModelId")]
		public IEnumerable <ArmeExemplar> Armes{
			get{
				if( _armes == null ){
					_armes = LoadFromJointure<ArmeExemplar,MonstreModelToArmeExemplar_Armes>(false);
				}
				return _armes;
			}
			set{
				SaveToJointure<ArmeExemplar, MonstreModelToArmeExemplar_Armes> (_armes, value,false);
				_armes = value;
			}
		}

		private IEnumerable<ArmureExemplar> _armures;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armures",OtherKey = "MonstreModelId")]
		public IEnumerable <ArmureExemplar> Armures{
			get{
				if( _armures == null ){
					_armures = LoadFromJointure<ArmureExemplar,MonstreModelToArmureExemplar_Armures>(false);
				}
				return _armures;
			}
			set{
				SaveToJointure<ArmureExemplar, MonstreModelToArmureExemplar_Armures> (_armures, value,false);
				_armures = value;
			}
		}

		private IEnumerable<AttaqueSpecialeModel> _attaqueSpeciales;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "AttaqueSpeciales",OtherKey = "MonstreModelId")]
		public IEnumerable <AttaqueSpecialeModel> AttaqueSpeciales{
			get{
				if( _attaqueSpeciales == null ){
					_attaqueSpeciales = LoadFromJointure<AttaqueSpecialeModel,MonstreModelToAttaqueSpecialeModel_AttaqueSpeciales>(false);
				}
				return _attaqueSpeciales;
			}
			set{
				SaveToJointure<AttaqueSpecialeModel, MonstreModelToAttaqueSpecialeModel_AttaqueSpeciales> (_attaqueSpeciales, value,false);
				_attaqueSpeciales = value;
			}
		}

		private IEnumerable<ParticulariteModel> _particularites;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Particularites",OtherKey = "MonstreModelId")]
		public IEnumerable <ParticulariteModel> Particularites{
			get{
				if( _particularites == null ){
					_particularites = LoadFromJointure<ParticulariteModel,MonstreModelToParticulariteModel_Particularites>(false);
				}
				return _particularites;
			}
			set{
				SaveToJointure<ParticulariteModel, MonstreModelToParticulariteModel_Particularites> (_particularites, value,false);
				_particularites = value;
			}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "MonstreModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,MonstreModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, MonstreModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private IEnumerable<DonExemplar> _dons;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Dons",OtherKey = "MonstreModelId")]
		public IEnumerable <DonExemplar> Dons{
			get{
				if( _dons == null ){
					_dons = LoadFromJointure<DonExemplar,MonstreModelToDonExemplar_Dons>(false);
				}
				return _dons;
			}
			set{
				SaveToJointure<DonExemplar, MonstreModelToDonExemplar_Dons> (_dons, value,false);
				_dons = value;
			}
		}

		private int _fP;
		[Column(Storage = "FP",Name = "fp")]
		public int FP{
			get{ return _fP;}
			set{_fP = value;}
		}

		private AlignementLoi _alignementLoi;
		[Column(Storage = "AlignementLoi",Name = "alignementloi")]
		public AlignementLoi AlignementLoi{
			get{ return _alignementLoi;}
			set{_alignementLoi = value;}
		}

		private AlignementBien _alignementBien;
		[Column(Storage = "AlignementBien",Name = "alignementbien")]
		public AlignementBien AlignementBien{
			get{ return _alignementBien;}
			set{_alignementBien = value;}
		}

		private FrequenceAlignement _frequenceAlignement;
		[Column(Storage = "FrequenceAlignement",Name = "frequencealignement")]
		public FrequenceAlignement FrequenceAlignement{
			get{ return _frequenceAlignement;}
			set{_frequenceAlignement = value;}
		}

		private IEnumerable<OrganisationSociale> _organisationSociale;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "OrganisationSociale",OtherKey = "MonstreModelId")]
		public IEnumerable <OrganisationSociale> OrganisationSociale{
			get{
				if( _organisationSociale == null ){
					_organisationSociale = LoadFromJointure<OrganisationSociale,MonstreModelToOrganisationSociale_OrganisationSociale>(false);
				}
				return _organisationSociale;
			}
			set{
				SaveToJointure<OrganisationSociale, MonstreModelToOrganisationSociale_OrganisationSociale> (_organisationSociale, value,false);
				_organisationSociale = value;
			}
		}


		private IEnumerable < int > _evolutions;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Evolutions",OtherKey = "MonstreModel")]
		public IEnumerable < int > Evolutions{
			get{
				if( _evolutions == null ){
					_evolutions = LoadFromDataValue<EvolutionsFromMonstreModel, int>();
				}
				return _evolutions;
			}
			set{
				SaveDataValue<EvolutionsFromMonstreModel, int>(_evolutions, value);
			}
		}

		private bool _evolutionParNiveauDeClasse;
		[Column(Storage = "EvolutionParNiveauDeClasse",Name = "evolutionparniveaudeclasse")]
		public bool EvolutionParNiveauDeClasse{
			get{ return _evolutionParNiveauDeClasse;}
			set{_evolutionParNiveauDeClasse = value;}
		}

		private int _ajustementNiveau;
		[Column(Storage = "AjustementNiveau",Name = "ajustementniveau")]
		public int AjustementNiveau{
			get{ return _ajustementNiveau;}
			set{_ajustementNiveau = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<MonstreModel,MonstreModelToTypeCreatureModel_SousType>(true);
			DeleteJoins<MonstreModel,MonstreModelToDeplacement_Deplacements>(true);
			DeleteJoins<MonstreModel,MonstreModelToClasseExemplar_Classes>(true);
			DeleteJoins<MonstreModel,MonstreModelToArmeNaturelleExemplar_AttaquesNaturelles>(true);
			DeleteJoins<MonstreModel,MonstreModelToArmeExemplar_Armes>(true);
			DeleteJoins<MonstreModel,MonstreModelToArmureExemplar_Armures>(true);
			DeleteJoins<MonstreModel,MonstreModelToAttaqueSpecialeModel_AttaqueSpeciales>(true);
			DeleteJoins<MonstreModel,MonstreModelToParticulariteModel_Particularites>(true);
			DeleteJoins<MonstreModel,MonstreModelToCompetenceExemplar_Competences>(true);
			DeleteJoins<MonstreModel,MonstreModelToDonExemplar_Dons>(true);
			DeleteJoins<MonstreModel,MonstreModelToOrganisationSociale_OrganisationSociale>(true);
			DeleteDataValue<EvolutionsFromMonstreModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "monstredescription")]
	public partial class MonstreDescription : DataDescription<MonstreModel> {

		private string _narrative = "";
		[LargeText]
		[Column(Storage = "Narrative",Name = "narrative")]
		public string Narrative{
			get{ return _narrative;}
			set{_narrative = value;}
		}

		private string _combat = "";
		[LargeText]
		[Column(Storage = "Combat",Name = "combat")]
		public string Combat{
			get{ return _combat;}
			set{_combat = value;}
		}
	}
	[Table(Schema = "dd35",Name = "monstreexemplar")]
	public partial class MonstreExemplar : DataExemplaire<MonstreModel> {
	}
}
