--DML - INSERIR DADOS NAS TABELAS

--USAR O BANCO CRIADO
USE Exercicio_1_1

--INSERIR DADOS NA TABELA
INSERT INTO Pessoa(Nome,CNH)
VALUES('Eduardo', '1231231231'),('Felipe', '3213213213')

INSERT INTO Email(IdPessoa, Endereco)
VALUES(1,'eduardo@email.com'),(2,'felipe@email.com')

INSERT INTO Telefone(IdPessoa, Numero)
VALUES(1,'999999999'),(2,'333333333')


SELECT * FROM Pessoa
SELECT * FROM Email
SELECT * FROM Telefone