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
	[Table(Schema = "pathfinder",Name = "organisationitrmmodel")]
	[CoreData]
	public partial class OrganisationItrmModel : ConstructibleItrmModel {

		private OrganisationItrmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<OrganisationItrmDescription> id = GetModelReferencer<OrganisationItrmDescription>();
					if(id.Count() == 0) {
						_obj = new OrganisationItrmDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<EmployeItrmExemplar> _employes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Employes",OtherKey = "OrganisationItrmModelId")]
		public IEnumerable <EmployeItrmExemplar> Employes{
			get{
				if( _employes == null ){
					_employes = LoadFromJointure<EmployeItrmExemplar,OrganisationItrmModelToEmployeItrmExemplar_Employes>(false);
				}
				return _employes;
			}
			set{
				SaveToJointure<EmployeItrmExemplar, OrganisationItrmModelToEmployeItrmExemplar_Employes> (_employes, value,false);
				_employes = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<OrganisationItrmModel,OrganisationItrmModelToEmployeItrmExemplar_Employes>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "organisationitrmdescription")]
	public partial class OrganisationItrmDescription : ConstructibleItrmDescription {
	}
	[Table(Schema = "pathfinder",Name = "organisationitrmexemplar")]
	public partial class OrganisationItrmExemplar : ConstructibleItrmExemplar {
	}
}
