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
	[Table(Schema = "shadowrun5",Name = "electronicmodel")]
	public abstract partial class ElectronicModel : ProductModel {

		private int _rating;
		[Column(Storage = "Rating",Name = "rating")]
		public int Rating{
			get{ return _rating;}
			set{_rating = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "electronicdescription")]
	public abstract partial class ElectronicDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "electronicexemplar")]
	public abstract partial class ElectronicExemplar : ProductExemplar {
	}
}
