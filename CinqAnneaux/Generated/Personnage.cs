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
	[Table(Schema = "cinqanneaux",Name = "personnagemodel")]
	public abstract partial class PersonnageModel : DataModel {

		private int _reflexes;
		[Column(Storage = "Reflexes",Name = "reflexes")]
		public int Reflexes{
			get{ return _reflexes;}
			set{_reflexes = value;}
		}

		private int _intuition;
		[Column(Storage = "Intuition",Name = "intuition")]
		public int Intuition{
			get{ return _intuition;}
			set{_intuition = value;}
		}

		private int _agilite;
		[Column(Storage = "Agilite",Name = "agilite")]
		public int Agilite{
			get{ return _agilite;}
			set{_agilite = value;}
		}

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _perception;
		[Column(Storage = "Perception",Name = "perception")]
		public int Perception{
			get{ return _perception;}
			set{_perception = value;}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int _volonte;
		[Column(Storage = "Volonte",Name = "volonte")]
		public int Volonte{
			get{ return _volonte;}
			set{_volonte = value;}
		}

		private int _constitution;
		[Column(Storage = "Constitution",Name = "constitution")]
		public int Constitution{
			get{ return _constitution;}
			set{_constitution = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "personnagedescription")]
	public abstract partial class PersonnageDescription : DataDescription<PersonnageModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "personnageexemplar")]
	public abstract partial class PersonnageExemplar : DataExemplaire<PersonnageModel> {

		private int _degatsSubis;
		[Column(Storage = "DegatsSubis",Name = "degatssubis")]
		public int DegatsSubis{
			get{ return _degatsSubis;}
			set{_degatsSubis = value;}
		}
	}
}
