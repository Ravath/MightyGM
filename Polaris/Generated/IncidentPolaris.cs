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
	[Table(Schema = "polaris",Name = "incidentpolarismodel")]
	[CoreData]
	public partial class IncidentPolarisModel : DataModel {

		private IncidentPolarisDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<IncidentPolarisDescription> id = GetModelReferencer<IncidentPolarisDescription>();
					if(id.Count() == 0) {
						_obj = new IncidentPolarisDescription();
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
	[Table(Schema = "polaris",Name = "incidentpolarisdescription")]
	public partial class IncidentPolarisDescription : DataDescription<IncidentPolarisModel> {
	}
	[Table(Schema = "polaris",Name = "incidentpolarisexemplar")]
	public partial class IncidentPolarisExemplar : DataExemplaire<IncidentPolarisModel> {
	}
}
