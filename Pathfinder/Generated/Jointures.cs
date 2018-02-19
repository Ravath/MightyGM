using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "racemodeltolanguemodel_languesbase")]
	public class RaceModelToLangueModel_LanguesBase : DataRelation<RaceModel, LangueModel> {

		[Column(Name = "fk_racemodel_join", Storage = "RaceModelId")]
		[HiddenProperty]
		public int RaceModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "RaceModelId", OtherKey = "Id", CanBeNull = false, Storage = "RaceModel")]
		public RaceModel RaceModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_languemodel_join", Storage = "LangueModelId")]
		[HiddenProperty]
		public int LangueModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "LangueModelId", OtherKey = "Id", CanBeNull = false, Storage = "LangueModel")]
		public LangueModel LangueModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "racemodeltolanguemodel_languesupplementaire")]
	public class RaceModelToLangueModel_LangueSupplementaire : DataRelation<RaceModel, LangueModel> {

		[Column(Name = "fk_racemodel_join", Storage = "RaceModelId")]
		[HiddenProperty]
		public int RaceModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "RaceModelId", OtherKey = "Id", CanBeNull = false, Storage = "RaceModel")]
		public RaceModel RaceModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_languemodel_join", Storage = "LangueModelId")]
		[HiddenProperty]
		public int LangueModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "LangueModelId", OtherKey = "Id", CanBeNull = false, Storage = "LangueModel")]
		public LangueModel LangueModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "racemodeltopouvoirspecialmodel_pouvoirs")]
	public class RaceModelToPouvoirSpecialModel_Pouvoirs : DataRelation<RaceModel, PouvoirSpecialModel> {

		[Column(Name = "fk_racemodel_join", Storage = "RaceModelId")]
		[HiddenProperty]
		public int RaceModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "RaceModelId", OtherKey = "Id", CanBeNull = false, Storage = "RaceModel")]
		public RaceModel RaceModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_pouvoirspecialmodel_join", Storage = "PouvoirSpecialModelId")]
		[HiddenProperty]
		public int PouvoirSpecialModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PouvoirSpecialModelId", OtherKey = "Id", CanBeNull = false, Storage = "PouvoirSpecialModel")]
		public PouvoirSpecialModel PouvoirSpecialModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "absdvmodeltocompetencemodel_competences")]
	public class AbsDVModelToCompetenceModel_Competences : DataRelation<AbsDVModel, CompetenceModel> {

		[Column(Name = "fk_absdvmodel_join", Storage = "AbsDVModelId")]
		[HiddenProperty]
		public int AbsDVModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsDVModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsDVModel")]
		public AbsDVModel AbsDVModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competencemodel_join", Storage = "CompetenceModelId")]
		[HiddenProperty]
		public int CompetenceModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceModelId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceModel")]
		public CompetenceModel CompetenceModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "divinitemodeltodomainemodel_domaines")]
	public class DiviniteModelToDomaineModel_Domaines : DataRelation<DiviniteModel, DomaineModel> {

		[Column(Name = "fk_divinitemodel_join", Storage = "DiviniteModelId")]
		[HiddenProperty]
		public int DiviniteModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "DiviniteModelId", OtherKey = "Id", CanBeNull = false, Storage = "DiviniteModel")]
		public DiviniteModel DiviniteModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_domainemodel_join", Storage = "DomaineModelId")]
		[HiddenProperty]
		public int DomaineModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DomaineModelId", OtherKey = "Id", CanBeNull = false, Storage = "DomaineModel")]
		public DomaineModel DomaineModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "themesfromdivinitedescription")]
	public class ThemesFromDiviniteDescription : DataValue<DiviniteDescription, string> {

		[Column(Storage = "Themes",Name = "themes")]
		public string Themes{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "DiviniteDescriptionId",Name = "fk_divinitedescription_from")]
		[HiddenProperty]
		public int DiviniteDescriptionId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public DiviniteDescription DiviniteDescription{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "pathfinder",Name = "donmodeltodonmodel_autresdonsrequis")]
	public class DonModelToDonModel_AutresDonsRequis : DataRelation<DonModel, DonModel> {

		[Column(Name = "fk_donmodel_joinautresdonsrequis", Storage = "DonModelAutresDonsRequisId")]
		[HiddenProperty]
		public int DonModelAutresDonsRequisId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "DonModelAutresDonsRequisId", OtherKey = "Id", CanBeNull = false, Storage = "DonModelAutresDonsRequis")]
		public DonModel DonModelAutresDonsRequis {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_donmodel_join", Storage = "DonModelId")]
		[HiddenProperty]
		public int DonModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DonModelId", OtherKey = "Id", CanBeNull = false, Storage = "DonModel")]
		public DonModel DonModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "registresfromsortmodel")]
	public class RegistresFromSortModel : DataValue<SortModel, int> {

		[Column(Storage = "Registres",Name = "registres")]
		public int Registres{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "SortModelId",Name = "fk_sortmodel_from")]
		[HiddenProperty]
		public int SortModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public SortModel SortModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "pathfinder",Name = "sortexemplartodonmodel_metamagie")]
	public class SortExemplarToDonModel_Metamagie : DataRelation<SortExemplar, DonModel> {

		[Column(Name = "fk_sortexemplar_join", Storage = "SortExemplarId")]
		[HiddenProperty]
		public int SortExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SortExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "SortExemplar")]
		public SortExemplar SortExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_donmodel_join", Storage = "DonModelId")]
		[HiddenProperty]
		public int DonModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DonModelId", OtherKey = "Id", CanBeNull = false, Storage = "DonModel")]
		public DonModel DonModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "objetintelligenttolanguemodel_languesconnues")]
	public class ObjetIntelligentToLangueModel_LanguesConnues : DataRelation<ObjetIntelligent, LangueModel> {

		[Column(Name = "fk_objetintelligent_join", Storage = "ObjetIntelligentId")]
		[HiddenProperty]
		public int ObjetIntelligentId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ObjetIntelligentId", OtherKey = "Id", CanBeNull = false, Storage = "ObjetIntelligent")]
		public ObjetIntelligent ObjetIntelligent {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_languemodel_join", Storage = "LangueModelId")]
		[HiddenProperty]
		public int LangueModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "LangueModelId", OtherKey = "Id", CanBeNull = false, Storage = "LangueModel")]
		public LangueModel LangueModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "enchantementobjetmodeltosortmodel_sortscreation")]
	public class EnchantementObjetModelToSortModel_SortsCreation : DataRelation<EnchantementObjetModel, SortModel> {

		[Column(Name = "fk_enchantementobjetmodel_join", Storage = "EnchantementObjetModelId")]
		[HiddenProperty]
		public int EnchantementObjetModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EnchantementObjetModelId", OtherKey = "Id", CanBeNull = false, Storage = "EnchantementObjetModel")]
		public EnchantementObjetModel EnchantementObjetModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sortmodel_join", Storage = "SortModelId")]
		[HiddenProperty]
		public int SortModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortModelId", OtherKey = "Id", CanBeNull = false, Storage = "SortModel")]
		public SortModel SortModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "enchantementobjetmodeltorequisexemplar_requisport")]
	public class EnchantementObjetModelToRequisExemplar_RequisPort : DataRelation<EnchantementObjetModel, RequisExemplar> {

		[Column(Name = "fk_enchantementobjetmodel_join", Storage = "EnchantementObjetModelId")]
		[HiddenProperty]
		public int EnchantementObjetModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EnchantementObjetModelId", OtherKey = "Id", CanBeNull = false, Storage = "EnchantementObjetModel")]
		public EnchantementObjetModel EnchantementObjetModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_requisexemplar_join", Storage = "RequisExemplarId")]
		[HiddenProperty]
		public int RequisExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "RequisExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "RequisExemplar")]
		public RequisExemplar RequisExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "enchantementobjetmodeltorequisexemplar_requiscreation")]
	public class EnchantementObjetModelToRequisExemplar_RequisCreation : DataRelation<EnchantementObjetModel, RequisExemplar> {

		[Column(Name = "fk_enchantementobjetmodel_join", Storage = "EnchantementObjetModelId")]
		[HiddenProperty]
		public int EnchantementObjetModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EnchantementObjetModelId", OtherKey = "Id", CanBeNull = false, Storage = "EnchantementObjetModel")]
		public EnchantementObjetModel EnchantementObjetModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_requisexemplar_join", Storage = "RequisExemplarId")]
		[HiddenProperty]
		public int RequisExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "RequisExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "RequisExemplar")]
		public RequisExemplar RequisExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "soustypecreaturemodeltopouvoirspecialexemplar_pouvoirs")]
	public class SousTypeCreatureModelToPouvoirSpecialExemplar_Pouvoirs : DataRelation<SousTypeCreatureModel, PouvoirSpecialExemplar> {

		[Column(Name = "fk_soustypecreaturemodel_join", Storage = "SousTypeCreatureModelId")]
		[HiddenProperty]
		public int SousTypeCreatureModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SousTypeCreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "SousTypeCreatureModel")]
		public SousTypeCreatureModel SousTypeCreatureModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_pouvoirspecialexemplar_join", Storage = "PouvoirSpecialExemplarId")]
		[HiddenProperty]
		public int PouvoirSpecialExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PouvoirSpecialExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PouvoirSpecialExemplar")]
		public PouvoirSpecialExemplar PouvoirSpecialExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "archetypemodeltoparticulariteexemplar_particularites")]
	public class ArchetypeModelToParticulariteExemplar_Particularites : DataRelation<ArchetypeModel, ParticulariteExemplar> {

		[Column(Name = "fk_archetypemodel_join", Storage = "ArchetypeModelId")]
		[HiddenProperty]
		public int ArchetypeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArchetypeModelId", OtherKey = "Id", CanBeNull = false, Storage = "ArchetypeModel")]
		public ArchetypeModel ArchetypeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_particulariteexemplar_join", Storage = "ParticulariteExemplarId")]
		[HiddenProperty]
		public int ParticulariteExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ParticulariteExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ParticulariteExemplar")]
		public ParticulariteExemplar ParticulariteExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "armenaturellemodeltoparticulariteattaqueexemplar_special")]
	public class ArmeNaturelleModelToParticulariteAttaqueExemplar_Special : DataRelation<ArmeNaturelleModel, ParticulariteAttaqueExemplar> {

		[Column(Name = "fk_armenaturellemodel_join", Storage = "ArmeNaturelleModelId")]
		[HiddenProperty]
		public int ArmeNaturelleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArmeNaturelleModelId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeNaturelleModel")]
		public ArmeNaturelleModel ArmeNaturelleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_particulariteattaqueexemplar_join", Storage = "ParticulariteAttaqueExemplarId")]
		[HiddenProperty]
		public int ParticulariteAttaqueExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ParticulariteAttaqueExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ParticulariteAttaqueExemplar")]
		public ParticulariteAttaqueExemplar ParticulariteAttaqueExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltosoustypecreaturemodel_soustype")]
	public class PersonnageModelToSousTypeCreatureModel_SousType : DataRelation<PersonnageModel, SousTypeCreatureModel> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_soustypecreaturemodel_join", Storage = "SousTypeCreatureModelId")]
		[HiddenProperty]
		public int SousTypeCreatureModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SousTypeCreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "SousTypeCreatureModel")]
		public SousTypeCreatureModel SousTypeCreatureModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltoorganisationsociale_organisationsociale")]
	public class PersonnageModelToOrganisationSociale_OrganisationSociale : DataRelation<PersonnageModel, OrganisationSociale> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_organisationsociale_join", Storage = "OrganisationSocialeId")]
		[HiddenProperty]
		public int OrganisationSocialeId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "OrganisationSocialeId", OtherKey = "Id", CanBeNull = false, Storage = "OrganisationSociale")]
		public OrganisationSociale OrganisationSociale {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltolangueexemplar_langues")]
	public class PersonnageModelToLangueExemplar_Langues : DataRelation<PersonnageModel, LangueExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_langueexemplar_join", Storage = "LangueExemplarId")]
		[HiddenProperty]
		public int LangueExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "LangueExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "LangueExemplar")]
		public LangueExemplar LangueExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "evolutionsfrompersonnagemodel")]
	public class EvolutionsFromPersonnageModel : DataValue<PersonnageModel, int> {

		[Column(Storage = "Evolutions",Name = "evolutions")]
		public int Evolutions{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "PersonnageModelId",Name = "fk_personnagemodel_from")]
		[HiddenProperty]
		public int PersonnageModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public PersonnageModel PersonnageModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltoabsdvexemplar_classes")]
	public class PersonnageModelToAbsDVExemplar_Classes : DataRelation<PersonnageModel, AbsDVExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_absdvexemplar_join", Storage = "AbsDVExemplarId")]
		[HiddenProperty]
		public int AbsDVExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AbsDVExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AbsDVExemplar")]
		public AbsDVExemplar AbsDVExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltoarmenaturelleexemplar_attaquesnaturelles")]
	public class PersonnageModelToArmeNaturelleExemplar_AttaquesNaturelles : DataRelation<PersonnageModel, ArmeNaturelleExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_armenaturelleexemplar_join", Storage = "ArmeNaturelleExemplarId")]
		[HiddenProperty]
		public int ArmeNaturelleExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArmeNaturelleExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeNaturelleExemplar")]
		public ArmeNaturelleExemplar ArmeNaturelleExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltoparticulariteexemplar_particularites")]
	public class PersonnageModelToParticulariteExemplar_Particularites : DataRelation<PersonnageModel, ParticulariteExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_particulariteexemplar_join", Storage = "ParticulariteExemplarId")]
		[HiddenProperty]
		public int ParticulariteExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ParticulariteExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ParticulariteExemplar")]
		public ParticulariteExemplar ParticulariteExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltocompetenceexemplar_competences")]
	public class PersonnageModelToCompetenceExemplar_Competences : DataRelation<PersonnageModel, CompetenceExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competenceexemplar_join", Storage = "CompetenceExemplarId")]
		[HiddenProperty]
		public int CompetenceExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceExemplar")]
		public CompetenceExemplar CompetenceExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltodonexemplar_dons")]
	public class PersonnageModelToDonExemplar_Dons : DataRelation<PersonnageModel, DonExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_donexemplar_join", Storage = "DonExemplarId")]
		[HiddenProperty]
		public int DonExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DonExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "DonExemplar")]
		public DonExemplar DonExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltolistesortclasseexemplar_sortsconnus")]
	public class PersonnageModelToListeSortClasseExemplar_SortsConnus : DataRelation<PersonnageModel, ListeSortClasseExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_listesortclasseexemplar_join", Storage = "ListeSortClasseExemplarId")]
		[HiddenProperty]
		public int ListeSortClasseExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ListeSortClasseExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ListeSortClasseExemplar")]
		public ListeSortClasseExemplar ListeSortClasseExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltosortexemplar_sorts")]
	public class PersonnageModelToSortExemplar_Sorts : DataRelation<PersonnageModel, SortExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sortexemplar_join", Storage = "SortExemplarId")]
		[HiddenProperty]
		public int SortExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "SortExemplar")]
		public SortExemplar SortExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltoarmeexemplar_armes")]
	public class PersonnageModelToArmeExemplar_Armes : DataRelation<PersonnageModel, ArmeExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_armeexemplar_join", Storage = "ArmeExemplarId")]
		[HiddenProperty]
		public int ArmeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArmeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeExemplar")]
		public ArmeExemplar ArmeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltoarmureexemplar_armures")]
	public class PersonnageModelToArmureExemplar_Armures : DataRelation<PersonnageModel, ArmureExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_armureexemplar_join", Storage = "ArmureExemplarId")]
		[HiddenProperty]
		public int ArmureExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArmureExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmureExemplar")]
		public ArmureExemplar ArmureExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltomaterielexemplar_equipement")]
	public class PersonnageModelToMaterielExemplar_Equipement : DataRelation<PersonnageModel, MaterielExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_materielexemplar_join", Storage = "MaterielExemplarId")]
		[HiddenProperty]
		public int MaterielExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "MaterielExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "MaterielExemplar")]
		public MaterielExemplar MaterielExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnagemodeltoobjectmagiqueexemplar_objetsmagiques")]
	public class PersonnageModelToObjectMagiqueExemplar_ObjetsMagiques : DataRelation<PersonnageModel, ObjectMagiqueExemplar> {

		[Column(Name = "fk_personnagemodel_join", Storage = "PersonnageModelId")]
		[HiddenProperty]
		public int PersonnageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageModelId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageModel")]
		public PersonnageModel PersonnageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_objectmagiqueexemplar_join", Storage = "ObjectMagiqueExemplarId")]
		[HiddenProperty]
		public int ObjectMagiqueExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ObjectMagiqueExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ObjectMagiqueExemplar")]
		public ObjectMagiqueExemplar ObjectMagiqueExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnageexemplartoafflictionexemplar_afflictions")]
	public class PersonnageExemplarToAfflictionExemplar_Afflictions : DataRelation<PersonnageExemplar, AfflictionExemplar> {

		[Column(Name = "fk_personnageexemplar_join", Storage = "PersonnageExemplarId")]
		[HiddenProperty]
		public int PersonnageExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageExemplar")]
		public PersonnageExemplar PersonnageExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_afflictionexemplar_join", Storage = "AfflictionExemplarId")]
		[HiddenProperty]
		public int AfflictionExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AfflictionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AfflictionExemplar")]
		public AfflictionExemplar AfflictionExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnageexemplartoetatexemplar_etats")]
	public class PersonnageExemplarToEtatExemplar_Etats : DataRelation<PersonnageExemplar, EtatExemplar> {

		[Column(Name = "fk_personnageexemplar_join", Storage = "PersonnageExemplarId")]
		[HiddenProperty]
		public int PersonnageExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageExemplar")]
		public PersonnageExemplar PersonnageExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_etatexemplar_join", Storage = "EtatExemplarId")]
		[HiddenProperty]
		public int EtatExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EtatExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EtatExemplar")]
		public EtatExemplar EtatExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "personnageexemplartoarchetypemodel_archetypes")]
	public class PersonnageExemplarToArchetypeModel_Archetypes : DataRelation<PersonnageExemplar, ArchetypeModel> {

		[Column(Name = "fk_personnageexemplar_join", Storage = "PersonnageExemplarId")]
		[HiddenProperty]
		public int PersonnageExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PersonnageExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PersonnageExemplar")]
		public PersonnageExemplar PersonnageExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_archetypemodel_join", Storage = "ArchetypeModelId")]
		[HiddenProperty]
		public int ArchetypeModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArchetypeModelId", OtherKey = "Id", CanBeNull = false, Storage = "ArchetypeModel")]
		public ArchetypeModel ArchetypeModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "gestionnaireitrmmodeltocompetenceexemplar_competences")]
	public class GestionnaireItrmModelToCompetenceExemplar_Competences : DataRelation<GestionnaireItrmModel, CompetenceExemplar> {

		[Column(Name = "fk_gestionnaireitrmmodel_join", Storage = "GestionnaireItrmModelId")]
		[HiddenProperty]
		public int GestionnaireItrmModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "GestionnaireItrmModelId", OtherKey = "Id", CanBeNull = false, Storage = "GestionnaireItrmModel")]
		public GestionnaireItrmModel GestionnaireItrmModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competenceexemplar_join", Storage = "CompetenceExemplarId")]
		[HiddenProperty]
		public int CompetenceExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceExemplar")]
		public CompetenceExemplar CompetenceExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "batimentroyaumemodeltobatimentroyaumemodel_reduction")]
	public class BatimentRoyaumeModelToBatimentRoyaumeModel_Reduction : DataRelation<BatimentRoyaumeModel, BatimentRoyaumeModel> {

		[Column(Name = "fk_batimentroyaumemodel_joinreduction", Storage = "BatimentRoyaumeModelReductionId")]
		[HiddenProperty]
		public int BatimentRoyaumeModelReductionId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "BatimentRoyaumeModelReductionId", OtherKey = "Id", CanBeNull = false, Storage = "BatimentRoyaumeModelReduction")]
		public BatimentRoyaumeModel BatimentRoyaumeModelReduction {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_batimentroyaumemodel_join", Storage = "BatimentRoyaumeModelId")]
		[HiddenProperty]
		public int BatimentRoyaumeModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "BatimentRoyaumeModelId", OtherKey = "Id", CanBeNull = false, Storage = "BatimentRoyaumeModel")]
		public BatimentRoyaumeModel BatimentRoyaumeModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "armeeroyaumemodeltoressourcearmeemodel_ressources")]
	public class ArmeeRoyaumeModelToRessourceArmeeModel_Ressources : DataRelation<ArmeeRoyaumeModel, RessourceArmeeModel> {

		[Column(Name = "fk_armeeroyaumemodel_join", Storage = "ArmeeRoyaumeModelId")]
		[HiddenProperty]
		public int ArmeeRoyaumeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArmeeRoyaumeModelId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeeRoyaumeModel")]
		public ArmeeRoyaumeModel ArmeeRoyaumeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_ressourcearmeemodel_join", Storage = "RessourceArmeeModelId")]
		[HiddenProperty]
		public int RessourceArmeeModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "RessourceArmeeModelId", OtherKey = "Id", CanBeNull = false, Storage = "RessourceArmeeModel")]
		public RessourceArmeeModel RessourceArmeeModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "armemodeltospecialarmeexemplar_specialarme")]
	public class ArmeModelToSpecialArmeExemplar_SpecialArme : DataRelation<ArmeModel, SpecialArmeExemplar> {

		[Column(Name = "fk_armemodel_join", Storage = "ArmeModelId")]
		[HiddenProperty]
		public int ArmeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArmeModelId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeModel")]
		public ArmeModel ArmeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_specialarmeexemplar_join", Storage = "SpecialArmeExemplarId")]
		[HiddenProperty]
		public int SpecialArmeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpecialArmeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "SpecialArmeExemplar")]
		public SpecialArmeExemplar SpecialArmeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "armeexemplartoenchantementarmeexemplar_enchantements")]
	public class ArmeExemplarToEnchantementArmeExemplar_Enchantements : DataRelation<ArmeExemplar, EnchantementArmeExemplar> {

		[Column(Name = "fk_armeexemplar_join", Storage = "ArmeExemplarId")]
		[HiddenProperty]
		public int ArmeExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArmeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeExemplar")]
		public ArmeExemplar ArmeExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_enchantementarmeexemplar_join", Storage = "EnchantementArmeExemplarId")]
		[HiddenProperty]
		public int EnchantementArmeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EnchantementArmeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EnchantementArmeExemplar")]
		public EnchantementArmeExemplar EnchantementArmeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "armeexemplartomunitionexemplar_munitions")]
	public class ArmeExemplarToMunitionExemplar_Munitions : DataRelation<ArmeExemplar, MunitionExemplar> {

		[Column(Name = "fk_armeexemplar_join", Storage = "ArmeExemplarId")]
		[HiddenProperty]
		public int ArmeExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArmeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeExemplar")]
		public ArmeExemplar ArmeExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_munitionexemplar_join", Storage = "MunitionExemplarId")]
		[HiddenProperty]
		public int MunitionExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "MunitionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "MunitionExemplar")]
		public MunitionExemplar MunitionExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "munitionexemplartoenchantementarmeexemplar_enchantements")]
	public class MunitionExemplarToEnchantementArmeExemplar_Enchantements : DataRelation<MunitionExemplar, EnchantementArmeExemplar> {

		[Column(Name = "fk_munitionexemplar_join", Storage = "MunitionExemplarId")]
		[HiddenProperty]
		public int MunitionExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MunitionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "MunitionExemplar")]
		public MunitionExemplar MunitionExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_enchantementarmeexemplar_join", Storage = "EnchantementArmeExemplarId")]
		[HiddenProperty]
		public int EnchantementArmeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EnchantementArmeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EnchantementArmeExemplar")]
		public EnchantementArmeExemplar EnchantementArmeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "armureexemplartoenchantementarmureexemplar_enchantements")]
	public class ArmureExemplarToEnchantementArmureExemplar_Enchantements : DataRelation<ArmureExemplar, EnchantementArmureExemplar> {

		[Column(Name = "fk_armureexemplar_join", Storage = "ArmureExemplarId")]
		[HiddenProperty]
		public int ArmureExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArmureExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmureExemplar")]
		public ArmureExemplar ArmureExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_enchantementarmureexemplar_join", Storage = "EnchantementArmureExemplarId")]
		[HiddenProperty]
		public int EnchantementArmureExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EnchantementArmureExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EnchantementArmureExemplar")]
		public EnchantementArmureExemplar EnchantementArmureExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "objectmagiquemodeltosortmodel_sortscreation")]
	public class ObjectMagiqueModelToSortModel_SortsCreation : DataRelation<ObjectMagiqueModel, SortModel> {

		[Column(Name = "fk_objectmagiquemodel_join", Storage = "ObjectMagiqueModelId")]
		[HiddenProperty]
		public int ObjectMagiqueModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ObjectMagiqueModelId", OtherKey = "Id", CanBeNull = false, Storage = "ObjectMagiqueModel")]
		public ObjectMagiqueModel ObjectMagiqueModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sortmodel_join", Storage = "SortModelId")]
		[HiddenProperty]
		public int SortModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortModelId", OtherKey = "Id", CanBeNull = false, Storage = "SortModel")]
		public SortModel SortModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "objectmagiquemodeltorequisexemplar_requisport")]
	public class ObjectMagiqueModelToRequisExemplar_RequisPort : DataRelation<ObjectMagiqueModel, RequisExemplar> {

		[Column(Name = "fk_objectmagiquemodel_join", Storage = "ObjectMagiqueModelId")]
		[HiddenProperty]
		public int ObjectMagiqueModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ObjectMagiqueModelId", OtherKey = "Id", CanBeNull = false, Storage = "ObjectMagiqueModel")]
		public ObjectMagiqueModel ObjectMagiqueModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_requisexemplar_join", Storage = "RequisExemplarId")]
		[HiddenProperty]
		public int RequisExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "RequisExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "RequisExemplar")]
		public RequisExemplar RequisExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "objectmagiquemodeltorequisexemplar_requiscreation")]
	public class ObjectMagiqueModelToRequisExemplar_RequisCreation : DataRelation<ObjectMagiqueModel, RequisExemplar> {

		[Column(Name = "fk_objectmagiquemodel_join", Storage = "ObjectMagiqueModelId")]
		[HiddenProperty]
		public int ObjectMagiqueModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ObjectMagiqueModelId", OtherKey = "Id", CanBeNull = false, Storage = "ObjectMagiqueModel")]
		public ObjectMagiqueModel ObjectMagiqueModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_requisexemplar_join", Storage = "RequisExemplarId")]
		[HiddenProperty]
		public int RequisExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "RequisExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "RequisExemplar")]
		public RequisExemplar RequisExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "typecreaturemodeltopouvoirspecialexemplar_pouvoirs")]
	public class TypeCreatureModelToPouvoirSpecialExemplar_Pouvoirs : DataRelation<TypeCreatureModel, PouvoirSpecialExemplar> {

		[Column(Name = "fk_typecreaturemodel_join", Storage = "TypeCreatureModelId")]
		[HiddenProperty]
		public int TypeCreatureModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "TypeCreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "TypeCreatureModel")]
		public TypeCreatureModel TypeCreatureModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_pouvoirspecialexemplar_join", Storage = "PouvoirSpecialExemplarId")]
		[HiddenProperty]
		public int PouvoirSpecialExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PouvoirSpecialExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PouvoirSpecialExemplar")]
		public PouvoirSpecialExemplar PouvoirSpecialExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "conflitexemplartoacteurconflitmodel_acteurs")]
	public class ConflitExemplarToActeurConflitModel_Acteurs : DataRelation<ConflitExemplar, ActeurConflitModel> {

		[Column(Name = "fk_conflitexemplar_join", Storage = "ConflitExemplarId")]
		[HiddenProperty]
		public int ConflitExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ConflitExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ConflitExemplar")]
		public ConflitExemplar ConflitExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_acteurconflitmodel_join", Storage = "ActeurConflitModelId")]
		[HiddenProperty]
		public int ActeurConflitModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ActeurConflitModelId", OtherKey = "Id", CanBeNull = false, Storage = "ActeurConflitModel")]
		public ActeurConflitModel ActeurConflitModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "batimentitrmmodeltosallebatimentitrmexemplar_salles")]
	public class BatimentItrmModelToSalleBatimentItrmExemplar_Salles : DataRelation<BatimentItrmModel, SalleBatimentItrmExemplar> {

		[Column(Name = "fk_batimentitrmmodel_join", Storage = "BatimentItrmModelId")]
		[HiddenProperty]
		public int BatimentItrmModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "BatimentItrmModelId", OtherKey = "Id", CanBeNull = false, Storage = "BatimentItrmModel")]
		public BatimentItrmModel BatimentItrmModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sallebatimentitrmexemplar_join", Storage = "SalleBatimentItrmExemplarId")]
		[HiddenProperty]
		public int SalleBatimentItrmExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SalleBatimentItrmExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "SalleBatimentItrmExemplar")]
		public SalleBatimentItrmExemplar SalleBatimentItrmExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "organisationitrmmodeltoemployeitrmexemplar_employes")]
	public class OrganisationItrmModelToEmployeItrmExemplar_Employes : DataRelation<OrganisationItrmModel, EmployeItrmExemplar> {

		[Column(Name = "fk_organisationitrmmodel_join", Storage = "OrganisationItrmModelId")]
		[HiddenProperty]
		public int OrganisationItrmModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "OrganisationItrmModelId", OtherKey = "Id", CanBeNull = false, Storage = "OrganisationItrmModel")]
		public OrganisationItrmModel OrganisationItrmModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_employeitrmexemplar_join", Storage = "EmployeItrmExemplarId")]
		[HiddenProperty]
		public int EmployeItrmExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EmployeItrmExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EmployeItrmExemplar")]
		public EmployeItrmExemplar EmployeItrmExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "batimentroyaumemodelamelioreentobatimentroyaumemodelameliorede")]
	public class BatimentRoyaumeModelAmelioreEnToBatimentRoyaumeModelAmelioreDe : DataRelation<BatimentRoyaumeModel, BatimentRoyaumeModel> {

		[Column(Name = "fk_batimentroyaumemodel_joinamelioreenameliorede", Storage = "BatimentRoyaumeModelAmelioreEnId")]
		[HiddenProperty]
		public int BatimentRoyaumeModelAmelioreEnId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "BatimentRoyaumeModelAmelioreEnId", OtherKey = "Id", CanBeNull = false, Storage = "BatimentRoyaumeModelAmelioreEn")]
		public BatimentRoyaumeModel BatimentRoyaumeModelAmelioreEn {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_batimentroyaumemodel_join", Storage = "BatimentRoyaumeModelAmelioreDeId")]
		[HiddenProperty]
		public int BatimentRoyaumeModelAmelioreDeId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "BatimentRoyaumeModelAmelioreDeId", OtherKey = "Id", CanBeNull = false, Storage = "BatimentRoyaumeModelAmelioreDe")]
		public BatimentRoyaumeModel BatimentRoyaumeModelAmelioreDe {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "batimentroyaumemodelamelioredetobatimentroyaumemodelamelioreen")]
	public class BatimentRoyaumeModelAmelioreDeToBatimentRoyaumeModelAmelioreEn : DataRelation<BatimentRoyaumeModel, BatimentRoyaumeModel> {

		[Column(Name = "fk_batimentroyaumemodel_joinamelioredeamelioreen", Storage = "BatimentRoyaumeModelAmelioreDeId")]
		[HiddenProperty]
		public int BatimentRoyaumeModelAmelioreDeId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "BatimentRoyaumeModelAmelioreDeId", OtherKey = "Id", CanBeNull = false, Storage = "BatimentRoyaumeModelAmelioreDe")]
		public BatimentRoyaumeModel BatimentRoyaumeModelAmelioreDe {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_batimentroyaumemodel_join", Storage = "BatimentRoyaumeModelAmelioreEnId")]
		[HiddenProperty]
		public int BatimentRoyaumeModelAmelioreEnId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "BatimentRoyaumeModelAmelioreEnId", OtherKey = "Id", CanBeNull = false, Storage = "BatimentRoyaumeModelAmelioreEn")]
		public BatimentRoyaumeModel BatimentRoyaumeModelAmelioreEn {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "sallebatimentitrmmodelameldetosallebatimentitrmmodelamelen")]
	public class SalleBatimentItrmModelAmelDeToSalleBatimentItrmModelAmelEn : DataRelation<SalleBatimentItrmModel, SalleBatimentItrmModel> {

		[Column(Name = "fk_sallebatimentitrmmodel_joinameldeamelen", Storage = "SalleBatimentItrmModelAmelDeId")]
		[HiddenProperty]
		public int SalleBatimentItrmModelAmelDeId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SalleBatimentItrmModelAmelDeId", OtherKey = "Id", CanBeNull = false, Storage = "SalleBatimentItrmModelAmelDe")]
		public SalleBatimentItrmModel SalleBatimentItrmModelAmelDe {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sallebatimentitrmmodel_join", Storage = "SalleBatimentItrmModelAmelEnId")]
		[HiddenProperty]
		public int SalleBatimentItrmModelAmelEnId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SalleBatimentItrmModelAmelEnId", OtherKey = "Id", CanBeNull = false, Storage = "SalleBatimentItrmModelAmelEn")]
		public SalleBatimentItrmModel SalleBatimentItrmModelAmelEn {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "sallebatimentitrmmodelamelentosallebatimentitrmmodelamelde")]
	public class SalleBatimentItrmModelAmelEnToSalleBatimentItrmModelAmelDe : DataRelation<SalleBatimentItrmModel, SalleBatimentItrmModel> {

		[Column(Name = "fk_sallebatimentitrmmodel_joinamelenamelde", Storage = "SalleBatimentItrmModelAmelEnId")]
		[HiddenProperty]
		public int SalleBatimentItrmModelAmelEnId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SalleBatimentItrmModelAmelEnId", OtherKey = "Id", CanBeNull = false, Storage = "SalleBatimentItrmModelAmelEn")]
		public SalleBatimentItrmModel SalleBatimentItrmModelAmelEn {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sallebatimentitrmmodel_join", Storage = "SalleBatimentItrmModelAmelDeId")]
		[HiddenProperty]
		public int SalleBatimentItrmModelAmelDeId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SalleBatimentItrmModelAmelDeId", OtherKey = "Id", CanBeNull = false, Storage = "SalleBatimentItrmModelAmelDe")]
		public SalleBatimentItrmModel SalleBatimentItrmModelAmelDe {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "employeitrmmodelameldetoemployeitrmmodelamelen")]
	public class EmployeItrmModelAmelDeToEmployeItrmModelAmelEn : DataRelation<EmployeItrmModel, EmployeItrmModel> {

		[Column(Name = "fk_employeitrmmodel_joinameldeamelen", Storage = "EmployeItrmModelAmelDeId")]
		[HiddenProperty]
		public int EmployeItrmModelAmelDeId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EmployeItrmModelAmelDeId", OtherKey = "Id", CanBeNull = false, Storage = "EmployeItrmModelAmelDe")]
		public EmployeItrmModel EmployeItrmModelAmelDe {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_employeitrmmodel_join", Storage = "EmployeItrmModelAmelEnId")]
		[HiddenProperty]
		public int EmployeItrmModelAmelEnId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EmployeItrmModelAmelEnId", OtherKey = "Id", CanBeNull = false, Storage = "EmployeItrmModelAmelEn")]
		public EmployeItrmModel EmployeItrmModelAmelEn {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "pathfinder",Name = "employeitrmmodelamelentoemployeitrmmodelamelde")]
	public class EmployeItrmModelAmelEnToEmployeItrmModelAmelDe : DataRelation<EmployeItrmModel, EmployeItrmModel> {

		[Column(Name = "fk_employeitrmmodel_joinamelenamelde", Storage = "EmployeItrmModelAmelEnId")]
		[HiddenProperty]
		public int EmployeItrmModelAmelEnId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EmployeItrmModelAmelEnId", OtherKey = "Id", CanBeNull = false, Storage = "EmployeItrmModelAmelEn")]
		public EmployeItrmModel EmployeItrmModelAmelEn {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_employeitrmmodel_join", Storage = "EmployeItrmModelAmelDeId")]
		[HiddenProperty]
		public int EmployeItrmModelAmelDeId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EmployeItrmModelAmelDeId", OtherKey = "Id", CanBeNull = false, Storage = "EmployeItrmModelAmelDe")]
		public EmployeItrmModel EmployeItrmModelAmelDe {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
