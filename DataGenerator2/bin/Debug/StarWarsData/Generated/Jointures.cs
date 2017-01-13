using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "racemodeltocapacitemodel")]
	public class RaceModelToCapaciteModel : DataRelation<RaceModel, CapaciteModel> {

		[Column(Name = "fk_racemodel", Storage = "RaceModelId")]
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

		[Column(Name = "fk_capacitemodel", Storage = "CapaciteModelId")]
		[HiddenProperty]
		public int CapaciteModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CapaciteModelId", OtherKey = "Id", CanBeNull = false, Storage = "CapaciteModel")]
		public CapaciteModel CapaciteModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "carrieremodeltocompetencemodel")]
	public class CarriereModelToCompetenceModel : DataRelation<CarriereModel, CompetenceModel> {

		[Column(Name = "fk_carrieremodel", Storage = "CarriereModelId")]
		[HiddenProperty]
		public int CarriereModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CarriereModelId", OtherKey = "Id", CanBeNull = false, Storage = "CarriereModel")]
		public CarriereModel CarriereModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competencemodel", Storage = "CompetenceModelId")]
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
	[Table(Schema = "starwars",Name = "specialitemodeltocompetencemodel")]
	public class SpecialiteModelToCompetenceModel : DataRelation<SpecialiteModel, CompetenceModel> {

		[Column(Name = "fk_specialitemodel", Storage = "SpecialiteModelId")]
		[HiddenProperty]
		public int SpecialiteModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SpecialiteModelId", OtherKey = "Id", CanBeNull = false, Storage = "SpecialiteModel")]
		public SpecialiteModel SpecialiteModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competencemodel", Storage = "CompetenceModelId")]
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
	[Table(Schema = "starwars",Name = "exempleutilisationfromcompetencedescription")]
	public class ExempleUtilisationFromCompetenceDescription : DataValue<CompetenceDescription, string> {

		[LargeText]
		[Column(Storage = "ExempleUtilisation",Name = "exempleutilisation")]
		public string ExempleUtilisation{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "CompetenceDescriptionId",Name = "fk_competencedescription")]
		[HiddenProperty]
		public int CompetenceDescriptionId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public CompetenceDescription CompetenceDescription{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "starwars",Name = "talentmodeltoarborescencedespecialite")]
	public class TalentModelToArborescenceDeSpecialite : DataRelation<TalentModel, ArborescenceDeSpecialite> {

		[Column(Name = "fk_talentmodel", Storage = "TalentModelId")]
		[HiddenProperty]
		public int TalentModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "TalentModelId", OtherKey = "Id", CanBeNull = false, Storage = "TalentModel")]
		public TalentModel TalentModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_arborescencedespecialite", Storage = "ArborescenceDeSpecialiteId")]
		[HiddenProperty]
		public int ArborescenceDeSpecialiteId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArborescenceDeSpecialiteId", OtherKey = "Id", CanBeNull = false, Storage = "ArborescenceDeSpecialite")]
		public ArborescenceDeSpecialite ArborescenceDeSpecialite {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "modelesfromobjectmodel")]
	public class ModelesFromObjectModel : DataValue<ObjectModel, string> {

		[Column(Storage = "Modeles",Name = "modeles")]
		public string Modeles{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "ObjectModelId",Name = "fk_objectmodel")]
		[HiddenProperty]
		public int ObjectModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public ObjectModel ObjectModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "starwars",Name = "vehiculemodeltoarmedevehiculeexemplar")]
	public class VehiculeModelToArmeDeVehiculeExemplar : DataRelation<VehiculeModel, ArmeDeVehiculeExemplar> {

		[Column(Name = "fk_vehiculemodel", Storage = "VehiculeModelId")]
		[HiddenProperty]
		public int VehiculeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "VehiculeModelId", OtherKey = "Id", CanBeNull = false, Storage = "VehiculeModel")]
		public VehiculeModel VehiculeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_armedevehiculeexemplar", Storage = "ArmeDeVehiculeExemplarId")]
		[HiddenProperty]
		public int ArmeDeVehiculeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArmeDeVehiculeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeDeVehiculeExemplar")]
		public ArmeDeVehiculeExemplar ArmeDeVehiculeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "vehiculemodeltoequipageexemplar")]
	public class VehiculeModelToEquipageExemplar : DataRelation<VehiculeModel, EquipageExemplar> {

		[Column(Name = "fk_vehiculemodel", Storage = "VehiculeModelId")]
		[HiddenProperty]
		public int VehiculeModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "VehiculeModelId", OtherKey = "Id", CanBeNull = false, Storage = "VehiculeModel")]
		public VehiculeModel VehiculeModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_equipageexemplar", Storage = "EquipageExemplarId")]
		[HiddenProperty]
		public int EquipageExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "EquipageExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "EquipageExemplar")]
		public EquipageExemplar EquipageExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "pouvoirforcedescriptiontoameliorationdecontrole")]
	public class PouvoirForceDescriptionToAmeliorationDeControle : DataRelation<PouvoirForceDescription, AmeliorationDeControle> {

		[Column(Name = "fk_pouvoirforcedescription", Storage = "PouvoirForceDescriptionId")]
		[HiddenProperty]
		public int PouvoirForceDescriptionId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "PouvoirForceDescriptionId", OtherKey = "Id", CanBeNull = false, Storage = "PouvoirForceDescription")]
		public PouvoirForceDescription PouvoirForceDescription {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_ameliorationdecontrole", Storage = "AmeliorationDeControleId")]
		[HiddenProperty]
		public int AmeliorationDeControleId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AmeliorationDeControleId", OtherKey = "Id", CanBeNull = false, Storage = "AmeliorationDeControle")]
		public AmeliorationDeControle AmeliorationDeControle {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "armemodeltoattributarmeexemplar")]
	public class ArmeModelToAttributArmeExemplar : DataRelation<ArmeModel, AttributArmeExemplar> {

		[Column(Name = "fk_armemodel", Storage = "ArmeModelId")]
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

		[Column(Name = "fk_attributarmeexemplar", Storage = "AttributArmeExemplarId")]
		[HiddenProperty]
		public int AttributArmeExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AttributArmeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AttributArmeExemplar")]
		public AttributArmeExemplar AttributArmeExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "armeexemplartokitexemplar")]
	public class ArmeExemplarToKitExemplar : DataRelation<ArmeExemplar, KitExemplar> {

		[Column(Name = "fk_armeexemplar", Storage = "ArmeExemplarId")]
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

		[Column(Name = "fk_kitexemplar", Storage = "KitExemplarId")]
		[HiddenProperty]
		public int KitExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "KitExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "KitExemplar")]
		public KitExemplar KitExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "kitmodeltomodmodel")]
	public class KitModelToModModel : DataRelation<KitModel, ModModel> {

		[Column(Name = "fk_kitmodel", Storage = "KitModelId")]
		[HiddenProperty]
		public int KitModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "KitModelId", OtherKey = "Id", CanBeNull = false, Storage = "KitModel")]
		public KitModel KitModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_modmodel", Storage = "ModModelId")]
		[HiddenProperty]
		public int ModModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ModModelId", OtherKey = "Id", CanBeNull = false, Storage = "ModModel")]
		public ModModel ModModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "starwars",Name = "kitexemplartomodexemplar")]
	public class KitExemplarToModExemplar : DataRelation<KitExemplar, ModExemplar> {

		[Column(Name = "fk_kitexemplar", Storage = "KitExemplarId")]
		[HiddenProperty]
		public int KitExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "KitExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "KitExemplar")]
		public KitExemplar KitExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_modexemplar", Storage = "ModExemplarId")]
		[HiddenProperty]
		public int ModExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ModExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ModExemplar")]
		public ModExemplar ModExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
