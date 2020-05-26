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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "ordinateur")]
	[CoreData]
	public partial class Ordinateur : DataObject {

		private int _gEN;
		[Column(Storage = "GEN",Name = "gen")]
		public int GEN{
			get{ return _gEN;}
			set{_gEN = value;}
		}

		private int _nT;
		[Column(Storage = "NT",Name = "nt")]
		public int NT{
			get{ return _nT;}
			set{_nT = value;}
		}

		private int _disponibilite;
		[Column(Storage = "Disponibilite",Name = "disponibilite")]
		public int Disponibilite{
			get{ return _disponibilite;}
			set{_disponibilite = value;}
		}

		private int _poids;
		[Column(Storage = "Poids",Name = "poids")]
		public int Poids{
			get{ return _poids;}
			set{_poids = value;}
		}
	}
}
