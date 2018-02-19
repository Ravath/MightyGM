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
	[Table(Schema = "pathfinder",Name = "evenementmodel")]
	[CoreData]
	public partial class EvenementModel : AbsOddTableModel {

		private EvenementDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EvenementDescription> id = GetModelReferencer<EvenementDescription>();
					if(id.Count() == 0) {
						_obj = new EvenementDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _continu;
		[Column(Storage = "Continu",Name = "continu")]
		public bool Continu{
			get{ return _continu;}
			set{_continu = value;}
		}

		private bool _royaume;
		[Column(Storage = "Royaume",Name = "royaume")]
		public bool Royaume{
			get{ return _royaume;}
			set{_royaume = value;}
		}

		private bool _communaute;
		[Column(Storage = "Communaute",Name = "communaute")]
		public bool Communaute{
			get{ return _communaute;}
			set{_communaute = value;}
		}

		private bool _nefaste;
		[Column(Storage = "Nefaste",Name = "nefaste")]
		public bool Nefaste{
			get{ return _nefaste;}
			set{_nefaste = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "evenementdescription")]
	public partial class EvenementDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "evenementexemplar")]
	public partial class EvenementExemplar : AbsOddTableExemplar {
	}
}
