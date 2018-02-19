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
	[Table(Schema = "cinqanneaux",Name = "conditionmodel")]
	[CoreData]
	public partial class ConditionModel : DataModel {

		private ConditionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ConditionDescription> id = GetModelReferencer<ConditionDescription>();
					if(id.Count() == 0) {
						_obj = new ConditionDescription();
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
	[Table(Schema = "cinqanneaux",Name = "conditiondescription")]
	public partial class ConditionDescription : DataDescription<ConditionModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "conditionexemplar")]
	public partial class ConditionExemplar : DataExemplaire<ConditionModel> {

		private string _valeurs = "";
		[Column(Storage = "Valeurs",Name = "valeurs")]
		public string Valeurs{
			get{ return _valeurs;}
			set{_valeurs = value;}
		}
	}
}
