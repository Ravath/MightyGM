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
	[Table(Schema = "polaris",Name = "originesmodel")]
	[CoreData]
	public partial class OriginesModel : DataModel {

		private OriginesDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<OriginesDescription> id = GetModelReferencer<OriginesDescription>();
					if(id.Count() == 0) {
						_obj = new OriginesDescription();
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

		private TypeOrigine _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeOrigine Type{
			get{ return _type;}
			set{_type = value;}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "OriginesModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,OriginesModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, OriginesModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<OriginesModel,OriginesModelToCompetenceExemplar_Competences>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "originesdescription")]
	public partial class OriginesDescription : DataDescription<OriginesModel> {
	}
	[Table(Schema = "polaris",Name = "originesexemplar")]
	public partial class OriginesExemplar : DataExemplaire<OriginesModel> {
	}
}
