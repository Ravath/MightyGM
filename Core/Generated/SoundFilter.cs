using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "soundfilter")]
	[CoreData]
	public partial class SoundFilter : DataObject {

		private SoundFilterType _type;
		[Column(Storage = "type",Name = "type")]
		public SoundFilterType type{
			get{ return _type;}
			set{_type = value;}
		}

		private string _values = "";
		[Column(Storage = "values",Name = "values")]
		public string values{
			get{ return _values;}
			set{_values = value;}
		}
	}
}
