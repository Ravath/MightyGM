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
	[Table(Schema = "shadowrun5",Name = "devicemodel")]
	[CoreData]
	public partial class DeviceModel : AbsDeviceModel {

		private DeviceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DeviceDescription> id = GetModelReferencer<DeviceDescription>();
					if(id.Count() == 0) {
						_obj = new DeviceDescription();
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
	}
	[Table(Schema = "shadowrun5",Name = "devicedescription")]
	public partial class DeviceDescription : AbsDeviceDescription {
	}
	[Table(Schema = "shadowrun5",Name = "deviceexemplar")]
	public partial class DeviceExemplar : AbsDeviceExemplar {
	}
}
