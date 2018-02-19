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
	[Table(Schema = "shadowrun5",Name = "vehiclemodel")]
	[CoreData]
	public partial class VehicleModel : ProductModel {

		private VehicleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<VehicleDescription> id = GetModelReferencer<VehicleDescription>();
					if(id.Count() == 0) {
						_obj = new VehicleDescription();
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

		private int _handlingOnRoad;
		[Column(Storage = "HandlingOnRoad",Name = "handlingonroad")]
		public int HandlingOnRoad{
			get{ return _handlingOnRoad;}
			set{_handlingOnRoad = value;}
		}

		private int _handlingOffRoad;
		[Column(Storage = "HandlingOffRoad",Name = "handlingoffroad")]
		public int HandlingOffRoad{
			get{ return _handlingOffRoad;}
			set{_handlingOffRoad = value;}
		}

		private int _speedOnRoad;
		[Column(Storage = "SpeedOnRoad",Name = "speedonroad")]
		public int SpeedOnRoad{
			get{ return _speedOnRoad;}
			set{_speedOnRoad = value;}
		}

		private int _speedOffRoad;
		[Column(Storage = "SpeedOffRoad",Name = "speedoffroad")]
		public int SpeedOffRoad{
			get{ return _speedOffRoad;}
			set{_speedOffRoad = value;}
		}

		private int _acceleration;
		[Column(Storage = "Acceleration",Name = "acceleration")]
		public int Acceleration{
			get{ return _acceleration;}
			set{_acceleration = value;}
		}

		private int _body;
		[Column(Storage = "Body",Name = "body")]
		public int Body{
			get{ return _body;}
			set{_body = value;}
		}

		private int _armor;
		[Column(Storage = "Armor",Name = "armor")]
		public int Armor{
			get{ return _armor;}
			set{_armor = value;}
		}

		private int _pilot;
		[Column(Storage = "Pilot",Name = "pilot")]
		public int Pilot{
			get{ return _pilot;}
			set{_pilot = value;}
		}

		private int _sensor;
		[Column(Storage = "Sensor",Name = "sensor")]
		public int Sensor{
			get{ return _sensor;}
			set{_sensor = value;}
		}

		private int _seats;
		[Column(Storage = "Seats",Name = "seats")]
		public int Seats{
			get{ return _seats;}
			set{_seats = value;}
		}

		private VehicleCategory _category;
		[Column(Storage = "Category",Name = "category")]
		public VehicleCategory Category{
			get{ return _category;}
			set{_category = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "vehicledescription")]
	public partial class VehicleDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "vehicleexemplar")]
	public partial class VehicleExemplar : ProductExemplar {
	}
}
