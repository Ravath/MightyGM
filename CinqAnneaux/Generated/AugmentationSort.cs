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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "augmentationsort")]
	[CoreData]
	public partial class AugmentationSort : DataObject {

		private TypeAugmentationSort _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeAugmentationSort Type{
			get{ return _type;}
			set{_type = value;}
		}

		private decimal _facteur;
		[Column(Storage = "Facteur",Name = "facteur")]
		public decimal Facteur{
			get{ return _facteur;}
			set{_facteur = value;}
		}
	}
}
