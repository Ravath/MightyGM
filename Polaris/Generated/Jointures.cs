using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "nationmodeltovillemodel_villes")]
	public class NationModelToVilleModel_Villes : DataRelation<NationModel, VilleModel> {

		[Column(Name = "fk_nationmodel_join", Storage = "NationModelId")]
		[HiddenProperty]
		public int NationModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "NationModelId", OtherKey = "Id", CanBeNull = false, Storage = "NationModel")]
		public NationModel NationModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_villemodel_join", Storage = "VilleModelId")]
		[HiddenProperty]
		public int VilleModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "VilleModelId", OtherKey = "Id", CanBeNull = false, Storage = "VilleModel")]
		public VilleModel VilleModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "sousdivisionfromfactiondescription")]
	public class SousDivisionFromFactionDescription : DataValue<FactionDescription, string> {

		[LargeText]
		[Column(Storage = "SousDivision",Name = "sousdivision")]
		public string SousDivision{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "FactionDescriptionId",Name = "fk_factiondescription_from")]
		[HiddenProperty]
		public int FactionDescriptionId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public FactionDescription FactionDescription{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "polaris",Name = "personnagemodeltomutationexemplar_mutations")]
	public class PersonnageModelToMutationExemplar_Mutations : DataRelation<PersonnageModel, MutationExemplar> {

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

		[Column(Name = "fk_mutationexemplar_join", Storage = "MutationExemplarId")]
		[HiddenProperty]
		public int MutationExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "MutationExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "MutationExemplar")]
		public MutationExemplar MutationExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "personnagemodeltoorigineexemplar_origines")]
	public class PersonnageModelToOrigineExemplar_Origines : DataRelation<PersonnageModel, OrigineExemplar> {

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

		[Column(Name = "fk_origineexemplar_join", Storage = "OrigineExemplarId")]
		[HiddenProperty]
		public int OrigineExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "OrigineExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "OrigineExemplar")]
		public OrigineExemplar OrigineExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "personnagemodeltocompetenceexemplar_competences")]
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
	[Table(Schema = "polaris",Name = "personnagemodeltoprofessionexemplar_professions")]
	public class PersonnageModelToProfessionExemplar_Professions : DataRelation<PersonnageModel, ProfessionExemplar> {

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

		[Column(Name = "fk_professionexemplar_join", Storage = "ProfessionExemplarId")]
		[HiddenProperty]
		public int ProfessionExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ProfessionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ProfessionExemplar")]
		public ProfessionExemplar ProfessionExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "personnagemodeltoavantageexemplar_avantages")]
	public class PersonnageModelToAvantageExemplar_Avantages : DataRelation<PersonnageModel, AvantageExemplar> {

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

		[Column(Name = "fk_avantageexemplar_join", Storage = "AvantageExemplarId")]
		[HiddenProperty]
		public int AvantageExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AvantageExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AvantageExemplar")]
		public AvantageExemplar AvantageExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "typegenetiquemodeltoplayerconditionexemplar_conditions")]
	public class TypeGenetiqueModelToPlayerConditionExemplar_Conditions : DataRelation<TypeGenetiqueModel, PlayerConditionExemplar> {

		[Column(Name = "fk_typegenetiquemodel_join", Storage = "TypeGenetiqueModelId")]
		[HiddenProperty]
		public int TypeGenetiqueModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "TypeGenetiqueModelId", OtherKey = "Id", CanBeNull = false, Storage = "TypeGenetiqueModel")]
		public TypeGenetiqueModel TypeGenetiqueModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_playerconditionexemplar_join", Storage = "PlayerConditionExemplarId")]
		[HiddenProperty]
		public int PlayerConditionExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerConditionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PlayerConditionExemplar")]
		public PlayerConditionExemplar PlayerConditionExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "typegenetiquemodeltoplayereffectexemplar_effets")]
	public class TypeGenetiqueModelToPlayerEffectExemplar_Effets : DataRelation<TypeGenetiqueModel, PlayerEffectExemplar> {

		[Column(Name = "fk_typegenetiquemodel_join", Storage = "TypeGenetiqueModelId")]
		[HiddenProperty]
		public int TypeGenetiqueModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "TypeGenetiqueModelId", OtherKey = "Id", CanBeNull = false, Storage = "TypeGenetiqueModel")]
		public TypeGenetiqueModel TypeGenetiqueModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_playereffectexemplar_join", Storage = "PlayerEffectExemplarId")]
		[HiddenProperty]
		public int PlayerEffectExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerEffectExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PlayerEffectExemplar")]
		public PlayerEffectExemplar PlayerEffectExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "mutationmodeltoplayereffectexemplar_effets")]
	public class MutationModelToPlayerEffectExemplar_Effets : DataRelation<MutationModel, PlayerEffectExemplar> {

		[Column(Name = "fk_mutationmodel_join", Storage = "MutationModelId")]
		[HiddenProperty]
		public int MutationModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MutationModelId", OtherKey = "Id", CanBeNull = false, Storage = "MutationModel")]
		public MutationModel MutationModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_playereffectexemplar_join", Storage = "PlayerEffectExemplarId")]
		[HiddenProperty]
		public int PlayerEffectExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerEffectExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PlayerEffectExemplar")]
		public PlayerEffectExemplar PlayerEffectExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "originemodeltooriginemodel_requis")]
	public class OrigineModelToOrigineModel_Requis : DataRelation<OrigineModel, OrigineModel> {

		[Column(Name = "fk_originemodel_joinrequis", Storage = "OrigineModelRequisId")]
		[HiddenProperty]
		public int OrigineModelRequisId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "OrigineModelRequisId", OtherKey = "Id", CanBeNull = false, Storage = "OrigineModelRequis")]
		public OrigineModel OrigineModelRequis {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_originemodel_join", Storage = "OrigineModelId")]
		[HiddenProperty]
		public int OrigineModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "OrigineModelId", OtherKey = "Id", CanBeNull = false, Storage = "OrigineModel")]
		public OrigineModel OrigineModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "originemodeltocompetenceexemplar_competences")]
	public class OrigineModelToCompetenceExemplar_Competences : DataRelation<OrigineModel, CompetenceExemplar> {

		[Column(Name = "fk_originemodel_join", Storage = "OrigineModelId")]
		[HiddenProperty]
		public int OrigineModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "OrigineModelId", OtherKey = "Id", CanBeNull = false, Storage = "OrigineModel")]
		public OrigineModel OrigineModel {
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
	[Table(Schema = "polaris",Name = "coutsfromavantagemodel")]
	public class CoutsFromAvantageModel : DataValue<AvantageModel, int> {

		[Column(Storage = "Couts",Name = "couts")]
		public int Couts{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "AvantageModelId",Name = "fk_avantagemodel_from")]
		[HiddenProperty]
		public int AvantageModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public AvantageModel AvantageModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "polaris",Name = "avantagemodeltoplayereffectmodel_effets")]
	public class AvantageModelToPlayerEffectModel_Effets : DataRelation<AvantageModel, PlayerEffectModel> {

		[Column(Name = "fk_avantagemodel_join", Storage = "AvantageModelId")]
		[HiddenProperty]
		public int AvantageModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AvantageModelId", OtherKey = "Id", CanBeNull = false, Storage = "AvantageModel")]
		public AvantageModel AvantageModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_playereffectmodel_join", Storage = "PlayerEffectModelId")]
		[HiddenProperty]
		public int PlayerEffectModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerEffectModelId", OtherKey = "Id", CanBeNull = false, Storage = "PlayerEffectModel")]
		public PlayerEffectModel PlayerEffectModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "professionmodeltoplayerconditionexemplar_requis")]
	public class ProfessionModelToPlayerConditionExemplar_Requis : DataRelation<ProfessionModel, PlayerConditionExemplar> {

		[Column(Name = "fk_professionmodel_join", Storage = "ProfessionModelId")]
		[HiddenProperty]
		public int ProfessionModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ProfessionModelId", OtherKey = "Id", CanBeNull = false, Storage = "ProfessionModel")]
		public ProfessionModel ProfessionModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_playerconditionexemplar_join", Storage = "PlayerConditionExemplarId")]
		[HiddenProperty]
		public int PlayerConditionExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerConditionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PlayerConditionExemplar")]
		public PlayerConditionExemplar PlayerConditionExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "professionmodeltocompetencemodel_competences")]
	public class ProfessionModelToCompetenceModel_Competences : DataRelation<ProfessionModel, CompetenceModel> {

		[Column(Name = "fk_professionmodel_join", Storage = "ProfessionModelId")]
		[HiddenProperty]
		public int ProfessionModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ProfessionModelId", OtherKey = "Id", CanBeNull = false, Storage = "ProfessionModel")]
		public ProfessionModel ProfessionModel {
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
	[Table(Schema = "polaris",Name = "professionmodeltoavantagepromodel_avantagespro")]
	public class ProfessionModelToAvantageProModel_AvantagesPro : DataRelation<ProfessionModel, AvantageProModel> {

		[Column(Name = "fk_professionmodel_join", Storage = "ProfessionModelId")]
		[HiddenProperty]
		public int ProfessionModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ProfessionModelId", OtherKey = "Id", CanBeNull = false, Storage = "ProfessionModel")]
		public ProfessionModel ProfessionModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_avantagepromodel_join", Storage = "AvantageProModelId")]
		[HiddenProperty]
		public int AvantageProModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AvantageProModelId", OtherKey = "Id", CanBeNull = false, Storage = "AvantageProModel")]
		public AvantageProModel AvantageProModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "professionmodeltocategoriematerielmodel_materielaccessible")]
	public class ProfessionModelToCategorieMaterielModel_MaterielAccessible : DataRelation<ProfessionModel, CategorieMaterielModel> {

		[Column(Name = "fk_professionmodel_join", Storage = "ProfessionModelId")]
		[HiddenProperty]
		public int ProfessionModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ProfessionModelId", OtherKey = "Id", CanBeNull = false, Storage = "ProfessionModel")]
		public ProfessionModel ProfessionModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_categoriematerielmodel_join", Storage = "CategorieMaterielModelId")]
		[HiddenProperty]
		public int CategorieMaterielModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CategorieMaterielModelId", OtherKey = "Id", CanBeNull = false, Storage = "CategorieMaterielModel")]
		public CategorieMaterielModel CategorieMaterielModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "avantageproaleatoiremodeltoplayereffectexemplar_effects")]
	public class AvantageProAleatoireModelToPlayerEffectExemplar_Effects : DataRelation<AvantageProAleatoireModel, PlayerEffectExemplar> {

		[Column(Name = "fk_avantageproaleatoiremodel_join", Storage = "AvantageProAleatoireModelId")]
		[HiddenProperty]
		public int AvantageProAleatoireModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AvantageProAleatoireModelId", OtherKey = "Id", CanBeNull = false, Storage = "AvantageProAleatoireModel")]
		public AvantageProAleatoireModel AvantageProAleatoireModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_playereffectexemplar_join", Storage = "PlayerEffectExemplarId")]
		[HiddenProperty]
		public int PlayerEffectExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerEffectExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PlayerEffectExemplar")]
		public PlayerEffectExemplar PlayerEffectExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "reversdefortunemodeltoplayereffectexemplar_effects")]
	public class ReversDeFortuneModelToPlayerEffectExemplar_Effects : DataRelation<ReversDeFortuneModel, PlayerEffectExemplar> {

		[Column(Name = "fk_reversdefortunemodel_join", Storage = "ReversDeFortuneModelId")]
		[HiddenProperty]
		public int ReversDeFortuneModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ReversDeFortuneModelId", OtherKey = "Id", CanBeNull = false, Storage = "ReversDeFortuneModel")]
		public ReversDeFortuneModel ReversDeFortuneModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_playereffectexemplar_join", Storage = "PlayerEffectExemplarId")]
		[HiddenProperty]
		public int PlayerEffectExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerEffectExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PlayerEffectExemplar")]
		public PlayerEffectExemplar PlayerEffectExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "abscompetencemodeltocompetenceexemplar_prerequis")]
	public class AbsCompetenceModelToCompetenceExemplar_Prerequis : DataRelation<AbsCompetenceModel, CompetenceExemplar> {

		[Column(Name = "fk_abscompetencemodel_join", Storage = "AbsCompetenceModelId")]
		[HiddenProperty]
		public int AbsCompetenceModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsCompetenceModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsCompetenceModel")]
		public AbsCompetenceModel AbsCompetenceModel {
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
	[Table(Schema = "polaris",Name = "objectmodeltofabriquantmodel_fabriquant")]
	public class ObjectModelToFabriquantModel_Fabriquant : DataRelation<ObjectModel, FabriquantModel> {

		[Column(Name = "fk_objectmodel_join", Storage = "ObjectModelId")]
		[HiddenProperty]
		public int ObjectModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ObjectModelId", OtherKey = "Id", CanBeNull = false, Storage = "ObjectModel")]
		public ObjectModel ObjectModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_fabriquantmodel_join", Storage = "FabriquantModelId")]
		[HiddenProperty]
		public int FabriquantModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "FabriquantModelId", OtherKey = "Id", CanBeNull = false, Storage = "FabriquantModel")]
		public FabriquantModel FabriquantModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "materielmodeltoobjecteffectexemplar_effects")]
	public class MaterielModelToObjectEffectExemplar_Effects : DataRelation<MaterielModel, ObjectEffectExemplar> {

		[Column(Name = "fk_materielmodel_join", Storage = "MaterielModelId")]
		[HiddenProperty]
		public int MaterielModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "MaterielModelId", OtherKey = "Id", CanBeNull = false, Storage = "MaterielModel")]
		public MaterielModel MaterielModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_objecteffectexemplar_join", Storage = "ObjectEffectExemplarId")]
		[HiddenProperty]
		public int ObjectEffectExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ObjectEffectExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ObjectEffectExemplar")]
		public ObjectEffectExemplar ObjectEffectExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "absarmemodeltospecialarmeexemplar_special")]
	public class AbsArmeModelToSpecialArmeExemplar_Special : DataRelation<AbsArmeModel, SpecialArmeExemplar> {

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
	[Table(Schema = "polaris",Name = "modetirfromarmedistancemodel")]
	public class ModeTirFromArmeDistanceModel : DataValue<ArmeDistanceModel, ModeTir> {

		[Column(Storage = "ModeTir",Name = "modetir")]
		public ModeTir ModeTir{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "ArmeDistanceModelId",Name = "fk_armedistancemodel_from")]
		[HiddenProperty]
		public int ArmeDistanceModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public ArmeDistanceModel ArmeDistanceModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "polaris",Name = "modetirfromlancetorpillemodel")]
	public class ModeTirFromLanceTorpilleModel : DataValue<LanceTorpilleModel, ModeTir> {

		[Column(Storage = "ModeTir",Name = "modetir")]
		public ModeTir ModeTir{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "LanceTorpilleModelId",Name = "fk_lancetorpillemodel_from")]
		[HiddenProperty]
		public int LanceTorpilleModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public LanceTorpilleModel LanceTorpilleModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "polaris",Name = "creaturemodeltolocalisationcreaturemodel_localisations")]
	public class CreatureModelToLocalisationCreatureModel_Localisations : DataRelation<CreatureModel, LocalisationCreatureModel> {

		[Column(Name = "fk_creaturemodel_join", Storage = "CreatureModelId")]
		[HiddenProperty]
		public int CreatureModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "CreatureModel")]
		public CreatureModel CreatureModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_localisationcreaturemodel_join", Storage = "LocalisationCreatureModelId")]
		[HiddenProperty]
		public int LocalisationCreatureModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "LocalisationCreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "LocalisationCreatureModel")]
		public LocalisationCreatureModel LocalisationCreatureModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "creaturemodeltocompetenceexemplar_competences")]
	public class CreatureModelToCompetenceExemplar_Competences : DataRelation<CreatureModel, CompetenceExemplar> {

		[Column(Name = "fk_creaturemodel_join", Storage = "CreatureModelId")]
		[HiddenProperty]
		public int CreatureModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "CreatureModel")]
		public CreatureModel CreatureModel {
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
	[Table(Schema = "polaris",Name = "creaturemodeltoattaquecreatureexemplar_attaquescreature")]
	public class CreatureModelToAttaqueCreatureExemplar_AttaquesCreature : DataRelation<CreatureModel, AttaqueCreatureExemplar> {

		[Column(Name = "fk_creaturemodel_join", Storage = "CreatureModelId")]
		[HiddenProperty]
		public int CreatureModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "CreatureModel")]
		public CreatureModel CreatureModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_attaquecreatureexemplar_join", Storage = "AttaqueCreatureExemplarId")]
		[HiddenProperty]
		public int AttaqueCreatureExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AttaqueCreatureExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AttaqueCreatureExemplar")]
		public AttaqueCreatureExemplar AttaqueCreatureExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "creaturemodeltospecialcreatureexemplar_specialcreature")]
	public class CreatureModelToSpecialCreatureExemplar_SpecialCreature : DataRelation<CreatureModel, SpecialCreatureExemplar> {

		[Column(Name = "fk_creaturemodel_join", Storage = "CreatureModelId")]
		[HiddenProperty]
		public int CreatureModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CreatureModelId", OtherKey = "Id", CanBeNull = false, Storage = "CreatureModel")]
		public CreatureModel CreatureModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_specialcreatureexemplar_join", Storage = "SpecialCreatureExemplarId")]
		[HiddenProperty]
		public int SpecialCreatureExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpecialCreatureExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "SpecialCreatureExemplar")]
		public SpecialCreatureExemplar SpecialCreatureExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
