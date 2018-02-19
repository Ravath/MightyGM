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
	[Table(Schema = "cinqanneaux",Name = "kihomodel")]
	[CoreData]
	public partial class KihoModel : DataModel {

		private KihoDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<KihoDescription> id = GetModelReferencer<KihoDescription>();
					if(id.Count() == 0) {
						_obj = new KihoDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeKiho _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeKiho Type{
			get{ return _type;}
			set{_type = value;}
		}

		private Anneau _anneau;
		[Column(Storage = "Anneau",Name = "anneau")]
		public Anneau Anneau{
			get{ return _anneau;}
			set{_anneau = value;}
		}

		private int _maitrise;
		[Column(Storage = "Maitrise",Name = "maitrise")]
		public int Maitrise{
			get{ return _maitrise;}
			set{_maitrise = value;}
		}

		private bool _useAtemi;
		[Column(Storage = "UseAtemi",Name = "useatemi")]
		public bool UseAtemi{
			get{ return _useAtemi;}
			set{_useAtemi = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "kihodescription")]
	public partial class KihoDescription : DataDescription<KihoModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "kihoexemplar")]
	public partial class KihoExemplar : DataExemplaire<KihoModel> {
	}
}
