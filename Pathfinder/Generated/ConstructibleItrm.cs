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
	[Table(Schema = "pathfinder",Name = "constructibleitrmmodel")]
	public abstract partial class ConstructibleItrmModel : DataModel {

		private int _marchandisesCreation;
		[Column(Storage = "MarchandisesCreation",Name = "marchandisescreation")]
		public int MarchandisesCreation{
			get{ return _marchandisesCreation;}
			set{_marchandisesCreation = value;}
		}

		private int _influenceCreation;
		[Column(Storage = "InfluenceCreation",Name = "influencecreation")]
		public int InfluenceCreation{
			get{ return _influenceCreation;}
			set{_influenceCreation = value;}
		}

		private int _travailCreation;
		[Column(Storage = "TravailCreation",Name = "travailcreation")]
		public int TravailCreation{
			get{ return _travailCreation;}
			set{_travailCreation = value;}
		}

		private int _coutCreation;
		[Column(Storage = "CoutCreation",Name = "coutcreation")]
		public int CoutCreation{
			get{ return _coutCreation;}
			set{_coutCreation = value;}
		}

		private int _magieCreation;
		[Column(Storage = "MagieCreation",Name = "magiecreation")]
		public int MagieCreation{
			get{ return _magieCreation;}
			set{_magieCreation = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "constructibleitrmdescription")]
	public abstract partial class ConstructibleItrmDescription : DataDescription<ConstructibleItrmModel> {
	}
	[Table(Schema = "pathfinder",Name = "constructibleitrmexemplar")]
	public abstract partial class ConstructibleItrmExemplar : DataExemplaire<ConstructibleItrmModel> {
	}
}
