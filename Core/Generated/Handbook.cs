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
	[Table(Schema = "core",Name = "handbook")]
	[CoreData]
	public partial class Handbook : DataObject {

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
	}
}
