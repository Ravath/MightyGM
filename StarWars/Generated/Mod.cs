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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "modmodel")]
	public abstract partial class ModModel : DataModel {

		private int _rangMax;
		[Column(Storage = "RangMax",Name = "rangmax")]
		public int RangMax{
			get{ return _rangMax;}
			set{_rangMax = value;}
		}
	}
	[Table(Schema = "starwars",Name = "moddescription")]
	public abstract partial class ModDescription : DataDescription<ModModel> {
	}
	[Table(Schema = "starwars",Name = "modexemplar")]
	public abstract partial class ModExemplar : DataExemplaire<ModModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
