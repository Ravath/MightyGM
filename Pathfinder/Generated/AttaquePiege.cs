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
	[Table(Schema = "pathfinder",Name = "attaquepiege")]
	[CoreData]
	public partial class AttaquePiege : DataObject {

		private bool _aDistance;
		[Column(Storage = "ADistance",Name = "adistance")]
		public bool ADistance{
			get{ return _aDistance;}
			set{_aDistance = value;}
		}

		private int _attaque;
		[Column(Storage = "Attaque",Name = "attaque")]
		public int Attaque{
			get{ return _attaque;}
			set{_attaque = value;}
		}

		private int _nbrDes;
		[Column(Storage = "nbrDes",Name = "nbrdes")]
		public int nbrDes{
			get{ return _nbrDes;}
			set{_nbrDes = value;}
		}

		private int _typeDes;
		[Column(Storage = "TypeDes",Name = "typedes")]
		public int TypeDes{
			get{ return _typeDes;}
			set{_typeDes = value;}
		}

		private int _zoneCritique;
		[Column(Storage = "ZoneCritique",Name = "zonecritique")]
		public int ZoneCritique{
			get{ return _zoneCritique;}
			set{_zoneCritique = value;}
		}

		private int _facteurCritique;
		[Column(Storage = "FacteurCritique",Name = "facteurcritique")]
		public int FacteurCritique{
			get{ return _facteurCritique;}
			set{_facteurCritique = value;}
		}
	}
}
