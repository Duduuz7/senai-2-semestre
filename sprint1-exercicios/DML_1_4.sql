-- DML 1_4

USE Exercicio_1_4

--INSERÇÃO
 
INSERT INTO Usuarios(Nome,Email,Senha,Permissao)
VALUES('Eduardo','eduardo@email.com','1234','Sim')

INSERT INTO Artistas(Nome)
VALUES('Leo Jaime')

INSERT INTO Estilos(Nome)
VALUES('MPB')

INSERT INTO Albuns(IdArtista,Titulo,DataLancamento,Localizacao,QtdMinutos,Ativo)
VALUES(1, 'Sessão da Tarde','01/01/1985','São Paulo','37','Sim')

INSERT INTO AlbunsEstilos(IdAlbum,IdEstilo)
VALUES(1,1)

SELECT * FROM Usuarios
SELECT * FROM Artistas
SELECT * FROM Estilos
SELECT * FROM Albuns
SELECT * FROM AlbunsEstilos


