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
	[Table(Schema = "polaris",Name = "attaquecreaturemodel")]
	[CoreData]
	public partial class AttaqueCreatureModel : DataModel {

		private AttaqueCreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AttaqueCreatureDescription> id = GetModelReferencer<AttaqueCreatureDescription>();
					if(id.Count() == 0) {
						_obj = new AttaqueCreatureDescription();
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
	[Table(Schema = "polaris",Name = "attaquecreaturedescription")]
	public partial class AttaqueCreatureDescription : DataDescription<AttaqueCreatureModel> {
	}
	[Table(Schema = "polaris",Name = "attaquecreatureexemplar")]
	public partial class AttaqueCreatureExemplar : DataExemplaire<AttaqueCreatureModel> {
	}
}
