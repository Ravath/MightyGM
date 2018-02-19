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
	[Table(Schema = "pathfinder",Name = "requismodel")]
	[CoreData]
	public partial class RequisModel : DataModel {

		private RequisDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RequisDescription> id = GetModelReferencer<RequisDescription>();
					if(id.Count() == 0) {
						_obj = new RequisDescription();
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
	[Table(Schema = "pathfinder",Name = "requisdescription")]
	public partial class RequisDescription : DataDescription<RequisModel> {
	}
	[Table(Schema = "pathfinder",Name = "requisexemplar")]
	public partial class RequisExemplar : DataExemplaire<RequisModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
