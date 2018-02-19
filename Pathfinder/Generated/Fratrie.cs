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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "fratrie")]
	[CoreData]
	public partial class Fratrie : DataObject {

		private int _parenteId;
		[Column(Storage = "ParenteId",Name = "fk_parentemodel_parente")]
		[HiddenProperty]
		public int ParenteId{
			get{ return _parenteId;}
			set{_parenteId = value;}
		}

		private ParenteModel _parente;
		public ParenteModel Parente{
			get {
				if(_parente == null) {
					_parente = LoadById<ParenteModel>(ParenteId);
			       }
				return _parente;
			} set {
				if(value == _parente) { return; }
				_parente = value;
				if(_parente != null) {
					_parenteId = _parente.Id;
				} else {
					_parenteId = 0;
				}
			}
		}

		private int _chances;
		[Column(Storage = "Chances",Name = "chances")]
		public int Chances{
			get{ return _chances;}
			set{_chances = value;}
		}

		private string _resultat = "";
		[LargeText]
		[Column(Storage = "Resultat",Name = "resultat")]
		public string Resultat{
			get{ return _resultat;}
			set{_resultat = value;}
		}

		private int _nbrDes;
		[Column(Storage = "NbrDes",Name = "nbrdes")]
		public int NbrDes{
			get{ return _nbrDes;}
			set{_nbrDes = value;}
		}

		private int _typeDes;
		[Column(Storage = "TypeDes",Name = "typedes")]
		public int TypeDes{
			get{ return _typeDes;}
			set{_typeDes = value;}
		}

		private int _bonus;
		[Column(Storage = "Bonus",Name = "bonus")]
		public int Bonus{
			get{ return _bonus;}
			set{_bonus = value;}
		}

		private bool _parentBiologique;
		[Column(Storage = "ParentBiologique",Name = "parentbiologique")]
		public bool ParentBiologique{
			get{ return _parentBiologique;}
			set{_parentBiologique = value;}
		}

		private int _raceId;
		[Column(Storage = "RaceId",Name = "fk_racemodel_race")]
		[HiddenProperty]
		public int RaceId{
			get{ return _raceId;}
			set{_raceId = value;}
		}

		private RaceModel _race;
		public RaceModel Race{
			get{
				if( _race == null)
					_race = LoadById<RaceModel>(RaceId);
				return _race;
			} set {
				if(_race == value){return;}
				_race = value;
				if( value != null)
					RaceId = value.Id;
			}
		}
	}
}
