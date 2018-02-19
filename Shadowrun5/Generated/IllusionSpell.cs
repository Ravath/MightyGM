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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "illusionspellmodel")]
	[CoreData]
	public partial class IllusionSpellModel : SpellModel {

		private IllusionSpellDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<IllusionSpellDescription> id = GetModelReferencer<IllusionSpellDescription>();
					if(id.Count() == 0) {
						_obj = new IllusionSpellDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private bool _realistic;
		[Column(Storage = "Realistic",Name = "realistic")]
		public bool Realistic{
			get{ return _realistic;}
			set{_realistic = value;}
		}

		private bool _singleSense;
		[Column(Storage = "SingleSense",Name = "singlesense")]
		public bool SingleSense{
			get{ return _singleSense;}
			set{_singleSense = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "illusionspelldescription")]
	public partial class IllusionSpellDescription : SpellDescription {
	}
	[Table(Schema = "shadowrun5",Name = "illusionspellexemplar")]
	public partial class IllusionSpellExemplar : SpellExemplar {
	}
}
