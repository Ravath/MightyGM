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
	[Table(Schema = "cinqanneaux",Name = "conditionadmissionmodel")]
	[CoreData]
	public partial class ConditionAdmissionModel : DataModel {

		private ConditionAdmissionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ConditionAdmissionDescription> id = GetModelReferencer<ConditionAdmissionDescription>();
					if(id.Count() == 0) {
						_obj = new ConditionAdmissionDescription();
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
	[Table(Schema = "cinqanneaux",Name = "conditionadmissiondescription")]
	public partial class ConditionAdmissionDescription : DataDescription<ConditionAdmissionModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "conditionadmissionexemplar")]
	public partial class ConditionAdmissionExemplar : DataExemplaire<ConditionAdmissionModel> {

		private string _valeurs = "";
		[Column(Storage = "Valeurs",Name = "valeurs")]
		public string Valeurs{
			get{ return _valeurs;}
			set{_valeurs = value;}
		}
	}
}
