CREATE DATABASE Preguntas;
GO

USE Preguntas;
GO

CREATE TABLE Rol(
	Id INT IDENTITY(1,1),
	NombreRol VARCHAR(50),

	CONSTRAINT pk_Rol PRIMARY KEY (Id)
);
GO

INSERT INTO Rol (NombreRol) VALUES ('ADMINISTRADOR');
INSERT INTO Rol (NombreRol) VALUES ('USUARIO');


CREATE TABLE Estado(
	Id INT IDENTITY(1,1),
	NombreEstado VARCHAR(50),

	CONSTRAINT pk_Estado PRIMARY KEY (Id)
);
GO
INSERT INTO Estado (NombreEstado) VALUES ('ACTIVA');
INSERT INTO Estado (NombreEstado) VALUES ('CERRADA');



CREATE TABLE Usuario(
	Id INT IDENTITY(1,1),
	NombreCompleto varchar(100),
	NombreUsuario varchar(20),
	Contrasena varchar(10),
	IdRol INT,

	CONSTRAINT pk_Usuario PRIMARY KEY (Id),
	CONSTRAINT fk_IdRolUsuario FOREIGN KEY (IdRol) REFERENCES Rol (Id)
);
GO
INSERT INTO Usuario(NombreCompleto,NombreUsuario,Contrasena,IdRol) VALUES('Cristian Mendoza','CRISOMP','SDFSDFDS',1)


CREATE TABLE Pregunta(
	Id INT IDENTITY(1,1),
	Pregunta VARCHAR(200),
	IdUsuario INT,
	IdEstado INT,
	Likes INT,

	CONSTRAINT pk_Pregunta PRIMARY KEY (Id),
	CONSTRAINT fk_IdUsuarioPregunta FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
	CONSTRAINT fk_IdEstadoPregunta FOREIGN KEY (IdEstado) REFERENCES Estado(Id)
);
GO

CREATE TABLE Respuesta(
	Id INT IDENTITY(1,1),
	Respuesta VARCHAR(200),
	IdPregunta INT,
	IdUsuario INT,
	Likes INT,

	CONSTRAINT pk_Respuesta PRIMARY KEY (Id),
	CONSTRAINT fk_IdPreguntaRespuesta FOREIGN KEY (IdPregunta) REFERENCES Pregunta(Id),
	CONSTRAINT fk_IdUsuarioRespuesta FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);



SELECT * FROM Rol;