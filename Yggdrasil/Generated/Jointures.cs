using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "personnagemodeltoruneexemplar_tirage")]
	public class PersonnageModelToRuneExemplar_Tirage : DataRelation<PersonnageModel, RuneExemplar> {

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

		[Column(Name = "fk_runeexemplar_join", Storage = "RuneExemplarId")]
		[HiddenProperty]
		public int RuneExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "RuneExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "RuneExemplar")]
		public RuneExemplar RuneExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltodonmodel_dons")]
	public class PersonnageModelToDonModel_Dons : DataRelation<PersonnageModel, DonModel> {

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
	[Table(Schema = "yggdrasil",Name = "personnagemodeltoblessureexemplar_sequelles")]
	public class PersonnageModelToBlessureExemplar_Sequelles : DataRelation<PersonnageModel, BlessureExemplar> {

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

		[Column(Name = "fk_blessureexemplar_join", Storage = "BlessureExemplarId")]
		[HiddenProperty]
		public int BlessureExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "BlessureExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "BlessureExemplar")]
		public BlessureExemplar BlessureExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltomaladieexemplar_maladies")]
	public class PersonnageModelToMaladieExemplar_Maladies : DataRelation<PersonnageModel, MaladieExemplar> {

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

		[Column(Name = "fk_maladieexemplar_join", Storage = "MaladieExemplarId")]
		[HiddenProperty]
		public int MaladieExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "MaladieExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "MaladieExemplar")]
		public MaladieExemplar MaladieExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltoprouesseexemplar_prouesses")]
	public class PersonnageModelToProuesseExemplar_Prouesses : DataRelation<PersonnageModel, ProuesseExemplar> {

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

		[Column(Name = "fk_prouesseexemplar_join", Storage = "ProuesseExemplarId")]
		[HiddenProperty]
		public int ProuesseExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ProuesseExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ProuesseExemplar")]
		public ProuesseExemplar ProuesseExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltosortsejdrmodel_sortssejdr")]
	public class PersonnageModelToSortSejdrModel_SortsSejdr : DataRelation<PersonnageModel, SortSejdrModel> {

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

		[Column(Name = "fk_sortsejdrmodel_join", Storage = "SortSejdrModelId")]
		[HiddenProperty]
		public int SortSejdrModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortSejdrModelId", OtherKey = "Id", CanBeNull = false, Storage = "SortSejdrModel")]
		public SortSejdrModel SortSejdrModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltosortgaldrmodel_sortsgaldr")]
	public class PersonnageModelToSortGaldrModel_SortsGaldr : DataRelation<PersonnageModel, SortGaldrModel> {

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

		[Column(Name = "fk_sortgaldrmodel_join", Storage = "SortGaldrModelId")]
		[HiddenProperty]
		public int SortGaldrModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortGaldrModelId", OtherKey = "Id", CanBeNull = false, Storage = "SortGaldrModel")]
		public SortGaldrModel SortGaldrModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltosortrunemodel_sortsrune")]
	public class PersonnageModelToSortRuneModel_SortsRune : DataRelation<PersonnageModel, SortRuneModel> {

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

		[Column(Name = "fk_sortrunemodel_join", Storage = "SortRuneModelId")]
		[HiddenProperty]
		public int SortRuneModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortRuneModelId", OtherKey = "Id", CanBeNull = false, Storage = "SortRuneModel")]
		public SortRuneModel SortRuneModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltoarmemodel_armes")]
	public class PersonnageModelToArmeModel_Armes : DataRelation<PersonnageModel, ArmeModel> {

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

		[Column(Name = "fk_armemodel_join", Storage = "ArmeModelId")]
		[HiddenProperty]
		public int ArmeModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArmeModelId", OtherKey = "Id", CanBeNull = false, Storage = "ArmeModel")]
		public ArmeModel ArmeModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltoarmuremodel_armures")]
	public class PersonnageModelToArmureModel_Armures : DataRelation<PersonnageModel, ArmureModel> {

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

		[Column(Name = "fk_armuremodel_join", Storage = "ArmureModelId")]
		[HiddenProperty]
		public int ArmureModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArmureModelId", OtherKey = "Id", CanBeNull = false, Storage = "ArmureModel")]
		public ArmureModel ArmureModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagemodeltoobjetquotidienmodel_objets")]
	public class PersonnageModelToObjetQuotidienModel_Objets : DataRelation<PersonnageModel, ObjetQuotidienModel> {

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

		[Column(Name = "fk_objetquotidienmodel_join", Storage = "ObjetQuotidienModelId")]
		[HiddenProperty]
		public int ObjetQuotidienModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ObjetQuotidienModelId", OtherKey = "Id", CanBeNull = false, Storage = "ObjetQuotidienModel")]
		public ObjetQuotidienModel ObjetQuotidienModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "yggdrasil",Name = "archetypemodeltocompetencemodel_competencesprivilegiees")]
	public class ArchetypeModelToCompetenceModel_CompetencesPrivilegiees : DataRelation<ArchetypeModel, CompetenceModel> {

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
	[Table(Schema = "yggdrasil",Name = "archetypeexemplartocompetencemodel_competenceschoisies")]
	public class ArchetypeExemplarToCompetenceModel_CompetencesChoisies : DataRelation<ArchetypeExemplar, CompetenceModel> {

		[Column(Name = "fk_archetypeexemplar_join", Storage = "ArchetypeExemplarId")]
		[HiddenProperty]
		public int ArchetypeExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArchetypeExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArchetypeExemplar")]
		public ArchetypeExemplar ArchetypeExemplar {
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
	[Table(Schema = "yggdrasil",Name = "figurantexemplartocaractereexemplar_caracteres")]
	public class FigurantExemplarToCaractereExemplar_Caracteres : DataRelation<FigurantExemplar, CaractereExemplar> {

		[Column(Name = "fk_figurantexemplar_join", Storage = "FigurantExemplarId")]
		[HiddenProperty]
		public int FigurantExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "FigurantExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "FigurantExemplar")]
		public FigurantExemplar FigurantExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_caractereexemplar_join", Storage = "CaractereExemplarId")]
		[HiddenProperty]
		public int CaractereExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CaractereExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CaractereExemplar")]
		public CaractereExemplar CaractereExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
