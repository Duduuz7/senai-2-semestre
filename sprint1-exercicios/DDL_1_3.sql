-- DML 1_3 

USE Exercicio_1_3;

-- INSERÇÃO


INSERT INTO Clinica(Endereco)
VALUES('Rua Niterói, 123'),('Rua das Papoulas, 143')

INSERT INTO TipoPet(Descricao)
VALUES('Mamífero'),('Réptil')

INSERT INTO Raca(Descricao)
VALUES('Bulldog'),('Jabuti')

INSERT INTO Dono(Nome)
VALUES('Eduardo'),('Felipe')

INSERT INTO Veterinario(IdClinica,Nome,CRMV)
VALUES(1,'Jose','1234'),(2,'Ramon','4321')

INSERT INTO Pet(IdTipoPet,IdRaca,IdDono,Nome,DataNascimento)
VALUES(1,1,1,'Billy','01/01/2001'),(2,2,2,'Josh','02/02/2002')

INSERT INTO Atendimentos(IdVeterinario,IdPet,Descricao,DataDoAtendimento)
VALUES(1,1,'ldkj','05/12/2023'),(2,2,'ld','07/12/2023')

SELECT * FROM Clinica
SELECT * FROM TipoPet
SELECT * FROM Raca
SELECT * FROM Dono
SELECT * FROM Veterinario
SELECT * FROM Pet
SELECT * FROM Atendimento



