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
	[Table(Schema = "cinqanneaux",Name = "technique_model")]
	public partial class TechniqueModel : DataModel {

		private EcoleModel _ecole;
		public EcoleModel Ecole{
			get {
				if(_ecole == null) {
					_ecole = LoadById<EcoleModel>(EcoleId);
			       }
				return _ecole;
			} set {
				if(value == _ecole) { return; }
				_ecole = value;
				if(_ecole != null) {
					_ecoleId = _ecole.Id;
				} else {
					_ecoleId = 0;
				}
			}
		}

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "technique_exemplar")]
	public partial class TechniqueExemplar : DataExemplaire<TechniqueModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "technique_description")]
	public partial class TechniqueDescription : DataDescription<TechniqueModel> {
	}
}
