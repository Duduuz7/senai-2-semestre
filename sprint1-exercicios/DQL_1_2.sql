--DQL 1_2

SELECT 
	Aluguel.IdAluguel,Aluguel.IdVeiculo,Aluguel.DataRetirada,Aluguel.DataDevolucao,
	Cliente.Nome AS NomeCliente,Modelo.Nome AS NomeModelo
FROM Aluguel 
INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente
INNER JOIN Modelo ON Aluguel.IdVeiculo = Modelo.IdModelo

SELECT
	Aluguel.IdAluguel,Aluguel.IdVeiculo,Aluguel.DataRetirada,Aluguel.DataDevolucao,
	Cliente.Nome AS NomeCliente,Modelo.Nome AS NomeModelo
FROM Aluguel 
INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente
INNER JOIN Modelo ON Aluguel.IdVeiculo = Modelo.IdModelo 
WHERE Cliente.IdCliente = 1