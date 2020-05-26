DROP SCHEMA IF EXISTS yggdrasil CASCADE;
CREATE SCHEMA yggdrasil;
create table yggdrasil.dataobject(
	id serial NOT NULL,
	primary key(id));
create table yggdrasil.personnagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	puissance integer NOT NULL,
	vigueur integer NOT NULL,
	agilite integer NOT NULL,
	intellect integer NOT NULL,
	perception integer NOT NULL,
	tenacite integer NOT NULL,
	charisme integer NOT NULL,
	instinct integer NOT NULL,
	communication integer NOT NULL,
	fk_archetypeexemplar_archetype integer,
	typefuror integer NOT NULL,
	historique text NOT NULL,
	experience integer NOT NULL,
	renommee integer NOT NULL,
	argent integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnageexemplar(
	fk_model_id integer,
	furordepensee integer NOT NULL,
	pointsdedegat integer NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.runemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	aett integer NOT NULL,
	nature integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.runedescription(
	description text NOT NULL,
	fk_model_id integer,
	effetpositif text NOT NULL,
	effetnegatif text NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.runeexemplar(
	fk_model_id integer,
	ispositif bool NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.archetypemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	classe integer NOT NULL,
	competencemagique bool NOT NULL,
	competencesmartiales integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.archetypedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.archetypeexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.competencemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	categorie integer NOT NULL,
	hasspecialisations bool NOT NULL,
	utilisationinnee bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.competencedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.competenceexemplar(
	fk_model_id integer,
	points integer NOT NULL,
	specialisationchoisie character varying(30) NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.donmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	faiblesse bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.dondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.donexemplar(
	fk_model_id integer,
	precisions character varying(30) NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.blessuremodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	oddmin integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.blessuredescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.blessureexemplar(
	fk_model_id integer,
	sequelle bool NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.maladiemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	categorie integer NOT NULL,
	seuil integer NOT NULL,
	periode_unit integer NOT NULL,
	periode_val integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.maladiedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.maladieexemplar(
	fk_model_id integer,
	avancement integer NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.poisonmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	categorie integer NOT NULL,
	seuil integer NOT NULL,
	ingestion bool NOT NULL,
	contact bool NOT NULL,
	injection bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.poisondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.poisonexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.prouessemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	niveau integer NOT NULL,
	ameliorations integer NOT NULL,
	typeprouesse integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.prouessedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.prouesseexemplar(
	fk_model_id integer,
	niveauactuel integer NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.domainesejdrmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.domainesejdrdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.domainesejdrexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortsejdrmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_domainesejdrmodel_categorie integer,
	niveau integer NOT NULL,
	malus integer NOT NULL,
	incantation_unit integer NOT NULL,
	incantation_val integer NOT NULL,
	dureeeffet_unit integer NOT NULL,
	dureeeffet_val integer NOT NULL,
	zoneeffet text NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortsejdrdescription(
	description text NOT NULL,
	fk_model_id integer,
	effetnegatif text NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortsejdrexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.domainegaldrmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.domainegaldrdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.domainegaldrexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortgaldrmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_domainegaldrmodel_domaine integer,
	sd integer NOT NULL,
	dureeeffet_unit integer NOT NULL,
	dureeeffet_val integer NOT NULL,
	cibles text NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortgaldrdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortgaldrexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortrunemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	niveau integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortrunedescription(
	description text NOT NULL,
	fk_model_id integer,
	effetpositif text NOT NULL,
	effetnegatif text NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.sortruneexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.figurantmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	conflitoffensif integer NOT NULL,
	conflitdefensif integer NOT NULL,
	relationnel integer NOT NULL,
	physique integer NOT NULL,
	mental integer NOT NULL,
	mystiqueactif integer NOT NULL,
	mystiquepassif integer NOT NULL,
	vitalite integer NOT NULL,
	categorie integer NOT NULL,
	degats integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.figurantdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.figurantexemplar(
	fk_model_id integer,
	nom character varying(30) NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.caracteremodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	categorie integer NOT NULL,
	conflitoffensif integer NOT NULL,
	conflitdefensif integer NOT NULL,
	relationnel integer NOT NULL,
	physique integer NOT NULL,
	mental integer NOT NULL,
	mystiqueactif integer NOT NULL,
	mystiquepassif integer NOT NULL,
	vitalite integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.caracteredescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.caractereexemplar(
	fk_model_id integer,
	precisions character varying(20) NOT NULL)INHERITS(yggdrasil.dataobject);
create table yggdrasil.objetmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	encombrement integer NOT NULL,
	prix integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(yggdrasil.dataobject);
create table yggdrasil.objetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.objetexemplar(
	fk_model_id integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltoruneexemplar_tirage(
	fk_personnagemodel_join integer,
	fk_runeexemplar_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltodonexemplar_dons(
	fk_personnagemodel_join integer,
	fk_donexemplar_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltoblessureexemplar_sequelles(
	fk_personnagemodel_join integer,
	fk_blessureexemplar_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltomaladieexemplar_maladies(
	fk_personnagemodel_join integer,
	fk_maladieexemplar_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltoprouesseexemplar_prouesses(
	fk_personnagemodel_join integer,
	fk_prouesseexemplar_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltosortsejdrmodel_sortssejdr(
	fk_personnagemodel_join integer,
	fk_sortsejdrmodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltosortgaldrmodel_sortsgaldr(
	fk_personnagemodel_join integer,
	fk_sortgaldrmodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltosortrunemodel_sortsrune(
	fk_personnagemodel_join integer,
	fk_sortrunemodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltoarmemodel_armes(
	fk_personnagemodel_join integer,
	fk_armemodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltoarmuremodel_armures(
	fk_personnagemodel_join integer,
	fk_armuremodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltoobjetquotidienmodel_objets(
	fk_personnagemodel_join integer,
	fk_objetquotidienmodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.personnagemodeltocaractereexemplar_caracteres(
	fk_personnagemodel_join integer,
	fk_caractereexemplar_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.archetypemodeltocompetencemodel_competencesprivilegiees(
	fk_archetypemodel_join integer,
	fk_competencemodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.archetypeexemplartocompetencemodel_competenceschoisies(
	fk_archetypeexemplar_join integer,
	fk_competencemodel_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.figurantexemplartocaractereexemplar_caracteres(
	fk_figurantexemplar_join integer,
	fk_caractereexemplar_join integer)INHERITS(yggdrasil.dataobject);
create table yggdrasil.armemodel(
	categorie integer NOT NULL,
	degats integer NOT NULL,
	solidite integer NOT NULL,
	peutetrelancee bool NOT NULL,
	porteec integer NOT NULL,
	porteem integer NOT NULL,
	porteel integer NOT NULL,
	porteee integer NOT NULL,
	primary key(id))INHERITS(yggdrasil.objetmodel);
create table yggdrasil.armedescription(
	primary key(id))INHERITS(yggdrasil.objetdescription);
create table yggdrasil.armeexemplar(
	soliditerestante integer NOT NULL,
	primary key(id))INHERITS(yggdrasil.objetexemplar);
create table yggdrasil.armuremodel(
	protection integer NOT NULL,
	categorie integer NOT NULL,
	primary key(id))INHERITS(yggdrasil.objetmodel);
create table yggdrasil.armuredescription(
	primary key(id))INHERITS(yggdrasil.objetdescription);
create table yggdrasil.armureexemplar(
	soliditerestante integer NOT NULL,
	piecedecoree bool NOT NULL,
	primary key(id))INHERITS(yggdrasil.objetexemplar);
create table yggdrasil.objetquotidienmodel(
	prixmax bool NOT NULL,
	quantite_unit integer NOT NULL,
	quantite_val integer NOT NULL,
	categorie integer NOT NULL,
	primary key(id))INHERITS(yggdrasil.objetmodel);
create table yggdrasil.objetquotidiendescription(
	primary key(id))INHERITS(yggdrasil.objetdescription);
create table yggdrasil.objetquotidienexemplar(
	prixachat integer NOT NULL,
	primary key(id))INHERITS(yggdrasil.objetexemplar);
