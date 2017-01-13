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
	[Table(Schema = "cinqanneaux",Name = "kata_model")]
	public partial class KataModel : DataModel {

		private Anneau _Anneau;
		[Column(Storage = "Anneau",Name = "anneau")]
		public Anneau Anneau{
			get{ return _Anneau;}
			set{_Anneau = value;}
		}

		private int _maitrise;
		[Column(Storage = "Maitrise",Name = "maitrise")]
		public int Maitrise{
			get{ return _maitrise;}
			set{_maitrise = value;}
		}

		private IEnumerable<KataModelToEcoleModel> _Ecoles;
		public IEnumerable<KataModelToEcoleModel> Ecoles{
			get {
				if(_Ecoles == null) {
					_Ecoles = LoadByForeignKey<KataModelToEcoleModel>(p => p.KataModelId, Id);
			    }
				return _Ecoles;
			}
			set {
				foreach(KataModelToEcoleModel item in _Ecoles) {
					item.KataModel = null;
				}
				_Ecoles = value;
				foreach(KataModelToEcoleModel item in value) {
					item.KataModel = this;
				}
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "kata_exemplar")]
	public partial class KataExemplar : DataExemplaire<KataModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "kata_description")]
	public partial class KataDescription : DataDescription<KataModel> {
	}
}
