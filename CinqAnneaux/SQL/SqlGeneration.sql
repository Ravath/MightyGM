CREATE SCHEMA cinqanneaux;
create table cinqanneaux.dataobject(
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.clanmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	typeclan integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.clandescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.clanexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.famillemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	bonusinitial integer NOT NULL,
	fk_clanmodel_clan integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.familledescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.familleexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecolemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_clanmodel_clan integer,
	motclef integer NOT NULL,
	bonusinitial integer NOT NULL,
	honneur decimal NOT NULL,
	argentinitial decimal NOT NULL,
	affinite integer,
	deficience integer,
	nbrsortterre integer,
	nbrsortfeu integer,
	nbrsorteau integer,
	nbrsortair integer,
	nbrsortvide integer,
	devotion integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoledescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleexemplar(
	fk_model_id integer,
	rang integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.techniquemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_ecolemodel_ecole integer,
	rang integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.techniquedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.techniqueexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competencemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	groupe integer NOT NULL,
	traitassocie integer NOT NULL,
	traitalternatif integer,
	degradante bool NOT NULL,
	sociale bool NOT NULL,
	martiale bool NOT NULL,
	fk_competenceglobalemodel_global integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competencedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceexemplar(
	fk_model_id integer,
	rang integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialisation(
	nom character varying(30) NOT NULL,
	fk_competencemodel_competence integer,
	degradante bool NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.maitrisemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_competencemodel_competence integer,
	rangrequis integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.maitrisedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.maitriseexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceglobalemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	groupe integer NOT NULL,
	traitassocie integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceglobaledescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceglobaleexemplar(
	fk_model_id integer,
	rang integer NOT NULL,
	fk_soustypeglobal_specialisation integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.soustypeglobal(
	tag character varying(7) NOT NULL,
	nom character varying(30) NOT NULL,
	traitassocie integer NOT NULL,
	degradante bool NOT NULL,
	noble bool NOT NULL,
	fk_competenceglobalemodel_competence integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absavantagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	soustype integer NOT NULL,
	cout integer NOT NULL,
	rangmax integer NOT NULL,
	fk_groupeavantagemodel_groupe integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absavantagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absavantageexemplar(
	fk_model_id integer,
	nbrrangs integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.groupeavantagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.groupeavantagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.groupeavantageexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.abssortmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	element integer NOT NULL,
	maitrise integer NOT NULL,
	portee integer NOT NULL,
	zoneeffet integer NOT NULL,
	duree integer NOT NULL,
	facteurportee decimal NOT NULL,
	facteurzone decimal NOT NULL,
	facteurduree decimal NOT NULL,
	porteexrang bool NOT NULL,
	zonexrang bool NOT NULL,
	dureexrang bool NOT NULL,
	concentration bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.abssortdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.abssortexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.augmentationsort(
	type integer NOT NULL,
	facteur decimal NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absobjetmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	monnaie integer NOT NULL,
	cout integer NOT NULL,
	fk_specialobjet_special integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absobjetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absobjetexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialobjet(
	name character varying(30) NOT NULL,
	description text NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ancetremodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_clanmodel_clan integer,
	cout integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ancetredescription(
	description text NOT NULL,
	fk_model_id integer,
	exigences text NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ancetreexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleavanceemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_clanmodel_clan integer,
	motclef integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleavanceedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleavanceeexemplar(
	fk_model_id integer,
	rang integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.techniqueavanceemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_ecoleavanceemodel_ecole integer,
	rang integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.techniqueavanceedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.techniqueavanceeexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	nomtechnique character varying(30) NOT NULL,
	rang integer NOT NULL,
	motclef integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativedescription(
	description text NOT NULL,
	fk_model_id integer,
	technique text NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativeexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.conditionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.conditiondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.conditionexemplar(
	fk_model_id integer,
	valeurs character varying(25) NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.katamodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	anneau integer NOT NULL,
	maitrise integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.katadescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.kataexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.kihomodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	anneau integer NOT NULL,
	maitrise integer NOT NULL,
	useatemi bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.kihodescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.kihoexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoiroutremondemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	typepouvoir integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoiroutremondedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoiroutremondeexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.intriguemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.intriguedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.intrigueexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.opportuniteheroiquemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	action text NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.opportuniteheroiquedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.opportuniteheroiqueexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	reflexes integer NOT NULL,
	intuition integer NOT NULL,
	agilite integer NOT NULL,
	intelligence integer NOT NULL,
	perception integer NOT NULL,
	force integer NOT NULL,
	volonte integer NOT NULL,
	constitution integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnageexemplar(
	fk_model_id integer,
	degatssubis integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoircreaturemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoircreaturedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoircreatureexemplar(
	fk_model_id integer,
	complement character varying(30) NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.attaquecreature(
	name character varying(20) NOT NULL,
	xgdegats integer NOT NULL,
	gxdegats integer NOT NULL,
	xgtoucher integer NOT NULL,
	gxtoucher integer NOT NULL,
	action integer NOT NULL,
	fk_creaturemodel_creature integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecolemodeltocompetenceexemplar_competences(
	fk_ecolemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecolemodeltoabsobjetmodel_equipement(
	fk_ecolemodel_join integer,
	fk_absobjetmodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceexemplartospecialisation_specialisationschoisies(
	fk_competenceexemplar_join integer,
	fk_specialisation_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.abssortmodeltoaugmentationsort_augmentations(
	fk_abssortmodel_join integer,
	fk_augmentationsort_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.motclefsfromabssortmodel(
	fk_abssortmodel_from integer,
	motclefs integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleavanceemodeltocompetenceexemplar_competencesrequises(
	fk_ecoleavanceemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleavanceemodeltoconditionexemplar_conditions(
	fk_ecoleavanceemodel_join integer,
	fk_conditionexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativemodeltocompetenceexemplar_competencesrequises(
	fk_voiealternativemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativemodeltoconditionexemplar_conditions(
	fk_voiealternativemodel_join integer,
	fk_conditionexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.katamodeltoecolemodel_ecoles(
	fk_katamodel_join integer,
	fk_ecolemodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.acteursfromintriguemodel(
	fk_intriguemodel_from integer,
	acteurs character varying(60) NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltocompetenceexemplar_competences(
	fk_personnagemodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltocompetenceglobaleexemplar_competencesglobales(
	fk_personnagemodel_join integer,
	fk_competenceglobaleexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.creaturemodeltopouvoircreatureexemplar_pouvoirs(
	fk_creaturemodel_join integer,
	fk_pouvoircreatureexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltocompetenceexemplar_armes(
	fk_pjmodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltoobjetexemplar_inventaire(
	fk_pjmodel_join integer,
	fk_objetexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltoecoleexemplar_ecoles(
	fk_pjmodel_join integer,
	fk_ecoleexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltoavantageexemplar_avantages(
	fk_pjmodel_join integer,
	fk_avantageexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltodesavantageexemplar_desavantages(
	fk_pjmodel_join integer,
	fk_desavantageexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltosortmodel_sorts(
	fk_pjmodel_join integer,
	fk_sortmodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltomahoumodel_mahou(
	fk_pjmodel_join integer,
	fk_mahoumodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltoecoleavanceeexemplar_ecolesavancees(
	fk_pjmodel_join integer,
	fk_ecoleavanceeexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltovoiealternativeexemplar_voiealternatives(
	fk_pjmodel_join integer,
	fk_voiealternativeexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltokataexemplar_katas(
	fk_pjmodel_join integer,
	fk_kataexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pjmodeltokihoexemplar_kihos(
	fk_pjmodel_join integer,
	fk_kihoexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.avantagemodel(
	primary key(id))INHERITS(cinqanneaux.absavantagemodel);
create table cinqanneaux.avantagedescription(
	primary key(id))INHERITS(cinqanneaux.absavantagedescription);
create table cinqanneaux.avantageexemplar(
	primary key(id))INHERITS(cinqanneaux.absavantageexemplar);
create table cinqanneaux.desavantagemodel(
	primary key(id))INHERITS(cinqanneaux.absavantagemodel);
create table cinqanneaux.desavantagedescription(
	primary key(id))INHERITS(cinqanneaux.absavantagedescription);
create table cinqanneaux.desavantageexemplar(
	primary key(id))INHERITS(cinqanneaux.absavantageexemplar);
create table cinqanneaux.sortmodel(
	primary key(id))INHERITS(cinqanneaux.abssortmodel);
create table cinqanneaux.sortdescription(
	primary key(id))INHERITS(cinqanneaux.abssortdescription);
create table cinqanneaux.sortexemplar(
	primary key(id))INHERITS(cinqanneaux.abssortexemplar);
create table cinqanneaux.mahoumodel(
	primary key(id))INHERITS(cinqanneaux.abssortmodel);
create table cinqanneaux.mahoudescription(
	primary key(id))INHERITS(cinqanneaux.abssortdescription);
create table cinqanneaux.mahouexemplar(
	primary key(id))INHERITS(cinqanneaux.abssortexemplar);
create table cinqanneaux.objetmodel(
	coutmax integer,
	vetement bool NOT NULL,
	necessairevoyage bool NOT NULL,
	primary key(id))INHERITS(cinqanneaux.absobjetmodel);
create table cinqanneaux.objetdescription(
	primary key(id))INHERITS(cinqanneaux.absobjetdescription);
create table cinqanneaux.objetexemplar(
	primary key(id))INHERITS(cinqanneaux.absobjetexemplar);
create table cinqanneaux.armemodel(
	type integer NOT NULL,
	rollvd integer NOT NULL,
	keepvd integer NOT NULL,
	taille integer NOT NULL,
	paysan bool NOT NULL,
	samurai bool NOT NULL,
	doublendarmure bool NOT NULL,
	force integer,
	forcerequise integer NOT NULL,
	portee decimal,
	armedejet bool NOT NULL,
	primary key(id))INHERITS(cinqanneaux.absobjetmodel);
create table cinqanneaux.armedescription(
	primary key(id))INHERITS(cinqanneaux.absobjetdescription);
create table cinqanneaux.armeexemplar(
	primary key(id))INHERITS(cinqanneaux.absobjetexemplar);
create table cinqanneaux.armuremodel(
	bonusnd integer NOT NULL,
	reduction integer NOT NULL,
	primary key(id))INHERITS(cinqanneaux.absobjetmodel);
create table cinqanneaux.armuredescription(
	primary key(id))INHERITS(cinqanneaux.absobjetdescription);
create table cinqanneaux.armureexemplar(
	primary key(id))INHERITS(cinqanneaux.absobjetexemplar);
create table cinqanneaux.creaturemodel(
	vide integer,
	souillure integer,
	ndarmure integer NOT NULL,
	reduction integer NOT NULL,
	xginitiative integer NOT NULL,
	gxinitiative integer NOT NULL,
	bless5 integer NOT NULL,
	bless10 integer NOT NULL,
	bless15 integer NOT NULL,
	viemax integer NOT NULL,
	viehumaine bool NOT NULL,
	typecreature integer NOT NULL,
	primary key(id))INHERITS(cinqanneaux.personnagemodel);
create table cinqanneaux.creaturedescription(
	primary key(id))INHERITS(cinqanneaux.personnagedescription);
create table cinqanneaux.creatureexemplar(
	primary key(id))INHERITS(cinqanneaux.personnageexemplar);
create table cinqanneaux.pjmodel(
	fk_joueur_id integer,
	vide integer NOT NULL,
	fk_competenceexemplar_armure integer,
	fk_ancetremodel_ancetre integer,
	fk_clanmodel_clan integer,
	fk_famillemodel_famille integer,
	primary key(id))INHERITS(cinqanneaux.personnagemodel);
create table cinqanneaux.pjdescription(
	primary key(id))INHERITS(cinqanneaux.personnagedescription);
create table cinqanneaux.pjexemplar(
	depensevide integer NOT NULL,
	status decimal NOT NULL,
	honneur decimal NOT NULL,
	gloire decimal NOT NULL,
	primary key(id))INHERITS(cinqanneaux.personnageexemplar);
