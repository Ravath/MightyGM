using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "nationtopersonnalite_personnalites")]
	public class NationToPersonnalite_Personnalites : DataRelation<Nation, Personnalite> {

		[Column(Name = "fk_nation_join", Storage = "NationId")]
		[HiddenProperty]
		public int NationId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "NationId", OtherKey = "Id", CanBeNull = false, Storage = "Nation")]
		public Nation Nation {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_personnalite_join", Storage = "PersonnaliteId")]
		[HiddenProperty]
		public int PersonnaliteId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PersonnaliteId", OtherKey = "Id", CanBeNull = false, Storage = "Personnalite")]
		public Personnalite Personnalite {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "nationtoville_villes")]
	public class NationToVille_Villes : DataRelation<Nation, Ville> {

		[Column(Name = "fk_nation_join", Storage = "NationId")]
		[HiddenProperty]
		public int NationId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "NationId", OtherKey = "Id", CanBeNull = false, Storage = "Nation")]
		public Nation Nation {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_ville_join", Storage = "VilleId")]
		[HiddenProperty]
		public int VilleId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "VilleId", OtherKey = "Id", CanBeNull = false, Storage = "Ville")]
		public Ville Ville {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "villetocomplexes_complexes")]
	public class VilleToComplexes_Complexes : DataRelation<Ville, Complexes> {

		[Column(Name = "fk_ville_join", Storage = "VilleId")]
		[HiddenProperty]
		public int VilleId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "VilleId", OtherKey = "Id", CanBeNull = false, Storage = "Ville")]
		public Ville Ville {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_complexes_join", Storage = "ComplexesId")]
		[HiddenProperty]
		public int ComplexesId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ComplexesId", OtherKey = "Id", CanBeNull = false, Storage = "Complexes")]
		public Complexes Complexes {
			get { return Object2; }
			set { Object2 = value; }
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
	[Table(Schema = "polaris",Name = "personnagemodeltooriginesexemplar_origines")]
	public class PersonnageModelToOriginesExemplar_Origines : DataRelation<PersonnageModel, OriginesExemplar> {

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

		[Column(Name = "fk_originesexemplar_join", Storage = "OriginesExemplarId")]
		[HiddenProperty]
		public int OriginesExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "OriginesExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "OriginesExemplar")]
		public OriginesExemplar OriginesExemplar {
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
	[Table(Schema = "polaris",Name = "originesmodeltocompetenceexemplar_competences")]
	public class OriginesModelToCompetenceExemplar_Competences : DataRelation<OriginesModel, CompetenceExemplar> {

		[Column(Name = "fk_originesmodel_join", Storage = "OriginesModelId")]
		[HiddenProperty]
		public int OriginesModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "OriginesModelId", OtherKey = "Id", CanBeNull = false, Storage = "OriginesModel")]
		public OriginesModel OriginesModel {
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
	[Table(Schema = "polaris",Name = "professionmodeltotitre_titres")]
	public class ProfessionModelToTitre_Titres : DataRelation<ProfessionModel, Titre> {

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

		[Column(Name = "fk_titre_join", Storage = "TitreId")]
		[HiddenProperty]
		public int TitreId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "TitreId", OtherKey = "Id", CanBeNull = false, Storage = "Titre")]
		public Titre Titre {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "competencemodeltospecialite_specialites")]
	public class CompetenceModelToSpecialite_Specialites : DataRelation<CompetenceModel, Specialite> {

		[Column(Name = "fk_competencemodel_join", Storage = "CompetenceModelId")]
		[HiddenProperty]
		public int CompetenceModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CompetenceModelId", OtherKey = "Id", CanBeNull = false, Storage = "CompetenceModel")]
		public CompetenceModel CompetenceModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_specialite_join", Storage = "SpecialiteId")]
		[HiddenProperty]
		public int SpecialiteId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpecialiteId", OtherKey = "Id", CanBeNull = false, Storage = "Specialite")]
		public Specialite Specialite {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "polaris",Name = "objectmodeltofabriquant_fabriquant")]
	public class ObjectModelToFabriquant_Fabriquant : DataRelation<ObjectModel, Fabriquant> {

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

		[Column(Name = "fk_fabriquant_join", Storage = "FabriquantId")]
		[HiddenProperty]
		public int FabriquantId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "FabriquantId", OtherKey = "Id", CanBeNull = false, Storage = "Fabriquant")]
		public Fabriquant Fabriquant {
			get { return Object2; }
			set { Object2 = value; }
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
