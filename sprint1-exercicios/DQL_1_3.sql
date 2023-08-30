--DQL 1_3

--------------------------------------
SELECT 
  Nome,CRMV
FROM
	Veterinario
WHERE
	Veterinario.IdClinica = 1
--------------------------------------
SELECT
	*
FROM
	Raca
WHERE Descricao LIKE 'S%'
--------------------------------------
SELECT
	*
FROM
	TipoPet
WHERE Descricao LIKE '%o'
--------------------------------------
SELECT
	Pet.IdPet,Pet.IdTipoPet,Pet.IdRaca,Pet.Nome AS NomePet,Pet.DataNascimento,Dono.IdDono,Dono.Nome AS NomeDono
FROM
	Pet
	INNER JOIN Dono ON Pet.IdDono = Dono.IdDono
--------------------------------------
--listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, 
--a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica onde o pet foi atendido

SELECT
	Atendimentos.IdAtendimento,Veterinario.Nome AS NomeVeterinario,Pet.Nome AS NomePet,
	Raca.Descricao AS Raca,TipoPet.Descricao AS TipoPet,Dono.Nome AS NomeDono, Clinica.IdClinica,Clinica.Endereco
FROM Atendimentos
	INNER JOIN Veterinario ON Atendimentos.IdVeterinario = Veterinario.IdVeterinario
	INNER JOIN Pet ON Atendimentos.IdPet = Pet.IdPet
	INNER JOIN Raca ON Pet.IdRaca = Raca.IdRaca
	INNER JOIN TipoPet ON Pet.IdTipoPet = TipoPet.IdTipoPet
	INNER JOIN Dono ON Pet.IdDono = Dono.IdDono
	INNER JOIN Clinica ON Veterinario.IdClinica = Clinica.IdClinica
----------------------------------------
