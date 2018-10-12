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
	[Table(Schema = "yggdrasil",Name = "domainesejdrmodel")]
	[CoreData]
	public partial class DomaineSejdrModel : DataModel {

		private DomaineSejdrDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DomaineSejdrDescription> id = GetModelReferencer<DomaineSejdrDescription>();
					if(id.Count() == 0) {
						_obj = new DomaineSejdrDescription();
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
	[Table(Schema = "yggdrasil",Name = "domainesejdrdescription")]
	public partial class DomaineSejdrDescription : DataDescription<DomaineSejdrModel> {
	}
	[Table(Schema = "yggdrasil",Name = "domainesejdrexemplar")]
	public partial class DomaineSejdrExemplar : DataExemplaire<DomaineSejdrModel> {
	}
}
