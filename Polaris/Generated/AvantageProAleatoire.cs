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
	[Table(Schema = "polaris",Name = "avantageproaleatoiremodel")]
	[CoreData]
	public partial class AvantageProAleatoireModel : DataModel {

		private AvantageProAleatoireDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AvantageProAleatoireDescription> id = GetModelReferencer<AvantageProAleatoireDescription>();
					if(id.Count() == 0) {
						_obj = new AvantageProAleatoireDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _professionId;
		[Column(Storage = "ProfessionId",Name = "fk_professionmodel_profession")]
		[HiddenProperty]
		public int ProfessionId{
			get{ return _professionId;}
			set{_professionId = value;}
		}

		private ProfessionModel _profession;
		public ProfessionModel Profession{
			get {
				if(_profession == null) {
					_profession = LoadById<ProfessionModel>(ProfessionId);
			       }
				return _profession;
			} set {
				if(value == _profession) { return; }
				_profession = value;
				if(_profession != null) {
					_professionId = _profession.Id;
				} else {
					_professionId = 0;
				}
			}
		}

		private IEnumerable<PlayerEffectExemplar> _effects;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Effects",OtherKey = "AvantageProAleatoireModelId")]
		public IEnumerable <PlayerEffectExemplar> Effects{
			get{
				if( _effects == null ){
					_effects = LoadFromJointure<PlayerEffectExemplar,AvantageProAleatoireModelToPlayerEffectExemplar_Effects>(false);
				}
				return _effects;
			}
			set{
				SaveToJointure<PlayerEffectExemplar, AvantageProAleatoireModelToPlayerEffectExemplar_Effects> (_effects, value,false);
				_effects = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AvantageProAleatoireModel,AvantageProAleatoireModelToPlayerEffectExemplar_Effects>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "avantageproaleatoiredescription")]
	public partial class AvantageProAleatoireDescription : DataDescription<AvantageProAleatoireModel> {
	}
	[Table(Schema = "polaris",Name = "avantageproaleatoireexemplar")]
	public partial class AvantageProAleatoireExemplar : DataExemplaire<AvantageProAleatoireModel> {
	}
}
