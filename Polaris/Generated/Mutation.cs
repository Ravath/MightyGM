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
	[Table(Schema = "polaris",Name = "mutationmodel")]
	[CoreData]
	public partial class MutationModel : DataModel {

		private MutationDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MutationDescription> id = GetModelReferencer<MutationDescription>();
					if(id.Count() == 0) {
						_obj = new MutationDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int? _cAvantage;
		[Column(Storage = "cAvantage",Name = "cavantage")]
		public int? cAvantage{
			get{ return _cAvantage;}
			set{_cAvantage = value;}
		}

		private int? _cDesavantage;
		[Column(Storage = "cDesavantage",Name = "cdesavantage")]
		public int? cDesavantage{
			get{ return _cDesavantage;}
			set{_cDesavantage = value;}
		}

		private IEnumerable<PlayerEffectExemplar> _effets;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Effets",OtherKey = "MutationModelId")]
		public IEnumerable <PlayerEffectExemplar> Effets{
			get{
				if( _effets == null ){
					_effets = LoadFromJointure<PlayerEffectExemplar,MutationModelToPlayerEffectExemplar_Effets>(false);
				}
				return _effets;
			}
			set{
				SaveToJointure<PlayerEffectExemplar, MutationModelToPlayerEffectExemplar_Effets> (_effets, value,false);
				_effets = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<MutationModel,MutationModelToPlayerEffectExemplar_Effets>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "mutationdescription")]
	public partial class MutationDescription : DataDescription<MutationModel> {
	}
	[Table(Schema = "polaris",Name = "mutationexemplar")]
	public partial class MutationExemplar : DataExemplaire<MutationModel> {
	}
}
