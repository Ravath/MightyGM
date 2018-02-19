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
	[Table(Schema = "pathfinder",Name = "raceparentsadoptifsmodel")]
	[CoreData]
	public partial class RaceParentsAdoptifsModel : AbsOddTableModel {

		private RaceParentsAdoptifsDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RaceParentsAdoptifsDescription> id = GetModelReferencer<RaceParentsAdoptifsDescription>();
					if(id.Count() == 0) {
						_obj = new RaceParentsAdoptifsDescription();
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
	[Table(Schema = "pathfinder",Name = "raceparentsadoptifsdescription")]
	public partial class RaceParentsAdoptifsDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "raceparentsadoptifsexemplar")]
	public partial class RaceParentsAdoptifsExemplar : AbsOddTableExemplar {
	}
}
