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
	[Table(Schema = "shadowrun5",Name = "devicemodificationmodel")]
	[CoreData]
	public partial class DeviceModificationModel : ProductModel {

		private DeviceModificationDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DeviceModificationDescription> id = GetModelReferencer<DeviceModificationDescription>();
					if(id.Count() == 0) {
						_obj = new DeviceModificationDescription();
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

		private DeviceType _type;
		[Column(Storage = "Type",Name = "type")]
		public DeviceType Type{
			get{ return _type;}
			set{_type = value;}
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

		private int _capacity;
		[Column(Storage = "Capacity",Name = "capacity")]
		public int Capacity{
			get{ return _capacity;}
			set{_capacity = value;}
		}

		private bool _capacityisRating;
		[Column(Storage = "CapacityisRating",Name = "capacityisrating")]
		public bool CapacityisRating{
			get{ return _capacityisRating;}
			set{_capacityisRating = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "devicemodificationdescription")]
	public partial class DeviceModificationDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "devicemodificationexemplar")]
	public partial class DeviceModificationExemplar : ProductExemplar {
	}
}
