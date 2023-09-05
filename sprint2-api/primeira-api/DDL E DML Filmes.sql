CREATE DATABASE Filmes_Tarde
USE Filmes_Tarde

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(70) UNIQUE NOT NULL,
	Senha VARCHAR(20) NOT NULL,
	Permissao VARCHAR(20) NOT NULL
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

INSERT INTO Genero(Nome)
VALUES ('Terror'),('Ação')

INSERT INTO Usuario(Email,Senha,Permissao)
VALUES ('eduardo@email.com','1234','Administrador'),('felipe@email.com','4321','Comum')

INSERT INTO Filme(IdGenero,Titulo)
VALUES (1,'A Freira'),(2,'Velozes e Furiosos')

SELECT * FROM Genero
SELECT * FROM Filme
SELECT * FROM Usuario


DROP TABLE Usuario