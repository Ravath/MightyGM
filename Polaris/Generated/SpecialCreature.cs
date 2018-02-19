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
	[Table(Schema = "polaris",Name = "specialcreaturemodel")]
	[CoreData]
	public partial class SpecialCreatureModel : DataModel {

		private SpecialCreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpecialCreatureDescription> id = GetModelReferencer<SpecialCreatureDescription>();
					if(id.Count() == 0) {
						_obj = new SpecialCreatureDescription();
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
	[Table(Schema = "polaris",Name = "specialcreaturedescription")]
	public partial class SpecialCreatureDescription : DataDescription<SpecialCreatureModel> {
	}
	[Table(Schema = "polaris",Name = "specialcreatureexemplar")]
	public partial class SpecialCreatureExemplar : DataExemplaire<SpecialCreatureModel> {
	}
}
