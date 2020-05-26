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
	[Table(Schema = "yggdrasil",Name = "blessuremodel")]
	[CoreData]
	public partial class BlessureModel : DataModel {

		private BlessureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<BlessureDescription> id = GetModelReferencer<BlessureDescription>();
					if(id.Count() == 0) {
						_obj = new BlessureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _oddMin;
		[Column(Storage = "oddMin",Name = "oddmin")]
		public int oddMin{
			get{ return _oddMin;}
			set{_oddMin = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "blessuredescription")]
	public partial class BlessureDescription : DataDescription<BlessureModel> {
	}
	[Table(Schema = "yggdrasil",Name = "blessureexemplar")]
	public partial class BlessureExemplar : DataExemplaire<BlessureModel> {

		private bool _sequelle;
		[Column(Storage = "Sequelle",Name = "sequelle")]
		public bool Sequelle{
			get{ return _sequelle;}
			set{_sequelle = value;}
		}
	}
}
