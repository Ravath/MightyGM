CREATE SCHEMA cinqanneaux;
create table cinqanneaux.absclan_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.absclan_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.absclan_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.famille_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	bonusinitial integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.famille_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.famille_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.competence_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	groupe integer NOT NULL,
	traitassocie integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.competence_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	rang integer NOT NULL,
	primary key(id));
create table cinqanneaux.competence_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.soustypefromcompetencemodel(
	id serial NOT NULL,
	fk_competence integer NOT NULL,
	soustype character varying(30),
	primary key(id));
create table cinqanneaux.specialisationsfromcompetencemodel(
	id serial NOT NULL,
	fk_competence integer NOT NULL,
	specialisations character varying(30),
	primary key(id));
create table cinqanneaux.maitrise_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	rangrequis integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.maitrise_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.maitrise_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.augmentationsort_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	type integer NOT NULL,
	facteur decimal NOT NULL,
	unite character varying(10) NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.augmentationsort_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.augmentationsort_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.abssort_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	element integer NOT NULL,
	maitrise integer NOT NULL,
	portee integer NOT NULL,
	facteurportee decimal NOT NULL,
	zoneeffet integer NOT NULL,
	facteurzone decimal NOT NULL,
	duree integer NOT NULL,
	facteurduree decimal NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.abssort_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.abssort_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.motclefsfromabssortmodel(
	id serial NOT NULL,
	fk_abssort integer NOT NULL,
	motclefs integer,
	primary key(id));
create table cinqanneaux.ecole_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	bonusinitial integer NOT NULL,
	honneur decimal NOT NULL,
	argentinitial decimal NOT NULL,
	affinite integer,
	deficience integer,
	motclef integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.ecole_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.ecole_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.technique_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	rang integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.technique_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.technique_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.absavantage_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	soustype integer NOT NULL,
	cout integer NOT NULL,
	mode integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.absavantage_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	nbrrangs integer NOT NULL,
	primary key(id));
create table cinqanneaux.absavantage_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.absobjet_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	prix integer NOT NULL,
	unite integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.absobjet_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.absobjet_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.kata_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	anneau integer NOT NULL,
	maitrise integer NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.kata_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.kata_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.kiho_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	type integer NOT NULL,
	anneau integer NOT NULL,
	maitrise integer NOT NULL,
	useatemi bool NOT NULL,
	unique(name),
	primary key(id));
create table cinqanneaux.kiho_exemplar(
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.kiho_description(
	description text NOT NULL,
	fk_fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.motscleffromarmemodel(
	id serial NOT NULL,
	fk_arme integer NOT NULL,
	motsclef integer,
	primary key(id));
create table cinqanneaux.specialfromarmedescription(
	id serial NOT NULL,
	fk_arme integer NOT NULL,
	special text,
	primary key(id));
create table cinqanneaux.specialfromarmuredescription(
	id serial NOT NULL,
	fk_armure integer NOT NULL,
	special text,
	primary key(id));
create table cinqanneaux.competencemodeltomaitrisemodel(
	id serial NOT NULL,
	fk_competencemodel integer NOT NULL,
	fk_maitrisemodel integer NOT NULL,
	primary key(id));
create table cinqanneaux.abssortmodeltoaugmentationsortmodel(
	id serial NOT NULL,
	fk_abssortmodel integer NOT NULL,
	fk_augmentationsortmodel integer NOT NULL,
	primary key(id));
create table cinqanneaux.ecolemodeltocompetenceexemplar(
	id serial NOT NULL,
	fk_ecolemodel integer NOT NULL,
	fk_competenceexemplar integer NOT NULL,
	primary key(id));
create table cinqanneaux.ecolemodeltoabsobjetmodel(
	id serial NOT NULL,
	fk_ecolemodel integer NOT NULL,
	fk_absobjetmodel integer NOT NULL,
	primary key(id));
create table cinqanneaux.ecolemodeltosortmodel(
	id serial NOT NULL,
	fk_ecolemodel integer NOT NULL,
	fk_sortmodel integer NOT NULL,
	primary key(id));
create table cinqanneaux.katamodeltoecolemodel(
	id serial NOT NULL,
	fk_katamodel integer NOT NULL,
	fk_ecolemodel integer NOT NULL,
	primary key(id));
create table cinqanneaux.clanmineur_model(
	primary key(id))INHERITS(cinqanneaux.absclan_model);
create table cinqanneaux.clanmineur_exemplar(
	primary key(id))INHERITS(cinqanneaux.absclan_exemplar);
create table cinqanneaux.clanmineur_description(
	primary key(id))INHERITS(cinqanneaux.absclan_description);
create table cinqanneaux.clanmajeur_model(
	primary key(id))INHERITS(cinqanneaux.absclan_model);
create table cinqanneaux.clanmajeur_exemplar(
	primary key(id))INHERITS(cinqanneaux.absclan_exemplar);
create table cinqanneaux.clanmajeur_description(
	perceptioncrabes text NOT NULL,
	perceptiondragons text NOT NULL,
	perceptiongrues text NOT NULL,
	perceptionlicornes text NOT NULL,
	perceptionlions text NOT NULL,
	perceptionmantes text NOT NULL,
	perceptionphenix text NOT NULL,
	perceptionscorpions text NOT NULL,
	primary key(id))INHERITS(cinqanneaux.absclan_description);
create table cinqanneaux.avantage_model(
	primary key(id))INHERITS(cinqanneaux.absavantage_model);
create table cinqanneaux.avantage_exemplar(
	primary key(id))INHERITS(cinqanneaux.absavantage_exemplar);
create table cinqanneaux.avantage_description(
	primary key(id))INHERITS(cinqanneaux.absavantage_description);
create table cinqanneaux.desavantage_model(
	primary key(id))INHERITS(cinqanneaux.absavantage_model);
create table cinqanneaux.desavantage_exemplar(
	primary key(id))INHERITS(cinqanneaux.absavantage_exemplar);
create table cinqanneaux.desavantage_description(
	primary key(id))INHERITS(cinqanneaux.absavantage_description);
create table cinqanneaux.objet_model(
	primary key(id))INHERITS(cinqanneaux.absobjet_model);
create table cinqanneaux.objet_exemplar(
	primary key(id))INHERITS(cinqanneaux.absobjet_exemplar);
create table cinqanneaux.objet_description(
	primary key(id))INHERITS(cinqanneaux.absobjet_description);
create table cinqanneaux.arme_model(
	type integer NOT NULL,
	keepvd integer NOT NULL,
	rollvd integer NOT NULL,
	force integer,
	portee integer,
	primary key(id))INHERITS(cinqanneaux.absobjet_model);
create table cinqanneaux.arme_exemplar(
	primary key(id))INHERITS(cinqanneaux.absobjet_exemplar);
create table cinqanneaux.arme_description(
	primary key(id))INHERITS(cinqanneaux.absobjet_description);
create table cinqanneaux.armure_model(
	bonusnd integer NOT NULL,
	reduction integer NOT NULL,
	primary key(id))INHERITS(cinqanneaux.absobjet_model);
create table cinqanneaux.armure_exemplar(
	primary key(id))INHERITS(cinqanneaux.absobjet_exemplar);
create table cinqanneaux.armure_description(
	primary key(id))INHERITS(cinqanneaux.absobjet_description);
create table cinqanneaux.sort_model(
	primary key(id))INHERITS(cinqanneaux.abssort_model);
create table cinqanneaux.sort_exemplar(
	primary key(id))INHERITS(cinqanneaux.abssort_exemplar);
create table cinqanneaux.sort_description(
	primary key(id))INHERITS(cinqanneaux.abssort_description);
create table cinqanneaux.mahou_model(
	primary key(id))INHERITS(cinqanneaux.abssort_model);
create table cinqanneaux.mahou_exemplar(
	primary key(id))INHERITS(cinqanneaux.abssort_exemplar);
create table cinqanneaux.mahou_description(
	primary key(id))INHERITS(cinqanneaux.abssort_description);
