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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "branchearborescence")]
	[CoreData]
	public partial class BrancheArborescence : DataObject {

		private int _arborescenceId;
		[Column(Storage = "ArborescenceId",Name = "fk_arborescence")]
		[HiddenProperty]
		public int ArborescenceId{
			get{ return _arborescenceId;}
			set{_arborescenceId = value;}
		}

		private Arborescence _arborescence;
		public Arborescence Arborescence{
			get {
				if(_arborescence == null) {
					_arborescence = LoadById<Arborescence>(ArborescenceId);
			       }
				return _arborescence;
			} set {
				if(value == _arborescence) { return; }
				_arborescence = value;
				if(_arborescence != null) {
					_arborescenceId = _arborescence.Id;
				} else {
					_arborescenceId = 0;
				}
			}
		}

		private bool _horizontal;
		[Column(Storage = "horizontal",Name = "horizontal")]
		public bool horizontal{
			get{ return _horizontal;}
			set{_horizontal = value;}
		}

		private int _ligne;
		[Column(Storage = "ligne",Name = "ligne")]
		public int ligne{
			get{ return _ligne;}
			set{_ligne = value;}
		}

		private int _colonne;
		[Column(Storage = "colonne",Name = "colonne")]
		public int colonne{
			get{ return _colonne;}
			set{_colonne = value;}
		}
	}
}
