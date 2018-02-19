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
	[Table(Schema = "polaris",Name = "avantagepromodel")]
	[CoreData]
	public partial class AvantageProModel : DataModel {

		private AvantageProDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AvantageProDescription> id = GetModelReferencer<AvantageProDescription>();
					if(id.Count() == 0) {
						_obj = new AvantageProDescription();
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
	}
	[Table(Schema = "polaris",Name = "avantageprodescription")]
	public partial class AvantageProDescription : DataDescription<AvantageProModel> {
	}
	[Table(Schema = "polaris",Name = "avantageproexemplar")]
	public partial class AvantageProExemplar : DataExemplaire<AvantageProModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
