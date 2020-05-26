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
	[Table(Schema = "polaris",Name = "categoriematerielmodel")]
	[CoreData]
	public partial class CategorieMaterielModel : DataModel {

		private CategorieMaterielDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CategorieMaterielDescription> id = GetModelReferencer<CategorieMaterielDescription>();
					if(id.Count() == 0) {
						_obj = new CategorieMaterielDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "polaris",Name = "categoriematerieldescription")]
	public partial class CategorieMaterielDescription : DataDescription<CategorieMaterielModel> {
	}
	[Table(Schema = "polaris",Name = "categoriematerielexemplar")]
	public partial class CategorieMaterielExemplar : DataExemplaire<CategorieMaterielModel> {
	}
}
