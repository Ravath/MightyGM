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
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "donmodel")]
	[CoreData]
	public partial class DonModel : DataModel {

		private DonDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DonDescription> id = GetModelReferencer<DonDescription>();
					if(id.Count() == 0) {
						_obj = new DonDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _faiblesse;
		[Column(Storage = "Faiblesse",Name = "faiblesse")]
		public bool Faiblesse{
			get{ return _faiblesse;}
			set{_faiblesse = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "dondescription")]
	public partial class DonDescription : DataDescription<DonModel> {
	}
	[Table(Schema = "yggdrasil",Name = "donexemplar")]
	public partial class DonExemplar : DataExemplaire<DonModel> {
	}
}
