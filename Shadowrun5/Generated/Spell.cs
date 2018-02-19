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
	[Table(Schema = "shadowrun5",Name = "spellmodel")]
	public abstract partial class SpellModel : DataModel {

		private PowerType _type;
		[Column(Storage = "Type",Name = "type")]
		public PowerType Type{
			get{ return _type;}
			set{_type = value;}
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

		private int _drainModifier;
		[Column(Storage = "DrainModifier",Name = "drainmodifier")]
		public int DrainModifier{
			get{ return _drainModifier;}
			set{_drainModifier = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "spelldescription")]
	public abstract partial class SpellDescription : DataDescription<SpellModel> {
	}
	[Table(Schema = "shadowrun5",Name = "spellexemplar")]
	public abstract partial class SpellExemplar : DataExemplaire<SpellModel> {
	}
}
