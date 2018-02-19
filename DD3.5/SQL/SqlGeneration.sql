CREATE SCHEMA dd35;
create table dd35.dataobject(
	id serial NOT NULL,
	primary key(id));
create table dd35.racemodel(
	name character varying(40) NOT NULL,
	force integer NOT NULL,
	dexterite integer NOT NULL,
	constitution integer NOT NULL,
	intelligence integer NOT NULL,
	sagesse integer NOT NULL,
	charisme integer NOT NULL,
	vd integer NOT NULL,
	fk_classemodel_classepredilection integer,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.racedescription(
	description text NOT NULL,
	fk_model_id integer,
	personnalite text NOT NULL,
	relations text NOT NULL,
	alignement text NOT NULL,
	territoires text NOT NULL,
	religion text NOT NULL,
	langue text NOT NULL,
	noms text NOT NULL,
	aventuriers text NOT NULL)INHERITS(dd35.dataobject);
create table dd35.raceexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.absdvmodel(
	name character varying(40) NOT NULL,
	dvtype integer NOT NULL,
	facteurcompetence integer NOT NULL,
	bba integer NOT NULL,
	reflexes integer NOT NULL,
	vigueur integer NOT NULL,
	volonte integer NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.absdvdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.absdvexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.pouvoirclassemodel(
	name character varying(40) NOT NULL,
	fk_pouvoirspecialmodel_pouvoir integer,
	niveau integer NOT NULL,
	fk_absclassemodel_classe integer,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.pouvoirclassedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.pouvoirclasseexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.languemodel(
	name character varying(40) NOT NULL,
	alphabet character varying(10) NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.languedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.langueexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.competencemodel(
	name character varying(40) NOT NULL,
	caracteristique integer NOT NULL,
	innee bool NOT NULL,
	malusarmure integer NOT NULL,
	generale bool NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.competencedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.competenceexemplar(
	fk_model_id integer,
	specialite character varying(40) NOT NULL,
	rang integer NOT NULL)INHERITS(dd35.dataobject);
create table dd35.donmodel(
	name character varying(40) NOT NULL,
	typedon integer NOT NULL,
	donmartial bool NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.dondescription(
	description text NOT NULL,
	fk_model_id integer,
	conditions text NOT NULL,
	avantage text NOT NULL,
	special text NOT NULL)INHERITS(dd35.dataobject);
create table dd35.donexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.divinitemodel(
	name character varying(40) NOT NULL,
	alignementloi integer NOT NULL,
	alignementbien integer NOT NULL,
	fk_armemodel_armedepredilection integer,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.divinitedescription(
	description text NOT NULL,
	fk_model_id integer,
	clerge text NOT NULL)INHERITS(dd35.dataobject);
create table dd35.diviniteexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.objetmodel(
	name character varying(40) NOT NULL,
	poids decimal,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.objetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.objetexemplar(
	fk_model_id integer,
	solidite integer NOT NULL,
	taille integer NOT NULL)INHERITS(dd35.dataobject);
create table dd35.specialarmemodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.specialarmedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.specialarmeexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.listesortmodel(
	name character varying(40) NOT NULL,
	fk_classemodel_classe integer,
	niveau integer NOT NULL,
	fk_sortmodel_sort integer,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.listesortdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.listesortexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.sortmodel(
	name character varying(40) NOT NULL,
	ecole integer NOT NULL,
	branche integer,
	tempsincantation integer NOT NULL,
	portee integer NOT NULL,
	metresportee integer,
	cibles character varying(50) NOT NULL,
	effets character varying(50),
	effettype integer,
	zone character varying(50),
	zonetype integer,
	duree integer NOT NULL,
	dureeprecision character varying(50),
	testsauvegarde integer,
	rm bool NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.sortdescription(
	description text NOT NULL,
	fk_model_id integer,
	courtedescription text NOT NULL)INHERITS(dd35.dataobject);
create table dd35.sortexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.domainemodel(
	name character varying(40) NOT NULL,
	fk_pouvoirspecialmodel_pouvoir integer,
	fk_sortmodel_sorti integer,
	fk_sortmodel_sortii integer,
	fk_sortmodel_sortiii integer,
	fk_sortmodel_sortiv integer,
	fk_sortmodel_sortv integer,
	fk_sortmodel_sortvi integer,
	fk_sortmodel_sortvii integer,
	fk_sortmodel_sortviii integer,
	fk_sortmodel_sortix integer,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.domainedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.domaineexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.pouvoirspecialmodel(
	name character varying(40) NOT NULL,
	type integer NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.pouvoirspecialdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.pouvoirspecialexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.soustypecreaturemodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.soustypecreaturedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.soustypecreatureexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.pouvoirmonstrueuxmodel(
	name character varying(40) NOT NULL,
	type integer NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.pouvoirmonstrueuxdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.pouvoirmonstrueuxexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.organisationsociale(
	nombre integer NOT NULL,
	typegroupe character varying(15) NOT NULL,
	p_noncombatants integer NOT NULL)INHERITS(dd35.dataobject);
create table dd35.deplacement(
	distance integer NOT NULL,
	type integer NOT NULL)INHERITS(dd35.dataobject);
create table dd35.monstremodel(
	name character varying(40) NOT NULL,
	fk_typecreaturemodel_type integer,
	taille integer NOT NULL,
	dv integer NOT NULL,
	force integer NOT NULL,
	dexterite integer NOT NULL,
	constitution integer NOT NULL,
	intelligence integer NOT NULL,
	sagesse integer NOT NULL,
	charisme integer NOT NULL,
	armurenaturelle integer NOT NULL,
	rm integer NOT NULL,
	fp integer NOT NULL,
	alignementloi integer NOT NULL,
	alignementbien integer NOT NULL,
	frequencealignement integer NOT NULL,
	evolutionparniveaudeclasse bool NOT NULL,
	ajustementniveau integer NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.monstredescription(
	description text NOT NULL,
	fk_model_id integer,
	narrative text NOT NULL,
	combat text NOT NULL)INHERITS(dd35.dataobject);
create table dd35.monstreexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.archetypemodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.archetypedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.archetypeexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.environnementmodel(
	name character varying(40) NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.environnementdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.environnementexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.piegemodel(
	name character varying(40) NOT NULL,
	fp integer NOT NULL,
	type integer NOT NULL,
	declencheur integer NOT NULL,
	remise integer NOT NULL,
	ddfouille integer NOT NULL,
	dddesamorcage integer NOT NULL,
	prix integer NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.piegedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.piegeexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.enchantementobjetmodel(
	name character varying(40) NOT NULL,
	alteration integer NOT NULL,
	ecoleaura integer NOT NULL,
	puissanceaura integer NOT NULL,
	nls integer NOT NULL,
	unique(name))INHERITS(dd35.dataobject);
create table dd35.enchantementobjetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.enchantementobjetexemplar(
	fk_model_id integer)INHERITS(dd35.dataobject);
create table dd35.sortbaton(
	charge integer NOT NULL,
	fk_sortmodel_sort integer)INHERITS(dd35.dataobject);
create table dd35.racemodeltolanguemodel_languebase(
	fk_racemodel_join integer,
	fk_languemodel_join integer)INHERITS(dd35.dataobject);
create table dd35.racemodeltolanguemodel_languesupplmentaire(
	fk_racemodel_join integer,
	fk_languemodel_join integer)INHERITS(dd35.dataobject);
create table dd35.divinitemodeltodomainemodel_domaines(
	fk_divinitemodel_join integer,
	fk_domainemodel_join integer)INHERITS(dd35.dataobject);
create table dd35.registresfromsortmodel(
	fk_sortmodel_from integer,
	registres integer)INHERITS(dd35.dataobject);
create table dd35.composantesfromsortmodel(
	fk_sortmodel_from integer,
	composantes integer NOT NULL)INHERITS(dd35.dataobject);
create table dd35.soustypecreaturemodeltopouvoirmonstrueuxmodel_pouvoirs(
	fk_soustypecreaturemodel_join integer,
	fk_pouvoirmonstrueuxmodel_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltotypecreaturemodel_soustype(
	fk_monstremodel_join integer,
	fk_typecreaturemodel_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltodeplacement_deplacements(
	fk_monstremodel_join integer,
	fk_deplacement_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltoclasseexemplar_classes(
	fk_monstremodel_join integer,
	fk_classeexemplar_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltoarmenaturelleexemplar_attaquesnaturelles(
	fk_monstremodel_join integer,
	fk_armenaturelleexemplar_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltoarmeexemplar_armes(
	fk_monstremodel_join integer,
	fk_armeexemplar_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltoarmureexemplar_armures(
	fk_monstremodel_join integer,
	fk_armureexemplar_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltoattaquespecialemodel_attaquespeciales(
	fk_monstremodel_join integer,
	fk_attaquespecialemodel_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltoparticularitemodel_particularites(
	fk_monstremodel_join integer,
	fk_particularitemodel_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltocompetenceexemplar_competences(
	fk_monstremodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltodonexemplar_dons(
	fk_monstremodel_join integer,
	fk_donexemplar_join integer)INHERITS(dd35.dataobject);
create table dd35.monstremodeltoorganisationsociale_organisationsociale(
	fk_monstremodel_join integer,
	fk_organisationsociale_join integer)INHERITS(dd35.dataobject);
create table dd35.evolutionsfrommonstremodel(
	fk_monstremodel_from integer,
	evolutions integer)INHERITS(dd35.dataobject);
create table dd35.enchantementobjetmodeltosortmodel_sortscreation(
	fk_enchantementobjetmodel_join integer,
	fk_sortmodel_join integer)INHERITS(dd35.dataobject);
create table dd35.absarmemodeltospecialarmemodel_specialarme(
	fk_absarmemodel_join integer,
	fk_specialarmemodel_join integer)INHERITS(dd35.dataobject);
create table dd35.typecreaturemodeltopouvoirmonstrueuxmodel_pouvoirs(
	fk_typecreaturemodel_join integer,
	fk_pouvoirmonstrueuxmodel_join integer)INHERITS(dd35.dataobject);
create table dd35.objectmagiquemodeltosortmodel_sortscreation(
	fk_objectmagiquemodel_join integer,
	fk_sortmodel_join integer)INHERITS(dd35.dataobject);
create table dd35.batonmodeltosortbaton_sorts(
	fk_batonmodel_join integer,
	fk_sortbaton_join integer)INHERITS(dd35.dataobject);
create table dd35.absclassemodel(
	fk_competencemodel_competences integer,
	primary key(id))INHERITS(dd35.absdvmodel);
create table dd35.absclassedescription(
	primary key(id))INHERITS(dd35.absdvdescription);
create table dd35.absclasseexemplar(
	niveau integer NOT NULL,
	primary key(id))INHERITS(dd35.absdvexemplar);
create table dd35.absarmemodel(
	nbrddegats integer NOT NULL,
	tailleddegats integer NOT NULL,
	facteurcritique integer NOT NULL,
	zonecritique integer NOT NULL,
	allonge bool NOT NULL,
	degatsnonletaux bool NOT NULL,
	typedegat integer NOT NULL,
	typedegatcomplementaire integer,
	typedegatcplisalternative bool NOT NULL,
	primary key(id))INHERITS(dd35.objetmodel);
create table dd35.absarmedescription(
	primary key(id))INHERITS(dd35.objetdescription);
create table dd35.absarmeexemplar(
	primary key(id))INHERITS(dd35.objetexemplar);
create table dd35.armuremodel(
	bonusca integer NOT NULL,
	malustests integer NOT NULL,
	dexmax integer NOT NULL,
	echecsorts integer NOT NULL,
	prix integer NOT NULL,
	primary key(id))INHERITS(dd35.objetmodel);
create table dd35.armuredescription(
	primary key(id))INHERITS(dd35.objetdescription);
create table dd35.armureexemplar(
	primary key(id))INHERITS(dd35.objetexemplar);
create table dd35.materielmodel(
	categorie integer NOT NULL,
	prix decimal NOT NULL,
	primary key(id))INHERITS(dd35.objetmodel);
create table dd35.materieldescription(
	primary key(id))INHERITS(dd35.objetdescription);
create table dd35.materielexemplar(
	primary key(id))INHERITS(dd35.objetexemplar);
create table dd35.typecreaturemodel(
	alignementloi integer NOT NULL,
	alignementbien integer NOT NULL,
	frequencealignement integer NOT NULL,
	formationarmecourante bool NOT NULL,
	formationarmeguerre bool NOT NULL,
	formationarmure bool NOT NULL,
	mange bool NOT NULL,
	dors bool NOT NULL,
	respire bool NOT NULL,
	primary key(id))INHERITS(dd35.absdvmodel);
create table dd35.typecreaturedescription(
	primary key(id))INHERITS(dd35.absdvdescription);
create table dd35.typecreatureexemplar(
	primary key(id))INHERITS(dd35.absdvexemplar);
create table dd35.attaquespecialemodel(
	primary key(id))INHERITS(dd35.pouvoirmonstrueuxmodel);
create table dd35.attaquespecialedescription(
	primary key(id))INHERITS(dd35.pouvoirmonstrueuxdescription);
create table dd35.attaquespecialeexemplar(
	primary key(id))INHERITS(dd35.pouvoirmonstrueuxexemplar);
create table dd35.particularitemodel(
	primary key(id))INHERITS(dd35.pouvoirmonstrueuxmodel);
create table dd35.particularitedescription(
	primary key(id))INHERITS(dd35.pouvoirmonstrueuxdescription);
create table dd35.particulariteexemplar(
	primary key(id))INHERITS(dd35.pouvoirmonstrueuxexemplar);
create table dd35.objectmagiquemodel(
	usage integer NOT NULL,
	prix integer NOT NULL,
	ecoleaura integer NOT NULL,
	puissanceaura integer NOT NULL,
	nls integer NOT NULL,
	primary key(id))INHERITS(dd35.objetmodel);
create table dd35.objectmagiquedescription(
	primary key(id))INHERITS(dd35.objetdescription);
create table dd35.objectmagiqueexemplar(
	primary key(id))INHERITS(dd35.objetexemplar);
create table dd35.encharmemodel(
	armemelee bool NOT NULL,
	armedistance bool NOT NULL,
	primary key(id))INHERITS(dd35.enchantementobjetmodel);
create table dd35.encharmedescription(
	primary key(id))INHERITS(dd35.enchantementobjetdescription);
create table dd35.encharmeexemplar(
	primary key(id))INHERITS(dd35.enchantementobjetexemplar);
create table dd35.encharmuremodel(
	armure bool NOT NULL,
	bouclier bool NOT NULL,
	prix integer,
	primary key(id))INHERITS(dd35.enchantementobjetmodel);
create table dd35.encharmuredescription(
	primary key(id))INHERITS(dd35.enchantementobjetdescription);
create table dd35.encharmureexemplar(
	primary key(id))INHERITS(dd35.enchantementobjetexemplar);
create table dd35.classemodel(
	primary key(id))INHERITS(dd35.absclassemodel);
create table dd35.classedescription(
	primary key(id))INHERITS(dd35.absclassedescription);
create table dd35.classeexemplar(
	primary key(id))INHERITS(dd35.absclasseexemplar);
create table dd35.armemodel(
	typearme integer NOT NULL,
	maniement integer NOT NULL,
	armedouble bool NOT NULL,
	prix decimal NOT NULL,
	facteurportee integer,
	prixprojectiles decimal,
	poidsprojectiles decimal,
	primary key(id))INHERITS(dd35.absarmemodel);
create table dd35.armedescription(
	primary key(id))INHERITS(dd35.absarmedescription);
create table dd35.armeexemplar(
	primary key(id))INHERITS(dd35.absarmeexemplar);
create table dd35.armenaturellemodel(
	secondaire bool NOT NULL,
	primary key(id))INHERITS(dd35.absarmemodel);
create table dd35.armenaturelledescription(
	primary key(id))INHERITS(dd35.absarmedescription);
create table dd35.armenaturelleexemplar(
	primary key(id))INHERITS(dd35.absarmeexemplar);
create table dd35.classeprestigemodel(
	primary key(id))INHERITS(dd35.absclassemodel);
create table dd35.classeprestigedescription(
	primary key(id))INHERITS(dd35.absclassedescription);
create table dd35.classeprestigeexemplar(
	primary key(id))INHERITS(dd35.absclasseexemplar);
create table dd35.anneauxmodel(
	primary key(id))INHERITS(dd35.objectmagiquemodel);
create table dd35.anneauxdescription(
	primary key(id))INHERITS(dd35.objectmagiquedescription);
create table dd35.anneauxexemplar(
	primary key(id))INHERITS(dd35.objectmagiqueexemplar);
create table dd35.armemagiquemodel(
	fk_armemodel_arme integer,
	alteration integer NOT NULL,
	primary key(id))INHERITS(dd35.objectmagiquemodel);
create table dd35.armemagiquedescription(
	primary key(id))INHERITS(dd35.objectmagiquedescription);
create table dd35.armemagiqueexemplar(
	primary key(id))INHERITS(dd35.objectmagiqueexemplar);
create table dd35.armuremagiquemodel(
	fk_armuremodel_armure integer,
	alteration integer NOT NULL,
	primary key(id))INHERITS(dd35.objectmagiquemodel);
create table dd35.armuremagiquedescription(
	primary key(id))INHERITS(dd35.objectmagiquedescription);
create table dd35.armuremagiqueexemplar(
	primary key(id))INHERITS(dd35.objectmagiqueexemplar);
create table dd35.batonmodel(
	primary key(id))INHERITS(dd35.objectmagiquemodel);
create table dd35.batondescription(
	primary key(id))INHERITS(dd35.objectmagiquedescription);
create table dd35.batonexemplar(
	primary key(id))INHERITS(dd35.objectmagiqueexemplar);
create table dd35.objetmerveilleuxmodel(
	puissance integer NOT NULL,
	primary key(id))INHERITS(dd35.objectmagiquemodel);
create table dd35.objetmerveilleuxdescription(
	primary key(id))INHERITS(dd35.objectmagiquedescription);
create table dd35.objetmerveilleuxexemplar(
	primary key(id))INHERITS(dd35.objectmagiqueexemplar);
create table dd35.sceptremodel(
	primary key(id))INHERITS(dd35.objectmagiquemodel);
create table dd35.sceptredescription(
	primary key(id))INHERITS(dd35.objectmagiquedescription);
create table dd35.sceptreexemplar(
	primary key(id))INHERITS(dd35.objectmagiqueexemplar);
