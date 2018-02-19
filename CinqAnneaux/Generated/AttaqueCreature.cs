using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "attaquecreature")]
	[CoreData]
	public partial class AttaqueCreature : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private int _xgDegats;
		[Column(Storage = "xgDegats",Name = "xgdegats")]
		public int xgDegats{
			get{ return _xgDegats;}
			set{_xgDegats = value;}
		}

		private int _gxDegats;
		[Column(Storage = "gxDegats",Name = "gxdegats")]
		public int gxDegats{
			get{ return _gxDegats;}
			set{_gxDegats = value;}
		}

		private int _xgToucher;
		[Column(Storage = "xgToucher",Name = "xgtoucher")]
		public int xgToucher{
			get{ return _xgToucher;}
			set{_xgToucher = value;}
		}

		private int _gxToucher;
		[Column(Storage = "gxToucher",Name = "gxtoucher")]
		public int gxToucher{
			get{ return _gxToucher;}
			set{_gxToucher = value;}
		}

		private Action _action;
		[Column(Storage = "Action",Name = "action")]
		public Action Action{
			get{ return _action;}
			set{_action = value;}
		}

		private int _creatureId;
		[Column(Storage = "CreatureId",Name = "fk_creaturemodel_creature")]
		[HiddenProperty]
		public int CreatureId{
			get{ return _creatureId;}
			set{_creatureId = value;}
		}

		private CreatureModel _creature;
		public CreatureModel Creature{
			get {
				if(_creature == null) {
					_creature = LoadById<CreatureModel>(CreatureId);
			       }
				return _creature;
			} set {
				if(value == _creature) { return; }
				_creature = value;
				if(_creature != null) {
					_creatureId = _creature.Id;
				} else {
					_creatureId = 0;
				}
			}
		}
	}
}
