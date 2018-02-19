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
	[Table(Schema = "starwars",Name = "blessurecritiquemodel")]
	[CoreData]
	public partial class BlessureCritiqueModel : DataModel {

		private BlessureCritiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<BlessureCritiqueDescription> id = GetModelReferencer<BlessureCritiqueDescription>();
					if(id.Count() == 0) {
						_obj = new BlessureCritiqueDescription();
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

		private DifficulteTest _gravite;
		[Column(Storage = "Gravite",Name = "gravite")]
		public DifficulteTest Gravite {
			get{ return _gravite;}
			set{_gravite = value;}
		}
		
		private bool _critVehicule;
		[Column(Storage = "Vehicule", Name = "bvehicule")]
		public bool Vehicule {
			get { return _critVehicule; }
			set { _critVehicule = value; }
		}

	}
	[Table(Schema = "starwars",Name = "blessurecritiquedescription")]
	public partial class BlessureCritiqueDescription : DataDescription<BlessureCritiqueModel> {
	}
	[Table(Schema = "starwars",Name = "blessurecritiqueexemplar")]
	public partial class BlessureCritiqueExemplar : DataExemplaire<BlessureCritiqueModel> {
	}
}
