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
	[Table(Schema = "polaris",Name = "reversdefortunemodel")]
	[CoreData]
	public partial class ReversDeFortuneModel : DataModel {

		private ReversDeFortuneDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ReversDeFortuneDescription> id = GetModelReferencer<ReversDeFortuneDescription>();
					if(id.Count() == 0) {
						_obj = new ReversDeFortuneDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<PlayerEffectExemplar> _effects;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Effects",OtherKey = "ReversDeFortuneModelId")]
		public IEnumerable <PlayerEffectExemplar> Effects{
			get{
				if( _effects == null ){
					_effects = LoadFromJointure<PlayerEffectExemplar,ReversDeFortuneModelToPlayerEffectExemplar_Effects>(false);
				}
				return _effects;
			}
			set{
				SaveToJointure<PlayerEffectExemplar, ReversDeFortuneModelToPlayerEffectExemplar_Effects> (_effects, value,false);
				_effects = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ReversDeFortuneModel,ReversDeFortuneModelToPlayerEffectExemplar_Effects>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "reversdefortunedescription")]
	public partial class ReversDeFortuneDescription : DataDescription<ReversDeFortuneModel> {
	}
	[Table(Schema = "polaris",Name = "reversdefortuneexemplar")]
	public partial class ReversDeFortuneExemplar : DataExemplaire<ReversDeFortuneModel> {
	}
}
