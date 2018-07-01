using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "scenario")]
	[CoreData]
	public partial class Scenario : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private int _rpgId;
		[Column(Storage = "RpgId",Name = "fk_rpg_rpg")]
		[HiddenProperty]
		public int RpgId{
			get{ return _rpgId;}
			set{_rpgId = value;}
		}

		private Rpg _rpg;
		public Rpg Rpg{
			get {
				if(_rpg == null) {
					_rpg = LoadById<Rpg>(RpgId);
			       }
				return _rpg;
			} set {
				if(value == _rpg) { return; }
				_rpg = value;
				if(_rpg != null) {
					_rpgId = _rpg.Id;
				} else {
					_rpgId = 0;
				}
			}
		}

		private int _gmId;
		[Column(Storage = "GmId",Name = "fk_player_gm")]
		[HiddenProperty]
		public int GmId{
			get{ return _gmId;}
			set{_gmId = value;}
		}

		private Player _gm;
		public Player Gm{
			get{
				if( _gm == null)
					_gm = LoadById<Player>(GmId);
				return _gm;
			} set {
				if(_gm == value){return;}
				_gm = value;
				if( value != null)
					GmId = value.Id;
			}
		}

		private IEnumerable<Player> _players;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Players",OtherKey = "ScenarioId")]
		public IEnumerable <Player> Players{
			get{
				if( _players == null ){
					_players = LoadFromJointure<Player,ScenarioToPlayer_Players>(false);
				}
				return _players;
			}
			set{
				SaveToJointure<Player, ScenarioToPlayer_Players> (_players, value,false);
				_players = value;
			}
		}

		private string _synopsis = "";
		[LargeText]
		[Column(Storage = "Synopsis",Name = "synopsis")]
		public string Synopsis{
			get{ return _synopsis;}
			set{_synopsis = value;}
		}

		private IEnumerable<Chapter> _chapters;
		public IEnumerable <Chapter> Chapters{
			get{
				if( _chapters == null ){
					_chapters = LoadByForeignKey<Chapter>(p => p.ScenarioId, Id);
				}
				return _chapters;
			}
			set{
				foreach( Chapter item in _chapters ){
					item.Scenario = null;

				}
				_chapters = value;
				foreach( Chapter item in value ){
					item.Scenario = this;
					item.SaveObject();
				}
			}
		}
		public override void DeleteObject() {
			DeleteJoins<Scenario,ScenarioToPlayer_Players>(true);
			base.DeleteObject();
		}
	}
}
