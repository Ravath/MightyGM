CREATE SCHEMA shadowrun5;
create table shadowrun5.dataobject(
	id serial NOT NULL,
	primary key(id));
create table shadowrun5.metatypemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	body integer NOT NULL,
	agility integer NOT NULL,
	reaction integer NOT NULL,
	strength integer NOT NULL,
	willpower integer NOT NULL,
	logic integer NOT NULL,
	intuition integer NOT NULL,
	charisma integer NOT NULL,
	edge integer NOT NULL,
	initiative integer NOT NULL,
	armor integer NOT NULL,
	reach integer NOT NULL,
	spea integer NOT NULL,
	speb integer NOT NULL,
	spec integer NOT NULL,
	sped integer NOT NULL,
	spee integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.metatypedescription(
	description text NOT NULL,
	fk_model_id integer,
	averageheight integer NOT NULL,
	averageweight integer NOT NULL,
	minlifespan integer NOT NULL,
	maxlifespan integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.metatypeexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.qualitymodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	cost integer NOT NULL,
	maxlevel integer,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.qualitydescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.qualityexemplar(
	fk_model_id integer,
	level integer NOT NULL)INHERITS(shadowrun5.dataobject);
create table shadowrun5.skillmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	skillgroup integer,
	caracteristic integer NOT NULL,
	type integer NOT NULL,
	defaultuse bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.skilldescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.skillexemplar(
	fk_model_id integer,
	rang integer NOT NULL)INHERITS(shadowrun5.dataobject);
create table shadowrun5.complexformmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	target integer NOT NULL,
	duration integer NOT NULL,
	fv integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.complexformdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.complexformexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.spritemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	attack integer NOT NULL,
	sleaze integer NOT NULL,
	dataprocessing integer NOT NULL,
	firewall integer NOT NULL,
	initiativedice character varying(3) NOT NULL,
	resonance integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.spritedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.spriteexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.spritepowermodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.spritepowerdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.spritepowerexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.spellmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	range integer NOT NULL,
	areaofeffect bool NOT NULL,
	duration integer NOT NULL,
	drainmodifier integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.spelldescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.spellexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.ritualmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	anchored bool NOT NULL,
	materiallink bool NOT NULL,
	minion bool NOT NULL,
	spell bool NOT NULL,
	spotter bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.ritualdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.ritualexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.adeptpowermodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	cost double precision NOT NULL,
	multilevel bool NOT NULL,
	activation integer,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.adeptpowerdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.adeptpowerexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.mentorspiritmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.mentorspiritdescription(
	description text NOT NULL,
	fk_model_id integer,
	alladvantage text NOT NULL,
	magicianadvantage text NOT NULL,
	adeptadvantage text NOT NULL,
	disadvantages text NOT NULL)INHERITS(shadowrun5.dataobject);
create table shadowrun5.mentorspiritexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.productmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	availabilitylevel integer NOT NULL,
	availabilitytype integer NOT NULL,
	cost integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.productdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.productexemplar(
	fk_model_id integer,
	quantity integer NOT NULL)INHERITS(shadowrun5.dataobject);
create table shadowrun5.sensorfunctionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	maxrange integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.sensorfunctiondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.sensorfunctionexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.charactermodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	body integer NOT NULL,
	agility integer NOT NULL,
	reaction integer NOT NULL,
	strength integer NOT NULL,
	willpower integer NOT NULL,
	logic integer NOT NULL,
	intuition integer NOT NULL,
	charisma integer NOT NULL,
	magic integer,
	resonance integer,
	essence integer NOT NULL,
	edge integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.characterdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.characterexemplar(
	fk_model_id integer,
	currentphysicaldamage integer NOT NULL,
	currentessence integer NOT NULL,
	currentedge integer NOT NULL,
	currentstressdamage integer NOT NULL)INHERITS(shadowrun5.dataobject);
create table shadowrun5.critterpowermodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	action integer NOT NULL,
	range integer NOT NULL,
	areaofeffect bool NOT NULL,
	duration integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.critterpowerdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.critterpowerexemplar(
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.naturalweaponmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.naturalweapondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.naturalweaponexemplar(
	fk_model_id integer,
	vd integer NOT NULL,
	usesforce bool NOT NULL,
	stressdamages bool NOT NULL,
	pa integer NOT NULL,
	reach integer NOT NULL)INHERITS(shadowrun5.dataobject);
create table shadowrun5.weaknessmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(shadowrun5.dataobject);
create table shadowrun5.weaknessdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.weaknessexemplar(
	fk_model_id integer,
	tag character varying(25))INHERITS(shadowrun5.dataobject);
create table shadowrun5.specialisationsfromskillmodel(
	fk_skillmodel_from integer,
	specialisations character varying(40))INHERITS(shadowrun5.dataobject);
create table shadowrun5.spritemodeltoskillmodel_skills(
	fk_spritemodel_join integer,
	fk_skillmodel_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.spritemodeltospritepowermodel_powers(
	fk_spritemodel_join integer,
	fk_spritepowermodel_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.similararchetypesfrommentorspiritdescription(
	fk_mentorspiritdescription_from integer,
	similararchetypes character varying(20))INHERITS(shadowrun5.dataobject);
create table shadowrun5.charactermodeltoskillexemplar_skills(
	fk_charactermodel_join integer,
	fk_skillexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.charactermodeltoqualityexemplar_qualities(
	fk_charactermodel_join integer,
	fk_qualityexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.charactermodeltoproductexemplar_inventory(
	fk_charactermodel_join integer,
	fk_productexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.charactermodeltoaugmentationexemplar_augmentations(
	fk_charactermodel_join integer,
	fk_augmentationexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.charactermodeltospellmodel_spells(
	fk_charactermodel_join integer,
	fk_spellmodel_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.charactermodeltocomplexformmodel_complexforms(
	fk_charactermodel_join integer,
	fk_complexformmodel_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.armorexemplartoarmormodificationexemplar_modifications(
	fk_armorexemplar_join integer,
	fk_armormodificationexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.absdeviceexemplartodevicemodificationmodel_modifications(
	fk_absdeviceexemplar_join integer,
	fk_devicemodificationmodel_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.augmentationexemplartoaugmentationmodel_modifications(
	fk_augmentationexemplar_join integer,
	fk_augmentationmodel_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.vectorfromsubstancemodel(
	fk_substancemodel_from integer,
	vector integer NOT NULL)INHERITS(shadowrun5.dataobject);
create table shadowrun5.abscrittermodeltocritterpowerexemplar_powers(
	fk_abscrittermodel_join integer,
	fk_critterpowerexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.abscrittermodeltocritterpowerexemplar_optionalpowers(
	fk_abscrittermodel_join integer,
	fk_critterpowerexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.abscrittermodeltonaturalweaponexemplar_naturalweapons(
	fk_abscrittermodel_join integer,
	fk_naturalweaponexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.abscritterexemplartocritterpowerexemplar_supplementarypowers(
	fk_abscritterexemplar_join integer,
	fk_critterpowerexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.firearmmodeltofirearmaccessoryexemplar_accessories(
	fk_firearmmodel_join integer,
	fk_firearmaccessoryexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.firearmexemplartofirearmaccessoryexemplar_customaccessories(
	fk_firearmexemplar_join integer,
	fk_firearmaccessoryexemplar_join integer)INHERITS(shadowrun5.dataobject);
create table shadowrun5.positivequalitymodel(
	primary key(id))INHERITS(shadowrun5.qualitymodel);
create table shadowrun5.positivequalitydescription(
	primary key(id))INHERITS(shadowrun5.qualitydescription);
create table shadowrun5.positivequalityexemplar(
	primary key(id))INHERITS(shadowrun5.qualityexemplar);
create table shadowrun5.negativequalitymodel(
	primary key(id))INHERITS(shadowrun5.qualitymodel);
create table shadowrun5.negativequalitydescription(
	primary key(id))INHERITS(shadowrun5.qualitydescription);
create table shadowrun5.negativequalityexemplar(
	primary key(id))INHERITS(shadowrun5.qualityexemplar);
create table shadowrun5.combatspellmodel(
	directspell bool NOT NULL,
	stressdamage bool NOT NULL,
	damage integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.spellmodel);
create table shadowrun5.combatspelldescription(
	primary key(id))INHERITS(shadowrun5.spelldescription);
create table shadowrun5.combatspellexemplar(
	primary key(id))INHERITS(shadowrun5.spellexemplar);
create table shadowrun5.detectionspellmodel(
	active bool NOT NULL,
	extended bool NOT NULL,
	area integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.spellmodel);
create table shadowrun5.detectionspelldescription(
	primary key(id))INHERITS(shadowrun5.spelldescription);
create table shadowrun5.detectionspellexemplar(
	primary key(id))INHERITS(shadowrun5.spellexemplar);
create table shadowrun5.healthspellmodel(
	essence bool NOT NULL,
	primary key(id))INHERITS(shadowrun5.spellmodel);
create table shadowrun5.healthspelldescription(
	primary key(id))INHERITS(shadowrun5.spelldescription);
create table shadowrun5.healthspellexemplar(
	primary key(id))INHERITS(shadowrun5.spellexemplar);
create table shadowrun5.illusionspellmodel(
	realistic bool NOT NULL,
	singlesense bool NOT NULL,
	primary key(id))INHERITS(shadowrun5.spellmodel);
create table shadowrun5.illusionspelldescription(
	primary key(id))INHERITS(shadowrun5.spelldescription);
create table shadowrun5.illusionspellexemplar(
	primary key(id))INHERITS(shadowrun5.spellexemplar);
create table shadowrun5.manipulationspellmodel(
	manipulationtype integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.spellmodel);
create table shadowrun5.manipulationspelldescription(
	primary key(id))INHERITS(shadowrun5.spelldescription);
create table shadowrun5.manipulationspellexemplar(
	primary key(id))INHERITS(shadowrun5.spellexemplar);
create table shadowrun5.weaponmodel(
	category integer NOT NULL,
	accuracy integer NOT NULL,
	damages integer NOT NULL,
	stressdamage bool NOT NULL,
	weapondamagetype integer,
	ap integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.weapondescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.weaponexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.firearmaccessorymodel(
	mount integer,
	minrating integer NOT NULL,
	maxrating integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.firearmaccessorydescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.firearmaccessoryexemplar(
	integrated bool NOT NULL,
	rating integer NOT NULL,
	mounted integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.ammunitionmodel(
	damagemodifier integer NOT NULL,
	apmodifier integer NOT NULL,
	stressdamage bool NOT NULL,
	damagetype integer,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.ammunitiondescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.ammunitionexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.armormodel(
	armor integer NOT NULL,
	armorcomplement bool NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.armordescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.armorexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.armormodificationmodel(
	capacity integer NOT NULL,
	hasrating bool NOT NULL,
	fk_armormodel_exlusivity integer,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.armormodificationdescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.armormodificationexemplar(
	rating integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.electronicmodel(
	rating integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.electronicdescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.electronicexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.gearmodel(
	type integer NOT NULL,
	minrating integer NOT NULL,
	maxrating integer NOT NULL,
	ratingperavail bool NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.geardescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.gearexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.absdevicemodel(
	devicetype integer NOT NULL,
	mincapacity integer NOT NULL,
	maxcapacity integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.absdevicedescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.absdeviceexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.devicemodificationmodel(
	type integer NOT NULL,
	minrating integer NOT NULL,
	maxrating integer NOT NULL,
	capacity integer NOT NULL,
	capacityisrating bool NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.devicemodificationdescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.devicemodificationexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.augmentationmodel(
	type integer NOT NULL,
	essence double precision NOT NULL,
	capacity integer NOT NULL,
	minrating integer NOT NULL,
	maxrating integer NOT NULL,
	iscontainer bool NOT NULL,
	ratperavail bool NOT NULL,
	ratperessence bool NOT NULL,
	ratpercapacity bool NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.augmentationdescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.augmentationexemplar(
	rating integer NOT NULL,
	grade integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.focusmodel(
	karmacost integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.focusdescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.focusexemplar(
	force integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.vehiclemodel(
	handlingonroad integer NOT NULL,
	handlingoffroad integer NOT NULL,
	speedonroad integer NOT NULL,
	speedoffroad integer NOT NULL,
	acceleration integer NOT NULL,
	body integer NOT NULL,
	armor integer NOT NULL,
	pilot integer NOT NULL,
	sensor integer NOT NULL,
	seats integer NOT NULL,
	category integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.vehicledescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.vehicleexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.substancemodel(
	speed_unit integer NOT NULL,
	speed_val integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.productmodel);
create table shadowrun5.substancedescription(
	primary key(id))INHERITS(shadowrun5.productdescription);
create table shadowrun5.substanceexemplar(
	primary key(id))INHERITS(shadowrun5.productexemplar);
create table shadowrun5.playercharactermodel(
	fk_joueur_id integer,
	primary key(id))INHERITS(shadowrun5.charactermodel);
create table shadowrun5.playercharacterdescription(
	primary key(id))INHERITS(shadowrun5.characterdescription);
create table shadowrun5.playercharacterexemplar(
	primary key(id))INHERITS(shadowrun5.characterexemplar);
create table shadowrun5.nonplayercharactermodel(
	primary key(id))INHERITS(shadowrun5.charactermodel);
create table shadowrun5.nonplayercharacterdescription(
	primary key(id))INHERITS(shadowrun5.characterdescription);
create table shadowrun5.nonplayercharacterexemplar(
	primary key(id))INHERITS(shadowrun5.characterexemplar);
create table shadowrun5.absgruntmodel(
	professionalrating integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.charactermodel);
create table shadowrun5.absgruntdescription(
	primary key(id))INHERITS(shadowrun5.characterdescription);
create table shadowrun5.absgruntexemplar(
	fk_metatypemodel_metatype integer,
	primary key(id))INHERITS(shadowrun5.characterexemplar);
create table shadowrun5.abscrittermodel(
	type integer NOT NULL,
	walk integer NOT NULL,
	run integer NOT NULL,
	sprint integer NOT NULL,
	armor integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.charactermodel);
create table shadowrun5.abscritterdescription(
	naturalhabitat text NOT NULL,
	notes text NOT NULL,
	primary key(id))INHERITS(shadowrun5.characterdescription);
create table shadowrun5.abscritterexemplar(
	primary key(id))INHERITS(shadowrun5.characterexemplar);
create table shadowrun5.meleeweaponmodel(
	reach integer NOT NULL,
	doesntusesstr bool NOT NULL,
	accuracyisphysicalthreshold bool NOT NULL,
	primary key(id))INHERITS(shadowrun5.weaponmodel);
create table shadowrun5.meleeweapondescription(
	primary key(id))INHERITS(shadowrun5.weapondescription);
create table shadowrun5.meleeweaponexemplar(
	primary key(id))INHERITS(shadowrun5.weaponexemplar);
create table shadowrun5.firearmmodel(
	ss bool NOT NULL,
	sa bool NOT NULL,
	bf bool NOT NULL,
	fa bool NOT NULL,
	canuseflechette bool NOT NULL,
	rc integer NOT NULL,
	ammo integer NOT NULL,
	loader integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.weaponmodel);
create table shadowrun5.firearmdescription(
	primary key(id))INHERITS(shadowrun5.weapondescription);
create table shadowrun5.firearmexemplar(
	primary key(id))INHERITS(shadowrun5.weaponexemplar);
create table shadowrun5.absgrenademodel(
	blastfactor integer NOT NULL,
	blasttype integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.weaponmodel);
create table shadowrun5.absgrenadedescription(
	primary key(id))INHERITS(shadowrun5.weapondescription);
create table shadowrun5.absgrenadeexemplar(
	primary key(id))INHERITS(shadowrun5.weaponexemplar);
create table shadowrun5.commlinkmodel(
	primary key(id))INHERITS(shadowrun5.electronicmodel);
create table shadowrun5.commlinkdescription(
	primary key(id))INHERITS(shadowrun5.electronicdescription);
create table shadowrun5.commlinkexemplar(
	primary key(id))INHERITS(shadowrun5.electronicexemplar);
create table shadowrun5.commandconsolemodel(
	dataprocessing integer NOT NULL,
	firewall integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.electronicmodel);
create table shadowrun5.commandconsoledescription(
	primary key(id))INHERITS(shadowrun5.electronicdescription);
create table shadowrun5.commandconsoleexemplar(
	primary key(id))INHERITS(shadowrun5.electronicexemplar);
create table shadowrun5.cyberdeckmodel(
	ratingi integer NOT NULL,
	ratingii integer NOT NULL,
	ratingiii integer NOT NULL,
	ratingiv integer NOT NULL,
	programs integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.electronicmodel);
create table shadowrun5.cyberdeckdescription(
	primary key(id))INHERITS(shadowrun5.electronicdescription);
create table shadowrun5.cyberdeckexemplar(
	primary key(id))INHERITS(shadowrun5.electronicexemplar);
create table shadowrun5.devicemodel(
	primary key(id))INHERITS(shadowrun5.absdevicemodel);
create table shadowrun5.devicedescription(
	primary key(id))INHERITS(shadowrun5.absdevicedescription);
create table shadowrun5.deviceexemplar(
	primary key(id))INHERITS(shadowrun5.absdeviceexemplar);
create table shadowrun5.sensormodel(
	minrating integer NOT NULL,
	maxrating integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.absdevicemodel);
create table shadowrun5.sensordescription(
	primary key(id))INHERITS(shadowrun5.absdevicedescription);
create table shadowrun5.sensorexemplar(
	fk_sensorfunctionmodel_sensortype integer,
	primary key(id))INHERITS(shadowrun5.absdeviceexemplar);
create table shadowrun5.cyberweaponmodel(
	fk_weaponmodel_weapon integer,
	cammo integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.augmentationmodel);
create table shadowrun5.cyberweapondescription(
	primary key(id))INHERITS(shadowrun5.augmentationdescription);
create table shadowrun5.cyberweaponexemplar(
	primary key(id))INHERITS(shadowrun5.augmentationexemplar);
create table shadowrun5.toxinmodel(
	power integer NOT NULL,
	penetration integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.substancemodel);
create table shadowrun5.toxindescription(
	primary key(id))INHERITS(shadowrun5.substancedescription);
create table shadowrun5.toxinexemplar(
	primary key(id))INHERITS(shadowrun5.substanceexemplar);
create table shadowrun5.drugmodel(
	duration character varying(40) NOT NULL,
	addiction integer NOT NULL,
	addictionrating integer NOT NULL,
	addictionthreshold integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.substancemodel);
create table shadowrun5.drugdescription(
	primary key(id))INHERITS(shadowrun5.substancedescription);
create table shadowrun5.drugexemplar(
	primary key(id))INHERITS(shadowrun5.substanceexemplar);
create table shadowrun5.gruntmodel(
	fk_lieutenantmodel_lieutenant integer,
	primary key(id))INHERITS(shadowrun5.absgruntmodel);
create table shadowrun5.gruntdescription(
	primary key(id))INHERITS(shadowrun5.absgruntdescription);
create table shadowrun5.gruntexemplar(
	primary key(id))INHERITS(shadowrun5.absgruntexemplar);
create table shadowrun5.lieutenantmodel(
	fk_gruntmodel_grunt integer,
	primary key(id))INHERITS(shadowrun5.absgruntmodel);
create table shadowrun5.lieutenantdescription(
	primary key(id))INHERITS(shadowrun5.absgruntdescription);
create table shadowrun5.lieutenantexemplar(
	primary key(id))INHERITS(shadowrun5.absgruntexemplar);
create table shadowrun5.crittermodel(
	primary key(id))INHERITS(shadowrun5.abscrittermodel);
create table shadowrun5.critterdescription(
	primary key(id))INHERITS(shadowrun5.abscritterdescription);
create table shadowrun5.critterexemplar(
	primary key(id))INHERITS(shadowrun5.abscritterexemplar);
create table shadowrun5.spiritmodel(
	primary key(id))INHERITS(shadowrun5.abscrittermodel);
create table shadowrun5.spiritdescription(
	primary key(id))INHERITS(shadowrun5.abscritterdescription);
create table shadowrun5.spiritexemplar(
	power integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.abscritterexemplar);
create table shadowrun5.grenademodel(
	primary key(id))INHERITS(shadowrun5.absgrenademodel);
create table shadowrun5.grenadedescription(
	primary key(id))INHERITS(shadowrun5.absgrenadedescription);
create table shadowrun5.grenadeexemplar(
	primary key(id))INHERITS(shadowrun5.absgrenadeexemplar);
create table shadowrun5.rocketmodel(
	primary key(id))INHERITS(shadowrun5.absgrenademodel);
create table shadowrun5.rocketdescription(
	primary key(id))INHERITS(shadowrun5.absgrenadedescription);
create table shadowrun5.rocketexemplar(
	missilerating integer NOT NULL,
	primary key(id))INHERITS(shadowrun5.absgrenadeexemplar);
