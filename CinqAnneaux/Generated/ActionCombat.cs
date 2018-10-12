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
	[Table(Schema = "cinqanneaux",Name = "actioncombatmodel")]
	[CoreData]
	public partial class ActionCombatModel : DataModel {

		private ActionCombatDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ActionCombatDescription> id = GetModelReferencer<ActionCombatDescription>();
					if(id.Count() == 0) {
						_obj = new ActionCombatDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeActionCombat _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeActionCombat Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _coutMin;
		[Column(Storage = "CoutMin",Name = "coutmin")]
		public int CoutMin{
			get{ return _coutMin;}
			set{_coutMin = value;}
		}

		private int _coutMax;
		[Column(Storage = "CoutMax",Name = "coutmax")]
		public int CoutMax{
			get{ return _coutMax;}
			set{_coutMax = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "actioncombatdescription")]
	public partial class ActionCombatDescription : DataDescription<ActionCombatModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "actioncombatexemplar")]
	public partial class ActionCombatExemplar : DataExemplaire<ActionCombatModel> {
	}
}
