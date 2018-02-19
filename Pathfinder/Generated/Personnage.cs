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
	[Table(Schema = "pathfinder",Name = "personnagemodel")]
	public abstract partial class PersonnageModel : DataModel {

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

		private IEnumerable<SousTypeCreatureModel> _sousType;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SousType",OtherKey = "PersonnageModelId")]
		public IEnumerable <SousTypeCreatureModel> SousType{
			get{
				if( _sousType == null ){
					_sousType = LoadFromJointure<SousTypeCreatureModel,PersonnageModelToSousTypeCreatureModel_SousType>(false);
				}
				return _sousType;
			}
			set{
				SaveToJointure<SousTypeCreatureModel, PersonnageModelToSousTypeCreatureModel_SousType> (_sousType, value,false);
				_sousType = value;
			}
		}

		private CategorieTaille _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public CategorieTaille Taille{
			get{ return _taille;}
			set{_taille = value;}
		}

		private int _allonge;
		[Column(Storage = "Allonge",Name = "allonge")]
		public int Allonge{
			get{ return _allonge;}
			set{_allonge = value;}
		}

		private MilieuNaturel _milieuNaturel;
		[Column(Storage = "MilieuNaturel",Name = "milieunaturel")]
		public MilieuNaturel MilieuNaturel{
			get{ return _milieuNaturel;}
			set{_milieuNaturel = value;}
		}

		private Climat _climat;
		[Column(Storage = "Climat",Name = "climat")]
		public Climat Climat{
			get{ return _climat;}
			set{_climat = value;}
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
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "OrganisationSociale",OtherKey = "PersonnageModelId")]
		public IEnumerable <OrganisationSociale> OrganisationSociale{
			get{
				if( _organisationSociale == null ){
					_organisationSociale = LoadFromJointure<OrganisationSociale,PersonnageModelToOrganisationSociale_OrganisationSociale>(false);
				}
				return _organisationSociale;
			}
			set{
				SaveToJointure<OrganisationSociale, PersonnageModelToOrganisationSociale_OrganisationSociale> (_organisationSociale, value,false);
				_organisationSociale = value;
			}
		}

		private int _tresorId;
		[Column(Storage = "TresorId",Name = "fk_tresor_tresor")]
		[HiddenProperty]
		public int TresorId{
			get{ return _tresorId;}
			set{_tresorId = value;}
		}

		private Tresor _tresor;
		public Tresor Tresor{
			get{
				if( _tresor == null)
					_tresor = LoadById<Tresor>(TresorId);
				return _tresor;
			} set {
				if(_tresor == value){return;}
				_tresor = value;
				if( value != null)
					TresorId = value.Id;
			}
		}

		private IEnumerable<LangueExemplar> _langues;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Langues",OtherKey = "PersonnageModelId")]
		public IEnumerable <LangueExemplar> Langues{
			get{
				if( _langues == null ){
					_langues = LoadFromJointure<LangueExemplar,PersonnageModelToLangueExemplar_Langues>(false);
				}
				return _langues;
			}
			set{
				SaveToJointure<LangueExemplar, PersonnageModelToLangueExemplar_Langues> (_langues, value,false);
				_langues = value;
			}
		}

		private int _fP;
		[Column(Storage = "FP",Name = "fp")]
		public int FP{
			get{ return _fP;}
			set{_fP = value;}
		}

		private int _dV;
		[Column(Storage = "DV",Name = "dv")]
		public int DV{
			get{ return _dV;}
			set{_dV = value;}
		}

		private int _ajustementDeNiveau;
		[Column(Storage = "AjustementDeNiveau",Name = "ajustementdeniveau")]
		public int AjustementDeNiveau{
			get{ return _ajustementDeNiveau;}
			set{_ajustementDeNiveau = value;}
		}


		private IEnumerable < int > _evolutions;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Evolutions",OtherKey = "PersonnageModel")]
		public IEnumerable < int > Evolutions{
			get{
				if( _evolutions == null ){
					_evolutions = LoadFromDataValue<EvolutionsFromPersonnageModel, int>();
				}
				return _evolutions;
			}
			set{
				SaveDataValue<EvolutionsFromPersonnageModel, int>(_evolutions, value);
			}
		}

		private bool _evolutionParNiveauDeClasse;
		[Column(Storage = "EvolutionParNiveauDeClasse",Name = "evolutionparniveaudeclasse")]
		public bool EvolutionParNiveauDeClasse{
			get{ return _evolutionParNiveauDeClasse;}
			set{_evolutionParNiveauDeClasse = value;}
		}

		private IEnumerable<AbsDVExemplar> _classes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Classes",OtherKey = "PersonnageModelId")]
		public IEnumerable <AbsDVExemplar> Classes{
			get{
				if( _classes == null ){
					_classes = LoadFromJointure<AbsDVExemplar,PersonnageModelToAbsDVExemplar_Classes>(false);
				}
				return _classes;
			}
			set{
				SaveToJointure<AbsDVExemplar, PersonnageModelToAbsDVExemplar_Classes> (_classes, value,false);
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
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "AttaquesNaturelles",OtherKey = "PersonnageModelId")]
		public IEnumerable <ArmeNaturelleExemplar> AttaquesNaturelles{
			get{
				if( _attaquesNaturelles == null ){
					_attaquesNaturelles = LoadFromJointure<ArmeNaturelleExemplar,PersonnageModelToArmeNaturelleExemplar_AttaquesNaturelles>(false);
				}
				return _attaquesNaturelles;
			}
			set{
				SaveToJointure<ArmeNaturelleExemplar, PersonnageModelToArmeNaturelleExemplar_AttaquesNaturelles> (_attaquesNaturelles, value,false);
				_attaquesNaturelles = value;
			}
		}

		private IEnumerable<ParticulariteExemplar> _particularites;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Particularites",OtherKey = "PersonnageModelId")]
		public IEnumerable <ParticulariteExemplar> Particularites{
			get{
				if( _particularites == null ){
					_particularites = LoadFromJointure<ParticulariteExemplar,PersonnageModelToParticulariteExemplar_Particularites>(false);
				}
				return _particularites;
			}
			set{
				SaveToJointure<ParticulariteExemplar, PersonnageModelToParticulariteExemplar_Particularites> (_particularites, value,false);
				_particularites = value;
			}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "PersonnageModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,PersonnageModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, PersonnageModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private IEnumerable<DonExemplar> _dons;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Dons",OtherKey = "PersonnageModelId")]
		public IEnumerable <DonExemplar> Dons{
			get{
				if( _dons == null ){
					_dons = LoadFromJointure<DonExemplar,PersonnageModelToDonExemplar_Dons>(false);
				}
				return _dons;
			}
			set{
				SaveToJointure<DonExemplar, PersonnageModelToDonExemplar_Dons> (_dons, value,false);
				_dons = value;
			}
		}

		private IEnumerable<ListeSortClasseExemplar> _sortsConnus;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SortsConnus",OtherKey = "PersonnageModelId")]
		public IEnumerable <ListeSortClasseExemplar> SortsConnus{
			get{
				if( _sortsConnus == null ){
					_sortsConnus = LoadFromJointure<ListeSortClasseExemplar,PersonnageModelToListeSortClasseExemplar_SortsConnus>(false);
				}
				return _sortsConnus;
			}
			set{
				SaveToJointure<ListeSortClasseExemplar, PersonnageModelToListeSortClasseExemplar_SortsConnus> (_sortsConnus, value,false);
				_sortsConnus = value;
			}
		}

		private IEnumerable<SortExemplar> _sorts;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Sorts",OtherKey = "PersonnageModelId")]
		public IEnumerable <SortExemplar> Sorts{
			get{
				if( _sorts == null ){
					_sorts = LoadFromJointure<SortExemplar,PersonnageModelToSortExemplar_Sorts>(false);
				}
				return _sorts;
			}
			set{
				SaveToJointure<SortExemplar, PersonnageModelToSortExemplar_Sorts> (_sorts, value,false);
				_sorts = value;
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

		private IEnumerable<ArmureExemplar> _armures;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armures",OtherKey = "PersonnageModelId")]
		public IEnumerable <ArmureExemplar> Armures{
			get{
				if( _armures == null ){
					_armures = LoadFromJointure<ArmureExemplar,PersonnageModelToArmureExemplar_Armures>(false);
				}
				return _armures;
			}
			set{
				SaveToJointure<ArmureExemplar, PersonnageModelToArmureExemplar_Armures> (_armures, value,false);
				_armures = value;
			}
		}

		private IEnumerable<MaterielExemplar> _equipement;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Equipement",OtherKey = "PersonnageModelId")]
		public IEnumerable <MaterielExemplar> Equipement{
			get{
				if( _equipement == null ){
					_equipement = LoadFromJointure<MaterielExemplar,PersonnageModelToMaterielExemplar_Equipement>(false);
				}
				return _equipement;
			}
			set{
				SaveToJointure<MaterielExemplar, PersonnageModelToMaterielExemplar_Equipement> (_equipement, value,false);
				_equipement = value;
			}
		}

		private IEnumerable<ObjectMagiqueExemplar> _objetsMagiques;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "ObjetsMagiques",OtherKey = "PersonnageModelId")]
		public IEnumerable <ObjectMagiqueExemplar> ObjetsMagiques{
			get{
				if( _objetsMagiques == null ){
					_objetsMagiques = LoadFromJointure<ObjectMagiqueExemplar,PersonnageModelToObjectMagiqueExemplar_ObjetsMagiques>(false);
				}
				return _objetsMagiques;
			}
			set{
				SaveToJointure<ObjectMagiqueExemplar, PersonnageModelToObjectMagiqueExemplar_ObjetsMagiques> (_objetsMagiques, value,false);
				_objetsMagiques = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageModel,PersonnageModelToSousTypeCreatureModel_SousType>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToOrganisationSociale_OrganisationSociale>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToLangueExemplar_Langues>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToAbsDVExemplar_Classes>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmeNaturelleExemplar_AttaquesNaturelles>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToParticulariteExemplar_Particularites>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToCompetenceExemplar_Competences>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToDonExemplar_Dons>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToListeSortClasseExemplar_SortsConnus>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToSortExemplar_Sorts>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmeExemplar_Armes>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmureExemplar_Armures>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToMaterielExemplar_Equipement>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToObjectMagiqueExemplar_ObjetsMagiques>(true);
			DeleteDataValue<EvolutionsFromPersonnageModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagedescription")]
	public abstract partial class PersonnageDescription : DataDescription<PersonnageModel> {

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
	[Table(Schema = "pathfinder",Name = "personnageexemplar")]
	public abstract partial class PersonnageExemplar : DataExemplaire<PersonnageModel> {

		private int _degats;
		[Column(Storage = "Degats",Name = "degats")]
		public int Degats{
			get{ return _degats;}
			set{_degats = value;}
		}

		private int _degatsNonLethaux;
		[Column(Storage = "DegatsNonLethaux",Name = "degatsnonlethaux")]
		public int DegatsNonLethaux{
			get{ return _degatsNonLethaux;}
			set{_degatsNonLethaux = value;}
		}

		private IEnumerable<AfflictionExemplar> _afflictions;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Afflictions",OtherKey = "PersonnageExemplarId")]
		public IEnumerable <AfflictionExemplar> Afflictions{
			get{
				if( _afflictions == null ){
					_afflictions = LoadFromJointure<AfflictionExemplar,PersonnageExemplarToAfflictionExemplar_Afflictions>(false);
				}
				return _afflictions;
			}
			set{
				SaveToJointure<AfflictionExemplar, PersonnageExemplarToAfflictionExemplar_Afflictions> (_afflictions, value,false);
				_afflictions = value;
			}
		}

		private IEnumerable<EtatExemplar> _etats;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Etats",OtherKey = "PersonnageExemplarId")]
		public IEnumerable <EtatExemplar> Etats{
			get{
				if( _etats == null ){
					_etats = LoadFromJointure<EtatExemplar,PersonnageExemplarToEtatExemplar_Etats>(false);
				}
				return _etats;
			}
			set{
				SaveToJointure<EtatExemplar, PersonnageExemplarToEtatExemplar_Etats> (_etats, value,false);
				_etats = value;
			}
		}

		private IEnumerable<ArchetypeModel> _archetypes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Archetypes",OtherKey = "PersonnageExemplarId")]
		public IEnumerable <ArchetypeModel> Archetypes{
			get{
				if( _archetypes == null ){
					_archetypes = LoadFromJointure<ArchetypeModel,PersonnageExemplarToArchetypeModel_Archetypes>(false);
				}
				return _archetypes;
			}
			set{
				SaveToJointure<ArchetypeModel, PersonnageExemplarToArchetypeModel_Archetypes> (_archetypes, value,false);
				_archetypes = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageExemplar,PersonnageExemplarToAfflictionExemplar_Afflictions>(true);
			DeleteJoins<PersonnageExemplar,PersonnageExemplarToEtatExemplar_Etats>(true);
			DeleteJoins<PersonnageExemplar,PersonnageExemplarToArchetypeModel_Archetypes>(true);
			base.DeleteObject();
		}
	}
}
