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
	[Table(Schema = "cinqanneaux",Name = "pouvoirnaturelmodel")]
	[CoreData]
	public partial class PouvoirNaturelModel : DataModel {

		private PouvoirNaturelDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirNaturelDescription> id = GetModelReferencer<PouvoirNaturelDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirNaturelDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pouvoirnatureldescription")]
	public partial class PouvoirNaturelDescription : DataDescription<PouvoirNaturelModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "pouvoirnaturelexemplar")]
	public partial class PouvoirNaturelExemplar : DataExemplaire<PouvoirNaturelModel> {

		private string _complement = "";
		[Column(Storage = "Complement",Name = "complement")]
		public string Complement{
			get{ return _complement;}
			set{_complement = value;}
		}
	}
}
