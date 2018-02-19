using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "specialisationsfromskillmodel")]
	public class SpecialisationsFromSkillModel : DataValue<SkillModel, string> {

		[Column(Storage = "Specialisations",Name = "specialisations")]
		public string Specialisations{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "SkillModelId",Name = "fk_skillmodel_from")]
		[HiddenProperty]
		public int SkillModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public SkillModel SkillModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "shadowrun5",Name = "spritemodeltoskillmodel_skills")]
	public class SpriteModelToSkillModel_Skills : DataRelation<SpriteModel, SkillModel> {

		[Column(Name = "fk_spritemodel_join", Storage = "SpriteModelId")]
		[HiddenProperty]
		public int SpriteModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SpriteModelId", OtherKey = "Id", CanBeNull = false, Storage = "SpriteModel")]
		public SpriteModel SpriteModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_skillmodel_join", Storage = "SkillModelId")]
		[HiddenProperty]
		public int SkillModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SkillModelId", OtherKey = "Id", CanBeNull = false, Storage = "SkillModel")]
		public SkillModel SkillModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "spritemodeltospritepowermodel_powers")]
	public class SpriteModelToSpritePowerModel_Powers : DataRelation<SpriteModel, SpritePowerModel> {

		[Column(Name = "fk_spritemodel_join", Storage = "SpriteModelId")]
		[HiddenProperty]
		public int SpriteModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "SpriteModelId", OtherKey = "Id", CanBeNull = false, Storage = "SpriteModel")]
		public SpriteModel SpriteModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_spritepowermodel_join", Storage = "SpritePowerModelId")]
		[HiddenProperty]
		public int SpritePowerModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpritePowerModelId", OtherKey = "Id", CanBeNull = false, Storage = "SpritePowerModel")]
		public SpritePowerModel SpritePowerModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "similararchetypesfrommentorspiritdescription")]
	public class SimilarArchetypesFromMentorSpiritDescription : DataValue<MentorSpiritDescription, string> {

		[Column(Storage = "SimilarArchetypes",Name = "similararchetypes")]
		public string SimilarArchetypes{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "MentorSpiritDescriptionId",Name = "fk_mentorspiritdescription_from")]
		[HiddenProperty]
		public int MentorSpiritDescriptionId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public MentorSpiritDescription MentorSpiritDescription{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "shadowrun5",Name = "charactermodeltoskillexemplar_skills")]
	public class CharacterModelToSkillExemplar_Skills : DataRelation<CharacterModel, SkillExemplar> {

		[Column(Name = "fk_charactermodel_join", Storage = "CharacterModelId")]
		[HiddenProperty]
		public int CharacterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CharacterModelId", OtherKey = "Id", CanBeNull = false, Storage = "CharacterModel")]
		public CharacterModel CharacterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_skillexemplar_join", Storage = "SkillExemplarId")]
		[HiddenProperty]
		public int SkillExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SkillExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "SkillExemplar")]
		public SkillExemplar SkillExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "charactermodeltoqualityexemplar_qualities")]
	public class CharacterModelToQualityExemplar_Qualities : DataRelation<CharacterModel, QualityExemplar> {

		[Column(Name = "fk_charactermodel_join", Storage = "CharacterModelId")]
		[HiddenProperty]
		public int CharacterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CharacterModelId", OtherKey = "Id", CanBeNull = false, Storage = "CharacterModel")]
		public CharacterModel CharacterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_qualityexemplar_join", Storage = "QualityExemplarId")]
		[HiddenProperty]
		public int QualityExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "QualityExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "QualityExemplar")]
		public QualityExemplar QualityExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "charactermodeltoproductexemplar_inventory")]
	public class CharacterModelToProductExemplar_Inventory : DataRelation<CharacterModel, ProductExemplar> {

		[Column(Name = "fk_charactermodel_join", Storage = "CharacterModelId")]
		[HiddenProperty]
		public int CharacterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CharacterModelId", OtherKey = "Id", CanBeNull = false, Storage = "CharacterModel")]
		public CharacterModel CharacterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_productexemplar_join", Storage = "ProductExemplarId")]
		[HiddenProperty]
		public int ProductExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ProductExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ProductExemplar")]
		public ProductExemplar ProductExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "charactermodeltoaugmentationexemplar_augmentations")]
	public class CharacterModelToAugmentationExemplar_Augmentations : DataRelation<CharacterModel, AugmentationExemplar> {

		[Column(Name = "fk_charactermodel_join", Storage = "CharacterModelId")]
		[HiddenProperty]
		public int CharacterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CharacterModelId", OtherKey = "Id", CanBeNull = false, Storage = "CharacterModel")]
		public CharacterModel CharacterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_augmentationexemplar_join", Storage = "AugmentationExemplarId")]
		[HiddenProperty]
		public int AugmentationExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AugmentationExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AugmentationExemplar")]
		public AugmentationExemplar AugmentationExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "charactermodeltospellmodel_spells")]
	public class CharacterModelToSpellModel_Spells : DataRelation<CharacterModel, SpellModel> {

		[Column(Name = "fk_charactermodel_join", Storage = "CharacterModelId")]
		[HiddenProperty]
		public int CharacterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CharacterModelId", OtherKey = "Id", CanBeNull = false, Storage = "CharacterModel")]
		public CharacterModel CharacterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_spellmodel_join", Storage = "SpellModelId")]
		[HiddenProperty]
		public int SpellModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "SpellModelId", OtherKey = "Id", CanBeNull = false, Storage = "SpellModel")]
		public SpellModel SpellModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "charactermodeltocomplexformmodel_complexforms")]
	public class CharacterModelToComplexFormModel_ComplexForms : DataRelation<CharacterModel, ComplexFormModel> {

		[Column(Name = "fk_charactermodel_join", Storage = "CharacterModelId")]
		[HiddenProperty]
		public int CharacterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "CharacterModelId", OtherKey = "Id", CanBeNull = false, Storage = "CharacterModel")]
		public CharacterModel CharacterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_complexformmodel_join", Storage = "ComplexFormModelId")]
		[HiddenProperty]
		public int ComplexFormModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ComplexFormModelId", OtherKey = "Id", CanBeNull = false, Storage = "ComplexFormModel")]
		public ComplexFormModel ComplexFormModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "armorexemplartoarmormodificationexemplar_modifications")]
	public class ArmorExemplarToArmorModificationExemplar_Modifications : DataRelation<ArmorExemplar, ArmorModificationExemplar> {

		[Column(Name = "fk_armorexemplar_join", Storage = "ArmorExemplarId")]
		[HiddenProperty]
		public int ArmorExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "ArmorExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmorExemplar")]
		public ArmorExemplar ArmorExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_armormodificationexemplar_join", Storage = "ArmorModificationExemplarId")]
		[HiddenProperty]
		public int ArmorModificationExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "ArmorModificationExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "ArmorModificationExemplar")]
		public ArmorModificationExemplar ArmorModificationExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "absdeviceexemplartodevicemodificationmodel_modifications")]
	public class AbsDeviceExemplarToDeviceModificationModel_Modifications : DataRelation<AbsDeviceExemplar, DeviceModificationModel> {

		[Column(Name = "fk_absdeviceexemplar_join", Storage = "AbsDeviceExemplarId")]
		[HiddenProperty]
		public int AbsDeviceExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsDeviceExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AbsDeviceExemplar")]
		public AbsDeviceExemplar AbsDeviceExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_devicemodificationmodel_join", Storage = "DeviceModificationModelId")]
		[HiddenProperty]
		public int DeviceModificationModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "DeviceModificationModelId", OtherKey = "Id", CanBeNull = false, Storage = "DeviceModificationModel")]
		public DeviceModificationModel DeviceModificationModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "augmentationexemplartoaugmentationmodel_modifications")]
	public class AugmentationExemplarToAugmentationModel_Modifications : DataRelation<AugmentationExemplar, AugmentationModel> {

		[Column(Name = "fk_augmentationexemplar_join", Storage = "AugmentationExemplarId")]
		[HiddenProperty]
		public int AugmentationExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AugmentationExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AugmentationExemplar")]
		public AugmentationExemplar AugmentationExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_augmentationmodel_join", Storage = "AugmentationModelId")]
		[HiddenProperty]
		public int AugmentationModelId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "AugmentationModelId", OtherKey = "Id", CanBeNull = false, Storage = "AugmentationModel")]
		public AugmentationModel AugmentationModel {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "vectorfromsubstancemodel")]
	public class VectorFromSubstanceModel : DataValue<SubstanceModel, int> {

		[Column(Storage = "Vector",Name = "vector")]
		public int Vector{
			get{
				return Value;
			}
			set{
				Value = value;
			}
		}


		[Column(Storage = "SubstanceModelId",Name = "fk_substancemodel_from")]
		[HiddenProperty]
		public int SubstanceModelId{
			get{
				return base.FromId;
			}
			set{
				base.FromId = value;
			}
		}



		public SubstanceModel SubstanceModel{
			get{
				return From;
			}
			set{
				From = value;
			}
		}

	}
	[Table(Schema = "shadowrun5",Name = "abscrittermodeltocritterpowerexemplar_powers")]
	public class AbsCritterModelToCritterPowerExemplar_Powers : DataRelation<AbsCritterModel, CritterPowerExemplar> {

		[Column(Name = "fk_abscrittermodel_join", Storage = "AbsCritterModelId")]
		[HiddenProperty]
		public int AbsCritterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsCritterModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsCritterModel")]
		public AbsCritterModel AbsCritterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_critterpowerexemplar_join", Storage = "CritterPowerExemplarId")]
		[HiddenProperty]
		public int CritterPowerExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CritterPowerExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CritterPowerExemplar")]
		public CritterPowerExemplar CritterPowerExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "abscrittermodeltocritterpowerexemplar_optionalpowers")]
	public class AbsCritterModelToCritterPowerExemplar_OptionalPowers : DataRelation<AbsCritterModel, CritterPowerExemplar> {

		[Column(Name = "fk_abscrittermodel_join", Storage = "AbsCritterModelId")]
		[HiddenProperty]
		public int AbsCritterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsCritterModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsCritterModel")]
		public AbsCritterModel AbsCritterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_critterpowerexemplar_join", Storage = "CritterPowerExemplarId")]
		[HiddenProperty]
		public int CritterPowerExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CritterPowerExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CritterPowerExemplar")]
		public CritterPowerExemplar CritterPowerExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "abscrittermodeltonaturalweaponexemplar_naturalweapons")]
	public class AbsCritterModelToNaturalWeaponExemplar_NaturalWeapons : DataRelation<AbsCritterModel, NaturalWeaponExemplar> {

		[Column(Name = "fk_abscrittermodel_join", Storage = "AbsCritterModelId")]
		[HiddenProperty]
		public int AbsCritterModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsCritterModelId", OtherKey = "Id", CanBeNull = false, Storage = "AbsCritterModel")]
		public AbsCritterModel AbsCritterModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_naturalweaponexemplar_join", Storage = "NaturalWeaponExemplarId")]
		[HiddenProperty]
		public int NaturalWeaponExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "NaturalWeaponExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "NaturalWeaponExemplar")]
		public NaturalWeaponExemplar NaturalWeaponExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "abscritterexemplartocritterpowerexemplar_supplementarypowers")]
	public class AbsCritterExemplarToCritterPowerExemplar_SupplementaryPowers : DataRelation<AbsCritterExemplar, CritterPowerExemplar> {

		[Column(Name = "fk_abscritterexemplar_join", Storage = "AbsCritterExemplarId")]
		[HiddenProperty]
		public int AbsCritterExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "AbsCritterExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "AbsCritterExemplar")]
		public AbsCritterExemplar AbsCritterExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_critterpowerexemplar_join", Storage = "CritterPowerExemplarId")]
		[HiddenProperty]
		public int CritterPowerExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "CritterPowerExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "CritterPowerExemplar")]
		public CritterPowerExemplar CritterPowerExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "firearmmodeltofirearmaccessoryexemplar_accessories")]
	public class FireArmModelToFirearmAccessoryExemplar_Accessories : DataRelation<FireArmModel, FirearmAccessoryExemplar> {

		[Column(Name = "fk_firearmmodel_join", Storage = "FireArmModelId")]
		[HiddenProperty]
		public int FireArmModelId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "FireArmModelId", OtherKey = "Id", CanBeNull = false, Storage = "FireArmModel")]
		public FireArmModel FireArmModel {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_firearmaccessoryexemplar_join", Storage = "FirearmAccessoryExemplarId")]
		[HiddenProperty]
		public int FirearmAccessoryExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "FirearmAccessoryExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "FirearmAccessoryExemplar")]
		public FirearmAccessoryExemplar FirearmAccessoryExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
	[Table(Schema = "shadowrun5",Name = "firearmexemplartofirearmaccessoryexemplar_customaccessories")]
	public class FireArmExemplarToFirearmAccessoryExemplar_CustomAccessories : DataRelation<FireArmExemplar, FirearmAccessoryExemplar> {

		[Column(Name = "fk_firearmexemplar_join", Storage = "FireArmExemplarId")]
		[HiddenProperty]
		public int FireArmExemplarId {
			get { return Object1Id; }
			set { Object1Id= value; }
		}
		[Association(ThisKey = "FireArmExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "FireArmExemplar")]
		public FireArmExemplar FireArmExemplar {
			get { return Object1; }
			set { Object1 = value; }
		}

		[Column(Name = "fk_firearmaccessoryexemplar_join", Storage = "FirearmAccessoryExemplarId")]
		[HiddenProperty]
		public int FirearmAccessoryExemplarId {
			get { return Object2Id; }
			set { Object2Id= value; }
		}
		[Association(ThisKey = "FirearmAccessoryExemplarId", OtherKey = "Id", CanBeNull = false, Storage = "FirearmAccessoryExemplar")]
		public FirearmAccessoryExemplar FirearmAccessoryExemplar {
			get { return Object2; }
			set { Object2 = value; }
		}
	}
}
