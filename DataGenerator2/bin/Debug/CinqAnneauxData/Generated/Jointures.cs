namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "competencemodeltomaitrisemodel")]
	public class CompetenceModelToMaitriseModel : DataRelation<CompetenceModel, MaitriseModel> {

		[Column(Name = "fk_competencemodel", Storage = "CompetenceModelId")]
		public int CompetenceModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CompetenceModelId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceModel")]
		public EcoleModel CompetenceModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_maitrisemodel", Storage = "MaitriseModelId")]
		public int MaitriseModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "MaitriseModelId", OtherKey = "Id", CanBeNull = false, Storage = "MaitriseModel")]
		public EcoleModel MaitriseModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "abssortmodeltoaugmentationsortmodel")]
	public class AbsSortModelToAugmentationSortModel : DataRelation<AbsSortModel, AugmentationSortModel> {

		[Column(Name = "fk_abssortmodel", Storage = "AbsSortModelId")]
		public int AbsSortModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsSortModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsSortModel")]
		public EcoleModel AbsSortModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_augmentationsortmodel", Storage = "AugmentationSortModelId")]
		public int AugmentationSortModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AugmentationSortModelId", OtherKey = "Id", CanBeNull = false, Storage = "AugmentationSortModel")]
		public EcoleModel AugmentationSortModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecolemodeltocompetenceexemplar")]
	public class EcoleModelToCompetenceExemplar : DataRelation<EcoleModel, CompetenceExemplar> {

		[Column(Name = "fk_ecolemodel", Storage = "EcoleModelId")]
		public int EcoleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_competenceexemplar", Storage = "CompetenceExemplarId")]
		public int CompetenceExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CompetenceExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceExemplar")]
		public EcoleModel CompetenceExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecolemodeltoabsobjetmodel")]
	public class EcoleModelToAbsObjetModel : DataRelation<EcoleModel, AbsObjetModel> {

		[Column(Name = "fk_ecolemodel", Storage = "EcoleModelId")]
		public int EcoleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_absobjetmodel", Storage = "AbsObjetModelId")]
		public int AbsObjetModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AbsObjetModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsObjetModel")]
		public EcoleModel AbsObjetModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecolemodeltosortmodel")]
	public class EcoleModelToSortModel : DataRelation<EcoleModel, SortModel> {

		[Column(Name = "fk_ecolemodel", Storage = "EcoleModelId")]
		public int EcoleModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "EcoleModelId", OtherKey = "Id", CanBeNull = false, Storage = "EcoleModel")]
		public EcoleModel EcoleModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_sortmodel", Storage = "SortModelId")]
		public int SortModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SortModelId", OtherKey = "Id", CanBeNull = false, Storage = "SortModel")]
		public EcoleModel SortModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "cinqanneaux",Name = "katamodeltoecolemodel")]
	public class KataModelToEcoleModel : DataRelation<KataModel, EcoleModel> {

		[Column(Name = "fk_katamodel", Storage = "KataModelId")]
		public int KataModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "KataModelId", OtherKey = "Id", CanBeNull = false, Storage = "KataModel")]
		public EcoleModel KataModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_ecolemodel", Storage = "EcoleModelId")]
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
}
