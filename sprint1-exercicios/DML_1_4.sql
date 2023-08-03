-- DML 1_4

USE Exercicio_1_4

--INSERÇÃO
 
INSERT INTO Usuarios(Nome,Email,Senha,Permissao)
VALUES('Eduardo','eduardo@email.com','1234','Sim'),('Felipe','felipe@email.com','4321','Não')

INSERT INTO Artistas(Nome)
VALUES('Leo Jaime'),('Metallica')

INSERT INTO Estilos(Nome)
VALUES('MPB'),('Metal')

INSERT INTO Albuns(IdArtista,Titulo,DataLancamento,Localizacao,QtdMinutos,Ativo)
VALUES(1, 'Sessão da Tarde','1985-01-01','São Paulo',37,'Sim'),(2, 'Master Of Puppets','1986-03-03','EUA',55,'Sim')

INSERT INTO AlbunsEstilos(IdAlbum,IdEstilo)
VALUES(1,1),(2,2)

SELECT * FROM Usuarios
SELECT * FROM Artistas
SELECT * FROM Estilos
SELECT * FROM Albuns
SELECT * FROM AlbunsEstilos


