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
	[Table(Schema = "shadowrun5",Name = "qualitymodel")]
	public abstract partial class QualityModel : DataModel {

		private int _cost;
		[Column(Storage = "Cost",Name = "cost")]
		public int Cost{
			get{ return _cost;}
			set{_cost = value;}
		}

		private int? _maxLevel;
		[Column(Storage = "MaxLevel",Name = "maxlevel")]
		public int? MaxLevel{
			get{ return _maxLevel;}
			set{_maxLevel = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "qualitydescription")]
	public abstract partial class QualityDescription : DataDescription<QualityModel> {
	}
	[Table(Schema = "shadowrun5",Name = "qualityexemplar")]
	public abstract partial class QualityExemplar : DataExemplaire<QualityModel> {

		private int _level;
		[Column(Storage = "Level",Name = "level")]
		public int Level{
			get{ return _level;}
			set{_level = value;}
		}
	}
}
