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
	[Table(Schema = "pathfinder",Name = "evenementrenomee")]
	[CoreData]
	public partial class EvenementRenomee : DataObject {

		private string _evenement = "";
		[Column(Storage = "Evenement",Name = "evenement")]
		public string Evenement{
			get{ return _evenement;}
			set{_evenement = value;}
		}

		private int _ptsRenomee;
		[Column(Storage = "PtsRenomee",Name = "ptsrenomee")]
		public int PtsRenomee{
			get{ return _ptsRenomee;}
			set{_ptsRenomee = value;}
		}
	}
}
