CREATE SCHEMA polaris;
create table polaris.dataobject(
	id serial NOT NULL,
	primary key(id));
create table polaris.complexes(
	type integer NOT NULL,
	nombre integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.titre(
	nom character varying(20) NOT NULL,
	ordre integer NOT NULL,
	annees integer NOT NULL,
	revenus integer NOT NULL,
	ndrandfactor integer,
	fdrandfactor integer)INHERITS(polaris.dataobject);
create table polaris.specialite(
	nom character varying(20) NOT NULL)INHERITS(polaris.dataobject);
create table polaris.fabriquant(
	nom character varying(20) NOT NULL)INHERITS(polaris.dataobject);
create table polaris.nationmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
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
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.personnagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.personnageexemplar(
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
create table polaris.originesmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.originesdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.originesexemplar(
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.avantagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	cout integer NOT NULL,
	unique bool NOT NULL,
	desavantage bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.avantagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.avantageexemplar(
	fk_model_id integer,
	rangs integer NOT NULL)INHERITS(polaris.dataobject);
create table polaris.professionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	contacts integer NOT NULL,
	allies integer NOT NULL,
	opposants integer NOT NULL,
	ratiosennemi integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.professiondescription(
	description text NOT NULL,
	fk_model_id integer,
	originegeographque text NOT NULL)INHERITS(polaris.dataobject);
create table polaris.professionexemplar(
	fk_model_id integer,
	experience integer NOT NULL)INHERITS(polaris.dataobject);
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
create table polaris.competencemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	reservee bool NOT NULL,
	limitative bool NOT NULL,
	prognaturelle bool NOT NULL,
	prerequis bool NOT NULL,
	generale bool NOT NULL,
	attributsvariables bool NOT NULL,
	caracteristiquei integer NOT NULL,
	caracteristiqueii integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(polaris.dataobject);
create table polaris.competencedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(polaris.dataobject);
create table polaris.competenceexemplar(
	fk_model_id integer,
	rang integer NOT NULL,
	fk_specialite_specialite integer)INHERITS(polaris.dataobject);
create table polaris.pouvoirpolarismodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	zoneeffet integer NOT NULL,
	porteemax integer NOT NULL,
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
	integrte integer NOT NULL)INHERITS(polaris.dataobject);
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
create table polaris.nationdescriptiontopersonnalitemodel_personnalites(
	fk_nationdescription_join integer,
	fk_personnalitemodel_join integer)INHERITS(polaris.dataobject);
create table polaris.nationdescriptiontovillemodel_villes(
	fk_nationdescription_join integer,
	fk_villemodel_join integer)INHERITS(polaris.dataobject);
create table polaris.villemodeltocomplexes_complexes(
	fk_villemodel_join integer,
	fk_complexes_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltomutationexemplar_mutations(
	fk_personnagemodel_join integer,
	fk_mutationexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltooriginesexemplar_origines(
	fk_personnagemodel_join integer,
	fk_originesexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltocompetenceexemplar_competences(
	fk_personnagemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltoprofessionexemplar_professions(
	fk_personnagemodel_join integer,
	fk_professionexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.personnagemodeltoavantageexemplar_avantages(
	fk_personnagemodel_join integer,
	fk_avantageexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.originesmodeltocompetenceexemplar_competences(
	fk_originesmodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(polaris.dataobject);
create table polaris.professionmodeltocompetencemodel_competences(
	fk_professionmodel_join integer,
	fk_competencemodel_join integer)INHERITS(polaris.dataobject);
create table polaris.professionmodeltoavantagepromodel_avantagespro(
	fk_professionmodel_join integer,
	fk_avantagepromodel_join integer)INHERITS(polaris.dataobject);
create table polaris.professionmodeltotitre_titres(
	fk_professionmodel_join integer,
	fk_titre_join integer)INHERITS(polaris.dataobject);
create table polaris.competencemodeltospecialite_specialites(
	fk_competencemodel_join integer,
	fk_specialite_join integer)INHERITS(polaris.dataobject);
create table polaris.objectmodeltofabriquant_fabriquant(
	fk_objectmodel_join integer,
	fk_fabriquant_join integer)INHERITS(polaris.dataobject);
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
create table polaris.materielmodel(
	niveau integer,
	isbonus bool NOT NULL,
	niveauvariable bool NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.materieldescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.materielexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.armemeleemodel(
	nbrddegats integer NOT NULL,
	dgtsd6 bool NOT NULL,
	plus integer NOT NULL,
	degatscumulatifs bool NOT NULL,
	nbrddegatschoc integer,
	dgtsd6choc bool,
	pluschoc integer,
	penalite integer NOT NULL,
	force integer NOT NULL,
	init integer NOT NULL,
	allonge integer NOT NULL,
	charge integer NOT NULL,
	coutcharge integer NOT NULL,
	chargehoraire bool NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.armemeleedescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.armemeleeexemplar(
	primary key(id))INHERITS(polaris.objectexemplar);
create table polaris.armetraitmodel(
	nbrddegats integer NOT NULL,
	dgtsd6 bool NOT NULL,
	plus integer NOT NULL,
	penalite integer NOT NULL,
	force integer NOT NULL,
	init integer NOT NULL,
	allonge integer NOT NULL,
	munitions integer NOT NULL,
	coutmunitions integer NOT NULL,
	chargehoraire bool NOT NULL,
	porteeportant integer NOT NULL,
	porteecourte integer NOT NULL,
	porteemoyenne integer NOT NULL,
	porteelongue integer NOT NULL,
	porteeextreme integer NOT NULL,
	modetir integer NOT NULL,
	primary key(id))INHERITS(polaris.objectmodel);
create table polaris.armetraitdescription(
	primary key(id))INHERITS(polaris.objectdescription);
create table polaris.armetraitexemplar(
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
