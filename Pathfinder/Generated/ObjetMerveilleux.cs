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
	[Table(Schema = "pathfinder",Name = "objetmerveilleuxmodel")]
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
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private EmplacementObjet _emplacement;
		[Column(Storage = "Emplacement",Name = "emplacement")]
		public EmplacementObjet Emplacement{
			get{ return _emplacement;}
			set{_emplacement = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "objetmerveilleuxdescription")]
	public partial class ObjetMerveilleuxDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "pathfinder",Name = "objetmerveilleuxexemplar")]
	public partial class ObjetMerveilleuxExemplar : ObjectMagiqueExemplar {
	}
}
