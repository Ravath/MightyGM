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
	[Table(Schema = "polaris",Name = "titre")]
	[CoreData]
	public partial class Titre : DataObject {

		private int _professionId;
		[Column(Storage = "ProfessionId",Name = "fk_professionmodel_profession")]
		[HiddenProperty]
		public int ProfessionId{
			get{ return _professionId;}
			set{_professionId = value;}
		}

		private ProfessionModel _profession;
		public ProfessionModel Profession{
			get {
				if(_profession == null) {
					_profession = LoadById<ProfessionModel>(ProfessionId);
			       }
				return _profession;
			} set {
				if(value == _profession) { return; }
				_profession = value;
				if(_profession != null) {
					_professionId = _profession.Id;
				} else {
					_professionId = 0;
				}
			}
		}

		private string _nom = "";
		[Column(Storage = "Nom",Name = "nom")]
		public string Nom{
			get{ return _nom;}
			set{_nom = value;}
		}

		private int _ordre;
		[Column(Storage = "Ordre",Name = "ordre")]
		public int Ordre{
			get{ return _ordre;}
			set{_ordre = value;}
		}

		private int _annees;
		[Column(Storage = "Annees",Name = "annees")]
		public int Annees{
			get{ return _annees;}
			set{_annees = value;}
		}

		private int _revenus;
		[Column(Storage = "Revenus",Name = "revenus")]
		public int Revenus{
			get{ return _revenus;}
			set{_revenus = value;}
		}

		private int? _ndRandFactor;
		[Column(Storage = "ndRandFactor",Name = "ndrandfactor")]
		public int? ndRandFactor{
			get{ return _ndRandFactor;}
			set{_ndRandFactor = value;}
		}

		private int? _fdRandFactor;
		[Column(Storage = "fdRandFactor",Name = "fdrandfactor")]
		public int? fdRandFactor{
			get{ return _fdRandFactor;}
			set{_fdRandFactor = value;}
		}
	}
}
