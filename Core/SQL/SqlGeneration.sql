DROP SCHEMA IF EXISTS core CASCADE;
CREATE SCHEMA core;
create table core.dataobject(
	id serial NOT NULL,
	primary key(id));
create table core.rpg(
	name character varying(255) NOT NULL)INHERITS(core.dataobject);
create table core.handbook(
	name character varying(255) NOT NULL,
	fk_rpg_rpg integer)INHERITS(core.dataobject);
create table core.handbookreference(
	name character varying(255) NOT NULL,
	fk_handbook_book integer,
	page integer NOT NULL)INHERITS(core.dataobject);
create table core.player(
	forename character varying(255) NOT NULL,
	name character varying(255) NOT NULL,
	pseudo character varying(255) NOT NULL)INHERITS(core.dataobject);
create table core.scenario(
	name character varying(255) NOT NULL,
	fk_rpg_rpg integer,
	fk_player_gm integer,
	synopsis text NOT NULL)INHERITS(core.dataobject);
create table core.chapter(
	name character varying(255) NOT NULL,
	synopsis text NOT NULL,
	fk_scenario_scenario integer)INHERITS(core.dataobject);
create table core.session(
	fk_chapter_chapter integer,
	startsession timestamp(6) NOT NULL,
	endsession timestamp(6) NOT NULL,
	playersummary text NOT NULL,
	gmnotes text NOT NULL)INHERITS(core.dataobject);
create table core.tag(
	label character varying(30) NOT NULL)INHERITS(core.dataobject);
create table core.ressource(
	name character varying(255) NOT NULL)INHERITS(core.dataobject);
create table core.soundfilter(
	type integer NOT NULL,
	values character varying(20) NOT NULL)INHERITS(core.dataobject);
create table core.scenariotoplayer_players(
	fk_scenario_join integer,
	fk_player_join integer)INHERITS(core.dataobject);
create table core.sessiontoplayer_playersatthesession(
	fk_session_join integer,
	fk_player_join integer)INHERITS(core.dataobject);
create table core.ressourcetotag_tags(
	fk_ressource_join integer,
	fk_tag_join integer)INHERITS(core.dataobject);
create table core.documenttoparagraph_paragraphs(
	fk_document_join integer,
	fk_paragraph_join integer)INHERITS(core.dataobject);
create table core.documenttodocument_subdocs(
	fk_document_joinsubdocs integer,
	fk_document_join integer)INHERITS(core.dataobject);
create table core.filteredtracktosoundfilter_filters(
	fk_filteredtrack_join integer,
	fk_soundfilter_join integer)INHERITS(core.dataobject);
create table core.paragraph(
	title character varying(255) NOT NULL,
	text text NOT NULL,
	primary key(id))INHERITS(core.ressource);
create table core.document(
	primary key(id))INHERITS(core.ressource);
create table core.image(
	filepath character varying(255) NOT NULL,
	primary key(id))INHERITS(core.ressource);
create table core.soundtrack(
	filepath character varying(255) NOT NULL,
	primary key(id))INHERITS(core.ressource);
create table core.playlist(
	fk_filteredtrack_track integer,
	primary key(id))INHERITS(core.ressource);
create table core.graph(
	primary key(id))INHERITS(core.ressource);
create table core.map(
	primary key(id))INHERITS(core.ressource);
create table core.filteredtrack(
	repeat bool NOT NULL,
	primary key(id))INHERITS(core.soundtrack);
