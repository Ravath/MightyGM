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
	[Table(Schema = "cinqanneaux",Name = "opportuniteheroiquemodel")]
	[CoreData]
	public partial class OpportuniteHeroiqueModel : DataModel {

		private OpportuniteHeroiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<OpportuniteHeroiqueDescription> id = GetModelReferencer<OpportuniteHeroiqueDescription>();
					if(id.Count() == 0) {
						_obj = new OpportuniteHeroiqueDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private string _action = "";
		[LargeText]
		[Column(Storage = "Action",Name = "action")]
		public string Action{
			get{ return _action;}
			set{_action = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "opportuniteheroiquedescription")]
	public partial class OpportuniteHeroiqueDescription : DataDescription<OpportuniteHeroiqueModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "opportuniteheroiqueexemplar")]
	public partial class OpportuniteHeroiqueExemplar : DataExemplaire<OpportuniteHeroiqueModel> {
	}
}
