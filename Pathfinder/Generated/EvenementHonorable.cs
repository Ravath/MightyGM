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
	[Table(Schema = "pathfinder",Name = "evenementhonorable")]
	[CoreData]
	public partial class EvenementHonorable : DataObject {

		private TypeCode _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeCode Type{
			get{ return _type;}
			set{_type = value;}
		}

		private string _evenement = "";
		[Column(Storage = "Evenement",Name = "evenement")]
		public string Evenement{
			get{ return _evenement;}
			set{_evenement = value;}
		}

		private int _ptsHonneur;
		[Column(Storage = "PtsHonneur",Name = "ptshonneur")]
		public int PtsHonneur{
			get{ return _ptsHonneur;}
			set{_ptsHonneur = value;}
		}
	}
}
