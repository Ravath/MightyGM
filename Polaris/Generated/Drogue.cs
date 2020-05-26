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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "droguemodel")]
	[CoreData]
	public partial class DrogueModel : DataModel {

		private DrogueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DrogueDescription> id = GetModelReferencer<DrogueDescription>();
					if(id.Count() == 0) {
						_obj = new DrogueDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _duree;
		[Column(Storage = "Duree",Name = "duree")]
		public int Duree{
			get{ return _duree;}
			set{_duree = value;}
		}

		private int _modifDependance;
		[Column(Storage = "ModifDependance",Name = "modifdependance")]
		public int ModifDependance{
			get{ return _modifDependance;}
			set{_modifDependance = value;}
		}

		private int _manque;
		[Column(Storage = "Manque",Name = "manque")]
		public int Manque{
			get{ return _manque;}
			set{_manque = value;}
		}

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}
	}
	[Table(Schema = "polaris",Name = "droguedescription")]
	public partial class DrogueDescription : DataDescription<DrogueModel> {
	}
	[Table(Schema = "polaris",Name = "drogueexemplar")]
	public partial class DrogueExemplar : DataExemplaire<DrogueModel> {
	}
}
