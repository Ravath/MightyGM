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
	[Table(Schema = "cinqanneaux",Name = "seuilblessure")]
	[CoreData]
	public partial class SeuilBlessure : DataObject {

		private int _figurantId;
		[Column(Storage = "FigurantId",Name = "fk_figurantmodel_figurant")]
		[HiddenProperty]
		public int FigurantId{
			get{ return _figurantId;}
			set{_figurantId = value;}
		}

		private FigurantModel _figurant;
		public FigurantModel Figurant{
			get {
				if(_figurant == null) {
					_figurant = LoadById<FigurantModel>(FigurantId);
			       }
				return _figurant;
			} set {
				if(value == _figurant) { return; }
				_figurant = value;
				if(_figurant != null) {
					_figurantId = _figurant.Id;
				} else {
					_figurantId = 0;
				}
			}
		}

		private int _seuil;
		[Column(Storage = "Seuil",Name = "seuil")]
		public int Seuil{
			get{ return _seuil;}
			set{_seuil = value;}
		}

		private int _malus;
		[Column(Storage = "Malus",Name = "malus")]
		public int Malus{
			get{ return _malus;}
			set{_malus = value;}
		}
	}
}
