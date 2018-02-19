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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "specialarmemodel")]
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
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "specialarmedescription")]
	public partial class SpecialArmeDescription : DataDescription<SpecialArmeModel> {
	}
	[Table(Schema = "pathfinder",Name = "specialarmeexemplar")]
	public partial class SpecialArmeExemplar : DataExemplaire<SpecialArmeModel> {
	}
}
