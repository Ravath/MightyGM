-- Database: MightyGM

-- DROP DATABASE "MightyGM";

CREATE DATABASE "MightyGM"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'French_France.1252'
    LC_CTYPE = 'French_France.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	

create table jdr(
	id serial NOT NULL,
	primary key(id),
	name varchar(255) NOT NULL,
	unique(name));
	
create table manuel(
	id serial NOT NULL,
	primary key(id),
	name varchar(255) NOT NULL,
	fk_jdr integer,
	unique(name,prenom),
	unique(pseudo),
	foreign key(fk_jdr)
		references jdr(id) match simple
		on update no action on delete no action);
	
create table joueur(
	id serial NOT NULL,
	primary key(id),
	name varchar(255) NOT NULL,
	prenom varchar(255),
	pseudo varchar(255),
	unique(name));
	
create table sceance(
	id serial NOT NULL,
	primary key(id),
	name varchar(255) NOT NULL,
	debut timestamp(6) DEFAULT timestamp 'now ( )' NOT NULL,
	fin timestamp(6),
	resume text,
	notes text,
	fk_scenario integer NOT NULL,
	unique(name; fk_scenario));
	
create table scenario(
	id serial NOT NULL,
	primary key(id),
	name varchar(255) NOT NULL,
	synopsis text,
	fk_joueur_gm integer NOT NULL,
	fk_jdr integer NOT NULL,
	unique(name, fk_jdr));

create table scenariotojoueur(
	id serial NOT NULL,
	primary key(id),
	fk_joueur integer NOT NULL,
	fk_scenario integer NOT NULL,
	unique(fk_joueur,fk_scenario));