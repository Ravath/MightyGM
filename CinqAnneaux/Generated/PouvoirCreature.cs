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
	[Table(Schema = "cinqanneaux",Name = "pouvoircreaturemodel")]
	[CoreData]
	public partial class PouvoirCreatureModel : DataModel {

		private PouvoirCreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirCreatureDescription> id = GetModelReferencer<PouvoirCreatureDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirCreatureDescription();
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
	[Table(Schema = "cinqanneaux",Name = "pouvoircreaturedescription")]
	public partial class PouvoirCreatureDescription : DataDescription<PouvoirCreatureModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "pouvoircreatureexemplar")]
	public partial class PouvoirCreatureExemplar : DataExemplaire<PouvoirCreatureModel> {

		private string _complement = "";
		[Column(Storage = "Complement",Name = "complement")]
		public string Complement{
			get{ return _complement;}
			set{_complement = value;}
		}
	}
}
