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
	[Table(Schema = "pathfinder",Name = "etatmodel")]
	[CoreData]
	public partial class EtatModel : DataModel {

		private EtatDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EtatDescription> id = GetModelReferencer<EtatDescription>();
					if(id.Count() == 0) {
						_obj = new EtatDescription();
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
	[Table(Schema = "pathfinder",Name = "etatdescription")]
	public partial class EtatDescription : DataDescription<EtatModel> {
	}
	[Table(Schema = "pathfinder",Name = "etatexemplar")]
	public partial class EtatExemplar : DataExemplaire<EtatModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
