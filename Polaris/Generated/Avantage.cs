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
	[Table(Schema = "polaris",Name = "avantagemodel")]
	[CoreData]
	public partial class AvantageModel : DataModel {

		private AvantageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AvantageDescription> id = GetModelReferencer<AvantageDescription>();
					if(id.Count() == 0) {
						_obj = new AvantageDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}


		private IEnumerable < int > _couts;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Couts",OtherKey = "AvantageModel")]
		public IEnumerable < int > Couts{
			get{
				if( _couts == null ){
					_couts = LoadFromDataValue<CoutsFromAvantageModel, int>();
				}
				return _couts;
			}
			set{
				SaveDataValue<CoutsFromAvantageModel, int>(_couts, value);
			}
		}

		private bool _unique;
		[Column(Storage = "Unique",Name = "unique")]
		public bool Unique{
			get{ return _unique;}
			set{_unique = value;}
		}

		private bool _desavantage;
		[Column(Storage = "Desavantage",Name = "desavantage")]
		public bool Desavantage{
			get{ return _desavantage;}
			set{_desavantage = value;}
		}

		private IEnumerable<PlayerEffectModel> _effets;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Effets",OtherKey = "AvantageModelId")]
		public IEnumerable <PlayerEffectModel> Effets{
			get{
				if( _effets == null ){
					_effets = LoadFromJointure<PlayerEffectModel,AvantageModelToPlayerEffectModel_Effets>(false);
				}
				return _effets;
			}
			set{
				SaveToJointure<PlayerEffectModel, AvantageModelToPlayerEffectModel_Effets> (_effets, value,false);
				_effets = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AvantageModel,AvantageModelToPlayerEffectModel_Effets>(true);
			DeleteDataValue<CoutsFromAvantageModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "avantagedescription")]
	public partial class AvantageDescription : DataDescription<AvantageModel> {
	}
	[Table(Schema = "polaris",Name = "avantageexemplar")]
	public partial class AvantageExemplar : DataExemplaire<AvantageModel> {

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
