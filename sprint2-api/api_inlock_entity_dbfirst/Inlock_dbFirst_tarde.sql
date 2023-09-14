CREATE DATABASE inlock_games_dbFirst_tarde
USE inlock_games_dbFirst_tarde

CREATE TABLE Estudio
(
	IdEstudio UNIQUEIDENTIFIER PRIMARY KEY,
	Nome VARCHAR(100) NOT NULL
)

CREATE TABLE Jogo
(
	IdJogo UNIQUEIDENTIFIER PRIMARY KEY,
	IdEstudio UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Estudio(IdEstudio),
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	DataLancamento DATE NOT NULL,
	Valor SMALLMONEY NOT NULL
)

CREATE TABLE TiposUsuario
(
	IdTipoUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR(100) NOT NULL
)

CREATE TABLE Usuario
(
	IdUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	IdTipoUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario),
	Email VARCHAR(100) NOT NULL,
	Senha VARCHAR(100) NOT NULL
)

INSERT INTO Estudio
VALUES (NEWID(),'SENAI'),(NEWID(),'SESI'),(NEWID(),'SEBRAE')

SELECT * FROM Estudio

INSERT INTO Jogo
VALUES (NEWID(),'9AD99E3F-F163-44A9-8F69-906B3F18AA80','PING PONG','JOGO LEGAL','2023-01-01',500),
	   (NEWID(),'9AD99E3F-F163-44A9-8F69-906B3F18AA80','JUCAMOM','CA�A POKEMOM','2022-03-23',2.99)

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES (NEWID(),'administrador'),(NEWID(),'comum')

SELECT * FROM TiposUsuario

INSERT INTO Usuario
VALUES (NEWID(),'95D28C48-6E8B-4AA1-8A8A-C443C68485A9','adm@adm.com','admin'),
	   (NEWID(),'2765DB81-6227-4C7E-8DDF-C0EBB7AD5842','comum@comum.com','comum')

SELECT * FROM Usuario