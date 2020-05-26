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
	[Table(Schema = "polaris",Name = "specialarmemodel")]
	[CoreData]
	public partial class SpecialArmeModel : DataModel {

		private SpecialArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpecialArmeDescription> id = GetModelReferencer<SpecialArmeDescription>();
					if(id.Count() == 0) {
						_obj = new SpecialArmeDescription();
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
	[Table(Schema = "polaris",Name = "specialarmedescription")]
	public partial class SpecialArmeDescription : DataDescription<SpecialArmeModel> {
	}
	[Table(Schema = "polaris",Name = "specialarmeexemplar")]
	public partial class SpecialArmeExemplar : DataExemplaire<SpecialArmeModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
