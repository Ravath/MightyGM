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
	[Table(Schema = "pathfinder",Name = "languemodel")]
	[CoreData]
	public partial class LangueModel : DataModel {

		private LangueDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<LangueDescription> id = GetModelReferencer<LangueDescription>();
					if(id.Count() == 0) {
						_obj = new LangueDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private string _alphabet = "";
		[Column(Storage = "Alphabet",Name = "alphabet")]
		public string Alphabet{
			get{ return _alphabet;}
			set{_alphabet = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "languedescription")]
	public partial class LangueDescription : DataDescription<LangueModel> {
	}
	[Table(Schema = "pathfinder",Name = "langueexemplar")]
	public partial class LangueExemplar : DataExemplaire<LangueModel> {

		private bool _comprend;
		[Column(Storage = "Comprend",Name = "comprend")]
		public bool Comprend{
			get{ return _comprend;}
			set{_comprend = value;}
		}

		private bool _parle;
		[Column(Storage = "Parle",Name = "parle")]
		public bool Parle{
			get{ return _parle;}
			set{_parle = value;}
		}

		private bool _lit;
		[Column(Storage = "Lit",Name = "lit")]
		public bool Lit{
			get{ return _lit;}
			set{_lit = value;}
		}
	}
}
