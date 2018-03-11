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
	[Table(Schema = "cinqanneaux",Name = "augmentationsortmodel")]
	[CoreData]
	public partial class AugmentationSortModel : DataModel {

		private AugmentationSortDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AugmentationSortDescription> id = GetModelReferencer<AugmentationSortDescription>();
					if(id.Count() == 0) {
						_obj = new AugmentationSortDescription();
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
	[Table(Schema = "cinqanneaux",Name = "augmentationsortdescription")]
	public partial class AugmentationSortDescription : DataDescription<AugmentationSortModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "augmentationsortexemplar")]
	public partial class AugmentationSortExemplar : DataExemplaire<AugmentationSortModel> {

		private string _complement = "";
		[Column(Storage = "Complement",Name = "complement")]
		public string Complement{
			get{ return _complement;}
			set{_complement = value;}
		}
	}
}
