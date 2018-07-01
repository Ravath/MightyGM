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
	[Table(Schema = "core",Name = "session")]
	[CoreData]
	public partial class Session : DataObject {

		private int _chapterId;
		[Column(Storage = "ChapterId",Name = "fk_chapter_chapter")]
		[HiddenProperty]
		public int ChapterId{
			get{ return _chapterId;}
			set{_chapterId = value;}
		}

		private Chapter _chapter;
		public Chapter Chapter{
			get {
				if(_chapter == null) {
					_chapter = LoadById<Chapter>(ChapterId);
			       }
				return _chapter;
			} set {
				if(value == _chapter) { return; }
				_chapter = value;
				if(_chapter != null) {
					_chapterId = _chapter.Id;
				} else {
					_chapterId = 0;
				}
			}
		}

		private DateTime _startSession;
		[Column(Storage = "StartSession",Name = "startsession")]
		public DateTime StartSession{
			get{ return _startSession;}
			set{_startSession = value;}
		}

		private DateTime _endSession;
		[Column(Storage = "EndSession",Name = "endsession")]
		public DateTime EndSession{
			get{ return _endSession;}
			set{_endSession = value;}
		}

		private string _playerSummary = "";
		[LargeText]
		[Column(Storage = "PlayerSummary",Name = "playersummary")]
		public string PlayerSummary{
			get{ return _playerSummary;}
			set{_playerSummary = value;}
		}

		private string _gmNotes = "";
		[LargeText]
		[Column(Storage = "GmNotes",Name = "gmnotes")]
		public string GmNotes{
			get{ return _gmNotes;}
			set{_gmNotes = value;}
		}

		private IEnumerable<Player> _playersAtTheSession;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "PlayersAtTheSession",OtherKey = "SessionId")]
		public IEnumerable <Player> PlayersAtTheSession{
			get{
				if( _playersAtTheSession == null ){
					_playersAtTheSession = LoadFromJointure<Player,SessionToPlayer_PlayersAtTheSession>(false);
				}
				return _playersAtTheSession;
			}
			set{
				SaveToJointure<Player, SessionToPlayer_PlayersAtTheSession> (_playersAtTheSession, value,false);
				_playersAtTheSession = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<Session,SessionToPlayer_PlayersAtTheSession>(true);
			base.DeleteObject();
		}
	}
}
