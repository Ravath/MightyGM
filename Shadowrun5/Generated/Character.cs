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
	[Table(Schema = "shadowrun5",Name = "charactermodel")]
	public abstract partial class CharacterModel : DataModel {

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

		private int? _magic;
		[Column(Storage = "Magic",Name = "magic")]
		public int? Magic{
			get{ return _magic;}
			set{_magic = value;}
		}

		private PratiquantMagie _magicUserType;
		[Column(Storage = "MagicUserType",Name = "magicusertype")]
		public PratiquantMagie MagicUserType{
			get{ return _magicUserType;}
			set{_magicUserType = value;}
		}

		private SpecialiteMage? _magicSpeciality;
		[Column(Storage = "MagicSpeciality",Name = "magicspeciality")]
		public SpecialiteMage? MagicSpeciality{
			get{ return _magicSpeciality;}
			set{_magicSpeciality = value;}
		}

		private int _essence;
		[Column(Storage = "Essence",Name = "essence")]
		public int Essence{
			get{ return _essence;}
			set{_essence = value;}
		}

		private int _edge;
		[Column(Storage = "Edge",Name = "edge")]
		public int Edge{
			get{ return _edge;}
			set{_edge = value;}
		}

		private IEnumerable<SkillExemplar> _skills;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Skills",OtherKey = "CharacterModelId")]
		public IEnumerable <SkillExemplar> Skills{
			get{
				if( _skills == null ){
					_skills = LoadFromJointure<SkillExemplar,CharacterModelToSkillExemplar_Skills>(false);
				}
				return _skills;
			}
			set{
				SaveToJointure<SkillExemplar, CharacterModelToSkillExemplar_Skills> (_skills, value,false);
				_skills = value;
			}
		}

		private IEnumerable<QualityExemplar> _qualities;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Qualities",OtherKey = "CharacterModelId")]
		public IEnumerable <QualityExemplar> Qualities{
			get{
				if( _qualities == null ){
					_qualities = LoadFromJointure<QualityExemplar,CharacterModelToQualityExemplar_Qualities>(false);
				}
				return _qualities;
			}
			set{
				SaveToJointure<QualityExemplar, CharacterModelToQualityExemplar_Qualities> (_qualities, value,false);
				_qualities = value;
			}
		}

		private IEnumerable<ProductExemplar> _inventory;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Inventory",OtherKey = "CharacterModelId")]
		public IEnumerable <ProductExemplar> Inventory{
			get{
				if( _inventory == null ){
					_inventory = LoadFromJointure<ProductExemplar,CharacterModelToProductExemplar_Inventory>(false);
				}
				return _inventory;
			}
			set{
				SaveToJointure<ProductExemplar, CharacterModelToProductExemplar_Inventory> (_inventory, value,false);
				_inventory = value;
			}
		}

		private IEnumerable<AugmentationExemplar> _augmentations;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Augmentations",OtherKey = "CharacterModelId")]
		public IEnumerable <AugmentationExemplar> Augmentations{
			get{
				if( _augmentations == null ){
					_augmentations = LoadFromJointure<AugmentationExemplar,CharacterModelToAugmentationExemplar_Augmentations>(false);
				}
				return _augmentations;
			}
			set{
				SaveToJointure<AugmentationExemplar, CharacterModelToAugmentationExemplar_Augmentations> (_augmentations, value,false);
				_augmentations = value;
			}
		}

		private IEnumerable<SpellModel> _spells;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Spells",OtherKey = "CharacterModelId")]
		public IEnumerable <SpellModel> Spells{
			get{
				if( _spells == null ){
					_spells = LoadFromJointure<SpellModel,CharacterModelToSpellModel_Spells>(false);
				}
				return _spells;
			}
			set{
				SaveToJointure<SpellModel, CharacterModelToSpellModel_Spells> (_spells, value,false);
				_spells = value;
			}
		}

		private IEnumerable<ComplexFormModel> _complexForms;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "ComplexForms",OtherKey = "CharacterModelId")]
		public IEnumerable <ComplexFormModel> ComplexForms{
			get{
				if( _complexForms == null ){
					_complexForms = LoadFromJointure<ComplexFormModel,CharacterModelToComplexFormModel_ComplexForms>(false);
				}
				return _complexForms;
			}
			set{
				SaveToJointure<ComplexFormModel, CharacterModelToComplexFormModel_ComplexForms> (_complexForms, value,false);
				_complexForms = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<CharacterModel,CharacterModelToSkillExemplar_Skills>(true);
			DeleteJoins<CharacterModel,CharacterModelToQualityExemplar_Qualities>(true);
			DeleteJoins<CharacterModel,CharacterModelToProductExemplar_Inventory>(true);
			DeleteJoins<CharacterModel,CharacterModelToAugmentationExemplar_Augmentations>(true);
			DeleteJoins<CharacterModel,CharacterModelToSpellModel_Spells>(true);
			DeleteJoins<CharacterModel,CharacterModelToComplexFormModel_ComplexForms>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "shadowrun5",Name = "characterdescription")]
	public abstract partial class CharacterDescription : DataDescription<CharacterModel> {
	}
	[Table(Schema = "shadowrun5",Name = "characterexemplar")]
	public abstract partial class CharacterExemplar : DataExemplaire<CharacterModel> {

		private int _currentPhysicalDamage;
		[Column(Storage = "CurrentPhysicalDamage",Name = "currentphysicaldamage")]
		public int CurrentPhysicalDamage{
			get{ return _currentPhysicalDamage;}
			set{_currentPhysicalDamage = value;}
		}

		private int _currentEssence;
		[Column(Storage = "CurrentEssence",Name = "currentessence")]
		public int EssenceMalus {
			get{ return _currentEssence;}
			set{_currentEssence = value;}
		}

		private int _currentEdge;
		[Column(Storage = "CurrentEdge",Name = "currentedge")]
		public int CurrentEdge{
			get{ return _currentEdge;}
			set{_currentEdge = value;}
		}

		private int _currentStressDamage;
		[Column(Storage = "CurrentStressDamage",Name = "currentstressdamage")]
		public int CurrentStressDamage{
			get{ return _currentStressDamage;}
			set{_currentStressDamage = value;}
		}
	}
}
