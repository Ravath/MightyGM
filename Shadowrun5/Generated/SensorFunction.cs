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
	[Table(Schema = "shadowrun5",Name = "sensorfunctionmodel")]
	[CoreData]
	public partial class SensorFunctionModel : DataModel {

		private SensorFunctionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SensorFunctionDescription> id = GetModelReferencer<SensorFunctionDescription>();
					if(id.Count() == 0) {
						_obj = new SensorFunctionDescription();
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

		private int _maxRange;
		[Column(Storage = "MaxRange",Name = "maxrange")]
		public int MaxRange{
			get{ return _maxRange;}
			set{_maxRange = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "sensorfunctiondescription")]
	public partial class SensorFunctionDescription : DataDescription<SensorFunctionModel> {
	}
	[Table(Schema = "shadowrun5",Name = "sensorfunctionexemplar")]
	public partial class SensorFunctionExemplar : DataExemplaire<SensorFunctionModel> {
	}
}
