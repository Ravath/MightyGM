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
	[Table(Schema = "polaris",Name = "poisonmodel")]
	[CoreData]
	public partial class PoisonModel : AbsPoisonModel {

		private PoisonDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PoisonDescription> id = GetModelReferencer<PoisonDescription>();
					if(id.Count() == 0) {
						_obj = new PoisonDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}
	}
	[Table(Schema = "polaris",Name = "poisondescription")]
	public partial class PoisonDescription : AbsPoisonDescription {
	}
	[Table(Schema = "polaris",Name = "poisonexemplar")]
	public partial class PoisonExemplar : AbsPoisonExemplar {
	}
}
