DROP SCHEMA IF EXISTS cinqanneaux CASCADE;
CREATE SCHEMA cinqanneaux;
create table cinqanneaux.dataobject(
	id serial NOT NULL,
	primary key(id));
create table cinqanneaux.competencestatus(
	fk_competencemodel_competence integer,
	rang integer NOT NULL,
	fk_specialisationmodel_specialite integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.infotable(
	rang integer NOT NULL,
	value decimal NOT NULL,
	description text NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.honneurinfo(
	seuil1 integer NOT NULL,
	seuil2 integer NOT NULL,
	seuil3 integer NOT NULL,
	seuil4 integer NOT NULL,
	seuil5 integer NOT NULL,
	seuil6 integer NOT NULL,
	description text NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.gaingloire(
	nom character varying(30) NOT NULL,
	description text NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.seuilblessure(
	fk_figurantmodel_figurant integer,
	seuil integer NOT NULL,
	malus integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.attaquefigurant(
	name character varying(20) NOT NULL,
	degats_r integer NOT NULL,
	degats_k integer NOT NULL,
	toucher_r integer NOT NULL,
	toucher_k integer NOT NULL,
	action integer NOT NULL,
	fk_figurantmodel_figurant integer)INHERITS(cinqanneaux.dataobject);
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
	familledisparue bool NOT NULL,
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
	balise integer NOT NULL,
	bonusinitial integer NOT NULL,
	honneur decimal NOT NULL,
	argentinitial decimal NOT NULL,
	necessairedevoyage bool NOT NULL,
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
create table cinqanneaux.apprentissageoptionnelmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.apprentissageoptionneldescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.apprentissageoptionnelexemplar(
	fk_model_id integer,
	nombre integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.equipementoptionnelmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.equipementoptionneldescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.equipementoptionnelexemplar(
	fk_model_id integer,
	nombre integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competencemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	groupe integer NOT NULL,
	traitassocie integer NOT NULL,
	traitalternatif integer,
	degradante bool NOT NULL,
	sociale bool NOT NULL,
	martiale bool NOT NULL,
	noble bool NOT NULL,
	fk_competenceglobalemodel_global integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competencedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceexemplar(
	fk_model_id integer,
	rang integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialisationmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_competencemodel_competence integer,
	degradante bool NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialisationdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialisationexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
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
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceglobaledescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceglobaleexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
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
create table cinqanneaux.augmentationsortmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.augmentationsortdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.augmentationsortexemplar(
	fk_model_id integer,
	complement character varying(30) NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absobjetmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	cout_unit integer NOT NULL,
	cout_val integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absobjetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absobjetexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialobjetmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialobjetdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.specialobjetexemplar(
	fk_model_id integer,
	complement character varying(30) NOT NULL)INHERITS(cinqanneaux.dataobject);
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
	balise integer NOT NULL,
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
	balise integer,
	fk_clanmodel_clanrequis integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativedescription(
	description text NOT NULL,
	fk_model_id integer,
	technique text NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativeexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.conditionadmissionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.conditionadmissiondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.conditionadmissionexemplar(
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
create table cinqanneaux.tatouagetogashimodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tatouagetogashidescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tatouagetogashiexemplar(
	fk_model_id integer,
	complement character varying(30) NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.actioncombatmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	coutmin integer NOT NULL,
	coutmax integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.actioncombatdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.actioncombatexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.combatconditionmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	type integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.combatconditiondescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.combatconditionexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tableheritagemodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_clanmodel_clan integer,
	chances integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tableheritagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tableheritageexemplar(
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tableheritageconsequencesmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	fk_tableheritagemodel_tableheritage integer,
	chances integer NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tableheritageconsequencesdescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.tableheritageconsequencesexemplar(
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
	vide integer,
	status decimal NOT NULL,
	honneur decimal NOT NULL,
	gloire decimal NOT NULL,
	infamie decimal NOT NULL,
	souillure decimal,
	fk_clanmodel_clan integer,
	fk_famillemodel_famille integer,
	fk_ancetremodel_ancetre integer,
	fk_armureexemplar_armure integer,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagedescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnageexemplar(
	fk_model_id integer,
	degatssubis integer NOT NULL,
	depensevide integer NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoirnaturelmodel(
	name character varying(40) NOT NULL,
	tag character varying(7) NOT NULL,
	unique(name),
	unique(tag))INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoirnatureldescription(
	description text NOT NULL,
	fk_model_id integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.pouvoirnaturelexemplar(
	fk_model_id integer,
	complement character varying(30) NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecolemodeltocompetencestatus_competences(
	fk_ecolemodel_join integer,
	fk_competencestatus_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecolemodeltoapprentissageoptionnelexemplar_competencesopt(
	fk_ecolemodel_join integer,
	fk_apprentissageoptionnelexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecolemodeltoabsobjetmodel_equipement(
	fk_ecolemodel_join integer,
	fk_absobjetmodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecolemodeltoequipementoptionnelexemplar_equipementsopt(
	fk_ecolemodel_join integer,
	fk_equipementoptionnelexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.competenceexemplartospecialisationmodel_specialisationschoisies(
	fk_competenceexemplar_join integer,
	fk_specialisationmodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.abssortmodeltoaugmentationsortexemplar_augmentations(
	fk_abssortmodel_join integer,
	fk_augmentationsortexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.motclefsfromabssortmodel(
	fk_abssortmodel_from integer,
	motclefs integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.absobjetmodeltospecialobjetexemplar_special(
	fk_absobjetmodel_join integer,
	fk_specialobjetexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleavanceemodeltocompetencestatus_competencesrequises(
	fk_ecoleavanceemodel_join integer,
	fk_competencestatus_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.ecoleavanceemodeltoconditionadmissionexemplar_conditions(
	fk_ecoleavanceemodel_join integer,
	fk_conditionadmissionexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativemodeltocompetencestatus_competencesrequises(
	fk_voiealternativemodel_join integer,
	fk_competencestatus_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.voiealternativemodeltoconditionadmissionexemplar_conditions(
	fk_voiealternativemodel_join integer,
	fk_conditionadmissionexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.katamodeltoecolemodel_ecoles(
	fk_katamodel_join integer,
	fk_ecolemodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.acteursfromintriguemodel(
	fk_intriguemodel_from integer,
	acteurs character varying(60) NOT NULL)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltoavantageexemplar_avantages(
	fk_personnagemodel_join integer,
	fk_avantageexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltodesavantageexemplar_desavantages(
	fk_personnagemodel_join integer,
	fk_desavantageexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltoecoleexemplar_ecoles(
	fk_personnagemodel_join integer,
	fk_ecoleexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltoecoleavanceeexemplar_ecolesavancees(
	fk_personnagemodel_join integer,
	fk_ecoleavanceeexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltovoiealternativeexemplar_voiealternatives(
	fk_personnagemodel_join integer,
	fk_voiealternativeexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltosortmodel_sorts(
	fk_personnagemodel_join integer,
	fk_sortmodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltomahoumodel_mahou(
	fk_personnagemodel_join integer,
	fk_mahoumodel_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltokataexemplar_katas(
	fk_personnagemodel_join integer,
	fk_kataexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltokihoexemplar_kihos(
	fk_personnagemodel_join integer,
	fk_kihoexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltopouvoirnaturelexemplar_pouvoirs(
	fk_personnagemodel_join integer,
	fk_pouvoirnaturelexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltoarmeexemplar_armes(
	fk_personnagemodel_join integer,
	fk_armeexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagemodeltoobjetexemplar_inventaire(
	fk_personnagemodel_join integer,
	fk_objetexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.figurantmodeltocompetencestatus_competences(
	fk_figurantmodel_join integer,
	fk_competencestatus_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.personnagejoueurmodeltocompetenceexemplar_competences(
	fk_personnagejoueurmodel_join integer,
	fk_competenceexemplar_join integer)INHERITS(cinqanneaux.dataobject);
create table cinqanneaux.gloireinfo(
	primary key(id))INHERITS(cinqanneaux.infotable);
create table cinqanneaux.statutinfo(
	primary key(id))INHERITS(cinqanneaux.infotable);
create table cinqanneaux.infamieinfo(
	primary key(id))INHERITS(cinqanneaux.infotable);
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
	type integer NOT NULL,
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
create table cinqanneaux.figurantmodel(
	ndarmure integer NOT NULL,
	reduction integer NOT NULL,
	initiative_r integer NOT NULL,
	initiative_k integer NOT NULL,
	viehumaine bool NOT NULL,
	viemax integer NOT NULL,
	primary key(id))INHERITS(cinqanneaux.personnagemodel);
create table cinqanneaux.figurantdescription(
	primary key(id))INHERITS(cinqanneaux.personnagedescription);
create table cinqanneaux.figurantexemplar(
	primary key(id))INHERITS(cinqanneaux.personnageexemplar);
create table cinqanneaux.personnagejoueurmodel(
	fk_player_id integer,
	xptotal integer NOT NULL,
	xpdepense integer NOT NULL,
	primary key(id))INHERITS(cinqanneaux.personnagemodel);
create table cinqanneaux.personnagejoueurdescription(
	primary key(id))INHERITS(cinqanneaux.personnagedescription);
create table cinqanneaux.personnagejoueurexemplar(
	primary key(id))INHERITS(cinqanneaux.personnageexemplar);
