create database PersonasDB
go

use PersonasDB

go
Create table Personas
(
	PersonaId int primary key identity,
	Nombre varchar(30),
	Telefono varchar(13),
	Cedula varchar(13),
	Direccion varchar(max),
	FechaNacimiento date,
	Balance decimal
);
go

Create table Inscripciones
(
	InscripcionId int primary key identity,
	Fecha date,
	Comentarios varchar(30),
	Monto decimal,
	Balance decimal,
	PersonaId int,
	Deposito Decimal,
	constraint Fk_PersonaInscipciones foreign key (PersonaId) references Personas(PersonaId)
);