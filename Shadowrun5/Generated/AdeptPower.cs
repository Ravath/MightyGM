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
	[Table(Schema = "shadowrun5",Name = "adeptpowermodel")]
	[CoreData]
	public partial class AdeptPowerModel : DataModel {

		private AdeptPowerDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AdeptPowerDescription> id = GetModelReferencer<AdeptPowerDescription>();
					if(id.Count() == 0) {
						_obj = new AdeptPowerDescription();
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

		private double _cost;
		[Column(Storage = "Cost",Name = "cost")]
		public double Cost{
			get{ return _cost;}
			set{_cost = value;}
		}

		private bool _multiLevel;
		[Column(Storage = "MultiLevel",Name = "multilevel")]
		public bool MultiLevel{
			get{ return _multiLevel;}
			set{_multiLevel = value;}
		}

		private Action? _activation;
		[Column(Storage = "Activation",Name = "activation")]
		public Action? Activation{
			get{ return _activation;}
			set{_activation = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "adeptpowerdescription")]
	public partial class AdeptPowerDescription : DataDescription<AdeptPowerModel> {
	}
	[Table(Schema = "shadowrun5",Name = "adeptpowerexemplar")]
	public partial class AdeptPowerExemplar : DataExemplaire<AdeptPowerModel> {
	}
}
