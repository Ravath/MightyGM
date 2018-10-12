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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "combatconditionmodel")]
	[CoreData]
	public partial class CombatConditionModel : DataModel {

		private CombatConditionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CombatConditionDescription> id = GetModelReferencer<CombatConditionDescription>();
					if(id.Count() == 0) {
						_obj = new CombatConditionDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeCombatCondition _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeCombatCondition Type{
			get{ return _type;}
			set{_type = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "combatconditiondescription")]
	public partial class CombatConditionDescription : DataDescription<CombatConditionModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "combatconditionexemplar")]
	public partial class CombatConditionExemplar : DataExemplaire<CombatConditionModel> {
	}
}
