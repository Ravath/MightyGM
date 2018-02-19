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
	[Table(Schema = "pathfinder",Name = "evenementorganisationitrmmodel")]
	[CoreData]
	public partial class EvenementOrganisationItrmModel : AbsOddTableModel {

		private EvenementOrganisationItrmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EvenementOrganisationItrmDescription> id = GetModelReferencer<EvenementOrganisationItrmDescription>();
					if(id.Count() == 0) {
						_obj = new EvenementOrganisationItrmDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _organisationId;
		[Column(Storage = "OrganisationId",Name = "fk_organisationitrmmodel_organisation")]
		[HiddenProperty]
		public int OrganisationId{
			get{ return _organisationId;}
			set{_organisationId = value;}
		}

		private OrganisationItrmModel _organisation;
		public OrganisationItrmModel Organisation{
			get{
				if( _organisation == null)
					_organisation = LoadById<OrganisationItrmModel>(OrganisationId);
				return _organisation;
			} set {
				if(_organisation == value){return;}
				_organisation = value;
				if( value != null)
					OrganisationId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "evenementorganisationitrmdescription")]
	public partial class EvenementOrganisationItrmDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "evenementorganisationitrmexemplar")]
	public partial class EvenementOrganisationItrmExemplar : AbsOddTableExemplar {
	}
}
