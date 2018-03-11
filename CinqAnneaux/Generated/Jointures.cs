using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "ecolemodeltocompetencestatus_competences")]
	public class EcoleModelToCompetenceStatus_Competences : DataRelation<EcoleModel, CompetenceStatus> {

		[Column(Name = "fk_ecolemodel_join", Storage = "EcoleModelId")]
		[HiddenProperty]
		public int EcoleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competencestatus_join", Storage = "CompetenceStatusId")]
		[HiddenProperty]
		public int CompetenceStatusId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceStatusId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceStatus")]
		public CompetenceStatus CompetenceStatus {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecolemodeltoapprentissageoptionnelexemplar_competencesopt")]
	public class EcoleModelToApprentissageOptionnelExemplar_CompetencesOpt : DataRelation<EcoleModel, ApprentissageOptionnelExemplar> {

		[Column(Name = "fk_ecolemodel_join", Storage = "EcoleModelId")]
		[HiddenProperty]
		public int EcoleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_apprentissageoptionnelexemplar_join", Storage = "ApprentissageOptionnelExemplarId")]
		[HiddenProperty]
		public int ApprentissageOptionnelExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ApprentissageOptionnelExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ApprentissageOptionnelExemplar")]
		public ApprentissageOptionnelExemplar ApprentissageOptionnelExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecolemodeltoabsobjetmodel_equipement")]
	public class EcoleModelToAbsObjetModel_Equipement : DataRelation<EcoleModel, AbsObjetModel> {

		[Column(Name = "fk_ecolemodel_join", Storage = "EcoleModelId")]
		[HiddenProperty]
		public int EcoleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_absobjetmodel_join", Storage = "AbsObjetModelId")]
		[HiddenProperty]
		public int AbsObjetModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AbsObjetModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsObjetModel")]
		public AbsObjetModel AbsObjetModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecolemodeltoequipementoptionnelexemplar_equipementsopt")]
	public class EcoleModelToEquipementOptionnelExemplar_EquipementsOpt : DataRelation<EcoleModel, EquipementOptionnelExemplar> {

		[Column(Name = "fk_ecolemodel_join", Storage = "EcoleModelId")]
		[HiddenProperty]
		public int EcoleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_equipementoptionnelexemplar_join", Storage = "EquipementOptionnelExemplarId")]
		[HiddenProperty]
		public int EquipementOptionnelExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EquipementOptionnelExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EquipementOptionnelExemplar")]
		public EquipementOptionnelExemplar EquipementOptionnelExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "competenceexemplartospecialisationmodel_specialisationschoisies")]
	public class CompetenceExemplarToSpecialisationModel_SpecialisationsChoisies : DataRelation<CompetenceExemplar, SpecialisationModel> {

		[Column(Name = "fk_competenceexemplar_join", Storage = "CompetenceExemplarId")]
		[HiddenProperty]
		public int CompetenceExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CompetenceExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceExemplar")]
		public CompetenceExemplar CompetenceExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_specialisationmodel_join", Storage = "SpecialisationModelId")]
		[HiddenProperty]
		public int SpecialisationModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpecialisationModelId", OtherKey = "Id", CanBeNull = false, Storage = "SpecialisationModel")]
		public SpecialisationModel SpecialisationModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "abssortmodeltoaugmentationsortexemplar_augmentations")]
	public class AbsSortModelToAugmentationSortExemplar_Augmentations : DataRelation<AbsSortModel, AugmentationSortExemplar> {

		[Column(Name = "fk_abssortmodel_join", Storage = "AbsSortModelId")]
		[HiddenProperty]
		public int AbsSortModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsSortModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsSortModel")]
		public AbsSortModel AbsSortModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_augmentationsortexemplar_join", Storage = "AugmentationSortExemplarId")]
		[HiddenProperty]
		public int AugmentationSortExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AugmentationSortExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AugmentationSortExemplar")]
		public AugmentationSortExemplar AugmentationSortExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "motclefsfromabssortmodel")]
	public class MotClefsFromAbsSortModel : DataValue<AbsSortModel, MotClefSort> {

		[Column(Storage = "MotClefs",Name = "motclefs")]
		public MotClefSort MotClefs{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "AbsSortModelId",Name = "fk_abssortmodel_from")]
		[HiddenProperty]
		public int AbsSortModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public AbsSortModel AbsSortModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "absobjetmodeltospecialobjetexemplar_special")]
	public class AbsObjetModelToSpecialObjetExemplar_Special : DataRelation<AbsObjetModel, SpecialObjetExemplar> {

		[Column(Name = "fk_absobjetmodel_join", Storage = "AbsObjetModelId")]
		[HiddenProperty]
		public int AbsObjetModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsObjetModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsObjetModel")]
		public AbsObjetModel AbsObjetModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_specialobjetexemplar_join", Storage = "SpecialObjetExemplarId")]
		[HiddenProperty]
		public int SpecialObjetExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpecialObjetExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "SpecialObjetExemplar")]
		public SpecialObjetExemplar SpecialObjetExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecoleavanceemodeltocompetencestatus_competencesrequises")]
	public class EcoleAvanceeModelToCompetenceStatus_CompetencesRequises : DataRelation<EcoleAvanceeModel, CompetenceStatus> {

		[Column(Name = "fk_ecoleavanceemodel_join", Storage = "EcoleAvanceeModelId")]
		[HiddenProperty]
		public int EcoleAvanceeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleAvanceeModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleAvanceeModel")]
		public EcoleAvanceeModel EcoleAvanceeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competencestatus_join", Storage = "CompetenceStatusId")]
		[HiddenProperty]
		public int CompetenceStatusId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceStatusId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceStatus")]
		public CompetenceStatus CompetenceStatus {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecoleavanceemodeltoconditionexemplar_conditions")]
	public class EcoleAvanceeModelToConditionExemplar_Conditions : DataRelation<EcoleAvanceeModel, ConditionExemplar> {

		[Column(Name = "fk_ecoleavanceemodel_join", Storage = "EcoleAvanceeModelId")]
		[HiddenProperty]
		public int EcoleAvanceeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleAvanceeModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleAvanceeModel")]
		public EcoleAvanceeModel EcoleAvanceeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_conditionexemplar_join", Storage = "ConditionExemplarId")]
		[HiddenProperty]
		public int ConditionExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ConditionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ConditionExemplar")]
		public ConditionExemplar ConditionExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "voiealternativemodeltocompetencestatus_competencesrequises")]
	public class VoieAlternativeModelToCompetenceStatus_CompetencesRequises : DataRelation<VoieAlternativeModel, CompetenceStatus> {

		[Column(Name = "fk_voiealternativemodel_join", Storage = "VoieAlternativeModelId")]
		[HiddenProperty]
		public int VoieAlternativeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "VoieAlternativeModelId", OtherKey = "Id", CanBeNull = false, Storage = "VoieAlternativeModel")]
		public VoieAlternativeModel VoieAlternativeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competencestatus_join", Storage = "CompetenceStatusId")]
		[HiddenProperty]
		public int CompetenceStatusId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceStatusId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceStatus")]
		public CompetenceStatus CompetenceStatus {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "voiealternativemodeltoconditionexemplar_conditions")]
	public class VoieAlternativeModelToConditionExemplar_Conditions : DataRelation<VoieAlternativeModel, ConditionExemplar> {

		[Column(Name = "fk_voiealternativemodel_join", Storage = "VoieAlternativeModelId")]
		[HiddenProperty]
		public int VoieAlternativeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "VoieAlternativeModelId", OtherKey = "Id", CanBeNull = false, Storage = "VoieAlternativeModel")]
		public VoieAlternativeModel VoieAlternativeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_conditionexemplar_join", Storage = "ConditionExemplarId")]
		[HiddenProperty]
		public int ConditionExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ConditionExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ConditionExemplar")]
		public ConditionExemplar ConditionExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "katamodeltoecolemodel_ecoles")]
	public class KataModelToEcoleModel_Ecoles : DataRelation<KataModel, EcoleModel> {

		[Column(Name = "fk_katamodel_join", Storage = "KataModelId")]
		[HiddenProperty]
		public int KataModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "KataModelId", OtherKey = "Id", CanBeNull = false, Storage = "KataModel")]
		public KataModel KataModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_ecolemodel_join", Storage = "EcoleModelId")]
		[HiddenProperty]
		public int EcoleModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "acteursfromintriguemodel")]
	public class ActeursFromIntrigueModel : DataValue<IntrigueModel, string> {

		[Column(Storage = "Acteurs",Name = "acteurs")]
		public string Acteurs{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "IntrigueModelId",Name = "fk_intriguemodel_from")]
		[HiddenProperty]
		public int IntrigueModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public IntrigueModel IntrigueModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "creaturemodeltopouvoircreatureexemplar_pouvoirs")]
	public class CreatureModelToPouvoirCreatureExemplar_Pouvoirs : DataRelation<CreatureModel, PouvoirCreatureExemplar> {

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

		[Column(Name = "fk_pouvoircreatureexemplar_join", Storage = "PouvoirCreatureExemplarId")]
		[HiddenProperty]
		public int PouvoirCreatureExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PouvoirCreatureExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "PouvoirCreatureExemplar")]
		public PouvoirCreatureExemplar PouvoirCreatureExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "creaturemodeltocompetencestatus_competences")]
	public class CreatureModelToCompetenceStatus_Competences : DataRelation<CreatureModel, CompetenceStatus> {

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

		[Column(Name = "fk_competencestatus_join", Storage = "CompetenceStatusId")]
		[HiddenProperty]
		public int CompetenceStatusId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceStatusId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceStatus")]
		public CompetenceStatus CompetenceStatus {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltocompetenceexemplar_armes")]
	public class PJModelToCompetenceExemplar_Armes : DataRelation<PJModel, CompetenceExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
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
	[Table(Schema = "cinqanneaux",Name = "pjmodeltoobjetexemplar_inventaire")]
	public class PJModelToObjetExemplar_Inventaire : DataRelation<PJModel, ObjetExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_objetexemplar_join", Storage = "ObjetExemplarId")]
		[HiddenProperty]
		public int ObjetExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ObjetExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ObjetExemplar")]
		public ObjetExemplar ObjetExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltoecoleexemplar_ecoles")]
	public class PJModelToEcoleExemplar_Ecoles : DataRelation<PJModel, EcoleExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_ecoleexemplar_join", Storage = "EcoleExemplarId")]
		[HiddenProperty]
		public int EcoleExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EcoleExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleExemplar")]
		public EcoleExemplar EcoleExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltoavantageexemplar_avantages")]
	public class PJModelToAvantageExemplar_Avantages : DataRelation<PJModel, AvantageExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
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
	[Table(Schema = "cinqanneaux",Name = "pjmodeltodesavantageexemplar_desavantages")]
	public class PJModelToDesavantageExemplar_Desavantages : DataRelation<PJModel, DesavantageExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_desavantageexemplar_join", Storage = "DesavantageExemplarId")]
		[HiddenProperty]
		public int DesavantageExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DesavantageExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "DesavantageExemplar")]
		public DesavantageExemplar DesavantageExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltocompetenceexemplar_competences")]
	public class PJModelToCompetenceExemplar_Competences : DataRelation<PJModel, CompetenceExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
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
	[Table(Schema = "cinqanneaux",Name = "pjmodeltosortmodel_sorts")]
	public class PJModelToSortModel_Sorts : DataRelation<PJModel, SortModel> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
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
	[Table(Schema = "cinqanneaux",Name = "pjmodeltomahoumodel_mahou")]
	public class PJModelToMahouModel_Mahou : DataRelation<PJModel, MahouModel> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_mahoumodel_join", Storage = "MahouModelId")]
		[HiddenProperty]
		public int MahouModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "MahouModelId", OtherKey = "Id", CanBeNull = false, Storage = "MahouModel")]
		public MahouModel MahouModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltoecoleavanceeexemplar_ecolesavancees")]
	public class PJModelToEcoleAvanceeExemplar_EcolesAvancees : DataRelation<PJModel, EcoleAvanceeExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_ecoleavanceeexemplar_join", Storage = "EcoleAvanceeExemplarId")]
		[HiddenProperty]
		public int EcoleAvanceeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EcoleAvanceeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleAvanceeExemplar")]
		public EcoleAvanceeExemplar EcoleAvanceeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltovoiealternativeexemplar_voiealternatives")]
	public class PJModelToVoieAlternativeExemplar_VoieAlternatives : DataRelation<PJModel, VoieAlternativeExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_voiealternativeexemplar_join", Storage = "VoieAlternativeExemplarId")]
		[HiddenProperty]
		public int VoieAlternativeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "VoieAlternativeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "VoieAlternativeExemplar")]
		public VoieAlternativeExemplar VoieAlternativeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltokataexemplar_katas")]
	public class PJModelToKataExemplar_Katas : DataRelation<PJModel, KataExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_kataexemplar_join", Storage = "KataExemplarId")]
		[HiddenProperty]
		public int KataExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "KataExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "KataExemplar")]
		public KataExemplar KataExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pjmodeltokihoexemplar_kihos")]
	public class PJModelToKihoExemplar_Kihos : DataRelation<PJModel, KihoExemplar> {

		[Column(Name = "fk_pjmodel_join", Storage = "PJModelId")]
		[HiddenProperty]
		public int PJModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PJModelId", OtherKey = "Id", CanBeNull = false, Storage = "PJModel")]
		public PJModel PJModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_kihoexemplar_join", Storage = "KihoExemplarId")]
		[HiddenProperty]
		public int KihoExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "KihoExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "KihoExemplar")]
		public KihoExemplar KihoExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
