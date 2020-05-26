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
	label character varying(30) NOT NULL,
	isfolder bool NOT NULL)INHERITS(core.dataobject);
create table core.ressource(
	name character varying(255) NOT NULL)INHERITS(core.dataobject);
create table core.ressourcebase(
	path character varying(516) NOT NULL,
	defaultmiscpath character varying(256) NOT NULL,
	defaulttextpath character varying(256) NOT NULL,
	defaultimagepath character varying(256) NOT NULL,
	defaultsoundtrackpath character varying(256) NOT NULL)INHERITS(core.dataobject);
create table core.scenariotoplayer_players(
	fk_scenario_join integer,
	fk_player_join integer)INHERITS(core.dataobject);
create table core.sessiontoplayer_playersatthesession(
	fk_session_join integer,
	fk_player_join integer)INHERITS(core.dataobject);
create table core.ressourcetotag_tags(
	fk_ressource_join integer,
	fk_tag_join integer)INHERITS(core.dataobject);
create table core.settorawressource_ressources(
	fk_set_join integer,
	fk_rawressource_join integer)INHERITS(core.dataobject);
create table core.rawressource(
	fk_ressourcebase_db integer,
	ressourcetype integer NOT NULL,
	path character varying(516) NOT NULL,
	primary key(id))INHERITS(core.ressource);
create table core.secondaryressource(
	primary key(id))INHERITS(core.ressource);
create table core.set(
	primary key(id))INHERITS(core.secondaryressource);
