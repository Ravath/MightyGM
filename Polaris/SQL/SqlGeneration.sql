DROP SCHEMA IF EXISTS polaris CASCADE;
CREATE SCHEMA polaris;
create table polaris.dataobject(
	id serial NOT NULL,
	primary key(id));
create table polaris.complexes(
	fk_villemodel_ville integer,
	type integer NOT NULL,
	nombre integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.blessures(
	legeres integer NOT NULL,
	moyennes integer NOT NULL,
	graves integer NOT NULL,
	critiques integer NOT NULL,
	mortelles integer NOT NULL,
	detruit bool NOT NULL)INHERITS(polaris.dataobject);
create table polaris.titre(
	fk_professionmodel_profession integer,
	nom character varying(20) NOT NULL,
	ordre integer NOT NULL,
	annees integer NOT NULL,
	revenus integer NOT NULL,
	ndrandfactor integer,
	fdrandfactor integer)INHERITS(polaris.dataobject);
create table polaris.ordinateur(
	gen integer NOT NULL,
	nt integer NOT NULL,
	disponibilite integer NOT NULL,
	poids integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.playerconditionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.playerconditiondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.playerconditionexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(polaris.dataobject);
create table polaris.playereffectmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.playereffectdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.playereffectexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(polaris.dataobject);
create table polaris.objecteffectmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.objecteffectdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.objecteffectexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(polaris.dataobject);
create table polaris.nationmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	typenation integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.nationdescription(
	description text NOT NULL,
	fk_model_id integer,
	geographie text NOT NULL,
	historique text NOT NULL,
	societe text NOT NULL,
	territoire text NOT NULL,
	armes text NOT NULL)INHERITS(polaris.dataobject);
create table polaris.nationexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.personnalitemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_nationmodel_nation integer,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.personnalitedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.personnaliteexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.villemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	population integer NOT NULL,
	profondeur_max integer NOT NULL,
	profondeur_min integer NOT NULL,
	popfeconde integer NOT NULL,
	popmutante integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.villedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.villeexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.factionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.factiondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.factionexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.villemajeuremodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_villemodel_ville integer,
	gouvernement character varying(60) NOT NULL,
	dirigeant character varying(60) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.villemajeuredescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.villemajeureexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	force integer NOT NULL,
	constitution integer NOT NULL,
	coordination integer NOT NULL,
	adaptation integer NOT NULL,
	perception integer NOT NULL,
	intelligence integer NOT NULL,
	volonte integer NOT NULL,
	presence integer NOT NULL,
	chance integer NOT NULL,
	effetpolaris bool NOT NULL,
	fecond bool NOT NULL,
	maindirectrice integer NOT NULL,
	fk_archetypemodel_archetype integer,
	fk_typegenetiqueexemplar_typegenetique integer,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.personnagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.personnageexemplar(
	fk_model_id integer,
	fk_blessures_tete integer,
	fk_blessures_corps integer,
	fk_blessures_brasd integer,
	fk_blessures_brasg integer,
	fk_blessures_jambed integer,
	fk_blessures_jambeg integer)INHERITS(polaris.dataobject);
create table polaris.archetypemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	base integer NOT NULL,
	genetique integer NOT NULL,
	special integer NOT NULL,
	experience integer NOT NULL,
	avantages integer NOT NULL,
	desavantages integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.archetypedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.archetypeexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.typegenetiquemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.typegenetiquedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.typegenetiqueexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.mutationmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	cavantage integer,
	cdesavantage integer,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.mutationdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.mutationexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.originemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.originedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.origineexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.avantagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique bool NOT NULL,
	desavantage bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.avantagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.avantageexemplar(
	fk_model_id integer,
	cout integer NOT NULL,
	valeur character varying(15) NOT NULL)INHERITS(polaris.dataobject);
create table polaris.professionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	contacts_num integer NOT NULL,
	contacts_den integer NOT NULL,
	allies_num integer NOT NULL,
	allies_den integer NOT NULL,
	opposants_num integer NOT NULL,
	opposants_den integer NOT NULL,
	ratiosennemi integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.professiondescription(
	description text NOT NULL,
	fk_model_id integer,
	originegeographique text NOT NULL)INHERITS(polaris.dataobject);
create table polaris.professionexemplar(
	fk_model_id integer,
	experience integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.categoriematerielmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.categoriematerieldescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.categoriematerielexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.avantagepromodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.avantageprodescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.avantageproexemplar(
	fk_model_id integer,
	rang integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.avantageproaleatoiremodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_professionmodel_profession integer,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.avantageproaleatoiredescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.avantageproaleatoireexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.reversdefortunemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.reversdefortunedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.reversdefortuneexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.abscompetencemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	acquisition integer NOT NULL,
	limitative bool NOT NULL,
	prognaturelle bool NOT NULL,
	attributsvariables bool NOT NULL,
	categorie integer NOT NULL,
	caracteristiquei integer NOT NULL,
	caracteristiqueii integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.abscompetencedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.abscompetenceexemplar(
	fk_model_id integer,
	rang integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.techniquemartialemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	utilisationlibre bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.techniquemartialedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.techniquemartialeexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.techniquetirmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	actionexclusive bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.techniquetirdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.techniquetirexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.abspoisonmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	modecontamination integer NOT NULL,
	modifdiagnostique integer NOT NULL,
	modifguerison integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.abspoisondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.abspoisonexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.droguemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	duree integer NOT NULL,
	modifdependance integer NOT NULL,
	manque integer NOT NULL,
	cout integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.droguedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.drogueexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.pouvoirpolarismodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	zoneeffet integer NOT NULL,
	porteemax integer NOT NULL,
	duree_unit integer NOT NULL,
	duree_val integer NOT NULL,
	autre integer NOT NULL,
	nbrddgts integer NOT NULL,
	bonusdgts integer NOT NULL,
	d6dgts bool NOT NULL,
	nombrelocalisations integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.pouvoirpolarisdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.pouvoirpolarisexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.incidentpolarismodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.incidentpolarisdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.incidentpolarisexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.fabriquantmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.fabriquantdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.fabriquantexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.objectmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	cout integer NOT NULL,
	dispo integer NOT NULL,
	disponoir integer NOT NULL,
	poids decimal NOT NULL,
	nt integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.objectdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.objectexemplar(
	fk_model_id integer,
	integritemax integer NOT NULL,
	integrite integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.programmemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	cout integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.programmedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.programmeexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.munitionspecialemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	multiplicateurcout integer NOT NULL,
	fk_specialarmeexemplar_special integer,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.munitionspecialedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.munitionspecialeexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.accessoirearmemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_specialarmeexemplar_special integer,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.accessoirearmedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.accessoirearmeexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.specialarmemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.specialarmedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.specialarmeexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(polaris.dataobject);
create table polaris.localisationcreaturemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.localisationcreaturedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.localisationcreatureexemplar(
	fk_model_id integer,
	chances integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.attaquecreaturemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.attaquecreaturedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.attaquecreatureexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.specialcreaturemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.specialcreaturedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.specialcreatureexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.creaturemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	echelle integer NOT NULL,
	force integer,
	constitution integer,
	coordination integer,
	adaptation integer,
	perception integer,
	intelligence integer,
	volonte integer,
	presence integer,
	vitesse integer NOT NULL,
	vit integer NOT NULL,
	poids integer NOT NULL,
	taille integer NOT NULL,
	marine bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.creaturedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.creatureexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.nationmodeltovillemodel_villes(
	fk_nationmodel_join integer,
	fk_villemodel_join integer)INHERITS(polaris.dataobject);
create table polaris.sousdivisionfromfactiondescription(
	fk_factiondescription_from integer,
	sousdivision text)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltomutationexemplar_mutations(
	fk_personnagemodel_join integer,
	fk_mutationexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltoorigineexemplar_origines(
	fk_personnagemodel_join integer,
	fk_origineexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltocompetenceexemplar_competences(
	fk_personnagemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltoprofessionexemplar_professions(
	fk_personnagemodel_join integer,
	fk_professionexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltoavantageexemplar_avantages(
	fk_personnagemodel_join integer,
	fk_avantageexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.typegenetiquemodeltoplayerconditionexemplar_conditions(
	fk_typegenetiquemodel_join integer,
	fk_playerconditionexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.typegenetiquemodeltoplayereffectexemplar_effets(
	fk_typegenetiquemodel_join integer,
	fk_playereffectexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.mutationmodeltoplayereffectexemplar_effets(
	fk_mutationmodel_join integer,
	fk_playereffectexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.originemodeltooriginemodel_requis(
	fk_originemodel_joinrequis integer,
	fk_originemodel_join integer)INHERITS(polaris.dataobject);
create table polaris.originemodeltocompetenceexemplar_competences(
	fk_originemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.coutsfromavantagemodel(
	fk_avantagemodel_from integer,
	couts integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.avantagemodeltoplayereffectmodel_effets(
	fk_avantagemodel_join integer,
	fk_playereffectmodel_join integer)INHERITS(polaris.dataobject);
create table polaris.professionmodeltoplayerconditionexemplar_requis(
	fk_professionmodel_join integer,
	fk_playerconditionexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.professionmodeltocompetencemodel_competences(
	fk_professionmodel_join integer,
	fk_competencemodel_join integer)INHERITS(polaris.dataobject);
create table polaris.professionmodeltoavantagepromodel_avantagespro(
	fk_professionmodel_join integer,
	fk_avantagepromodel_join integer)INHERITS(polaris.dataobject);
create table polaris.professionmodeltocategoriematerielmodel_materielaccessible(
	fk_professionmodel_join integer,
	fk_categoriematerielmodel_join integer)INHERITS(polaris.dataobject);
create table polaris.avantageproaleatoiremodeltoplayereffectexemplar_effects(
	fk_avantageproaleatoiremodel_join integer,
	fk_playereffectexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.reversdefortunemodeltoplayereffectexemplar_effects(
	fk_reversdefortunemodel_join integer,
	fk_playereffectexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.abscompetencemodeltocompetenceexemplar_prerequis(
	fk_abscompetencemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.objectmodeltofabriquantmodel_fabriquant(
	fk_objectmodel_join integer,
	fk_fabriquantmodel_join integer)INHERITS(polaris.dataobject);
create table polaris.materielmodeltoobjecteffectexemplar_effects(
	fk_materielmodel_join integer,
	fk_objecteffectexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.absarmemodeltospecialarmeexemplar_special(
	fk_absarmemodel_join integer,
	fk_specialarmeexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.modetirfromarmedistancemodel(
	fk_armedistancemodel_from integer,
	modetir integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.modetirfromlancetorpillemodel(
	fk_lancetorpillemodel_from integer,
	modetir integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.creaturemodeltolocalisationcreaturemodel_localisations(
	fk_creaturemodel_join integer,
	fk_localisationcreaturemodel_join integer)INHERITS(polaris.dataobject);
create table polaris.creaturemodeltocompetenceexemplar_competences(
	fk_creaturemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.creaturemodeltoattaquecreatureexemplar_attaquescreature(
	fk_creaturemodel_join integer,
	fk_attaquecreatureexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.creaturemodeltospecialcreatureexemplar_specialcreature(
	fk_creaturemodel_join integer,
	fk_specialcreatureexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.competencemodel(
	primary key(id))INHERITS(polaris.abscompetencemodel);
create table polaris.competencedescription(
	primary key(id))INHERITS(polaris.abscompetencedescription);
create table polaris.competenceexemplar(
	fk_specialitemodel_specialite integer,
	primary key(id))INHERITS(polaris.abscompetenceexemplar);
create table polaris.specialitemodel(
	fk_competencemodel_competence integer,
	primary key(id))INHERITS(polaris.abscompetencemodel);
create table polaris.specialitedescription(
	primary key(id))INHERITS(polaris.abscompetencedescription);
create table polaris.specialiteexemplar(
	primary key(id))INHERITS(polaris.abscompetenceexemplar);
create table polaris.maladiemodel(
	primary key(id))INHERITS(polaris.abspoisonmodel);
create table polaris.maladiedescription(
	primary key(id))INHERITS(polaris.abspoisondescription);
create table polaris.maladieexemplar(
	primary key(id))INHERITS(polaris.abspoisonexemplar);
create table polaris.poisonmodel(
	cout integer NOT NULL,
	primary key(id))INHERITS(polaris.abspoisonmodel);
create table polaris.poisondescription(
	primary key(id))INHERITS(polaris.abspoisondescription);
create table polaris.poisonexemplar(
	primary key(id))INHERITS(polaris.abspoisonexemplar);
create table polaris.materielmodel(
	niveau integer,
	isbonus bool NOT NULL,
	niveauvariable bool NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.materieldescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.materielexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.absarmemodel(
	degats character varying(15) NOT NULL,
	penalite integer NOT NULL,
	force integer NOT NULL,
	init integer NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.absarmedescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.absarmeexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.lancetorpillemodel(
	tailletorpille_max integer NOT NULL,
	tailletorpille_min integer NOT NULL,
	for integer NOT NULL,
	init integer NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.lancetorpilledescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.lancetorpilleexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.armuremodel(
	protection integer NOT NULL,
	choc integer,
	parniveau bool NOT NULL,
	tete bool NOT NULL,
	corps bool NOT NULL,
	bras bool NOT NULL,
	jambes bool NOT NULL,
	categorie integer NOT NULL,
	force integer NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.armuredescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.armureexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.dronemodel(
	gabarit integer NOT NULL,
	echelle integer NOT NULL,
	blindage integer NOT NULL,
	resistangedgts integer NOT NULL,
	modintegrite integer NOT NULL,
	blindageiem integer NOT NULL,
	autonomie integer NOT NULL,
	profondeuroperationelle integer NOT NULL,
	vitesse integer NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.dronedescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.droneexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.exoarmuremodel(
	echelle integer NOT NULL,
	categorie integer NOT NULL,
	type integer NOT NULL,
	profoperationelle integer NOT NULL,
	proflimite integer NOT NULL,
	profecrasement integer NOT NULL,
	autonomie integer NOT NULL,
	resistancedommages integer NOT NULL,
	blindage integer NOT NULL,
	architecture integer NOT NULL,
	modintegrite integer NOT NULL,
	exoforce integer NOT NULL,
	moddommages integer NOT NULL,
	vitesse integer NOT NULL,
	vit integer NOT NULL,
	initsseau integer NOT NULL,
	initaterre integer NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.exoarmuredescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.exoarmureexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.vehiculemodel(
	echelle integer NOT NULL,
	longueur integer NOT NULL,
	diametre integer NOT NULL,
	equipage integer NOT NULL,
	passagers integer NOT NULL,
	poidsfret integer NOT NULL,
	volumefret integer NOT NULL,
	profoperationelle integer NOT NULL,
	proflimite integer NOT NULL,
	profecrasement integer NOT NULL,
	autonomie integer NOT NULL,
	gabarit integer NOT NULL,
	resistancedommages integer NOT NULL,
	architecture integer NOT NULL,
	modintegrite integer NOT NULL,
	blindage integer NOT NULL,
	manoeuvrabilite integer NOT NULL,
	vitesse integer NOT NULL,
	vit integer NOT NULL,
	ponts integer NOT NULL,
	cloisonsetanches integer NOT NULL,
	ecoutilles integer NOT NULL,
	portesexternes integer NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.vehiculedescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.vehiculeexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.implantmodel(
	attribut integer,
	artificiel bool NOT NULL,
	primary key(id))INHERITS(polaris.materielmodel);
create table polaris.implantdescription(
	primary key(id))INHERITS(polaris.materieldescription);
create table polaris.implantexemplar(
	primary key(id))INHERITS(polaris.materielexemplar);
create table polaris.armemeleemodel(
	degatschoc character varying(15) NOT NULL,
	degatscumulatifs integer NOT NULL,
	penalitecumulative integer NOT NULL,
	allonge integer NOT NULL,
	charge integer NOT NULL,
	coutcharge integer NOT NULL,
	chargehoraire bool NOT NULL,
	primary key(id))INHERITS(polaris.absarmemodel);
create table polaris.armemeleedescription(
	primary key(id))INHERITS(polaris.absarmedescription);
create table polaris.armemeleeexemplar(
	primary key(id))INHERITS(polaris.absarmeexemplar);
create table polaris.armedistancemodel(
	type integer NOT NULL,
	munitions integer NOT NULL,
	coutmunitions integer NOT NULL,
	porteeportant integer NOT NULL,
	porteecourte integer NOT NULL,
	porteemoyenne integer NOT NULL,
	porteelongue integer NOT NULL,
	porteeextreme integer NOT NULL,
	primary key(id))INHERITS(polaris.absarmemodel);
create table polaris.armedistancedescription(
	primary key(id))INHERITS(polaris.absarmedescription);
create table polaris.armedistanceexemplar(
	primary key(id))INHERITS(polaris.absarmeexemplar);
