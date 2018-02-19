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
	[Table(Schema = "cinqanneaux",Name = "absavantagemodel")]
	public abstract partial class AbsAvantageModel : DataModel {

		private SousTypeAvantage _sousType;
		[Column(Storage = "SousType",Name = "soustype")]
		public SousTypeAvantage SousType{
			get{ return _sousType;}
			set{_sousType = value;}
		}

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}

		private int _rangMax;
		[Column(Storage = "RangMax",Name = "rangmax")]
		public int RangMax{
			get{ return _rangMax;}
			set{_rangMax = value;}
		}

		private int _groupeId;
		[Column(Storage = "GroupeId",Name = "fk_groupeavantagemodel_groupe")]
		[HiddenProperty]
		public int GroupeId{
			get{ return _groupeId;}
			set{_groupeId = value;}
		}

		private GroupeAvantageModel _groupe;
		public GroupeAvantageModel Groupe{
			get {
				if(_groupe == null) {
					_groupe = LoadById<GroupeAvantageModel>(GroupeId);
			       }
				return _groupe;
			} set {
				if(value == _groupe) { return; }
				_groupe = value;
				if(_groupe != null) {
					_groupeId = _groupe.Id;
				} else {
					_groupeId = 0;
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "absavantagedescription")]
	public abstract partial class AbsAvantageDescription : DataDescription<AbsAvantageModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "absavantageexemplar")]
	public abstract partial class AbsAvantageExemplar : DataExemplaire<AbsAvantageModel> {

		private int _nbrRangs;
		[Column(Storage = "NbrRangs",Name = "nbrrangs")]
		public int NbrRangs{
			get{ return _nbrRangs;}
			set{_nbrRangs = value;}
		}
	}
}
