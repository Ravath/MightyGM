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
	[Table(Schema = "shadowrun5",Name = "metatypemodel")]
	[CoreData]
	public partial class MetatypeModel : DataModel {

		private MetatypeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MetatypeDescription> id = GetModelReferencer<MetatypeDescription>();
					if(id.Count() == 0) {
						_obj = new MetatypeDescription();
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

		public VisionType Vision {
			get {
				return VisionType.Normale;
			}
			set { }
		}

		private int _body;
		[Column(Storage = "Body",Name = "body")]
		public int Body{
			get{ return _body;}
			set{_body = value;}
		}

		private int _agility;
		[Column(Storage = "Agility",Name = "agility")]
		public int Agility{
			get{ return _agility;}
			set{_agility = value;}
		}

		private int _reaction;
		[Column(Storage = "Reaction",Name = "reaction")]
		public int Reaction{
			get{ return _reaction;}
			set{_reaction = value;}
		}

		private int _strength;
		[Column(Storage = "Strength",Name = "strength")]
		public int Strength{
			get{ return _strength;}
			set{_strength = value;}
		}

		private int _willpower;
		[Column(Storage = "Willpower",Name = "willpower")]
		public int Willpower{
			get{ return _willpower;}
			set{_willpower = value;}
		}

		private int _logic;
		[Column(Storage = "Logic",Name = "logic")]
		public int Logic{
			get{ return _logic;}
			set{_logic = value;}
		}

		private int _intuition;
		[Column(Storage = "Intuition",Name = "intuition")]
		public int Intuition{
			get{ return _intuition;}
			set{_intuition = value;}
		}

		private int _charisma;
		[Column(Storage = "Charisma",Name = "charisma")]
		public int Charisma{
			get{ return _charisma;}
			set{_charisma = value;}
		}

		private int _edge;
		[Column(Storage = "Edge",Name = "edge")]
		public int Edge{
			get{ return _edge;}
			set{_edge = value;}
		}

		private int _initiative;
		[Column(Storage = "LifeStyleMod", Name = "initiative")]
		public int LifeStyleMod {
			get{ return _initiative;}
			set{_initiative = value;}
		}

		private int _armor;
		[Column(Storage = "Armor",Name = "armor")]
		public int Armor{
			get{ return _armor;}
			set{_armor = value;}
		}

		private int _reach;
		[Column(Storage = "Reach",Name = "reach")]
		public int Reach{
			get{ return _reach;}
			set{_reach = value;}
		}

		private int _speA;
		[Column(Storage = "SpeA",Name = "spea")]
		public int SpeA{
			get{ return _speA;}
			set{_speA = value;}
		}

		private int _speB;
		[Column(Storage = "SpeB",Name = "speb")]
		public int SpeB{
			get{ return _speB;}
			set{_speB = value;}
		}

		private int _speC;
		[Column(Storage = "SpeC",Name = "spec")]
		public int SpeC{
			get{ return _speC;}
			set{_speC = value;}
		}

		private int _speD;
		[Column(Storage = "SpeD",Name = "sped")]
		public int SpeD{
			get{ return _speD;}
			set{_speD = value;}
		}

		private int _speE;
		[Column(Storage = "SpeE",Name = "spee")]
		public int SpeE{
			get{ return _speE;}
			set{_speE = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "metatypedescription")]
	public partial class MetatypeDescription : DataDescription<MetatypeModel> {

		private int _averageHeight;
		[Column(Storage = "AverageHeight",Name = "averageheight")]
		public int AverageHeight{
			get{ return _averageHeight;}
			set{_averageHeight = value;}
		}

		private int _averageWeight;
		[Column(Storage = "AverageWeight",Name = "averageweight")]
		public int AverageWeight{
			get{ return _averageWeight;}
			set{_averageWeight = value;}
		}

		private int _minLifespan;
		[Column(Storage = "MinLifespan",Name = "minlifespan")]
		public int MinLifespan{
			get{ return _minLifespan;}
			set{_minLifespan = value;}
		}

		private int? _maxLifespan;
		[Column(Storage = "MaxLifespan",Name = "maxlifespan")]
		public int? MaxLifespan{
			get{ return _maxLifespan;}
			set{_maxLifespan = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "metatypeexemplar")]
	public partial class MetatypeExemplar : DataExemplaire<MetatypeModel> {
	}
}
