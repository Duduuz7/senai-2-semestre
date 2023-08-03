-- DQL 1_4

SELECT 
	Usuarios.Nome,Usuarios.Email,Usuarios.Permissao AS Administrador
FROM
	Usuarios
WHERE
	Usuarios.Permissao = 'Sim'

--------------------------------------------

SELECT 
	*
FROM 
	Albuns
WHERE
	Albuns.DataLancamento >= '01-12-1985'

---------------------------------------------

SELECT
	*
FROM
	Usuarios
WHERE
Usuarios.Email = 'eduardo@email.com' AND Usuarios.Senha = '1234'

---------------------------------------------

SELECT 
	Albuns.IdAlbum,Albuns.Titulo,Albuns.DataLancamento,Albuns.Localizacao,Albuns.QtdMinutos,Albuns.Ativo,Artistas.Nome AS NomeArtista,Estilos.IdEstilo AS NomeEstilo
FROM 
	Albuns
	INNER JOIN Artistas ON Albuns.IdArtista = Artistas.IdArtista
	INNER JOIN Estilos ON Albuns.IdAlbum = Estilos.IdEstilo

----------------------------------------------