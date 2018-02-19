CREATE SCHEMA pathfinder;
create table pathfinder.dataobject(
	id serial NOT NULL,
	primary key(id));
create table pathfinder.requismodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.requisdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.requisexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.racemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	force integer NOT NULL,
	dexterite integer NOT NULL,
	constitution integer NOT NULL,
	intelligence integer NOT NULL,
	sagesse integer NOT NULL,
	charisme integer NOT NULL,
	vd integer NOT NULL,
	fk_classemodel_classepredilection integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.racedescription(
	description text NOT NULL,
	fk_model_id integer,
	physique text NOT NULL,
	societe text NOT NULL,
	relations text NOT NULL,
	alignement text NOT NULL,
	aventuriers text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.raceexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.languemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	alphabet character varying(10) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.languedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.langueexemplar(
	fk_model_id integer,
	comprend bool NOT NULL,
	parle bool NOT NULL,
	lit bool NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.absdvmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	dvtype integer NOT NULL,
	facteurcompetence integer NOT NULL,
	bba integer NOT NULL,
	reflexes integer NOT NULL,
	vigueur integer NOT NULL,
	volonte integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.absdvdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.absdvexemplar(
	fk_model_id integer,
	niveau integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.tablesorts(
	niveauclasse integer NOT NULL,
	lvl1 integer NOT NULL,
	lvl2 integer NOT NULL,
	lvl3 integer NOT NULL,
	lvl4 integer NOT NULL,
	lvl5 integer NOT NULL,
	lvl6 integer NOT NULL,
	lvl7 integer NOT NULL,
	lvl8 integer NOT NULL,
	lvl9 integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.divinitemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	alignementloi integer NOT NULL,
	alignementbien integer NOT NULL,
	fk_armemodel_armedepredilection integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.divinitedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.diviniteexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.domainemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_pouvoirspecialmodel_pouvoir integer,
	fk_pouvoirspecialmodel_pouvoirlvl8 integer,
	fk_sortmodel_sorti integer,
	fk_sortmodel_sortii integer,
	fk_sortmodel_sortiii integer,
	fk_sortmodel_sortiv integer,
	fk_sortmodel_sortv integer,
	fk_sortmodel_sortvi integer,
	fk_sortmodel_sortvii integer,
	fk_sortmodel_sortviii integer,
	fk_sortmodel_sortix integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.domainedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.domaineexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.competencemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	caracteristique integer NOT NULL,
	sansformation bool NOT NULL,
	malusarmure bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.competencedescription(
	description text NOT NULL,
	fk_model_id integer,
	testcompetence text NOT NULL,
	action text NOT NULL,
	nouvellestentatives text NOT NULL,
	special text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.competenceexemplar(
	fk_model_id integer,
	fk_soustypemodel_specialite integer,
	rang integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.soustypemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_competencemodel_competence integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.soustypedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.soustypeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.donmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	typedon integer NOT NULL,
	fk_donmodel_donrequis integer,
	donmartial bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.dondescription(
	description text NOT NULL,
	fk_model_id integer,
	conditions text NOT NULL,
	avantage text NOT NULL,
	normal text NOT NULL,
	special text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.donexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirclassemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_pouvoirspecialmodel_pouvoir integer,
	niveau integer NOT NULL,
	fk_absclassemodel_classe integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirclassedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirclasseexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirspecialmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirspecialdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirspecialexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.objetmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	poids integer NOT NULL,
	prix integer NOT NULL,
	solidite integer NOT NULL,
	resistance integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.objetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.objetexemplar(
	fk_model_id integer,
	soliditecourante integer NOT NULL,
	taille integer NOT NULL,
	fk_matiere_matiere integer)INHERITS(pathfinder.dataobject);
create table pathfinder.specialarmemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.specialarmedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.specialarmeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.matiere(
	)INHERITS(pathfinder.dataobject);
create table pathfinder.listesortclassemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_absclassemodel_classe integer,
	niveau integer NOT NULL,
	fk_sortmodel_sort integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.listesortclassedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.listesortclasseexemplar(
	fk_model_id integer,
	maitrisedessorts bool NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.sortmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	ecole integer NOT NULL,
	branche integer NOT NULL,
	testsauvegarde integer,
	typetestsauvegarde integer NOT NULL,
	rm bool NOT NULL,
	compverbale bool NOT NULL,
	compgestuelle bool NOT NULL,
	compfocalisateurdivin bool NOT NULL,
	fk_composantematerielle_compmaterielle integer,
	fk_composantefocalisateur_compfocalisateur integer,
	tempsincantation integer NOT NULL,
	facteurtempsincantation integer NOT NULL,
	portee integer NOT NULL,
	facteurportee integer NOT NULL,
	cibles integer NOT NULL,
	facteurcible integer NOT NULL,
	facteurciblerparniveau bool NOT NULL,
	effettype integer,
	facteureffet integer NOT NULL,
	facteureffetparniveau bool NOT NULL,
	faconnable bool NOT NULL,
	descriptioncibles character varying(50) NOT NULL,
	descriptionzoneeffet character varying(50) NOT NULL,
	duree integer NOT NULL,
	facteurduree integer NOT NULL,
	terminaison bool NOT NULL,
	facteurparniveau bool NOT NULL,
	dureeprecision character varying(50),
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.sortdescription(
	description text NOT NULL,
	fk_model_id integer,
	descriptioncourte text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.sortexemplar(
	fk_model_id integer,
	pouvoirmagique bool NOT NULL,
	frequence integer NOT NULL,
	niveauempacement integer NOT NULL,
	fk_classemodel_classe integer,
	nombreutilisations integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.abscomposantesort(
	nom character varying(25) NOT NULL,
	cout integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.objetintelligent(
	intelligence integer NOT NULL,
	sagesse integer NOT NULL,
	charisme integer NOT NULL,
	ego integer NOT NULL,
	alignementloi integer NOT NULL,
	alignementbien integer NOT NULL,
	empathie bool NOT NULL,
	telepathie bool NOT NULL,
	parole bool NOT NULL,
	sens integer NOT NULL,
	visiodanslenoir bool NOT NULL,
	visionaveugle bool NOT NULL,
	lecturedeslangues bool NOT NULL,
	lecturedelamagie bool NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.sortbaton(
	fk_batonmodel_baton integer,
	charge integer NOT NULL,
	fk_sortmodel_sort integer)INHERITS(pathfinder.dataobject);
create table pathfinder.enchantementobjetmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	alteration integer NOT NULL,
	prix integer NOT NULL,
	ecoleaura integer NOT NULL,
	puissanceaura integer NOT NULL,
	nls integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.enchantementobjetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.enchantementobjetexemplar(
	fk_model_id integer,
	value character varying(15) NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.piegemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fp integer NOT NULL,
	type integer NOT NULL,
	declencheur integer NOT NULL,
	remise integer NOT NULL,
	desarmement integer NOT NULL,
	ddfouille integer NOT NULL,
	dddesamorcage integer NOT NULL,
	prix integer NOT NULL,
	duree integer NOT NULL,
	fosse bool NOT NULL,
	liquide bool NOT NULL,
	gaz bool NOT NULL,
	neratejamais bool NOT NULL,
	ciblesmultiples bool NOT NULL,
	retardement integer NOT NULL,
	pieux bool NOT NULL,
	fk_attaquepiege_attaque integer,
	fk_afflictionmodel_affliction integer,
	fk_sortexemplar_sort integer,
	nls integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.piegedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.piegeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.attaquepiege(
	adistance bool NOT NULL,
	attaque integer NOT NULL,
	nbrdes integer NOT NULL,
	typedes integer NOT NULL,
	zonecritique integer NOT NULL,
	facteurcritique integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.afflictionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	typeaffliction integer NOT NULL,
	blessure bool NOT NULL,
	contact bool NOT NULL,
	ingestion bool NOT NULL,
	inhalation bool NOT NULL,
	piege bool NOT NULL,
	sort bool NOT NULL,
	dd integer NOT NULL,
	jetsauvegarde integer NOT NULL,
	facteurfrequence integer NOT NULL,
	frequence integer NOT NULL,
	facteurincubation integer NOT NULL,
	incubation integer NOT NULL,
	facteurdureemax integer NOT NULL,
	dureemax integer NOT NULL,
	guerisonjsconsecutifs integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.afflictiondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.afflictionexemplar(
	fk_model_id integer,
	tour integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.etatmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.etatdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.etatexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.soustypecreaturemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.soustypecreaturedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.soustypecreatureexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.archetypemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	modfp integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.archetypedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.archetypeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.organisationsociale(
	nombremin integer NOT NULL,
	nombremax integer NOT NULL,
	nomgroupe character varying(15) NOT NULL,
	p_noncombatants integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.tresor(
	armes integer NOT NULL,
	objetsprecieux integer NOT NULL,
	objetsmagiques integer NOT NULL,
	argent integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.armenaturellemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	nombre integer NOT NULL,
	nbrddegats integer NOT NULL,
	tailleddegats integer NOT NULL,
	facteurcritique integer NOT NULL,
	zonecritique integer NOT NULL,
	typedegat integer NOT NULL,
	secondaire bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.armenaturelledescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armenaturelleexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.particularitemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.particularitedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.particulariteexemplar(
	fk_model_id integer,
	valeur character varying(15) NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_typecreaturemodel_type integer,
	taille integer NOT NULL,
	allonge integer NOT NULL,
	milieunaturel integer NOT NULL,
	climat integer NOT NULL,
	alignementloi integer NOT NULL,
	alignementbien integer NOT NULL,
	frequencealignement integer NOT NULL,
	fk_tresor_tresor integer,
	fp integer NOT NULL,
	dv integer NOT NULL,
	ajustementdeniveau integer NOT NULL,
	evolutionparniveaudeclasse bool NOT NULL,
	force integer NOT NULL,
	dexterite integer NOT NULL,
	constitution integer NOT NULL,
	intelligence integer NOT NULL,
	sagesse integer NOT NULL,
	charisme integer NOT NULL,
	armurenaturelle integer NOT NULL,
	rm integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.personnagedescription(
	description text NOT NULL,
	fk_model_id integer,
	narrative text NOT NULL,
	combat text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.personnageexemplar(
	fk_model_id integer,
	degats integer NOT NULL,
	degatsnonlethaux integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.parentemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_racemodel_race integer,
	chancesparentsenvie integer NOT NULL,
	chancespereenvie integer NOT NULL,
	chancesmereenvie integer NOT NULL,
	chancesorphelin integer NOT NULL,
	chancesenfantunique integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.parentedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.parenteexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.paysnatal(
	fk_parentemodel_parente integer,
	chances integer NOT NULL,
	resultat text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.fratrie(
	fk_parentemodel_parente integer,
	chances integer NOT NULL,
	resultat text NOT NULL,
	nbrdes integer NOT NULL,
	typedes integer NOT NULL,
	bonus integer NOT NULL,
	parentbiologique bool NOT NULL,
	fk_racemodel_race integer)INHERITS(pathfinder.dataobject);
create table pathfinder.absoddtablemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	chances integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.absoddtabledescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.absoddtableexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.resolutionconflitmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	modpcon integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.resolutionconflitdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.resolutionconflitexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.traitmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	fk_racemodel_race integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.traitdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.traitexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.donhistoiremodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.donhistoiredescription(
	description text NOT NULL,
	fk_model_id integer,
	conditionrequise text NOT NULL,
	avantage text NOT NULL,
	objectif text NOT NULL,
	avantagereussite text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.donhistoireexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.gestionnaireitrmmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	salaire integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.gestionnaireitrmdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.gestionnaireitrmexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.constructibleitrmmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	marchandisescreation integer NOT NULL,
	influencecreation integer NOT NULL,
	travailcreation integer NOT NULL,
	coutcreation integer NOT NULL,
	magiecreation integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.constructibleitrmdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.constructibleitrmexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.evenementhonorable(
	type integer NOT NULL,
	evenement character varying(255) NOT NULL,
	ptshonneur integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.evenementrenomee(
	evenement character varying(255) NOT NULL,
	ptsrenomee integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.ageracial(
	fk_racemodel_race integer,
	debutjeunesse integer NOT NULL,
	debutadulte integer NOT NULL,
	nbrdespeuple integer NOT NULL,
	typedespeuple integer NOT NULL,
	nbrdesadepte integer NOT NULL,
	typedesadepte integer NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.responsablepolitiquemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.responsablepolitiquedescription(
	description text NOT NULL,
	fk_model_id integer,
	avantage text NOT NULL,
	fonctioninoccupee text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.responsablepolitiqueexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.ameliorationterrainmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	superposable bool NOT NULL,
	prixpc integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.ameliorationterraindescription(
	description text NOT NULL,
	fk_model_id integer,
	terrain text NOT NULL,
	effet text NOT NULL,
	prix text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.ameliorationterrainexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.terrainroyaumemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	dureeexploration integer NOT NULL,
	dureepreparation integer NOT NULL,
	coutpreparation integer NOT NULL,
	coutferme integer NOT NULL,
	coutroute integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.terrainroyaumedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.terrainroyaumeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.batimentroyaumemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	nbrlots integer NOT NULL,
	coutpc integer NOT NULL,
	bonuseconomie integer NOT NULL,
	bonusloyaute integer NOT NULL,
	bonusstablite integer NOT NULL,
	bonuscorruption integer NOT NULL,
	bonuscriminalite integer NOT NULL,
	bonusloi integer NOT NULL,
	bonusfolklore integer NOT NULL,
	bonussociete integer NOT NULL,
	bonusproductivite integer NOT NULL,
	bonusgloire integer NOT NULL,
	bonusinfamie integer NOT NULL,
	bonusinsatisfaction integer NOT NULL,
	objmagfaible integer NOT NULL,
	objmagintermediaire integer NOT NULL,
	objmagpuissant integer NOT NULL,
	objmaganneau integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.batimentroyaumedescription(
	description text NOT NULL,
	fk_model_id integer,
	special text NOT NULL)INHERITS(pathfinder.dataobject);
create table pathfinder.batimentroyaumeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.formegouvernementmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.formegouvernementdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.formegouvernementexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.tactiquearmeemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.tactiquearmeedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.tactiquearmeeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armeeroyaumemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	taille integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.armeeroyaumedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armeeroyaumeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.ressourcearmeemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.ressourcearmeedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.ressourcearmeeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirarmeemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_pouvoirspecialmodel_pouvoirorigine integer,
	unique(name),
	unique(tag))INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirarmeedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.pouvoirarmeeexemplar(
	fk_model_id integer)INHERITS(pathfinder.dataobject);
create table pathfinder.racemodeltolanguemodel_languesbase(
	fk_racemodel_join integer,
	fk_languemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.racemodeltolanguemodel_languesupplementaire(
	fk_racemodel_join integer,
	fk_languemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.racemodeltopouvoirspecialmodel_pouvoirs(
	fk_racemodel_join integer,
	fk_pouvoirspecialmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.absdvmodeltocompetencemodel_competences(
	fk_absdvmodel_join integer,
	fk_competencemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.divinitemodeltodomainemodel_domaines(
	fk_divinitemodel_join integer,
	fk_domainemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.themesfromdivinitedescription(
	fk_divinitedescription_from integer,
	themes character varying(15))INHERITS(pathfinder.dataobject);
create table pathfinder.donmodeltodonmodel_autresdonsrequis(
	fk_donmodel_joinautresdonsrequis integer,
	fk_donmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.registresfromsortmodel(
	fk_sortmodel_from integer,
	registres integer)INHERITS(pathfinder.dataobject);
create table pathfinder.sortexemplartodonmodel_metamagie(
	fk_sortexemplar_join integer,
	fk_donmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.objetintelligenttolanguemodel_languesconnues(
	fk_objetintelligent_join integer,
	fk_languemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.enchantementobjetmodeltosortmodel_sortscreation(
	fk_enchantementobjetmodel_join integer,
	fk_sortmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.enchantementobjetmodeltorequisexemplar_requisport(
	fk_enchantementobjetmodel_join integer,
	fk_requisexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.enchantementobjetmodeltorequisexemplar_requiscreation(
	fk_enchantementobjetmodel_join integer,
	fk_requisexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.soustypecreaturemodeltopouvoirspecialexemplar_pouvoirs(
	fk_soustypecreaturemodel_join integer,
	fk_pouvoirspecialexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.archetypemodeltoparticulariteexemplar_particularites(
	fk_archetypemodel_join integer,
	fk_particulariteexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armenaturellemodeltoparticulariteattaqueexemplar_special(
	fk_armenaturellemodel_join integer,
	fk_particulariteattaqueexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltosoustypecreaturemodel_soustype(
	fk_personnagemodel_join integer,
	fk_soustypecreaturemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltoorganisationsociale_organisationsociale(
	fk_personnagemodel_join integer,
	fk_organisationsociale_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltolangueexemplar_langues(
	fk_personnagemodel_join integer,
	fk_langueexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.evolutionsfrompersonnagemodel(
	fk_personnagemodel_from integer,
	evolutions integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltoabsdvexemplar_classes(
	fk_personnagemodel_join integer,
	fk_absdvexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltoarmenaturelleexemplar_attaquesnaturelles(
	fk_personnagemodel_join integer,
	fk_armenaturelleexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltoparticulariteexemplar_particularites(
	fk_personnagemodel_join integer,
	fk_particulariteexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltocompetenceexemplar_competences(
	fk_personnagemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltodonexemplar_dons(
	fk_personnagemodel_join integer,
	fk_donexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltolistesortclasseexemplar_sortsconnus(
	fk_personnagemodel_join integer,
	fk_listesortclasseexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltosortexemplar_sorts(
	fk_personnagemodel_join integer,
	fk_sortexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltoarmeexemplar_armes(
	fk_personnagemodel_join integer,
	fk_armeexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltoarmureexemplar_armures(
	fk_personnagemodel_join integer,
	fk_armureexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltomaterielexemplar_equipement(
	fk_personnagemodel_join integer,
	fk_materielexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnagemodeltoobjectmagiqueexemplar_objetsmagiques(
	fk_personnagemodel_join integer,
	fk_objectmagiqueexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnageexemplartoafflictionexemplar_afflictions(
	fk_personnageexemplar_join integer,
	fk_afflictionexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnageexemplartoetatexemplar_etats(
	fk_personnageexemplar_join integer,
	fk_etatexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.personnageexemplartoarchetypemodel_archetypes(
	fk_personnageexemplar_join integer,
	fk_archetypemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.gestionnaireitrmmodeltocompetenceexemplar_competences(
	fk_gestionnaireitrmmodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.batimentroyaumemodeltobatimentroyaumemodel_reduction(
	fk_batimentroyaumemodel_joinreduction integer,
	fk_batimentroyaumemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armeeroyaumemodeltoressourcearmeemodel_ressources(
	fk_armeeroyaumemodel_join integer,
	fk_ressourcearmeemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armemodeltospecialarmeexemplar_specialarme(
	fk_armemodel_join integer,
	fk_specialarmeexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armeexemplartoenchantementarmeexemplar_enchantements(
	fk_armeexemplar_join integer,
	fk_enchantementarmeexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armeexemplartomunitionexemplar_munitions(
	fk_armeexemplar_join integer,
	fk_munitionexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.munitionexemplartoenchantementarmeexemplar_enchantements(
	fk_munitionexemplar_join integer,
	fk_enchantementarmeexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.armureexemplartoenchantementarmureexemplar_enchantements(
	fk_armureexemplar_join integer,
	fk_enchantementarmureexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.objectmagiquemodeltosortmodel_sortscreation(
	fk_objectmagiquemodel_join integer,
	fk_sortmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.objectmagiquemodeltorequisexemplar_requisport(
	fk_objectmagiquemodel_join integer,
	fk_requisexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.objectmagiquemodeltorequisexemplar_requiscreation(
	fk_objectmagiquemodel_join integer,
	fk_requisexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.typecreaturemodeltopouvoirspecialexemplar_pouvoirs(
	fk_typecreaturemodel_join integer,
	fk_pouvoirspecialexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.conflitexemplartoacteurconflitmodel_acteurs(
	fk_conflitexemplar_join integer,
	fk_acteurconflitmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.batimentitrmmodeltosallebatimentitrmexemplar_salles(
	fk_batimentitrmmodel_join integer,
	fk_sallebatimentitrmexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.organisationitrmmodeltoemployeitrmexemplar_employes(
	fk_organisationitrmmodel_join integer,
	fk_employeitrmexemplar_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.batimentroyaumemodelamelioreentobatimentroyaumemodelameliorede(
	fk_batimentroyaumemodel_joinamelioreenameliorede integer,
	fk_batimentroyaumemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.batimentroyaumemodelamelioredetobatimentroyaumemodelamelioreen(
	fk_batimentroyaumemodel_joinamelioredeamelioreen integer,
	fk_batimentroyaumemodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.sallebatimentitrmmodelameldetosallebatimentitrmmodelamelen(
	fk_sallebatimentitrmmodel_joinameldeamelen integer,
	fk_sallebatimentitrmmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.sallebatimentitrmmodelamelentosallebatimentitrmmodelamelde(
	fk_sallebatimentitrmmodel_joinamelenamelde integer,
	fk_sallebatimentitrmmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.employeitrmmodelameldetoemployeitrmmodelamelen(
	fk_employeitrmmodel_joinameldeamelen integer,
	fk_employeitrmmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.employeitrmmodelamelentoemployeitrmmodelamelde(
	fk_employeitrmmodel_joinamelenamelde integer,
	fk_employeitrmmodel_join integer)INHERITS(pathfinder.dataobject);
create table pathfinder.absclassemodel(
	armescourantes bool NOT NULL,
	armesguerre bool NOT NULL,
	armureslegeres bool NOT NULL,
	armuresintermediaires bool NOT NULL,
	armureslourdes bool NOT NULL,
	primary key(id))INHERITS(pathfinder.absdvmodel);
create table pathfinder.absclassedescription(
	role text NOT NULL,
	primary key(id))INHERITS(pathfinder.absdvdescription);
create table pathfinder.absclasseexemplar(
	primary key(id))INHERITS(pathfinder.absdvexemplar);
create table pathfinder.sortsconnus(
	fk_absclassemodel_classe integer,
	primary key(id))INHERITS(pathfinder.tablesorts);
create table pathfinder.sortsquotidiens(
	fk_absclassemodel_classe integer,
	primary key(id))INHERITS(pathfinder.tablesorts);
create table pathfinder.pouvoirspecialclassemodel(
	niveaumin integer NOT NULL,
	primary key(id))INHERITS(pathfinder.pouvoirspecialmodel);
create table pathfinder.pouvoirspecialclassedescription(
	primary key(id))INHERITS(pathfinder.pouvoirspecialdescription);
create table pathfinder.pouvoirspecialclasseexemplar(
	primary key(id))INHERITS(pathfinder.pouvoirspecialexemplar);
create table pathfinder.lignageensorceleurmodel(
	fk_competencemodel_competence integer,
	fk_pouvoirspecialmodel_arcane integer,
	fk_pouvoirspecialmodel_pouvoirlvl1 integer,
	fk_pouvoirspecialmodel_pouvoirlvl3 integer,
	fk_pouvoirspecialmodel_pouvoirlvl9 integer,
	fk_pouvoirspecialmodel_pouvoirlvl15 integer,
	fk_pouvoirspecialmodel_pouvoirlvl20 integer,
	fk_sortmodel_sortlvl3 integer,
	fk_sortmodel_sortlvl5 integer,
	fk_sortmodel_sortlvl7 integer,
	fk_sortmodel_sortlvl9 integer,
	fk_sortmodel_sortlvl11 integer,
	fk_sortmodel_sortlvl13 integer,
	fk_sortmodel_sortlvl15 integer,
	fk_sortmodel_sortlvl17 integer,
	fk_sortmodel_sortlvl19 integer,
	fk_donexemplar_dons integer,
	primary key(id))INHERITS(pathfinder.pouvoirspecialmodel);
create table pathfinder.lignageensorceleurdescription(
	primary key(id))INHERITS(pathfinder.pouvoirspecialdescription);
create table pathfinder.lignageensorceleurexemplar(
	primary key(id))INHERITS(pathfinder.pouvoirspecialexemplar);
create table pathfinder.ecolemagemodel(
	fk_pouvoirspecialmodel_capacite1 integer,
	fk_pouvoirspecialmodel_capacite2 integer,
	fk_pouvoirspecialmodel_capacitelvl8 integer,
	primary key(id))INHERITS(pathfinder.pouvoirspecialmodel);
create table pathfinder.ecolemagedescription(
	primary key(id))INHERITS(pathfinder.pouvoirspecialdescription);
create table pathfinder.ecolemageexemplar(
	primary key(id))INHERITS(pathfinder.pouvoirspecialexemplar);
create table pathfinder.armemodel(
	typearme integer NOT NULL,
	maniement integer NOT NULL,
	nbrddegats integer NOT NULL,
	tailleddegats integer NOT NULL,
	facteurcritique integer NOT NULL,
	zonecritique integer NOT NULL,
	typedegat integer NOT NULL,
	typedegatcomplementaire integer,
	typedegatcplisalternative bool NOT NULL,
	fk_armemodel_secondetete integer,
	facteurportee integer,
	fk_munitionmodel_munition integer,
	primary key(id))INHERITS(pathfinder.objetmodel);
create table pathfinder.armedescription(
	primary key(id))INHERITS(pathfinder.objetdescription);
create table pathfinder.armeexemplar(
	armedemaitre bool NOT NULL,
	alteration integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objetexemplar);
create table pathfinder.munitionmodel(
	quantite integer NOT NULL,
	fk_armemodel_arme integer,
	primary key(id))INHERITS(pathfinder.objetmodel);
create table pathfinder.munitiondescription(
	primary key(id))INHERITS(pathfinder.objetdescription);
create table pathfinder.munitionexemplar(
	alteration integer NOT NULL,
	stock integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objetexemplar);
create table pathfinder.armuremodel(
	bonusca integer NOT NULL,
	malustests integer NOT NULL,
	dexmax integer NOT NULL,
	echecsorts integer NOT NULL,
	categorie integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objetmodel);
create table pathfinder.armuredescription(
	primary key(id))INHERITS(pathfinder.objetdescription);
create table pathfinder.armureexemplar(
	armuredemaitre bool NOT NULL,
	alteration integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objetexemplar);
create table pathfinder.materielmodel(
	categorie integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objetmodel);
create table pathfinder.materieldescription(
	primary key(id))INHERITS(pathfinder.objetdescription);
create table pathfinder.materielexemplar(
	primary key(id))INHERITS(pathfinder.objetexemplar);
create table pathfinder.armedesiegemodel(
	nbrdesdgts integer NOT NULL,
	typedesdgts integer NOT NULL,
	zonecritique integer NOT NULL,
	facteurportee integer NOT NULL,
	porteemin integer NOT NULL,
	serviteurs integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objetmodel);
create table pathfinder.armedesiegedescription(
	primary key(id))INHERITS(pathfinder.objetdescription);
create table pathfinder.armedesiegeexemplar(
	primary key(id))INHERITS(pathfinder.objetexemplar);
create table pathfinder.composantematerielle(
	fk_sortmodel_sort integer,
	primary key(id))INHERITS(pathfinder.abscomposantesort);
create table pathfinder.composantefocalisateur(
	fk_sortmodel_sort integer,
	primary key(id))INHERITS(pathfinder.abscomposantesort);
create table pathfinder.objectmagiquemodel(
	usage integer NOT NULL,
	ecoleaura integer NOT NULL,
	puissanceaura integer NOT NULL,
	nls integer NOT NULL,
	typeobjetmagique integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objetmodel);
create table pathfinder.objectmagiquedescription(
	primary key(id))INHERITS(pathfinder.objetdescription);
create table pathfinder.objectmagiqueexemplar(
	fk_objetintelligent_intelligence integer,
	primary key(id))INHERITS(pathfinder.objetexemplar);
create table pathfinder.enchantementarmemodel(
	armemelee bool NOT NULL,
	armedistance bool NOT NULL,
	primary key(id))INHERITS(pathfinder.enchantementobjetmodel);
create table pathfinder.enchantementarmedescription(
	primary key(id))INHERITS(pathfinder.enchantementobjetdescription);
create table pathfinder.enchantementarmeexemplar(
	primary key(id))INHERITS(pathfinder.enchantementobjetexemplar);
create table pathfinder.enchantementarmuremodel(
	armure bool NOT NULL,
	bouclier bool NOT NULL,
	primary key(id))INHERITS(pathfinder.enchantementobjetmodel);
create table pathfinder.enchantementarmuredescription(
	primary key(id))INHERITS(pathfinder.enchantementobjetdescription);
create table pathfinder.enchantementarmureexemplar(
	primary key(id))INHERITS(pathfinder.enchantementobjetexemplar);
create table pathfinder.typecreaturemodel(
	alignementloi integer NOT NULL,
	alignementbien integer NOT NULL,
	frequencealignement integer NOT NULL,
	formationarmecourante bool NOT NULL,
	formationarmeguerre bool NOT NULL,
	formationarmure bool NOT NULL,
	mange bool NOT NULL,
	dors bool NOT NULL,
	respire bool NOT NULL,
	primary key(id))INHERITS(pathfinder.absdvmodel);
create table pathfinder.typecreaturedescription(
	primary key(id))INHERITS(pathfinder.absdvdescription);
create table pathfinder.typecreatureexemplar(
	primary key(id))INHERITS(pathfinder.absdvexemplar);
create table pathfinder.particulariteattaquemodel(
	primary key(id))INHERITS(pathfinder.particularitemodel);
create table pathfinder.particulariteattaquedescription(
	primary key(id))INHERITS(pathfinder.particularitedescription);
create table pathfinder.particulariteattaqueexemplar(
	primary key(id))INHERITS(pathfinder.particulariteexemplar);
create table pathfinder.pjmodel(
	fk_joueur_id integer,
	primary key(id))INHERITS(pathfinder.personnagemodel);
create table pathfinder.pjdescription(
	primary key(id))INHERITS(pathfinder.personnagedescription);
create table pathfinder.pjexemplar(
	primary key(id))INHERITS(pathfinder.personnageexemplar);
create table pathfinder.pnjmodel(
	primary key(id))INHERITS(pathfinder.personnagemodel);
create table pathfinder.pnjdescription(
	primary key(id))INHERITS(pathfinder.personnagedescription);
create table pathfinder.pnjexemplar(
	primary key(id))INHERITS(pathfinder.personnageexemplar);
create table pathfinder.monstremodel(
	primary key(id))INHERITS(pathfinder.personnagemodel);
create table pathfinder.monstredescription(
	primary key(id))INHERITS(pathfinder.personnagedescription);
create table pathfinder.monstreexemplar(
	primary key(id))INHERITS(pathfinder.personnageexemplar);
create table pathfinder.foyerinhabituelmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.foyerinhabitueldescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.foyerinhabituelexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.circonstancesnaissancemodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.circonstancesnaissancedescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.circonstancesnaissanceexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.professionparentsmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.professionparentsdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.professionparentsexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.raceparentsadoptifsmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.raceparentsadoptifsdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.raceparentsadoptifsexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.noblessemodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.noblessedescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.noblesseexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.evenementenfancemodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.evenementenfancedescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.evenementenfanceexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.historiqueclassemodel(
	fk_classemodel_classe integer,
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.historiqueclassedescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.historiqueclasseexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.associeinfluentmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.associeinfluentdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.associeinfluentexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.conflitmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.conflitdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.conflitexemplar(
	fk_origineconflitmodel_origine integer,
	fk_resolutionconflitmodel_resolution integer,
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.acteurconflitmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.acteurconflitdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.acteurconflitexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.origineconflitmodel(
	pcon integer NOT NULL,
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.origineconflitdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.origineconflitexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.relationamoureusemodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.relationamoureusedescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.relationamoureuseexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.relationaveccompagnonsmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.relationaveccompagnonsdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.relationaveccompagnonsexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.handicapmodel(
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.handicapdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.handicapexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.lucratifitrmmodel(
	recettes integer NOT NULL,
	recettesor bool NOT NULL,
	recettesmarchandises bool NOT NULL,
	recettesinfluence bool NOT NULL,
	recettestravail bool NOT NULL,
	recettesmagie bool NOT NULL,
	duree integer NOT NULL,
	taillemin integer NOT NULL,
	taillemax integer NOT NULL,
	primary key(id))INHERITS(pathfinder.constructibleitrmmodel);
create table pathfinder.lucratifitrmdescription(
	avantage text NOT NULL,
	primary key(id))INHERITS(pathfinder.constructibleitrmdescription);
create table pathfinder.lucratifitrmexemplar(
	primary key(id))INHERITS(pathfinder.constructibleitrmexemplar);
create table pathfinder.batimentitrmmodel(
	primary key(id))INHERITS(pathfinder.constructibleitrmmodel);
create table pathfinder.batimentitrmdescription(
	primary key(id))INHERITS(pathfinder.constructibleitrmdescription);
create table pathfinder.batimentitrmexemplar(
	primary key(id))INHERITS(pathfinder.constructibleitrmexemplar);
create table pathfinder.organisationitrmmodel(
	primary key(id))INHERITS(pathfinder.constructibleitrmmodel);
create table pathfinder.organisationitrmdescription(
	primary key(id))INHERITS(pathfinder.constructibleitrmdescription);
create table pathfinder.organisationitrmexemplar(
	primary key(id))INHERITS(pathfinder.constructibleitrmexemplar);
create table pathfinder.evenementbatimentitrmmodel(
	fk_batimentitrmmodel_batiment integer,
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.evenementbatimentitrmdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.evenementbatimentitrmexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.evenementorganisationitrmmodel(
	fk_organisationitrmmodel_organisation integer,
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.evenementorganisationitrmdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.evenementorganisationitrmexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.evenementmodel(
	continu bool NOT NULL,
	royaume bool NOT NULL,
	communaute bool NOT NULL,
	nefaste bool NOT NULL,
	primary key(id))INHERITS(pathfinder.absoddtablemodel);
create table pathfinder.evenementdescription(
	primary key(id))INHERITS(pathfinder.absoddtabledescription);
create table pathfinder.evenementexemplar(
	primary key(id))INHERITS(pathfinder.absoddtableexemplar);
create table pathfinder.classemodel(
	classepnj bool NOT NULL,
	primary key(id))INHERITS(pathfinder.absclassemodel);
create table pathfinder.classedescription(
	primary key(id))INHERITS(pathfinder.absclassedescription);
create table pathfinder.classeexemplar(
	primary key(id))INHERITS(pathfinder.absclasseexemplar);
create table pathfinder.classeprestigemodel(
	primary key(id))INHERITS(pathfinder.absclassemodel);
create table pathfinder.classeprestigedescription(
	primary key(id))INHERITS(pathfinder.absclassedescription);
create table pathfinder.classeprestigeexemplar(
	primary key(id))INHERITS(pathfinder.absclasseexemplar);
create table pathfinder.pouvoirragemodel(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassemodel);
create table pathfinder.pouvoirragedescription(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassedescription);
create table pathfinder.pouvoirrageexemplar(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclasseexemplar);
create table pathfinder.representationbardiquemodel(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassemodel);
create table pathfinder.representationbardiquedescription(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassedescription);
create table pathfinder.representationbardiqueexemplar(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclasseexemplar);
create table pathfinder.gracepaladinmodel(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassemodel);
create table pathfinder.gracepaladindescription(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassedescription);
create table pathfinder.gracepaladinexemplar(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclasseexemplar);
create table pathfinder.talentsroublardmodel(
	maitreroublard bool NOT NULL,
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassemodel);
create table pathfinder.talentsroublarddescription(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclassedescription);
create table pathfinder.talentsroublardexemplar(
	primary key(id))INHERITS(pathfinder.pouvoirspecialclasseexemplar);
create table pathfinder.anneauxmodel(
	primary key(id))INHERITS(pathfinder.objectmagiquemodel);
create table pathfinder.anneauxdescription(
	primary key(id))INHERITS(pathfinder.objectmagiquedescription);
create table pathfinder.anneauxexemplar(
	primary key(id))INHERITS(pathfinder.objectmagiqueexemplar);
create table pathfinder.armemagiquemodel(
	fk_armeexemplar_arme integer,
	primary key(id))INHERITS(pathfinder.objectmagiquemodel);
create table pathfinder.armemagiquedescription(
	primary key(id))INHERITS(pathfinder.objectmagiquedescription);
create table pathfinder.armemagiqueexemplar(
	primary key(id))INHERITS(pathfinder.objectmagiqueexemplar);
create table pathfinder.armuremagiquemodel(
	fk_armureexemplar_armure integer,
	primary key(id))INHERITS(pathfinder.objectmagiquemodel);
create table pathfinder.armuremagiquedescription(
	primary key(id))INHERITS(pathfinder.objectmagiquedescription);
create table pathfinder.armuremagiqueexemplar(
	primary key(id))INHERITS(pathfinder.objectmagiqueexemplar);
create table pathfinder.batonmodel(
	primary key(id))INHERITS(pathfinder.objectmagiquemodel);
create table pathfinder.batondescription(
	primary key(id))INHERITS(pathfinder.objectmagiquedescription);
create table pathfinder.batonexemplar(
	chargesrestantes integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objectmagiqueexemplar);
create table pathfinder.objetmerveilleuxmodel(
	emplacement integer NOT NULL,
	primary key(id))INHERITS(pathfinder.objectmagiquemodel);
create table pathfinder.objetmerveilleuxdescription(
	primary key(id))INHERITS(pathfinder.objectmagiquedescription);
create table pathfinder.objetmerveilleuxexemplar(
	primary key(id))INHERITS(pathfinder.objectmagiqueexemplar);
create table pathfinder.sceptremodel(
	primary key(id))INHERITS(pathfinder.objectmagiquemodel);
create table pathfinder.sceptredescription(
	primary key(id))INHERITS(pathfinder.objectmagiquedescription);
create table pathfinder.sceptreexemplar(
	primary key(id))INHERITS(pathfinder.objectmagiqueexemplar);
create table pathfinder.sallebatimentitrmmodel(
	extension bool NOT NULL,
	primary key(id))INHERITS(pathfinder.lucratifitrmmodel);
create table pathfinder.sallebatimentitrmdescription(
	primary key(id))INHERITS(pathfinder.lucratifitrmdescription);
create table pathfinder.sallebatimentitrmexemplar(
	nbr integer NOT NULL,
	primary key(id))INHERITS(pathfinder.lucratifitrmexemplar);
create table pathfinder.employeitrmmodel(
	primary key(id))INHERITS(pathfinder.lucratifitrmmodel);
create table pathfinder.employeitrmdescription(
	primary key(id))INHERITS(pathfinder.lucratifitrmdescription);
create table pathfinder.employeitrmexemplar(
	primary key(id))INHERITS(pathfinder.lucratifitrmexemplar);
