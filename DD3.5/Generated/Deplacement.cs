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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "deplacement")]
	[CoreData]
	public partial class Deplacement : DataObject {

		private int _distance;
		[Column(Storage = "Distance",Name = "distance")]
		public int Distance{
			get{ return _distance;}
			set{_distance = value;}
		}

		private TypeDeplacement _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeDeplacement Type{
			get{ return _type;}
			set{_type = value;}
		}
	}
}
