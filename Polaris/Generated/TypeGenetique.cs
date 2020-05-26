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
	[Table(Schema = "polaris",Name = "typegenetiquemodel")]
	[CoreData]
	public partial class TypeGenetiqueModel : DataModel {

		private TypeGenetiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TypeGenetiqueDescription> id = GetModelReferencer<TypeGenetiqueDescription>();
					if(id.Count() == 0) {
						_obj = new TypeGenetiqueDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<PlayerConditionExemplar> _conditions;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Conditions",OtherKey = "TypeGenetiqueModelId")]
		public IEnumerable <PlayerConditionExemplar> Conditions{
			get{
				if( _conditions == null ){
					_conditions = LoadFromJointure<PlayerConditionExemplar,TypeGenetiqueModelToPlayerConditionExemplar_Conditions>(false);
				}
				return _conditions;
			}
			set{
				SaveToJointure<PlayerConditionExemplar, TypeGenetiqueModelToPlayerConditionExemplar_Conditions> (_conditions, value,false);
				_conditions = value;
			}
		}

		private IEnumerable<PlayerEffectExemplar> _effets;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Effets",OtherKey = "TypeGenetiqueModelId")]
		public IEnumerable <PlayerEffectExemplar> Effets{
			get{
				if( _effets == null ){
					_effets = LoadFromJointure<PlayerEffectExemplar,TypeGenetiqueModelToPlayerEffectExemplar_Effets>(false);
				}
				return _effets;
			}
			set{
				SaveToJointure<PlayerEffectExemplar, TypeGenetiqueModelToPlayerEffectExemplar_Effets> (_effets, value,false);
				_effets = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<TypeGenetiqueModel,TypeGenetiqueModelToPlayerConditionExemplar_Conditions>(true);
			DeleteJoins<TypeGenetiqueModel,TypeGenetiqueModelToPlayerEffectExemplar_Effets>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "typegenetiquedescription")]
	public partial class TypeGenetiqueDescription : DataDescription<TypeGenetiqueModel> {
	}
	[Table(Schema = "polaris",Name = "typegenetiqueexemplar")]
	public partial class TypeGenetiqueExemplar : DataExemplaire<TypeGenetiqueModel> {
	}
}
