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
	[Table(Schema = "shadowrun5",Name = "critterpowermodel")]
	[CoreData]
	public partial class CritterPowerModel : DataModel {

		private CritterPowerDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CritterPowerDescription> id = GetModelReferencer<CritterPowerDescription>();
					if(id.Count() == 0) {
						_obj = new CritterPowerDescription();
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

		private PowerType _type;
		[Column(Storage = "Type",Name = "type")]
		public PowerType Type{
			get{ return _type;}
			set{_type = value;}
		}

		private Action _action;
		[Column(Storage = "Action",Name = "action")]
		public Action Action{
			get{ return _action;}
			set{_action = value;}
		}

		private PowerRange _range;
		[Column(Storage = "Range",Name = "range")]
		public PowerRange Range{
			get{ return _range;}
			set{_range = value;}
		}

		private bool _areaOfEffect;
		[Column(Storage = "AreaOfEffect",Name = "areaofeffect")]
		public bool AreaOfEffect{
			get{ return _areaOfEffect;}
			set{_areaOfEffect = value;}
		}

		private Duration _duration;
		[Column(Storage = "Duration",Name = "duration")]
		public Duration Duration{
			get{ return _duration;}
			set{_duration = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "critterpowerdescription")]
	public partial class CritterPowerDescription : DataDescription<CritterPowerModel> {
	}
	[Table(Schema = "shadowrun5",Name = "critterpowerexemplar")]
	public partial class CritterPowerExemplar : DataExemplaire<CritterPowerModel> {
	}
}
