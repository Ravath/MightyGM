using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "racemodeltolanguemodel_languebase")]
	public class RaceModelToLangueModel_LangueBase : DataRelation<RaceModel, LangueModel> {

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
	[Table(Schema = "dd35",Name = "racemodeltolanguemodel_languesupplmentaire")]
	public class RaceModelToLangueModel_LangueSupplmentaire : DataRelation<RaceModel, LangueModel> {

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
	[Table(Schema = "dd35",Name = "divinitemodeltodomainemodel_domaines")]
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
	[Table(Schema = "dd35",Name = "registresfromsortmodel")]
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
	[Table(Schema = "dd35",Name = "composantesfromsortmodel")]
	public class ComposantesFromSortModel : DataValue<SortModel, int> {

		[Column(Storage = "Composantes",Name = "composantes")]
		public int Composantes{
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
	[Table(Schema = "dd35",Name = "soustypecreaturemodeltopouvoirmonstrueuxmodel_pouvoirs")]
	public class SousTypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs : DataRelation<SousTypeCreatureModel, PouvoirMonstrueuxModel> {

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

		[Column(Name = "fk_pouvoirmonstrueuxmodel_join", Storage = "PouvoirMonstrueuxModelId")]
		[HiddenProperty]
		public int PouvoirMonstrueuxModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PouvoirMonstrueuxModelId", OtherKey = "Id", CanBeNull = false, Storage = "PouvoirMonstrueuxModel")]
		public PouvoirMonstrueuxModel PouvoirMonstrueuxModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "monstremodeltotypecreaturemodel_soustype")]
	public class MonstreModelToTypeCreatureModel_SousType : DataRelation<MonstreModel, TypeCreatureModel> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_typecreaturemodel_join", Storage = "TypeCreatureModelId")]
		[HiddenProperty]
		public int TypeCreatureModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "TypeCreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "TypeCreatureModel")]
		public TypeCreatureModel TypeCreatureModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "monstremodeltodeplacement_deplacements")]
	public class MonstreModelToDeplacement_Deplacements : DataRelation<MonstreModel, Deplacement> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_deplacement_join", Storage = "DeplacementId")]
		[HiddenProperty]
		public int DeplacementId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DeplacementId", OtherKey = "Id", CanBeNull = false, Storage = "Deplacement")]
		public Deplacement Deplacement {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "monstremodeltoclasseexemplar_classes")]
	public class MonstreModelToClasseExemplar_Classes : DataRelation<MonstreModel, ClasseExemplar> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_classeexemplar_join", Storage = "ClasseExemplarId")]
		[HiddenProperty]
		public int ClasseExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ClasseExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ClasseExemplar")]
		public ClasseExemplar ClasseExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "monstremodeltoarmenaturelleexemplar_attaquesnaturelles")]
	public class MonstreModelToArmeNaturelleExemplar_AttaquesNaturelles : DataRelation<MonstreModel, ArmeNaturelleExemplar> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
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
	[Table(Schema = "dd35",Name = "monstremodeltoarmeexemplar_armes")]
	public class MonstreModelToArmeExemplar_Armes : DataRelation<MonstreModel, ArmeExemplar> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
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
	[Table(Schema = "dd35",Name = "monstremodeltoarmureexemplar_armures")]
	public class MonstreModelToArmureExemplar_Armures : DataRelation<MonstreModel, ArmureExemplar> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
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
	[Table(Schema = "dd35",Name = "monstremodeltoattaquespecialemodel_attaquespeciales")]
	public class MonstreModelToAttaqueSpecialeModel_AttaqueSpeciales : DataRelation<MonstreModel, AttaqueSpecialeModel> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_attaquespecialemodel_join", Storage = "AttaqueSpecialeModelId")]
		[HiddenProperty]
		public int AttaqueSpecialeModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AttaqueSpecialeModelId", OtherKey = "Id", CanBeNull = false, Storage = "AttaqueSpecialeModel")]
		public AttaqueSpecialeModel AttaqueSpecialeModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "monstremodeltoparticularitemodel_particularites")]
	public class MonstreModelToParticulariteModel_Particularites : DataRelation<MonstreModel, ParticulariteModel> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_particularitemodel_join", Storage = "ParticulariteModelId")]
		[HiddenProperty]
		public int ParticulariteModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ParticulariteModelId", OtherKey = "Id", CanBeNull = false, Storage = "ParticulariteModel")]
		public ParticulariteModel ParticulariteModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "monstremodeltocompetenceexemplar_competences")]
	public class MonstreModelToCompetenceExemplar_Competences : DataRelation<MonstreModel, CompetenceExemplar> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
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
	[Table(Schema = "dd35",Name = "monstremodeltodonexemplar_dons")]
	public class MonstreModelToDonExemplar_Dons : DataRelation<MonstreModel, DonExemplar> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
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
	[Table(Schema = "dd35",Name = "monstremodeltoorganisationsociale_organisationsociale")]
	public class MonstreModelToOrganisationSociale_OrganisationSociale : DataRelation<MonstreModel, OrganisationSociale> {

		[Column(Name = "fk_monstremodel_join", Storage = "MonstreModelId")]
		[HiddenProperty]
		public int MonstreModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MonstreModelId", OtherKey = "Id", CanBeNull = false, Storage = "MonstreModel")]
		public MonstreModel MonstreModel {
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
	[Table(Schema = "dd35",Name = "evolutionsfrommonstremodel")]
	public class EvolutionsFromMonstreModel : DataValue<MonstreModel, int> {

		[Column(Storage = "Evolutions",Name = "evolutions")]
		public int Evolutions{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "MonstreModelId",Name = "fk_monstremodel_from")]
		[HiddenProperty]
		public int MonstreModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public MonstreModel MonstreModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "dd35",Name = "enchantementobjetmodeltosortmodel_sortscreation")]
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
	[Table(Schema = "dd35",Name = "absarmemodeltospecialarmemodel_specialarme")]
	public class AbsArmeModelToSpecialArmeModel_SpecialArme : DataRelation<AbsArmeModel, SpecialArmeModel> {

		[Column(Name = "fk_absarmemodel_join", Storage = "AbsArmeModelId")]
		[HiddenProperty]
		public int AbsArmeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsArmeModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsArmeModel")]
		public AbsArmeModel AbsArmeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_specialarmemodel_join", Storage = "SpecialArmeModelId")]
		[HiddenProperty]
		public int SpecialArmeModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpecialArmeModelId", OtherKey = "Id", CanBeNull = false, Storage = "SpecialArmeModel")]
		public SpecialArmeModel SpecialArmeModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "typecreaturemodeltopouvoirmonstrueuxmodel_pouvoirs")]
	public class TypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs : DataRelation<TypeCreatureModel, PouvoirMonstrueuxModel> {

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

		[Column(Name = "fk_pouvoirmonstrueuxmodel_join", Storage = "PouvoirMonstrueuxModelId")]
		[HiddenProperty]
		public int PouvoirMonstrueuxModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PouvoirMonstrueuxModelId", OtherKey = "Id", CanBeNull = false, Storage = "PouvoirMonstrueuxModel")]
		public PouvoirMonstrueuxModel PouvoirMonstrueuxModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "dd35",Name = "objectmagiquemodeltosortmodel_sortscreation")]
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
	[Table(Schema = "dd35",Name = "batonmodeltosortbaton_sorts")]
	public class BatonModelToSortBaton_Sorts : DataRelation<BatonModel, SortBaton> {

		[Column(Name = "fk_batonmodel_join", Storage = "BatonModelId")]
		[HiddenProperty]
		public int BatonModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "BatonModelId", OtherKey = "Id", CanBeNull = false, Storage = "BatonModel")]
		public BatonModel BatonModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sortbaton_join", Storage = "SortBatonId")]
		[HiddenProperty]
		public int SortBatonId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortBatonId", OtherKey = "Id", CanBeNull = false, Storage = "SortBaton")]
		public SortBaton SortBaton {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
