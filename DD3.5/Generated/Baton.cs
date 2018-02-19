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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "batonmodel")]
	[CoreData]
	public partial class BatonModel : ObjectMagiqueModel {

		private BatonDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<BatonDescription> id = GetModelReferencer<BatonDescription>();
					if(id.Count() == 0) {
						_obj = new BatonDescription();
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

		private IEnumerable<SortBaton> _sorts;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Sorts",OtherKey = "BatonModelId")]
		public IEnumerable <SortBaton> Sorts{
			get{
				if( _sorts == null ){
					_sorts = LoadFromJointure<SortBaton,BatonModelToSortBaton_Sorts>(false);
				}
				return _sorts;
			}
			set{
				SaveToJointure<SortBaton, BatonModelToSortBaton_Sorts> (_sorts, value,false);
				_sorts = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<BatonModel,BatonModelToSortBaton_Sorts>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "batondescription")]
	public partial class BatonDescription : ObjectMagiqueDescription {
	}
	[Table(Schema = "dd35",Name = "batonexemplar")]
	public partial class BatonExemplar : ObjectMagiqueExemplar {
	}
}
