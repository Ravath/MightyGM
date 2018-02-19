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
	[Table(Schema = "dd35",Name = "archetypemodel")]
	[CoreData]
	public partial class ArchetypeModel : DataModel {

		private ArchetypeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArchetypeDescription> id = GetModelReferencer<ArchetypeDescription>();
					if(id.Count() == 0) {
						_obj = new ArchetypeDescription();
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
	[Table(Schema = "dd35",Name = "archetypedescription")]
	public partial class ArchetypeDescription : DataDescription<ArchetypeModel> {
	}
	[Table(Schema = "dd35",Name = "archetypeexemplar")]
	public partial class ArchetypeExemplar : DataExemplaire<ArchetypeModel> {
	}
}
