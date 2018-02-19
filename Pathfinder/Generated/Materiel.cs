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
	[Table(Schema = "pathfinder",Name = "materielmodel")]
	[CoreData]
	public partial class MaterielModel : ObjetModel {

		private MaterielDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MaterielDescription> id = GetModelReferencer<MaterielDescription>();
					if(id.Count() == 0) {
						_obj = new MaterielDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private CategorieMateriel _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieMateriel Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "materieldescription")]
	public partial class MaterielDescription : ObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "materielexemplar")]
	public partial class MaterielExemplar : ObjetExemplar {
	}
}
