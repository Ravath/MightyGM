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
	[Table(Schema = "shadowrun5",Name = "productmodel")]
	public abstract partial class ProductModel : DataModel {

		private int _availabilityLevel;
		[Column(Storage = "AvailabilityLevel",Name = "availabilitylevel")]
		public int AvailabilityLevel{
			get{ return _availabilityLevel;}
			set{_availabilityLevel = value;}
		}

		private AvailabilityType _availabilityType;
		[Column(Storage = "AvailabilityType",Name = "availabilitytype")]
		public AvailabilityType AvailabilityType{
			get{ return _availabilityType;}
			set{_availabilityType = value;}
		}

		private int _cost;
		[Column(Storage = "Cost",Name = "cost")]
		public int Cost{
			get{ return _cost;}
			set{_cost = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "productdescription")]
	public abstract partial class ProductDescription : DataDescription<ProductModel> {
	}
	[Table(Schema = "shadowrun5",Name = "productexemplar")]
	public abstract partial class ProductExemplar : DataExemplaire<ProductModel> {

		private int _quantity;
		[Column(Storage = "Quantity",Name = "quantity")]
		public int Quantity{
			get{ return _quantity;}
			set{_quantity = value;}
		}
	}
}
