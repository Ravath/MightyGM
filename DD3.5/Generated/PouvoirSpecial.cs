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
	[Table(Schema = "dd35",Name = "pouvoirspecialmodel")]
	[CoreData]
	public partial class PouvoirSpecialModel : DataModel {

		private PouvoirSpecialDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirSpecialDescription> id = GetModelReferencer<PouvoirSpecialDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirSpecialDescription();
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

		private TypePouvoir _type;
		[Column(Storage = "Type",Name = "type")]
		public TypePouvoir Type{
			get{ return _type;}
			set{_type = value;}
		}
	}
	[Table(Schema = "dd35",Name = "pouvoirspecialdescription")]
	public partial class PouvoirSpecialDescription : DataDescription<PouvoirSpecialModel> {
	}
	[Table(Schema = "dd35",Name = "pouvoirspecialexemplar")]
	public partial class PouvoirSpecialExemplar : DataExemplaire<PouvoirSpecialModel> {
	}
}
