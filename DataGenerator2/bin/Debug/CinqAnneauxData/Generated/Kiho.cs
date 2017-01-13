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
	[Table(Schema = "cinqanneaux",Name = "kiho_model")]
	public partial class KihoModel : DataModel {

		private TypeKiho _Type;
		[Column(Storage = "Type",Name = "type")]
		public TypeKiho Type{
			get{ return _Type;}
			set{_Type = value;}
		}

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

		private bool _useAtemi;
		[Column(Storage = "useAtemi",Name = "useatemi")]
		public bool useAtemi{
			get{ return _useAtemi;}
			set{_useAtemi = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "kiho_exemplar")]
	public partial class KihoExemplar : DataExemplaire<KihoModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "kiho_description")]
	public partial class KihoDescription : DataDescription<KihoModel> {
	}
}
