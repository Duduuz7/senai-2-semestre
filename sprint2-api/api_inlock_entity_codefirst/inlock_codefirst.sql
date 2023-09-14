USE inlock_games_codeFirst

INSERT INTO Estudio
VALUES (NEWID(),'Activision'),(NEWID(),'Epic Games'),(NEWID(),'GG')

SELECT * FROM Estudio

INSERT INTO Jogo
VALUES (NEWID(),'Fortnite','Battle Royale','2023-01-10',19.9,'649B670A-F38D-4D97-B347-1398512CA453'),
	   (NEWID(),'CoD MW3','Ação e tiro','2023-01-25',99.9,'157A2573-868E-4C75-B6DE-C2D5392B2E47')

SELECT * FROM Jogo

INSERT INTO TiposUsuario
VALUES (NEWID(),'Administrador'),(NEWID(),'Comum')

SELECT * FROM TiposUsuario

INSERT INTO Usuario
VALUES (NEWID(),'adm@adm.com','123456','CC240F41-EC33-44D4-A9E9-D32F1F01AB4B'),
	   (NEWID(),'comum@comum.com','654321','54B43C87-032A-4F90-9BB4-155DEF5E71D7')

SELECT * FROM Usuario