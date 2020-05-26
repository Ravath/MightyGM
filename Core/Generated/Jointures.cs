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
	[Table(Schema = "core",Name = "settorawressource_ressources")]
	public class SetToRawRessource_Ressources : DataRelation<Set, RawRessource> {

		[Column(Name = "fk_set_join", Storage = "SetId")]
		[HiddenProperty]
		public int SetId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SetId", OtherKey = "Id", CanBeNull = false, Storage = "Set")]
		public Set Set {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_rawressource_join", Storage = "RawRessourceId")]
		[HiddenProperty]
		public int RawRessourceId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "RawRessourceId", OtherKey = "Id", CanBeNull = false, Storage = "RawRessource")]
		public RawRessource RawRessource {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
