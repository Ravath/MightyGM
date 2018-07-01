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
	[Table(Schema = "core",Name = "rpg")]
	[CoreData]
	public partial class Rpg : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private IEnumerable<Scenario> _scenarios;
		public IEnumerable <Scenario> Scenarios{
			get{
				if( _scenarios == null ){
					_scenarios = LoadByForeignKey<Scenario>(p => p.RpgId, Id);
				}
				return _scenarios;
			}
			set{
				foreach( Scenario item in _scenarios ){
					item.Rpg = null;

				}
				_scenarios = value;
				foreach( Scenario item in value ){
					item.Rpg = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<Handbook> _handbooks;
		public IEnumerable <Handbook> Handbooks{
			get{
				if( _handbooks == null ){
					_handbooks = LoadByForeignKey<Handbook>(p => p.RpgId, Id);
				}
				return _handbooks;
			}
			set{
				foreach( Handbook item in _handbooks ){
					item.Rpg = null;

				}
				_handbooks = value;
				foreach( Handbook item in value ){
					item.Rpg = this;
					item.SaveObject();
				}
			}
		}
	}
}
