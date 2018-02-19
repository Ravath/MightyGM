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
	[Table(Schema = "pathfinder",Name = "employeitrmmodel")]
	[CoreData]
	public partial class EmployeItrmModel : LucratifItrmModel {

		private EmployeItrmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EmployeItrmDescription> id = GetModelReferencer<EmployeItrmDescription>();
					if(id.Count() == 0) {
						_obj = new EmployeItrmDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<EmployeItrmModel> _amelDe;
		public IEnumerable <EmployeItrmModel> AmelDe{
			get{
				if( _amelDe == null ){
					_amelDe = LoadFromJointure<EmployeItrmModel,EmployeItrmModelAmelEnToEmployeItrmModelAmelDe>(true);
				}
				return _amelDe;
			}
			set{
				SaveToJointure<EmployeItrmModel, EmployeItrmModelAmelEnToEmployeItrmModelAmelDe> (_amelDe, value,true);
				_amelDe = value;
			}
		}

		private IEnumerable<EmployeItrmModel> _amelEn;
		public IEnumerable <EmployeItrmModel> AmelEn{
			get{
				if( _amelEn == null ){
					_amelEn = LoadFromJointure<EmployeItrmModel,EmployeItrmModelAmelEnToEmployeItrmModelAmelDe>(false);
				}
				return _amelEn;
			}
			set{
				SaveToJointure<EmployeItrmModel, EmployeItrmModelAmelEnToEmployeItrmModelAmelDe> (_amelEn, value,false);
				_amelEn = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<EmployeItrmModel,EmployeItrmModelAmelDeToEmployeItrmModelAmelEn>(false);
			DeleteJoins<EmployeItrmModel,EmployeItrmModelAmelDeToEmployeItrmModelAmelEn>(true);
			DeleteJoins<EmployeItrmModel,EmployeItrmModelAmelEnToEmployeItrmModelAmelDe>(true);
			DeleteJoins<EmployeItrmModel,EmployeItrmModelAmelEnToEmployeItrmModelAmelDe>(false);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "employeitrmdescription")]
	public partial class EmployeItrmDescription : LucratifItrmDescription {
	}
	[Table(Schema = "pathfinder",Name = "employeitrmexemplar")]
	public partial class EmployeItrmExemplar : LucratifItrmExemplar {
	}
}
