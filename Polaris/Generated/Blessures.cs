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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "blessures")]
	[CoreData]
	public partial class Blessures : DataObject {

		private int _legeres;
		[Column(Storage = "Legeres",Name = "legeres")]
		public int Legeres{
			get{ return _legeres;}
			set{_legeres = value;}
		}

		private int _moyennes;
		[Column(Storage = "Moyennes",Name = "moyennes")]
		public int Moyennes{
			get{ return _moyennes;}
			set{_moyennes = value;}
		}

		private int _graves;
		[Column(Storage = "Graves",Name = "graves")]
		public int Graves{
			get{ return _graves;}
			set{_graves = value;}
		}

		private int _critiques;
		[Column(Storage = "Critiques",Name = "critiques")]
		public int Critiques{
			get{ return _critiques;}
			set{_critiques = value;}
		}

		private int _mortelles;
		[Column(Storage = "Mortelles",Name = "mortelles")]
		public int Mortelles{
			get{ return _mortelles;}
			set{_mortelles = value;}
		}

		private bool _detruit;
		[Column(Storage = "Detruit",Name = "detruit")]
		public bool Detruit{
			get{ return _detruit;}
			set{_detruit = value;}
		}
	}
}
