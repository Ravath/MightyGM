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
	[Table(Schema = "cinqanneaux",Name = "pouvoiroutremondemodel")]
	[CoreData]
	public partial class PouvoirOutremondeModel : DataModel {

		private PouvoirOutremondeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirOutremondeDescription> id = GetModelReferencer<PouvoirOutremondeDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirOutremondeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypePouvoirOutremonde _typePouvoir;
		[Column(Storage = "TypePouvoir",Name = "typepouvoir")]
		public TypePouvoirOutremonde TypePouvoir{
			get{ return _typePouvoir;}
			set{_typePouvoir = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "pouvoiroutremondedescription")]
	public partial class PouvoirOutremondeDescription : DataDescription<PouvoirOutremondeModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "pouvoiroutremondeexemplar")]
	public partial class PouvoirOutremondeExemplar : DataExemplaire<PouvoirOutremondeModel> {
	}
}
