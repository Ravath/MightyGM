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
	[Table(Schema = "core",Name = "chapter")]
	[CoreData]
	public partial class Chapter : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private string _synopsis = "";
		[LargeText]
		[Column(Storage = "Synopsis",Name = "synopsis")]
		public string Synopsis{
			get{ return _synopsis;}
			set{_synopsis = value;}
		}

		private int _scenarioId;
		[Column(Storage = "ScenarioId",Name = "fk_scenario_scenario")]
		[HiddenProperty]
		public int ScenarioId{
			get{ return _scenarioId;}
			set{_scenarioId = value;}
		}

		private Scenario _scenario;
		public Scenario Scenario{
			get {
				if(_scenario == null) {
					_scenario = LoadById<Scenario>(ScenarioId);
			       }
				return _scenario;
			} set {
				if(value == _scenario) { return; }
				_scenario = value;
				if(_scenario != null) {
					_scenarioId = _scenario.Id;
				} else {
					_scenarioId = 0;
				}
			}
		}

		private IEnumerable<Session> _playedSessions;
		public IEnumerable <Session> PlayedSessions{
			get{
				if( _playedSessions == null ){
					_playedSessions = LoadByForeignKey<Session>(p => p.ChapterId, Id);
				}
				return _playedSessions;
			}
			set{
				foreach( Session item in _playedSessions ){
					item.Chapter = null;

				}
				_playedSessions = value;
				foreach( Session item in value ){
					item.Chapter = this;
					item.SaveObject();
				}
			}
		}
	}
}
