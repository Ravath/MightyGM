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
	[Table(Schema = "cinqanneaux",Name = "sortmodel")]
	[CoreData]
	public partial class SortModel : AbsSortModel {

		private SortDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SortDescription> id = GetModelReferencer<SortDescription>();
					if(id.Count() == 0) {
						_obj = new SortDescription();
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
	[Table(Schema = "cinqanneaux",Name = "sortdescription")]
	public partial class SortDescription : AbsSortDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "sortexemplar")]
	public partial class SortExemplar : AbsSortExemplar {
	}
}
