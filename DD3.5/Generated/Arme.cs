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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "armemodel")]
	[CoreData]
	public partial class ArmeModel : AbsArmeModel {

		private ArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDescription> id = GetModelReferencer<ArmeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private TypeArme _typeArme;
		[Column(Storage = "TypeArme",Name = "typearme")]
		public TypeArme TypeArme{
			get{ return _typeArme;}
			set{_typeArme = value;}
		}

		private ManiementArme _maniement;
		[Column(Storage = "Maniement",Name = "maniement")]
		public ManiementArme Maniement{
			get{ return _maniement;}
			set{_maniement = value;}
		}

		private bool _armeDouble;
		[Column(Storage = "ArmeDouble",Name = "armedouble")]
		public bool ArmeDouble{
			get{ return _armeDouble;}
			set{_armeDouble = value;}
		}

		private decimal _prix;
		[Column(Storage = "prix",Name = "prix")]
		public decimal prix{
			get{ return _prix;}
			set{_prix = value;}
		}

		private int? _facteurPortee;
		[Column(Storage = "FacteurPortee",Name = "facteurportee")]
		public int? FacteurPortee{
			get{ return _facteurPortee;}
			set{_facteurPortee = value;}
		}

		private decimal? _prixProjectiles;
		[Column(Storage = "PrixProjectiles",Name = "prixprojectiles")]
		public decimal? PrixProjectiles{
			get{ return _prixProjectiles;}
			set{_prixProjectiles = value;}
		}

		private decimal? _poidsProjectiles;
		[Column(Storage = "PoidsProjectiles",Name = "poidsprojectiles")]
		public decimal? PoidsProjectiles{
			get{ return _poidsProjectiles;}
			set{_poidsProjectiles = value;}
		}
	}
	[Table(Schema = "dd35",Name = "armedescription")]
	public partial class ArmeDescription : AbsArmeDescription {
	}
	[Table(Schema = "dd35",Name = "armeexemplar")]
	public partial class ArmeExemplar : AbsArmeExemplar {
	}
}
