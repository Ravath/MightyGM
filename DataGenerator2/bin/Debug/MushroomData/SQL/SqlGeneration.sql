CREATE SCHEMA mushroom;
create table mushroom.carrieremodel(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	fk_specialitemodel integer,
	unique(name),
	primary key(id));
create table mushroom.carrieredescription(
	description text NOT NULL,
	fk_model integer,
	id serial NOT NULL,
	primary key(id));
create table mushroom.carriereexemplaire(
	fk_model integer,
	id serial NOT NULL,
	primary key(id));
create table mushroom.specialitemodel(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	unique(name),
	primary key(id));
create table mushroom.specialitedescription(
	description text NOT NULL,
	fk_model integer,
	id serial NOT NULL,
	primary key(id));
create table mushroom.specialiteexemplaire(
	fk_model integer,
	id serial NOT NULL,
	primary key(id));
