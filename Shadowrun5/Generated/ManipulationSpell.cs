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
	[Table(Schema = "shadowrun5",Name = "manipulationspellmodel")]
	[CoreData]
	public partial class ManipulationSpellModel : SpellModel {

		private ManipulationSpellDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ManipulationSpellDescription> id = GetModelReferencer<ManipulationSpellDescription>();
					if(id.Count() == 0) {
						_obj = new ManipulationSpellDescription();
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

		private ManipulationPowerType _manipulationType;
		[Column(Storage = "ManipulationType",Name = "manipulationtype")]
		public ManipulationPowerType ManipulationType{
			get{ return _manipulationType;}
			set{_manipulationType = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "manipulationspelldescription")]
	public partial class ManipulationSpellDescription : SpellDescription {
	}
	[Table(Schema = "shadowrun5",Name = "manipulationspellexemplar")]
	public partial class ManipulationSpellExemplar : SpellExemplar {
	}
}
