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
	[Table(Schema = "pathfinder",Name = "soustypecreaturemodel")]
	[CoreData]
	public partial class SousTypeCreatureModel : DataModel {

		private SousTypeCreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SousTypeCreatureDescription> id = GetModelReferencer<SousTypeCreatureDescription>();
					if(id.Count() == 0) {
						_obj = new SousTypeCreatureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<PouvoirSpecialExemplar> _pouvoirs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Pouvoirs",OtherKey = "SousTypeCreatureModelId")]
		public IEnumerable <PouvoirSpecialExemplar> Pouvoirs{
			get{
				if( _pouvoirs == null ){
					_pouvoirs = LoadFromJointure<PouvoirSpecialExemplar,SousTypeCreatureModelToPouvoirSpecialExemplar_Pouvoirs>(false);
				}
				return _pouvoirs;
			}
			set{
				SaveToJointure<PouvoirSpecialExemplar, SousTypeCreatureModelToPouvoirSpecialExemplar_Pouvoirs> (_pouvoirs, value,false);
				_pouvoirs = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<SousTypeCreatureModel,SousTypeCreatureModelToPouvoirSpecialExemplar_Pouvoirs>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "soustypecreaturedescription")]
	public partial class SousTypeCreatureDescription : DataDescription<SousTypeCreatureModel> {
	}
	[Table(Schema = "pathfinder",Name = "soustypecreatureexemplar")]
	public partial class SousTypeCreatureExemplar : DataExemplaire<SousTypeCreatureModel> {
	}
}
