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
	[Table(Schema = "starwars",Name = "obligationsmodel")]
	[CoreData]
	public partial class ObligationsModel : DataModel {

		private ObligationsDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ObligationsDescription> id = GetModelReferencer<ObligationsDescription>();
					if(id.Count() == 0) {
						_obj = new ObligationsDescription();
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
	}
	[Table(Schema = "starwars",Name = "obligationsdescription")]
	public partial class ObligationsDescription : DataDescription<ObligationsModel> {
	}
	[Table(Schema = "starwars",Name = "obligationsexemplar")]
	public partial class ObligationsExemplar : DataExemplaire<ObligationsModel> {

		private int _valeur;
		[Column(Storage = "Valeur",Name = "valeur")]
		public int Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
