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
	[Table(Schema = "dd35",Name = "soustypecreaturemodel")]
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
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private IEnumerable<PouvoirMonstrueuxModel> _pouvoirs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Pouvoirs",OtherKey = "SousTypeCreatureModelId")]
		public IEnumerable <PouvoirMonstrueuxModel> Pouvoirs{
			get{
				if( _pouvoirs == null ){
					_pouvoirs = LoadFromJointure<PouvoirMonstrueuxModel,SousTypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs>(false);
				}
				return _pouvoirs;
			}
			set{
				SaveToJointure<PouvoirMonstrueuxModel, SousTypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs> (_pouvoirs, value,false);
				_pouvoirs = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<SousTypeCreatureModel,SousTypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "soustypecreaturedescription")]
	public partial class SousTypeCreatureDescription : DataDescription<SousTypeCreatureModel> {
	}
	[Table(Schema = "dd35",Name = "soustypecreatureexemplar")]
	public partial class SousTypeCreatureExemplar : DataExemplaire<SousTypeCreatureModel> {
	}
}
