namespace Shadowrun5.Data {
	public enum Attribut{
		Body, Agility, Reaction, Strength, Willpower, Logic, Intuition, Charisma, Magic, Resonance, Edge, Essence}

	public enum Duration{
		Instantaneous, Sustained, Permanent, Always, Special}

	public enum AvailabilityType{
		Free, Restricted, Prohibited}

	public enum Action{
		Free, Simple, Interrupt, Complex, Auto, Special}

	public enum PowerType{
		Physical, Mana}

	public enum PowerRange{
		LineOfSight, Touch, Self, Special}

	public enum SkillGroup{
		Acting, Athletics, Biotech, Conjuring, CloseCombat, Craking, Electronics, Enchanting, Engineering, FireArms, Influence, Outdoors, Sorcery, Stealth, Tasking}

	public enum SkillCategory{
		Combat, Physical, Social, Magical, Resonance, Technical, Vehicle, Knowledge, Language}

	public enum ResonanceTarget{
		Persona, Device, File, Self, Sprite}

	public enum DetectionSpellArea{
		Directional, Area, Psychic}

	public enum ManipulationPowerType{
		Physical, Mental, Environmemental}

	public enum WeaponDamageType{
		Acid, Cold, Electric, Fire, Flechette, Chemical, Toxin, Special, Grenade, Missile}

	public enum WeaponCategory{
		Blade, Club, ExoticMelee, CyberMelee, Bow, Crossbow, ThrowingWeapon, Taser, HoldOut, LightPistol, HeavyPistol, MachinePistol, SubmachinePistol, AssaultRifle, SniperRifle, Shotgun, MachineGun, Cannon, Grenade, Rocket, ExoticFirearm, CyberGun}

	public enum AmmoLoader{
		b, c, d, ml, m, cy, belt}

	public enum FirearmAccessoryMount{
		top, Under, TopOrUnder, Barrel}

	public enum BlastType{
		Radius, Radiant, Special}

	public enum GearType{
		Accessory, Explosive, RFID, Communication, Software, SkillSoft, Credstick, Identification, Tool, Security, Breaking, Chemical, Survival, Grapple, Biotech, DocWagon, Patch}

	public enum DeviceType{
		Optical, Audio, Sensor}

	public enum AugmentationType{
		Head, Eye, Ear, Body, Limb, Weapon, WeaponAmelioration, Bio, Cultured}

	public enum WareGrade{
		Standard, Alpha, Beta, Delta, Used}

	public enum VehicleCategory{
		Bike, Car, Truck, Boat, Submarine, FixedWing, Rotorcraft, VTOL, Microdrone, Minidrone, SmallDrone, MediumDrone, LargeDrone}

	public enum ToxinVector{
		Contact, Ingestion, Inhalation, Injection}

	public enum AddictionType{
		Physiological, Psychological, Both}

	public enum CritterType{
		Mundane, Paracritter, Spirit, Dracoform
	}
	public enum PratiquantMagie {
		Non, Technomancien, Adepte, AdepteMystique, Magicien, MageSpecialise
	}
	public enum SpecialiteMage {
		Sorcier, Conjurateur, Enchanteur
	}
	public enum VisionType {
		Normale, Nocturne, Thermographique
	}
}
