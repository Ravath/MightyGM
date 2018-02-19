CREATE SCHEMA mushroom;
create table mushroom.carriere_model(
	name character varying(40) NOT NULL,
	id serial NOT NULL,
	unique(name),
	primary key(id));
create table mushroom.carriere_exemplar(
	fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table mushroom.carriere_description(
	description text NOT NULL,
	fk_model integer NOT NULL,
	id serial NOT NULL,
	primary key(id));
create table mushroom.machinsfromcarrieremodel(
	id serial NOT NULL,
	fk_carriere integer NOT NULL,
	machins integer NOT NULL,
	primary key(id));
