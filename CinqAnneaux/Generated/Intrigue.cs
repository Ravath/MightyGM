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
	[Table(Schema = "cinqanneaux",Name = "intriguemodel")]
	[CoreData]
	public partial class IntrigueModel : DataModel {

		private IntrigueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<IntrigueDescription> id = GetModelReferencer<IntrigueDescription>();
					if(id.Count() == 0) {
						_obj = new IntrigueDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}


		private IEnumerable < string > _acteurs;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Acteurs",OtherKey = "IntrigueModel")]
		public IEnumerable < string > Acteurs{
			get{
				if( _acteurs == null ){
					_acteurs = LoadFromDataValue<ActeursFromIntrigueModel, string>();
				}
				return _acteurs;
			}
			set{
				SaveDataValue<ActeursFromIntrigueModel, string>(_acteurs, value);
			}
		}
		public override void DeleteObject() {
			DeleteDataValue<ActeursFromIntrigueModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "intriguedescription")]
	public partial class IntrigueDescription : DataDescription<IntrigueModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "intrigueexemplar")]
	public partial class IntrigueExemplar : DataExemplaire<IntrigueModel> {
	}
}
