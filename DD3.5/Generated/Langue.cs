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
	[Table(Schema = "dd35",Name = "languemodel")]
	[CoreData]
	public partial class LangueModel : DataModel {

		private LangueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<LangueDescription> id = GetModelReferencer<LangueDescription>();
					if(id.Count() == 0) {
						_obj = new LangueDescription();
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

		private string _alphabet = "";
		[Column(Storage = "Alphabet",Name = "alphabet")]
		public string Alphabet{
			get{ return _alphabet;}
			set{_alphabet = value;}
		}
	}
	[Table(Schema = "dd35",Name = "languedescription")]
	public partial class LangueDescription : DataDescription<LangueModel> {
	}
	[Table(Schema = "dd35",Name = "langueexemplar")]
	public partial class LangueExemplar : DataExemplaire<LangueModel> {
	}
}
