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
	[Table(Schema = "cinqanneaux",Name = "absavantage_model")]
	public partial class AbsAvantageModel : DataModel {

		private SousTypeAvantage _SousType;
		[Column(Storage = "SousType",Name = "soustype")]
		public SousTypeAvantage SousType{
			get{ return _SousType;}
			set{_SousType = value;}
		}

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}

		private ModeDepenseAvantage _Mode;
		[Column(Storage = "Mode",Name = "mode")]
		public ModeDepenseAvantage Mode{
			get{ return _Mode;}
			set{_Mode = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "absavantage_exemplar")]
	public partial class AbsAvantageExemplar : DataExemplaire<AbsAvantageModel> {

		private int _nbrRangs;
		[Column(Storage = "NbrRangs",Name = "nbrrangs")]
		public int NbrRangs{
			get{ return _nbrRangs;}
			set{_nbrRangs = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "absavantage_description")]
	public partial class AbsAvantageDescription : DataDescription<AbsAvantageModel> {
	}
}
