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
	[Table(Schema = "dd35",Name = "objetmodel")]
	public abstract partial class ObjetModel : DataModel {

		private decimal? _poids;
		[Column(Storage = "Poids",Name = "poids")]
		public decimal? Poids{
			get{ return _poids;}
			set{_poids = value;}
		}
	}
	[Table(Schema = "dd35",Name = "objetdescription")]
	public abstract partial class ObjetDescription : DataDescription<ObjetModel> {
	}
	[Table(Schema = "dd35",Name = "objetexemplar")]
	public abstract partial class ObjetExemplar : DataExemplaire<ObjetModel> {

		private int _solidite;
		[Column(Storage = "Solidite",Name = "solidite")]
		public int Solidite{
			get{ return _solidite;}
			set{_solidite = value;}
		}

		private CategorieTaille _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public CategorieTaille Taille{
			get{ return _taille;}
			set{_taille = value;}
		}
	}
}
