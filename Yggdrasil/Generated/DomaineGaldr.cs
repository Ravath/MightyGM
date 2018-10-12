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
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "domainegaldrmodel")]
	[CoreData]
	public partial class DomaineGaldrModel : DataModel {

		private DomaineGaldrDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DomaineGaldrDescription> id = GetModelReferencer<DomaineGaldrDescription>();
					if(id.Count() == 0) {
						_obj = new DomaineGaldrDescription();
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
	[Table(Schema = "yggdrasil",Name = "domainegaldrdescription")]
	public partial class DomaineGaldrDescription : DataDescription<DomaineGaldrModel> {
	}
	[Table(Schema = "yggdrasil",Name = "domainegaldrexemplar")]
	public partial class DomaineGaldrExemplar : DataExemplaire<DomaineGaldrModel> {
	}
}
