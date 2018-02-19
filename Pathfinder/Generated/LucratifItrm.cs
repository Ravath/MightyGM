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
	[Table(Schema = "pathfinder",Name = "lucratifitrmmodel")]
	public abstract partial class LucratifItrmModel : ConstructibleItrmModel {

		private int _recettes;
		[Column(Storage = "Recettes",Name = "recettes")]
		public int Recettes{
			get{ return _recettes;}
			set{_recettes = value;}
		}

		private bool _recettesOr;
		[Column(Storage = "RecettesOr",Name = "recettesor")]
		public bool RecettesOr{
			get{ return _recettesOr;}
			set{_recettesOr = value;}
		}

		private bool _recettesMarchandises;
		[Column(Storage = "RecettesMarchandises",Name = "recettesmarchandises")]
		public bool RecettesMarchandises{
			get{ return _recettesMarchandises;}
			set{_recettesMarchandises = value;}
		}

		private bool _recettesInfluence;
		[Column(Storage = "RecettesInfluence",Name = "recettesinfluence")]
		public bool RecettesInfluence{
			get{ return _recettesInfluence;}
			set{_recettesInfluence = value;}
		}

		private bool _recettesTravail;
		[Column(Storage = "RecettesTravail",Name = "recettestravail")]
		public bool RecettesTravail{
			get{ return _recettesTravail;}
			set{_recettesTravail = value;}
		}

		private bool _recettesMagie;
		[Column(Storage = "RecettesMagie",Name = "recettesmagie")]
		public bool RecettesMagie{
			get{ return _recettesMagie;}
			set{_recettesMagie = value;}
		}

		private int _duree;
		[Column(Storage = "Duree",Name = "duree")]
		public int Duree{
			get{ return _duree;}
			set{_duree = value;}
		}

		private int _tailleMin;
		[Column(Storage = "TailleMin",Name = "taillemin")]
		public int TailleMin{
			get{ return _tailleMin;}
			set{_tailleMin = value;}
		}

		private int _tailleMax;
		[Column(Storage = "TailleMax",Name = "taillemax")]
		public int TailleMax{
			get{ return _tailleMax;}
			set{_tailleMax = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "lucratifitrmdescription")]
	public abstract partial class LucratifItrmDescription : ConstructibleItrmDescription {

		private string _avantage = "";
		[LargeText]
		[Column(Storage = "Avantage",Name = "avantage")]
		public string Avantage{
			get{ return _avantage;}
			set{_avantage = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "lucratifitrmexemplar")]
	public abstract partial class LucratifItrmExemplar : ConstructibleItrmExemplar {
	}
}
