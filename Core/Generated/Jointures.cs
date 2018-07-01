using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "scenariotoplayer_players")]
	public class ScenarioToPlayer_Players : DataRelation<Scenario, Player> {

		[Column(Name = "fk_scenario_join", Storage = "ScenarioId")]
		[HiddenProperty]
		public int ScenarioId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ScenarioId", OtherKey = "Id", CanBeNull = false, Storage = "Scenario")]
		public Scenario Scenario {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_player_join", Storage = "PlayerId")]
		[HiddenProperty]
		public int PlayerId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerId", OtherKey = "Id", CanBeNull = false, Storage = "Player")]
		public Player Player {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "core",Name = "sessiontoplayer_playersatthesession")]
	public class SessionToPlayer_PlayersAtTheSession : DataRelation<Session, Player> {

		[Column(Name = "fk_session_join", Storage = "SessionId")]
		[HiddenProperty]
		public int SessionId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SessionId", OtherKey = "Id", CanBeNull = false, Storage = "Session")]
		public Session Session {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_player_join", Storage = "PlayerId")]
		[HiddenProperty]
		public int PlayerId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "PlayerId", OtherKey = "Id", CanBeNull = false, Storage = "Player")]
		public Player Player {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "core",Name = "ressourcetotag_tags")]
	public class RessourceToTag_Tags : DataRelation<Ressource, Tag> {

		[Column(Name = "fk_ressource_join", Storage = "RessourceId")]
		[HiddenProperty]
		public int RessourceId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "RessourceId", OtherKey = "Id", CanBeNull = false, Storage = "Ressource")]
		public Ressource Ressource {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_tag_join", Storage = "TagId")]
		[HiddenProperty]
		public int TagId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "TagId", OtherKey = "Id", CanBeNull = false, Storage = "Tag")]
		public Tag Tag {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "core",Name = "documenttoparagraph_paragraphs")]
	public class DocumentToParagraph_Paragraphs : DataRelation<Document, Paragraph> {

		[Column(Name = "fk_document_join", Storage = "DocumentId")]
		[HiddenProperty]
		public int DocumentId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "DocumentId", OtherKey = "Id", CanBeNull = false, Storage = "Document")]
		public Document Document {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_paragraph_join", Storage = "ParagraphId")]
		[HiddenProperty]
		public int ParagraphId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ParagraphId", OtherKey = "Id", CanBeNull = false, Storage = "Paragraph")]
		public Paragraph Paragraph {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "core",Name = "documenttodocument_subdocs")]
	public class DocumentToDocument_SubDocs : DataRelation<Document, Document> {

		[Column(Name = "fk_document_joinsubdocs", Storage = "DocumentSubDocsId")]
		[HiddenProperty]
		public int DocumentSubDocsId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "DocumentSubDocsId", OtherKey = "Id", CanBeNull = false, Storage = "DocumentSubDocs")]
		public Document DocumentSubDocs {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_document_join", Storage = "DocumentId")]
		[HiddenProperty]
		public int DocumentId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DocumentId", OtherKey = "Id", CanBeNull = false, Storage = "Document")]
		public Document Document {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "core",Name = "filteredtracktosoundfilter_filters")]
	public class FilteredTrackToSoundFilter_Filters : DataRelation<FilteredTrack, SoundFilter> {

		[Column(Name = "fk_filteredtrack_join", Storage = "FilteredTrackId")]
		[HiddenProperty]
		public int FilteredTrackId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "FilteredTrackId", OtherKey = "Id", CanBeNull = false, Storage = "FilteredTrack")]
		public FilteredTrack FilteredTrack {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_soundfilter_join", Storage = "SoundFilterId")]
		[HiddenProperty]
		public int SoundFilterId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SoundFilterId", OtherKey = "Id", CanBeNull = false, Storage = "SoundFilter")]
		public SoundFilter SoundFilter {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
