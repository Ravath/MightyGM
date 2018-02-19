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
	[Table(Schema = "pathfinder",Name = "paysnatal")]
	[CoreData]
	public partial class PaysNatal : DataObject {

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
	}
}
