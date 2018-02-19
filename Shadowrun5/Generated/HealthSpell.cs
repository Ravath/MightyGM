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
	[Table(Schema = "shadowrun5",Name = "healthspellmodel")]
	[CoreData]
	public partial class HealthSpellModel : SpellModel {

		private HealthSpellDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<HealthSpellDescription> id = GetModelReferencer<HealthSpellDescription>();
					if(id.Count() == 0) {
						_obj = new HealthSpellDescription();
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

		private bool _essence;
		[Column(Storage = "Essence",Name = "essence")]
		public bool Essence{
			get{ return _essence;}
			set{_essence = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "healthspelldescription")]
	public partial class HealthSpellDescription : SpellDescription {
	}
	[Table(Schema = "shadowrun5",Name = "healthspellexemplar")]
	public partial class HealthSpellExemplar : SpellExemplar {
	}
}
