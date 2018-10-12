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
	[Table(Schema = "yggdrasil",Name = "objetmodel")]
	[CoreData]
	public partial class ObjetModel : DataModel {

		private ObjetDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ObjetDescription> id = GetModelReferencer<ObjetDescription>();
					if(id.Count() == 0) {
						_obj = new ObjetDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _encombrement;
		[Column(Storage = "Encombrement",Name = "encombrement")]
		public int Encombrement{
			get{ return _encombrement;}
			set{_encombrement = value;}
		}

		private int _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int Prix{
			get{ return _prix;}
			set{_prix = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "objetdescription")]
	public partial class ObjetDescription : DataDescription<ObjetModel> {
	}
	[Table(Schema = "yggdrasil",Name = "objetexemplar")]
	public partial class ObjetExemplar : DataExemplaire<ObjetModel> {
	}
}
