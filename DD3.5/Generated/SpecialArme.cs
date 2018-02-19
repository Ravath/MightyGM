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
	[Table(Schema = "dd35",Name = "specialarmemodel")]
	[CoreData]
	public partial class SpecialArmeModel : DataModel {

		private SpecialArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpecialArmeDescription> id = GetModelReferencer<SpecialArmeDescription>();
					if(id.Count() == 0) {
						_obj = new SpecialArmeDescription();
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
	[Table(Schema = "dd35",Name = "specialarmedescription")]
	public partial class SpecialArmeDescription : DataDescription<SpecialArmeModel> {
	}
	[Table(Schema = "dd35",Name = "specialarmeexemplar")]
	public partial class SpecialArmeExemplar : DataExemplaire<SpecialArmeModel> {
	}
}
