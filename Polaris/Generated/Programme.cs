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
	[Table(Schema = "polaris",Name = "programmemodel")]
	[CoreData]
	public partial class ProgrammeModel : DataModel {

		private ProgrammeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ProgrammeDescription> id = GetModelReferencer<ProgrammeDescription>();
					if(id.Count() == 0) {
						_obj = new ProgrammeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}
	}
	[Table(Schema = "polaris",Name = "programmedescription")]
	public partial class ProgrammeDescription : DataDescription<ProgrammeModel> {
	}
	[Table(Schema = "polaris",Name = "programmeexemplar")]
	public partial class ProgrammeExemplar : DataExemplaire<ProgrammeModel> {
	}
}
