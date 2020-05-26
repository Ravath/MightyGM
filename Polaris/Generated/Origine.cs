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
	[Table(Schema = "polaris",Name = "originemodel")]
	[CoreData]
	public partial class OrigineModel : DataModel {

		private OrigineDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<OrigineDescription> id = GetModelReferencer<OrigineDescription>();
					if(id.Count() == 0) {
						_obj = new OrigineDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<OrigineModel> _requis;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Requis",OtherKey = "OrigineModelRequisId")]
		public IEnumerable <OrigineModel> Requis{
			get{
				if( _requis == null ){
					_requis = LoadFromJointure<OrigineModel,OrigineModelToOrigineModel_Requis>(false);
				}
				return _requis;
			}
			set{
				SaveToJointure<OrigineModel, OrigineModelToOrigineModel_Requis> (_requis, value,false);
				_requis = value;
			}
		}

		private TypeOrigine _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeOrigine Type{
			get{ return _type;}
			set{_type = value;}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "OrigineModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,OrigineModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, OrigineModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<OrigineModel,OrigineModelToOrigineModel_Requis>(true);
			DeleteJoins<OrigineModel,OrigineModelToCompetenceExemplar_Competences>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "originedescription")]
	public partial class OrigineDescription : DataDescription<OrigineModel> {
	}
	[Table(Schema = "polaris",Name = "origineexemplar")]
	public partial class OrigineExemplar : DataExemplaire<OrigineModel> {
	}
}
