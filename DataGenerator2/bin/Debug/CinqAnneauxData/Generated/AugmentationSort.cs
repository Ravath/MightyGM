using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[CoreData]
	[Table(Schema = "cinqanneaux",Name = "augmentationsort_model")]
	public partial class AugmentationSortModel : DataModel {

		private TypeAugmentationSort _Type;
		[Column(Storage = "Type",Name = "type")]
		public TypeAugmentationSort Type{
			get{ return _Type;}
			set{_Type = value;}
		}

		private decimal _facteur;
		[Column(Storage = "Facteur",Name = "facteur")]
		public decimal Facteur{
			get{ return _facteur;}
			set{_facteur = value;}
		}

		private string _unite;
		[Column(Storage = "Unite",Name = "unite")]
		public string Unite{
			get{ return _unite;}
			set{_unite = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "augmentationsort_exemplar")]
	public partial class AugmentationSortExemplar : DataExemplaire<AugmentationSortModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "augmentationsort_description")]
	public partial class AugmentationSortDescription : DataDescription<AugmentationSortModel> {
	}
}
