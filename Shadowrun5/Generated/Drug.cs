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
	[Table(Schema = "shadowrun5",Name = "drugmodel")]
	[CoreData]
	public partial class DrugModel : SubstanceModel {

		private DrugDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DrugDescription> id = GetModelReferencer<DrugDescription>();
					if(id.Count() == 0) {
						_obj = new DrugDescription();
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

		private string _duration = "";
		[Column(Storage = "Duration",Name = "duration")]
		public string Duration{
			get{ return _duration;}
			set{_duration = value;}
		}

		private AddictionType _addiction;
		[Column(Storage = "Addiction",Name = "addiction")]
		public AddictionType Addiction{
			get{ return _addiction;}
			set{_addiction = value;}
		}

		private int _addictionRating;
		[Column(Storage = "AddictionRating",Name = "addictionrating")]
		public int AddictionRating{
			get{ return _addictionRating;}
			set{_addictionRating = value;}
		}

		private int _addictionThreshold;
		[Column(Storage = "AddictionThreshold",Name = "addictionthreshold")]
		public int AddictionThreshold{
			get{ return _addictionThreshold;}
			set{_addictionThreshold = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "drugdescription")]
	public partial class DrugDescription : SubstanceDescription {
	}
	[Table(Schema = "shadowrun5",Name = "drugexemplar")]
	public partial class DrugExemplar : SubstanceExemplar {
	}
}
