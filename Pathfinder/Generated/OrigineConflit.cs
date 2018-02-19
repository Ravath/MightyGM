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
	[Table(Schema = "pathfinder",Name = "origineconflitmodel")]
	[CoreData]
	public partial class OrigineConflitModel : AbsOddTableModel {

		private OrigineConflitDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<OrigineConflitDescription> id = GetModelReferencer<OrigineConflitDescription>();
					if(id.Count() == 0) {
						_obj = new OrigineConflitDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _pCon;
		[Column(Storage = "PCon",Name = "pcon")]
		public int PCon{
			get{ return _pCon;}
			set{_pCon = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "origineconflitdescription")]
	public partial class OrigineConflitDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "origineconflitexemplar")]
	public partial class OrigineConflitExemplar : AbsOddTableExemplar {
	}
}
