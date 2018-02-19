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
	[Table(Schema = "cinqanneaux",Name = "armuremodel")]
	[CoreData]
	public partial class ArmureModel : AbsObjetModel {

		private ArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmureDescription> id = GetModelReferencer<ArmureDescription>();
					if(id.Count() == 0) {
						_obj = new ArmureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _bonusND;
		[Column(Storage = "BonusND",Name = "bonusnd")]
		public int BonusND{
			get{ return _bonusND;}
			set{_bonusND = value;}
		}

		private int _reduction;
		[Column(Storage = "Reduction",Name = "reduction")]
		public int Reduction{
			get{ return _reduction;}
			set{_reduction = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "armuredescription")]
	public partial class ArmureDescription : AbsObjetDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "armureexemplar")]
	public partial class ArmureExemplar : AbsObjetExemplar {
	}
}
