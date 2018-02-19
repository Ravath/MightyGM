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
	[Table(Schema = "pathfinder",Name = "talentsroublardmodel")]
	[CoreData]
	public partial class TalentsRoublardModel : PouvoirSpecialClasseModel {

		private TalentsRoublardDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TalentsRoublardDescription> id = GetModelReferencer<TalentsRoublardDescription>();
					if(id.Count() == 0) {
						_obj = new TalentsRoublardDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _maitreRoublard;
		[Column(Storage = "MaitreRoublard",Name = "maitreroublard")]
		public bool MaitreRoublard{
			get{ return _maitreRoublard;}
			set{_maitreRoublard = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "talentsroublarddescription")]
	public partial class TalentsRoublardDescription : PouvoirSpecialClasseDescription {
	}
	[Table(Schema = "pathfinder",Name = "talentsroublardexemplar")]
	public partial class TalentsRoublardExemplar : PouvoirSpecialClasseExemplar {
	}
}
