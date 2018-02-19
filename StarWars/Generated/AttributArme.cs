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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "attributarmemodel")]
	[CoreData]
	public partial class AttributArmeModel : DataModel {

		private AttributArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AttributArmeDescription> id = GetModelReferencer<AttributArmeDescription>();
					if(id.Count() == 0) {
						_obj = new AttributArmeDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private bool _declenche;
		[Column(Storage = "Declenche",Name = "declenche")]
		public bool Declenche{
			get{ return _declenche;}
			set{_declenche = value;}
		}

		private bool _hasrangs;
		[Column(Storage = "Hasrangs",Name = "hasrangs")]
		public bool Hasrangs{
			get{ return _hasrangs;}
			set{_hasrangs = value;}
		}
	}
	[Table(Schema = "starwars",Name = "attributarmedescription")]
	public partial class AttributArmeDescription : DataDescription<AttributArmeModel> {
	}
	[Table(Schema = "starwars",Name = "attributarmeexemplar")]
	public partial class AttributArmeExemplar : DataExemplaire<AttributArmeModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
