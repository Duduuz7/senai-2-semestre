using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interface;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// CLasse responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
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
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateCorpo = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@NovoNome", genero.Nome);
                    cmd.Parameters.AddWithValue("@Id", genero.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Atualiza um gênero passando o id do gênero que deseja atualizar pela URL
        /// </summary>
        /// <param name="id">Id do gênero que deseja atualizar</param>
        /// <param name="genero">Objeto com gênero que dejeta atualizar</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@NovoNome", genero.Nome);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Buscar um gênero pelo seu Id
        /// </summary>
        /// <param name="Id">Id do gênero buscado</param>
        /// <returns>Objeto com o gênero buscado</returns>
        //public GeneroDomain BuscarPorId(int Id)
        //{
        //    List<GeneroDomain> listaGeneros = ListarTodos();
        //    GeneroDomain generoBuscado = new GeneroDomain()
        //    {
        //        IdGenero = Id,
        //        Nome = "Erro, gênero não encontrado !!!"
        //    };

        //    foreach (GeneroDomain genero in listaGeneros)
        //    {
        //        if (genero.IdGenero == Id) generoBuscado = genero;
        //    }
        //    return generoBuscado;
        //}

        /// <summary>
        /// Buscar um gênero pelo seu Id
        /// </summary>
        /// <param name="Id">Id do gênero buscado</param>
        /// <returns>Objeto com o gênero buscado</returns>
        public GeneroDomain BuscarPorId(int Id)
        {
            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada 
                string queryFindById = $"SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryFindById, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", Id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        return generoBuscado;
                    }
                    return null;
                }
            }
        }

            /// <summary>
            /// Cadastrar um novo gênero
            /// </summary>
            /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
            public void Cadastrar(GeneroDomain novoGenero)
            {
            //Declara a SqlConnection passando a string de conexão como parâmetro
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                //Declara a query que será executada 
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                     using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                     {
                        //Passa o valor do parâmetro @Nome
                        cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                        //Abre a conexão com o banco de dados
                        con.Open();

                        //Executa a query
                        cmd.ExecuteNonQuery();
                     }
                }
        }


        /// <summary>
        /// Deleta um gênero
        /// </summary>
        /// <param name="Id">Id do gênero a ser deletado</param>
        public void Deletar(int Id)
        {
            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada 
                string queryDelete = $"DELETE FROM Genero WHERE IdGenero = @IdGenero";

                //Abre a conexão com o banco de dados
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", Id);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }




        /// <summary>
        /// Listar todos os objetos do tipo gênero
        /// </summary>
        /// <returns>Uma lista de objetos do tipo gênero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de gêneros onde será armazenados os gêneros
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repetirá
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor da primeira coluna da tabela,
                            //Convert converte a variavel para o desejado, no caso Int, pois ela é int no banco 
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade nome o valor da coluna Nome da tabela
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona um objeto criado dentro da lista
                        listaGeneros.Add(genero);
                    }
                }
            }
            //Retorna a lista de gêneros 
            return listaGeneros;
        }
    }
}
