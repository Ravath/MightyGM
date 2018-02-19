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
	[Table(Schema = "pathfinder",Name = "resolutionconflitmodel")]
	[CoreData]
	public partial class ResolutionConflitModel : DataModel {

		private ResolutionConflitDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ResolutionConflitDescription> id = GetModelReferencer<ResolutionConflitDescription>();
					if(id.Count() == 0) {
						_obj = new ResolutionConflitDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _modPCon;
		[Column(Storage = "ModPCon",Name = "modpcon")]
		public int ModPCon{
			get{ return _modPCon;}
			set{_modPCon = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "resolutionconflitdescription")]
	public partial class ResolutionConflitDescription : DataDescription<ResolutionConflitModel> {
	}
	[Table(Schema = "pathfinder",Name = "resolutionconflitexemplar")]
	public partial class ResolutionConflitExemplar : DataExemplaire<ResolutionConflitModel> {
	}
}
