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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "substancemodel")]
	public abstract partial class SubstanceModel : ProductModel {


		private IEnumerable < int > _vector;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Vector",OtherKey = "SubstanceModel")]
		public IEnumerable < int > Vector{
			get{
				if( _vector == null ){
					_vector = LoadFromDataValue<VectorFromSubstanceModel, int>();
				}
				return _vector;
			}
			set{
				SaveDataValue<VectorFromSubstanceModel, int>(_vector, value);
			}
		}

		[Column(Name = "speed_val", Storage="SpeedVal")]
		[HiddenProperty]
		public int SpeedVal{
			get{
				return Speed.Value;
			}
			set{
				Speed.Value = value;
			}
		}

		[Column(Name = "speed_unit", Storage="SpeedUnit")]
		[HiddenProperty]
		public TimeUnity SpeedUnit{
			get{
				return Speed.Unity;
			}
			set{
				Speed.Unity = value;
			}
		}

		private TimePeriod _speed = new TimePeriod();
		public TimePeriod Speed{
			get{
				return _speed;
			}
			set{
				_speed = value;
			}
		}


		public override void DeleteObject() {
			DeleteDataValue<VectorFromSubstanceModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "shadowrun5",Name = "substancedescription")]
	public abstract partial class SubstanceDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "substanceexemplar")]
	public abstract partial class SubstanceExemplar : ProductExemplar {
	}
}
