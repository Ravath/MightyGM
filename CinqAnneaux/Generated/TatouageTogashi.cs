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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "tatouagetogashimodel")]
	[CoreData]
	public partial class TatouageTogashiModel : DataModel {

		private TatouageTogashiDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TatouageTogashiDescription> id = GetModelReferencer<TatouageTogashiDescription>();
					if(id.Count() == 0) {
						_obj = new TatouageTogashiDescription();
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
	[Table(Schema = "cinqanneaux",Name = "tatouagetogashidescription")]
	public partial class TatouageTogashiDescription : DataDescription<TatouageTogashiModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "tatouagetogashiexemplar")]
	public partial class TatouageTogashiExemplar : DataExemplaire<TatouageTogashiModel> {

		private string _complement = "";
		[Column(Storage = "Complement",Name = "complement")]
		public string Complement{
			get{ return _complement;}
			set{_complement = value;}
		}
	}
}
