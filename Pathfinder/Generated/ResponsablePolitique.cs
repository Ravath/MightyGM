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
	[Table(Schema = "pathfinder",Name = "responsablepolitiquemodel")]
	[CoreData]
	public partial class ResponsablePolitiqueModel : DataModel {

		private ResponsablePolitiqueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ResponsablePolitiqueDescription> id = GetModelReferencer<ResponsablePolitiqueDescription>();
					if(id.Count() == 0) {
						_obj = new ResponsablePolitiqueDescription();
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
	[Table(Schema = "pathfinder",Name = "responsablepolitiquedescription")]
	public partial class ResponsablePolitiqueDescription : DataDescription<ResponsablePolitiqueModel> {

		private string _avantage = "";
		[LargeText]
		[Column(Storage = "Avantage",Name = "avantage")]
		public string Avantage{
			get{ return _avantage;}
			set{_avantage = value;}
		}

		private string _fonctionInoccupee = "";
		[LargeText]
		[Column(Storage = "FonctionInoccupee",Name = "fonctioninoccupee")]
		public string FonctionInoccupee{
			get{ return _fonctionInoccupee;}
			set{_fonctionInoccupee = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "responsablepolitiqueexemplar")]
	public partial class ResponsablePolitiqueExemplar : DataExemplaire<ResponsablePolitiqueModel> {
	}
}
