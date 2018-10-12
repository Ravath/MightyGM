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
	[Table(Schema = "cinqanneaux",Name = "armemodel")]
	[CoreData]
	public partial class ArmeModel : AbsObjetModel {

		private ArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDescription> id = GetModelReferencer<ArmeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeArme _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeArme Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _rollVD;
		[Column(Storage = "RollVD",Name = "rollvd")]
		public int RollVD{
			get{ return _rollVD;}
			set{_rollVD = value;}
		}

		private int _keepVD;
		[Column(Storage = "KeepVD",Name = "keepvd")]
		public int KeepVD{
			get{ return _keepVD;}
			set{_keepVD = value;}
		}

		private TailleArme _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public TailleArme Taille{
			get{ return _taille;}
			set{_taille = value;}
		}

		private bool _paysan;
		[Column(Storage = "Paysan",Name = "paysan")]
		public bool Paysan{
			get{ return _paysan;}
			set{_paysan = value;}
		}

		private bool _samurai;
		[Column(Storage = "Samurai",Name = "samurai")]
		public bool Samurai{
			get{ return _samurai;}
			set{_samurai = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "armedescription")]
	public partial class ArmeDescription : AbsObjetDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "armeexemplar")]
	public partial class ArmeExemplar : AbsObjetExemplar {
	}
}
