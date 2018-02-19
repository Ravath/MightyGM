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
	[Table(Schema = "shadowrun5",Name = "ritualmodel")]
	[CoreData]
	public partial class RitualModel : DataModel {

		private RitualDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RitualDescription> id = GetModelReferencer<RitualDescription>();
					if(id.Count() == 0) {
						_obj = new RitualDescription();
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

		private bool _anchored;
		[Column(Storage = "Anchored",Name = "anchored")]
		public bool Anchored{
			get{ return _anchored;}
			set{_anchored = value;}
		}

		private bool _materialLink;
		[Column(Storage = "MaterialLink",Name = "materiallink")]
		public bool MaterialLink{
			get{ return _materialLink;}
			set{_materialLink = value;}
		}

		private bool _minion;
		[Column(Storage = "Minion",Name = "minion")]
		public bool Minion{
			get{ return _minion;}
			set{_minion = value;}
		}

		private bool _spell;
		[Column(Storage = "Spell",Name = "spell")]
		public bool Spell{
			get{ return _spell;}
			set{_spell = value;}
		}

		private bool _spotter;
		[Column(Storage = "Spotter",Name = "spotter")]
		public bool Spotter{
			get{ return _spotter;}
			set{_spotter = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "ritualdescription")]
	public partial class RitualDescription : DataDescription<RitualModel> {
	}
	[Table(Schema = "shadowrun5",Name = "ritualexemplar")]
	public partial class RitualExemplar : DataExemplaire<RitualModel> {
	}
}
