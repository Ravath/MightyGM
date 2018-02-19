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
	[Table(Schema = "shadowrun5",Name = "positivequalitymodel")]
	[CoreData]
	public partial class PositiveQualityModel : QualityModel {

		private PositiveQualityDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PositiveQualityDescription> id = GetModelReferencer<PositiveQualityDescription>();
					if(id.Count() == 0) {
						_obj = new PositiveQualityDescription();
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
	[Table(Schema = "shadowrun5",Name = "positivequalitydescription")]
	public partial class PositiveQualityDescription : QualityDescription {
	}
	[Table(Schema = "shadowrun5",Name = "positivequalityexemplar")]
	public partial class PositiveQualityExemplar : QualityExemplar {
	}
}
