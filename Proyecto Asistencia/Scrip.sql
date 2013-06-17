create database planilla;
go

use planilla ;
go



create table turno(
	id int identity(1,1) not null primary key,
	descricion varchar(150),
);

create table horario(
	id int identity(1,1) not null primary key,
	dia varchar(15),
	horaEntrada datetime,
	horaSalida datetime,
	idTurno int,
	
	foreign key(idTurno) references turno(id)
);

create table cronograma(
	id int identity(1,1) not null primary key,
	descripcion varchar(150),
	fechaIni datetime,
	fechaFin datetime,
);

create table cronogramaTurno(
	id int identity(1,1) not null primary key,
	fecha datetime,
	activo int,
	idCronograma int,
	idTurno int,
	
	foreign key(idCronograma) references cronograma(id),
	foreign key(idTurno) references turno(id)
);





