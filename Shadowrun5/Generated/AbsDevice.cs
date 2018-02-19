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
	[Table(Schema = "shadowrun5",Name = "absdevicemodel")]
	public abstract partial class AbsDeviceModel : ProductModel {

		private DeviceType _deviceType;
		[Column(Storage = "DeviceType",Name = "devicetype")]
		public DeviceType DeviceType{
			get{ return _deviceType;}
			set{_deviceType = value;}
		}

		private int _minCapacity;
		[Column(Storage = "MinCapacity",Name = "mincapacity")]
		public int MinCapacity{
			get{ return _minCapacity;}
			set{_minCapacity = value;}
		}

		private int _maxCapacity;
		[Column(Storage = "MaxCapacity",Name = "maxcapacity")]
		public int MaxCapacity{
			get{ return _maxCapacity;}
			set{_maxCapacity = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "absdevicedescription")]
	public abstract partial class AbsDeviceDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "absdeviceexemplar")]
	public abstract partial class AbsDeviceExemplar : ProductExemplar {

		private IEnumerable<DeviceModificationModel> _modifications;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Modifications",OtherKey = "AbsDeviceExemplarId")]
		public IEnumerable <DeviceModificationModel> Modifications{
			get{
				if( _modifications == null ){
					_modifications = LoadFromJointure<DeviceModificationModel,AbsDeviceExemplarToDeviceModificationModel_Modifications>(false);
				}
				return _modifications;
			}
			set{
				SaveToJointure<DeviceModificationModel, AbsDeviceExemplarToDeviceModificationModel_Modifications> (_modifications, value,false);
				_modifications = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsDeviceExemplar,AbsDeviceExemplarToDeviceModificationModel_Modifications>(true);
			base.DeleteObject();
		}
	}
}
