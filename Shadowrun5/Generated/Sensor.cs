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
	[Table(Schema = "shadowrun5",Name = "sensormodel")]
	[CoreData]
	public partial class SensorModel : AbsDeviceModel {

		private SensorDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SensorDescription> id = GetModelReferencer<SensorDescription>();
					if(id.Count() == 0) {
						_obj = new SensorDescription();
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

		private int _minRating;
		[Column(Storage = "MinRating",Name = "minrating")]
		public int MinRating{
			get{ return _minRating;}
			set{_minRating = value;}
		}

		private int _maxRating;
		[Column(Storage = "MaxRating",Name = "maxrating")]
		public int MaxRating{
			get{ return _maxRating;}
			set{_maxRating = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "sensordescription")]
	public partial class SensorDescription : AbsDeviceDescription {
	}
	[Table(Schema = "shadowrun5",Name = "sensorexemplar")]
	public partial class SensorExemplar : AbsDeviceExemplar {

		private int _sensorTypeId;
		[Column(Storage = "SensorTypeId",Name = "fk_sensorfunctionmodel_sensortype")]
		[HiddenProperty]
		public int SensorTypeId{
			get{ return _sensorTypeId;}
			set{_sensorTypeId = value;}
		}

		private SensorFunctionModel _sensorType;
		public SensorFunctionModel SensorType{
			get{
				if( _sensorType == null)
					_sensorType = LoadById<SensorFunctionModel>(SensorTypeId);
				return _sensorType;
			} set {
				if(_sensorType == value){return;}
				_sensorType = value;
				if( value != null)
					SensorTypeId = value.Id;
			}
		}
	}
}
