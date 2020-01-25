create database PersonasDB

go
use PersonasDB
go
create table Personas
(
Id int primary key identity,
Nombre varchar(30),
Telefono varchar(13),
Cedula varchar(13),
Direccion varchar(max)
);