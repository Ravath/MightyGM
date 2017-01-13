CREATE SCHEMA starwars;
create table starwars.dataobject(
	id serial NOT NULL,
	primary key(id));
create table starwars.obligationsmodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.obligationsdescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.obligationsexemplar(
	fk_model integer,
	valeur integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.racemodel(
	name character varying(40) NOT NULL,
	vigueur integer NOT NULL,
	agilite integer NOT NULL,
	intelligence integer NOT NULL,
	ruse integer NOT NULL,
	volonte integer NOT NULL,
	presence integer NOT NULL,
	b_blessure integer NOT NULL,
	b_stress integer NOT NULL,
	xp_depart integer NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.racedescription(
	description text NOT NULL,
	fk_model integer,
	psychologie text NOT NULL,
	societe text NOT NULL,
	mondenatal text NOT NULL,
	langue text NOT NULL,
	campagne text NOT NULL)INHERITS(starwars.dataobject);
create table starwars.raceexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.capacitemodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.capacitedescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.capaciteexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.carrieremodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.carrieredescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.carriereexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.histoiredecarrieremodel(
	name character varying(40) NOT NULL,
	fk_carrieremodel integer,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.histoiredecarrieredescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.histoiredecarriereexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.specialitemodel(
	name character varying(40) NOT NULL,
	soustitre character varying(40) NOT NULL,
	fk_carrieremodel integer,
	fk_arborescencedespecialite integer,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.specialitedescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.specialiteexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.competencemodel(
	name character varying(40) NOT NULL,
	caracteristique integer NOT NULL,
	typecompetence integer NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.competencedescription(
	description text NOT NULL,
	fk_model integer,
	constitutionpool text NOT NULL,
	utilisationsucces text NOT NULL,
	utilisationavantages text NOT NULL,
	utilisationmenaces text NOT NULL,
	utilisationechecs text NOT NULL,
	utilisationtriomphes text NOT NULL,
	utilisationdesastres text NOT NULL)INHERITS(starwars.dataobject);
create table starwars.competenceexemplar(
	fk_model integer,
	maitrise integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.talentmodel(
	name character varying(40) NOT NULL,
	rangs bool NOT NULL,
	action integer NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.talentdescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.talentexemplar(
	fk_model integer,
	rang integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.objectmodel(
	name character varying(40) NOT NULL,
	prix integer NOT NULL,
	rarete integer NOT NULL,
	type integer NOT NULL,
	interdit bool NOT NULL,
	encombrement integer NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.objectdescription(
	description text NOT NULL,
	fk_model integer,
	reglementation text NOT NULL)INHERITS(starwars.dataobject);
create table starwars.objectexemplar(
	fk_model integer,
	dommages integer NOT NULL,
	modele character varying(40) NOT NULL)INHERITS(starwars.dataobject);
create table starwars.attributarmemodel(
	name character varying(40) NOT NULL,
	declenche bool NOT NULL,
	hasrangs bool NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.attributarmedescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.attributarmeexemplar(
	fk_model integer,
	rang integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.modmodel(
	name character varying(40) NOT NULL,
	rangmax integer NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.moddescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.modexemplar(
	fk_model integer,
	rang integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.vehiculemodel(
	name character varying(40) NOT NULL,
	gabarit integer NOT NULL,
	vitesse integer NOT NULL,
	maniabilite integer NOT NULL,
	defenseavant integer NOT NULL,
	defensearriere integer NOT NULL,
	defensebabord integer,
	defensetribord integer,
	blindage integer NOT NULL,
	seuildommage integer NOT NULL,
	seuilstressmecanique integer NOT NULL,
	type integer NOT NULL,
	modele character varying(40) NOT NULL,
	constructeur character varying(40) NOT NULL,
	porteesenseurs integer,
	chargeutile_max integer NOT NULL,
	chargeutile_min integer NOT NULL,
	passagers_max integer NOT NULL,
	passagers_min integer NOT NULL,
	provisions_unit integer NOT NULL,
	provisions_val integer NOT NULL,
	cout integer NOT NULL,
	rarete integer NOT NULL,
	interdit bool NOT NULL,
	emplacements integer NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.vehiculedescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.vehiculeexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.equipagemodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.equipagedescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.equipageexemplar(
	fk_model integer,
	nombre_max integer NOT NULL,
	nombre_min integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.pouvoirforcemodel(
	name character varying(40) NOT NULL,
	fk_arborescencedeforce integer,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.pouvoirforcedescription(
	description text NOT NULL,
	fk_model integer,
	pouvoirdebase text NOT NULL,
	ameliorationdepuissance text NOT NULL,
	ameliorationdeduree text NOT NULL,
	ameliorationdeportee text NOT NULL,
	ameliorationdeamplitude text NOT NULL)INHERITS(starwars.dataobject);
create table starwars.pouvoirforceexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.ameliorationdecontrole(
	description text NOT NULL)INHERITS(starwars.dataobject);
create table starwars.arborescence(
	name character varying(40) NOT NULL)INHERITS(starwars.dataobject);
create table starwars.branchearborescence(
	fk_arborescence integer,
	horizontal bool NOT NULL,
	ligne integer NOT NULL,
	colonne integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.casearborescence(
	fk_arborescence integer,
	colonne integer NOT NULL,
	ligne integer NOT NULL,
	largeur integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.blessurecritiquemodel(
	name character varying(40) NOT NULL,
	gravite integer NOT NULL,
	vehicule bool NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.blessurecritiquedescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.blessurecritiqueexemplar(
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.personnagemodel(
	name character varying(40) NOT NULL,
	vigueur integer NOT NULL,
	agilite integer NOT NULL,
	intelligence integer NOT NULL,
	ruse integer NOT NULL,
	volonte integer NOT NULL,
	presence integer NOT NULL,
	maitriselaforce bool NOT NULL,
	unique(name))INHERITS(starwars.dataobject);
create table starwars.personnagedescription(
	description text NOT NULL,
	fk_model integer)INHERITS(starwars.dataobject);
create table starwars.personnageexemplar(
	fk_model integer,
	isdead bool NOT NULL,
	stresscourant integer NOT NULL,
	viecourante integer NOT NULL)INHERITS(starwars.dataobject);
create table starwars.racemodeltocapacitemodel(
	fk_racemodel integer,
	fk_capacitemodel integer)INHERITS(starwars.dataobject);
create table starwars.carrieremodeltocompetencemodel(
	fk_carrieremodel integer,
	fk_competencemodel integer)INHERITS(starwars.dataobject);
create table starwars.specialitemodeltocompetencemodel(
	fk_specialitemodel integer,
	fk_competencemodel integer)INHERITS(starwars.dataobject);
create table starwars.exempleutilisationfromcompetencedescription(
	fk_competencedescription integer,
	exempleutilisation text)INHERITS(starwars.dataobject);
create table starwars.talentmodeltoarborescencedespecialite(
	fk_talentmodel integer,
	fk_arborescencedespecialite integer)INHERITS(starwars.dataobject);
create table starwars.modelesfromobjectmodel(
	fk_objectmodel integer,
	modeles character varying(40))INHERITS(starwars.dataobject);
create table starwars.vehiculemodeltoarmedevehiculeexemplar(
	fk_vehiculemodel integer,
	fk_armedevehiculeexemplar integer)INHERITS(starwars.dataobject);
create table starwars.vehiculemodeltoequipageexemplar(
	fk_vehiculemodel integer,
	fk_equipageexemplar integer)INHERITS(starwars.dataobject);
create table starwars.pouvoirforcedescriptiontoameliorationdecontrole(
	fk_pouvoirforcedescription integer,
	fk_ameliorationdecontrole integer)INHERITS(starwars.dataobject);
create table starwars.personnagemodeltocapacitemodel(
	fk_personnagemodel integer,
	fk_capacitemodel integer)INHERITS(starwars.dataobject);
create table starwars.personnagemodeltotalentexemplar(
	fk_personnagemodel integer,
	fk_talentexemplar integer)INHERITS(starwars.dataobject);
create table starwars.personnagemodeltocompetenceexemplar(
	fk_personnagemodel integer,
	fk_competenceexemplar integer)INHERITS(starwars.dataobject);
create table starwars.personnagemodeltoobjectexemplar(
	fk_personnagemodel integer,
	fk_objectexemplar integer)INHERITS(starwars.dataobject);
create table starwars.personnagemodeltoarmeexemplar(
	fk_personnagemodel integer,
	fk_armeexemplar integer)INHERITS(starwars.dataobject);
create table starwars.personnagemodeltoarmureexemplar(
	fk_personnagemodel integer,
	fk_armureexemplar integer)INHERITS(starwars.dataobject);
create table starwars.personnageexemplartoblessurecritiquemodel(
	fk_personnageexemplar integer,
	fk_blessurecritiquemodel integer)INHERITS(starwars.dataobject);
create table starwars.armemodeltoattributarmeexemplar(
	fk_armemodel integer,
	fk_attributarmeexemplar integer)INHERITS(starwars.dataobject);
create table starwars.armeexemplartokitexemplar(
	fk_armeexemplar integer,
	fk_kitexemplar integer)INHERITS(starwars.dataobject);
create table starwars.kitmodeltomodmodel(
	fk_kitmodel integer,
	fk_modmodel integer)INHERITS(starwars.dataobject);
create table starwars.kitexemplartomodexemplar(
	fk_kitexemplar integer,
	fk_modexemplar integer)INHERITS(starwars.dataobject);
create table starwars.pjmodeltocarrieremodel(
	fk_pjmodel integer,
	fk_carrieremodel integer)INHERITS(starwars.dataobject);
create table starwars.pjmodeltospecialitemodel(
	fk_pjmodel integer,
	fk_specialitemodel integer)INHERITS(starwars.dataobject);
create table starwars.pjmodeltoobligationsexemplar(
	fk_pjmodel integer,
	fk_obligationsexemplar integer)INHERITS(starwars.dataobject);
create table starwars.signesparticuliersfrompjdescription(
	fk_pjdescription integer,
	signesparticuliers character varying(40))INHERITS(starwars.dataobject);
create table starwars.capacitedecompetencemodel(
	fk_competencemodel integer,
	primary key(id))INHERITS(starwars.capacitemodel);
create table starwars.capacitedecompetencedescription(
	primary key(id))INHERITS(starwars.capacitedescription);
create table starwars.capacitedecompetenceexemplar(
	primary key(id))INHERITS(starwars.capaciteexemplar);
create table starwars.armemodel(
	degats integer NOT NULL,
	critique integer NOT NULL,
	typearme integer NOT NULL,
	portee integer NOT NULL,
	emplacements integer NOT NULL,
	competence integer NOT NULL,
	primary key(id))INHERITS(starwars.objectmodel);
create table starwars.armedescription(
	primary key(id))INHERITS(starwars.objectdescription);
create table starwars.armeexemplar(
	primary key(id))INHERITS(starwars.objectexemplar);
create table starwars.armuremodel(
	defense integer NOT NULL,
	encaissement integer NOT NULL,
	emplacements integer NOT NULL,
	primary key(id))INHERITS(starwars.objectmodel);
create table starwars.armuredescription(
	primary key(id))INHERITS(starwars.objectdescription);
create table starwars.armureexemplar(
	primary key(id))INHERITS(starwars.objectexemplar);
create table starwars.kitmodel(
	emplacement integer NOT NULL,
	typekit integer NOT NULL,
	effet text NOT NULL,
	primary key(id))INHERITS(starwars.objectmodel);
create table starwars.kitdescription(
	primary key(id))INHERITS(starwars.objectdescription);
create table starwars.kitexemplar(
	primary key(id))INHERITS(starwars.objectexemplar);
create table starwars.moddegatmodel(
	degats integer NOT NULL,
	primary key(id))INHERITS(starwars.modmodel);
create table starwars.moddegatdescription(
	primary key(id))INHERITS(starwars.moddescription);
create table starwars.moddegatexemplar(
	primary key(id))INHERITS(starwars.modexemplar);
create table starwars.modattributmodel(
	fk_attributarmemodel integer,
	primary key(id))INHERITS(starwars.modmodel);
create table starwars.modattributdescription(
	primary key(id))INHERITS(starwars.moddescription);
create table starwars.modattributexemplar(
	primary key(id))INHERITS(starwars.modexemplar);
create table starwars.modtalentmodel(
	fk_talentmodel integer,
	horstour bool NOT NULL,
	primary key(id))INHERITS(starwars.modmodel);
create table starwars.modtalentdescription(
	primary key(id))INHERITS(starwars.moddescription);
create table starwars.modtalentexemplar(
	primary key(id))INHERITS(starwars.modexemplar);
create table starwars.modcompetencemodel(
	fk_competencemodel integer,
	primary key(id))INHERITS(starwars.modmodel);
create table starwars.modcompetencedescription(
	primary key(id))INHERITS(starwars.moddescription);
create table starwars.modcompetenceexemplar(
	primary key(id))INHERITS(starwars.modexemplar);
create table starwars.modcaracteristiquemodel(
	caracteristique integer NOT NULL,
	primary key(id))INHERITS(starwars.modmodel);
create table starwars.modcaracteristiquedescription(
	primary key(id))INHERITS(starwars.moddescription);
create table starwars.modcaracteristiqueexemplar(
	primary key(id))INHERITS(starwars.modexemplar);
create table starwars.modspecialmodel(
	fk_capacitemodel integer,
	primary key(id))INHERITS(starwars.modmodel);
create table starwars.modspecialdescription(
	primary key(id))INHERITS(starwars.moddescription);
create table starwars.modspecialexemplar(
	primary key(id))INHERITS(starwars.modexemplar);
create table starwars.arborescencedespecialite(
	fk_specialitemodel integer,
	primary key(id))INHERITS(starwars.arborescence);
create table starwars.arborescencedeforce(
	fk_pouvoirforcemodel integer,
	primary key(id))INHERITS(starwars.arborescence);
create table starwars.casearborescencedespecialite(
	fk_talentmodel integer,
	primary key(id))INHERITS(starwars.casearborescence);
create table starwars.casearborescenceforce(
	type integer NOT NULL,
	cout integer NOT NULL,
	fk_ameliorationdecontrole integer,
	primary key(id))INHERITS(starwars.casearborescence);
create table starwars.adversairemodel(
	rangadversite integer NOT NULL,
	primary key(id))INHERITS(starwars.personnagemodel);
create table starwars.adversairedescription(
	primary key(id))INHERITS(starwars.personnagedescription);
create table starwars.adversaireexemplar(
	primary key(id))INHERITS(starwars.personnageexemplar);
create table starwars.pjmodel(
	fk_joueur integer,
	fk_racemodel integer,
	fk_carrieremodel integer,
	fk_specialitemodel integer,
	credits integer NOT NULL,
	totalxp integer NOT NULL,
	xpdepense integer NOT NULL,
	primary key(id))INHERITS(starwars.personnagemodel);
create table starwars.pjdescription(
	sexemasculin bool NOT NULL,
	age integer NOT NULL,
	taille integer NOT NULL,
	carrure character varying(40) NOT NULL,
	cheveux character varying(40) NOT NULL,
	yeux character varying(40) NOT NULL,
	primary key(id))INHERITS(starwars.personnagedescription);
create table starwars.pjexemplar(
	primary key(id))INHERITS(starwars.personnageexemplar);
create table starwars.armedevehiculemodel(
	primary key(id))INHERITS(starwars.armemodel);
create table starwars.armedevehiculedescription(
	primary key(id))INHERITS(starwars.armedescription);
create table starwars.armedevehiculeexemplar(
	nombre integer NOT NULL,
	arcdetir integer NOT NULL,
	primary key(id))INHERITS(starwars.armeexemplar);
