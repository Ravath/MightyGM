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
	[Table(Schema = "cinqanneaux",Name = "specialobjetmodel")]
	[CoreData]
	public partial class SpecialObjetModel : DataModel {

		private SpecialObjetDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpecialObjetDescription> id = GetModelReferencer<SpecialObjetDescription>();
					if(id.Count() == 0) {
						_obj = new SpecialObjetDescription();
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
	[Table(Schema = "cinqanneaux",Name = "specialobjetdescription")]
	public partial class SpecialObjetDescription : DataDescription<SpecialObjetModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "specialobjetexemplar")]
	public partial class SpecialObjetExemplar : DataExemplaire<SpecialObjetModel> {

		private string _complement = "";
		[Column(Storage = "Complement",Name = "complement")]
		public string Complement{
			get{ return _complement;}
			set{_complement = value;}
		}
	}
}
