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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "infotable")]
	public abstract partial class InfoTable : DataObject {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}

		private decimal _value;
		[Column(Storage = "Value",Name = "value")]
		public decimal Value{
			get{ return _value;}
			set{_value = value;}
		}

		private string _description = "";
		[LargeText]
		[Column(Storage = "Description",Name = "description")]
		public string Description{
			get{ return _description;}
			set{_description = value;}
		}
	}
}
