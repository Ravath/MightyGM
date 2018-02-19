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
	[Table(Schema = "pathfinder",Name = "tresor")]
	[CoreData]
	public partial class Tresor : DataObject {

		private int _armes;
		[Column(Storage = "Armes",Name = "armes")]
		public int Armes{
			get{ return _armes;}
			set{_armes = value;}
		}

		private int _objetsPrecieux;
		[Column(Storage = "ObjetsPrecieux",Name = "objetsprecieux")]
		public int ObjetsPrecieux{
			get{ return _objetsPrecieux;}
			set{_objetsPrecieux = value;}
		}

		private int _objetsMagiques;
		[Column(Storage = "ObjetsMagiques",Name = "objetsmagiques")]
		public int ObjetsMagiques{
			get{ return _objetsMagiques;}
			set{_objetsMagiques = value;}
		}

		private int _argent;
		[Column(Storage = "Argent",Name = "argent")]
		public int Argent{
			get{ return _argent;}
			set{_argent = value;}
		}
	}
}
