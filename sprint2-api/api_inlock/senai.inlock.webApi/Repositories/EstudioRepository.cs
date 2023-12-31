﻿using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES(@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarComJogos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        List<JogoDomain> listaJogos = new List<JogoDomain>();

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            Nome = (rdr["Nome"]).ToString(),

                        };

                        using (SqlConnection conJogos = new SqlConnection(StringConexao))
                        {
                            string querySelectAllGames = "SELECT IdJogo, Nome, Descricao, DataLancamento, Valor FROM jogo WHERE IdEstudio = @IdEstudio";

                            conJogos.Open();

                            using (SqlCommand cmdJogos = new SqlCommand(querySelectAllGames, conJogos))
                            {
                                cmdJogos.Parameters.AddWithValue("@IdEstudio", estudio.IdEstudio);

                                SqlDataReader readerJogos = cmdJogos.ExecuteReader();

                                while (readerJogos.Read()) 
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        IdJogo = Convert.ToInt32(readerJogos["IdJogo"]),

                                        Nome = readerJogos["Nome"].ToString(),

                                        Descricao = readerJogos["Descricao"].ToString(),

                                        DataLancamento = Convert.ToDateTime(readerJogos["DataLancamento"]),

                                        Valor = Convert.ToDecimal(readerJogos["Valor"]),
                                    };
                                    
                                    listaJogos.Add(jogo);
                                }
                            }

                            estudio.ListaJogos = listaJogos;

                            listaEstudios.Add(estudio);
                            
                        }
                    }
                }
                return listaEstudios;
            }
        }

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            Nome = (rdr["Nome"]).ToString(),

                        };
                        listaEstudios.Add(estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }
}
