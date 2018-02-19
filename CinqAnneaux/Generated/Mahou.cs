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
	[Table(Schema = "cinqanneaux",Name = "mahoumodel")]
	[CoreData]
	public partial class MahouModel : AbsSortModel {

		private MahouDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MahouDescription> id = GetModelReferencer<MahouDescription>();
					if(id.Count() == 0) {
						_obj = new MahouDescription();
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
	[Table(Schema = "cinqanneaux",Name = "mahoudescription")]
	public partial class MahouDescription : AbsSortDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "mahouexemplar")]
	public partial class MahouExemplar : AbsSortExemplar {
	}
}
