-- DDL 1_3

--CRIA BANCO
CREATE DATABASE Exercicio_1_3_Clinica;

--USA BANCO
USE Exercicio_1_3_Clinica

--CRIA TABELA
CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	Endereco VARCHAR(60) NOT NULL
)

CREATE TABLE TipoPet
(
	IdTipoPet INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(20) NOT NULL
)

CREATE TABLE Raca
(
	IdRaca INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(20) NOT NULL
)


CREATE TABLE Dono
(
	IdDono INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL
)

CREATE TABLE Veterinario
(
	IdVeterinario INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	Nome VARCHAR(20) NOT NULL,
	CRMV VARCHAR(15) NOT NULL
)

CREATE TABLE Pet
(
	IdPet INT PRIMARY KEY IDENTITY,
	IdTipoPet INT FOREIGN KEY REFERENCES TipoPet(IdTipoPet),
	IdRaca INT FOREIGN KEY REFERENCES Raca(IdRaca),
	IdDono INT FOREIGN KEY REFERENCES Dono(IdDono),
	Nome VARCHAR(20) NOT NULL,
	DataNascimento VARCHAR(10)
)

CREATE TABLE Atendimentos
(
	IdAtendimento INT PRIMARY KEY IDENTITY,
	IdVeterinario INT FOREIGN KEY REFERENCES Veterinario(IdVeterinario),
	IdPet INT FOREIGN KEY REFERENCES Pet(IdPet),
	Descricao VARCHAR(30) NOT NULL,
	DataAtendimento VARCHAR(10)
)


SELECT * FROM Clinica
SELECT * FROM TipoPet
SELECT * FROM Raca
SELECT * FROM Dono
SELECT * FROM Veterinario
SELECT * FROM Pet
SELECT * FROM Atendimentos
