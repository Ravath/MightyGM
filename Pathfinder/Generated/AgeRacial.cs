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
	[Table(Schema = "pathfinder",Name = "ageracial")]
	[CoreData]
	public partial class AgeRacial : DataObject {

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

		private int _debutJeunesse;
		[Column(Storage = "DebutJeunesse",Name = "debutjeunesse")]
		public int DebutJeunesse{
			get{ return _debutJeunesse;}
			set{_debutJeunesse = value;}
		}

		private int _debutAdulte;
		[Column(Storage = "DebutAdulte",Name = "debutadulte")]
		public int DebutAdulte{
			get{ return _debutAdulte;}
			set{_debutAdulte = value;}
		}

		private int _nbrDesPeuple;
		[Column(Storage = "NbrDesPeuple",Name = "nbrdespeuple")]
		public int NbrDesPeuple{
			get{ return _nbrDesPeuple;}
			set{_nbrDesPeuple = value;}
		}

		private int _typeDesPeuple;
		[Column(Storage = "TypeDesPeuple",Name = "typedespeuple")]
		public int TypeDesPeuple{
			get{ return _typeDesPeuple;}
			set{_typeDesPeuple = value;}
		}

		private int _nbrDesAdepte;
		[Column(Storage = "NbrDesAdepte",Name = "nbrdesadepte")]
		public int NbrDesAdepte{
			get{ return _nbrDesAdepte;}
			set{_nbrDesAdepte = value;}
		}

		private int _typeDesAdepte;
		[Column(Storage = "TypeDesAdepte",Name = "typedesadepte")]
		public int TypeDesAdepte{
			get{ return _typeDesAdepte;}
			set{_typeDesAdepte = value;}
		}
	}
}
