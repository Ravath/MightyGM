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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "tablesorts")]
	public abstract partial class TableSorts : DataObject {

		private int _niveauClasse;
		[Column(Storage = "NiveauClasse",Name = "niveauclasse")]
		public int NiveauClasse{
			get{ return _niveauClasse;}
			set{_niveauClasse = value;}
		}

		private int _lvl1;
		[Column(Storage = "lvl1",Name = "lvl1")]
		public int lvl1{
			get{ return _lvl1;}
			set{_lvl1 = value;}
		}

		private int _lvl2;
		[Column(Storage = "lvl2",Name = "lvl2")]
		public int lvl2{
			get{ return _lvl2;}
			set{_lvl2 = value;}
		}

		private int _lvl3;
		[Column(Storage = "lvl3",Name = "lvl3")]
		public int lvl3{
			get{ return _lvl3;}
			set{_lvl3 = value;}
		}

		private int _lvl4;
		[Column(Storage = "lvl4",Name = "lvl4")]
		public int lvl4{
			get{ return _lvl4;}
			set{_lvl4 = value;}
		}

		private int _lvl5;
		[Column(Storage = "lvl5",Name = "lvl5")]
		public int lvl5{
			get{ return _lvl5;}
			set{_lvl5 = value;}
		}

		private int _lvl6;
		[Column(Storage = "lvl6",Name = "lvl6")]
		public int lvl6{
			get{ return _lvl6;}
			set{_lvl6 = value;}
		}

		private int _lvl7;
		[Column(Storage = "lvl7",Name = "lvl7")]
		public int lvl7{
			get{ return _lvl7;}
			set{_lvl7 = value;}
		}

		private int _lvl8;
		[Column(Storage = "lvl8",Name = "lvl8")]
		public int lvl8{
			get{ return _lvl8;}
			set{_lvl8 = value;}
		}

		private int _lvl9;
		[Column(Storage = "lvl9",Name = "lvl9")]
		public int lvl9{
			get{ return _lvl9;}
			set{_lvl9 = value;}
		}
	}
}
