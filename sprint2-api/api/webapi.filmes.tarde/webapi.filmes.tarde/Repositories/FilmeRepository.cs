using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interface;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// CLasse responsável pelo repositório dos filmes
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {

        /// <summary>
        /// String de conexão comm o banco de dados, que recebe os seguintes parâmetros:
        /// Data Source : Nome do servidor do banco
        /// Initial Catalog : Nome do banco de dados
        /// Autenticação
        ///     -Windows : Integrated Security = True
        ///     SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";


        /// <summary>
        /// Atualiza um filme passando o Id dele pelo corpo/JSON
        /// </summary>
        /// <param name="filme">objeeto com o filme que deseja atualizar</param>
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateCorpo = "UPDATE Filme SET Titulo = @NovoTitulo, IdGenero = @NovoIdGenero WHERE IdFilme = @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@NovoTitulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@NovoIdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@id", filme.IdFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um filme passando seu id pela URL
        /// </summary>
        /// <param name="id">Id do filme que deseja atualizar</param>
        /// <param name="filme">Objeto com filme que deseja atualizar</param>
        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Filme SET Titulo = @NovoTitulo, IdGenero = @NovoIdGenero WHERE IdFilme = @Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@NovoTitulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@NovoIdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca apenas um filme desejado pelo seu id
        /// </summary>
        /// <param name="id">Id do filme que deseja buscar</param>
        /// <returns>Filme buscado</returns>
        public FilmeDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryFindById = $"SELECT Filme.IdFilme, Genero.IdGenero, Genero.Nome, Filme.Titulo FROM Filme INNER JOIN Genero ON Genero.IdGenero = Filme.IdGenero WHERE IdFilme = @IdFilme";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryFindById, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[1]),
                                Nome = rdr["Nome"].ToString()
                            },
                            Titulo = rdr["Titulo"].ToString()
                        };
                        return filmeBuscado;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto com novo filme</param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme(IdGenero, Titulo) VALUES (@IdGenero,@Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">Id do filme que deseja deletar</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = $"DELETE FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista com todos os filmes</returns>
        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Filme.IdFilme, Genero.IdGenero, Genero.Nome, Filme.Titulo FROM Filme INNER JOIN Genero ON Genero.IdGenero = Filme.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            //Convert converte a variavel para o desejado, no caso Int, pois ela é int no banco 
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[1]),
                                Nome = rdr["Nome"].ToString()
                            },
                        
                            Titulo = rdr["Titulo"].ToString()
                        };
                        listaFilmes.Add(filme);
                    }
                }
            }
            return listaFilmes;
        }
    }
}
