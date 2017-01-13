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
	[Table(Schema = "starwars",Name = "modcaracteristiquemodel")]
	[CoreData]
	public partial class ModCaracteristiqueModel : ModModel {

		private ModCaracteristiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ModCaracteristiqueDescription> id = GetModelReferencer<ModCaracteristiqueDescription>();
					if(id.Count() == 0) {
						_obj = new ModCaracteristiqueDescription();
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

		private Caracteristique _caracteristique;
		[Column(Storage = "Caracteristique",Name = "caracteristique")]
		public Caracteristique Caracteristique{
			get{ return _caracteristique;}
			set{_caracteristique = value;}
		}
	}
	[Table(Schema = "starwars",Name = "modcaracteristiquedescription")]
	public partial class ModCaracteristiqueDescription : ModDescription {
	}
	[Table(Schema = "starwars",Name = "modcaracteristiqueexemplar")]
	public partial class ModCaracteristiqueExemplar : ModExemplar {
	}
}
