-- DML 1_2

USE Exercicio_1_2

--INSER��O

INSERT INTO Empresa(Nome)
VALUES('JKM'),('GG CARS')

INSERT INTO Cliente(Nome, CPF)
VALUES('Eduardo','12312312312'),('Felipe','32132132132')

INSERT INTO Marca(Nome)
VALUES('BMW'),('FIAT')

INSERT INTO Modelo(Nome)
VALUES('X1'),('500')

INSERT INTO Veiculo(IdEmpresa,IdMarca,IdModelo,Placa)
VALUES(1,1,1, 'EFG123'),(2,2,2, 'MKG321')

INSERT INTO Aluguel(IdVeiculo,IdCliente,Protocolo)
VALUES(1,1,'12345678'),(2,2, '76584932')


SELECT * FROM Empresa
SELECT * FROM Cliente
SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Veiculo
SELECT * FROM Aluguel