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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "negativequalitymodel")]
	[CoreData]
	public partial class NegativeQualityModel : QualityModel {

		private NegativeQualityDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<NegativeQualityDescription> id = GetModelReferencer<NegativeQualityDescription>();
					if(id.Count() == 0) {
						_obj = new NegativeQualityDescription();
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
	[Table(Schema = "shadowrun5",Name = "negativequalitydescription")]
	public partial class NegativeQualityDescription : QualityDescription {
	}
	[Table(Schema = "shadowrun5",Name = "negativequalityexemplar")]
	public partial class NegativeQualityExemplar : QualityExemplar {
	}
}
