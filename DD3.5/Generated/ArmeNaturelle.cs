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
	[Table(Schema = "dd35",Name = "armenaturellemodel")]
	[CoreData]
	public partial class ArmeNaturelleModel : AbsArmeModel {

		private ArmeNaturelleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeNaturelleDescription> id = GetModelReferencer<ArmeNaturelleDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeNaturelleDescription();
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

		private bool _secondaire;
		[Column(Storage = "Secondaire",Name = "secondaire")]
		public bool Secondaire{
			get{ return _secondaire;}
			set{_secondaire = value;}
		}
	}
	[Table(Schema = "dd35",Name = "armenaturelledescription")]
	public partial class ArmeNaturelleDescription : AbsArmeDescription {
	}
	[Table(Schema = "dd35",Name = "armenaturelleexemplar")]
	public partial class ArmeNaturelleExemplar : AbsArmeExemplar {
	}
}
