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
	[Table(Schema = "shadowrun5",Name = "spritemodel")]
	[CoreData]
	public partial class SpriteModel : DataModel {

		private SpriteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpriteDescription> id = GetModelReferencer<SpriteDescription>();
					if(id.Count() == 0) {
						_obj = new SpriteDescription();
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

		private int _attack;
		[Column(Storage = "Attack",Name = "attack")]
		public int Attack{
			get{ return _attack;}
			set{_attack = value;}
		}

		private int _sleaze;
		[Column(Storage = "Sleaze",Name = "sleaze")]
		public int Sleaze{
			get{ return _sleaze;}
			set{_sleaze = value;}
		}

		private int _dataProcessing;
		[Column(Storage = "DataProcessing",Name = "dataprocessing")]
		public int DataProcessing{
			get{ return _dataProcessing;}
			set{_dataProcessing = value;}
		}

		private int _firewall;
		[Column(Storage = "Firewall",Name = "firewall")]
		public int Firewall{
			get{ return _firewall;}
			set{_firewall = value;}
		}

		private string _initiativeDice = "";
		[Column(Storage = "InitiativeDice",Name = "initiativedice")]
		public string InitiativeDice{
			get{ return _initiativeDice;}
			set{_initiativeDice = value;}
		}

		private int _resonance;
		[Column(Storage = "Resonance",Name = "resonance")]
		public int Resonance{
			get{ return _resonance;}
			set{_resonance = value;}
		}

		private IEnumerable<SkillModel> _skills;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Skills",OtherKey = "SpriteModelId")]
		public IEnumerable <SkillModel> Skills{
			get{
				if( _skills == null ){
					_skills = LoadFromJointure<SkillModel,SpriteModelToSkillModel_Skills>(false);
				}
				return _skills;
			}
			set{
				SaveToJointure<SkillModel, SpriteModelToSkillModel_Skills> (_skills, value,false);
				_skills = value;
			}
		}

		private IEnumerable<SpritePowerModel> _powers;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Powers",OtherKey = "SpriteModelId")]
		public IEnumerable <SpritePowerModel> Powers{
			get{
				if( _powers == null ){
					_powers = LoadFromJointure<SpritePowerModel,SpriteModelToSpritePowerModel_Powers>(false);
				}
				return _powers;
			}
			set{
				SaveToJointure<SpritePowerModel, SpriteModelToSpritePowerModel_Powers> (_powers, value,false);
				_powers = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<SpriteModel,SpriteModelToSkillModel_Skills>(true);
			DeleteJoins<SpriteModel,SpriteModelToSpritePowerModel_Powers>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "shadowrun5",Name = "spritedescription")]
	public partial class SpriteDescription : DataDescription<SpriteModel> {
	}
	[Table(Schema = "shadowrun5",Name = "spriteexemplar")]
	public partial class SpriteExemplar : DataExemplaire<SpriteModel> {
	}
}
