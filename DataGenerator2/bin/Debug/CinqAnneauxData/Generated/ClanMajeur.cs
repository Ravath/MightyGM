using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[CoreData]
	[Table(Schema = "cinqanneaux",Name = "clanmajeur_model")]
	public partial class ClanMajeurModel : AbsClanModel {
	}
	[Table(Schema = "cinqanneaux",Name = "clanmajeur_exemplar")]
	public partial class ClanMajeurExemplar : AbsClanExemplar {
	}
	[Table(Schema = "cinqanneaux",Name = "clanmajeur_description")]
	public partial class ClanMajeurDescription : AbsClanDescription {

		private string _perceptionCrabes;
		[LargeText]
		[Column(Storage = "PerceptionCrabes",Name = "perceptioncrabes")]
		public string PerceptionCrabes{
			get{ return _perceptionCrabes;}
			set{_perceptionCrabes = value;}
		}

		private string _perceptionDragons;
		[LargeText]
		[Column(Storage = "PerceptionDragons",Name = "perceptiondragons")]
		public string PerceptionDragons{
			get{ return _perceptionDragons;}
			set{_perceptionDragons = value;}
		}

		private string _perceptionGrues;
		[LargeText]
		[Column(Storage = "PerceptionGrues",Name = "perceptiongrues")]
		public string PerceptionGrues{
			get{ return _perceptionGrues;}
			set{_perceptionGrues = value;}
		}

		private string _perceptionLicornes;
		[LargeText]
		[Column(Storage = "PerceptionLicornes",Name = "perceptionlicornes")]
		public string PerceptionLicornes{
			get{ return _perceptionLicornes;}
			set{_perceptionLicornes = value;}
		}

		private string _perceptionLions;
		[LargeText]
		[Column(Storage = "PerceptionLions",Name = "perceptionlions")]
		public string PerceptionLions{
			get{ return _perceptionLions;}
			set{_perceptionLions = value;}
		}

		private string _perceptionMantes;
		[LargeText]
		[Column(Storage = "PerceptionMantes",Name = "perceptionmantes")]
		public string PerceptionMantes{
			get{ return _perceptionMantes;}
			set{_perceptionMantes = value;}
		}

		private string _perceptionPhenix;
		[LargeText]
		[Column(Storage = "PerceptionPhenix",Name = "perceptionphenix")]
		public string PerceptionPhenix{
			get{ return _perceptionPhenix;}
			set{_perceptionPhenix = value;}
		}

		private string _perceptionScorpions;
		[LargeText]
		[Column(Storage = "PerceptionScorpions",Name = "perceptionscorpions")]
		public string PerceptionScorpions{
			get{ return _perceptionScorpions;}
			set{_perceptionScorpions = value;}
		}
	}
}
