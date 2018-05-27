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
	[Table(Schema = "polaris",Name = "personnalitemodel")]
	[CoreData]
	public partial class PersonnaliteModel : DataModel {

		private PersonnaliteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PersonnaliteDescription> id = GetModelReferencer<PersonnaliteDescription>();
					if(id.Count() == 0) {
						_obj = new PersonnaliteDescription();
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
	[Table(Schema = "polaris",Name = "personnalitedescription")]
	public partial class PersonnaliteDescription : DataDescription<PersonnaliteModel> {
	}
	[Table(Schema = "polaris",Name = "personnaliteexemplar")]
	public partial class PersonnaliteExemplar : DataExemplaire<PersonnaliteModel> {
	}
}
