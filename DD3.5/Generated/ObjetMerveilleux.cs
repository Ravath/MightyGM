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
	[Table(Schema = "dd35",Name = "objetmerveilleuxmodel")]
	[CoreData]
	public partial class ObjetMerveilleuxModel : ObjectMagiqueModel {

		private ObjetMerveilleuxDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ObjetMerveilleuxDescription> id = GetModelReferencer<ObjetMerveilleuxDescription>();
					if(id.Count() == 0) {
						_obj = new ObjetMerveilleuxDescription();
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

		private PuissanceObjetMerveilleux _puissance;
		[Column(Storage = "Puissance",Name = "puissance")]
		public PuissanceObjetMerveilleux Puissance{
			get{ return _puissance;}
			set{_puissance = value;}
		}
	}
	[Table(Schema = "dd35",Name = "objetmerveilleuxdescription")]
	public partial class ObjetMerveilleuxDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "dd35",Name = "objetmerveilleuxexemplar")]
	public partial class ObjetMerveilleuxExemplar : ObjectMagiqueExemplar {
	}
}
