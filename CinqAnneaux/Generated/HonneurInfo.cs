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
	[Table(Schema = "cinqanneaux",Name = "honneurinfo")]
	[CoreData]
	public partial class HonneurInfo : DataObject {

		private int _seuil1;
		[Column(Storage = "Seuil1",Name = "seuil1")]
		public int Seuil1{
			get{ return _seuil1;}
			set{_seuil1 = value;}
		}

		private int _seuil2;
		[Column(Storage = "Seuil2",Name = "seuil2")]
		public int Seuil2{
			get{ return _seuil2;}
			set{_seuil2 = value;}
		}

		private int _seuil3;
		[Column(Storage = "Seuil3",Name = "seuil3")]
		public int Seuil3{
			get{ return _seuil3;}
			set{_seuil3 = value;}
		}

		private int _seuil4;
		[Column(Storage = "Seuil4",Name = "seuil4")]
		public int Seuil4{
			get{ return _seuil4;}
			set{_seuil4 = value;}
		}

		private int _seuil5;
		[Column(Storage = "Seuil5",Name = "seuil5")]
		public int Seuil5{
			get{ return _seuil5;}
			set{_seuil5 = value;}
		}

		private int _seuil6;
		[Column(Storage = "Seuil6",Name = "seuil6")]
		public int Seuil6{
			get{ return _seuil6;}
			set{_seuil6 = value;}
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
