using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interface;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Busca um login pela seu email e senha
        /// </summary>
        /// <param name="email">Email da conta que deseja encontrar</param>
        /// <param name="senha">Senha da conta que deseja encontrar</param>
        /// <returns>Objeto com Login</returns>
        public UsuarioDomain BuscarLogin(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT IdUsuario, Permissao, Email FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            UsuarioDomain usuario = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Permissao = rdr["Permissao"].ToString(),
                                Email = rdr["Email"].ToString()                               
                            };
                            return usuario;
                        }
                        return null;
                    }
                }
            }
        }        
    }
}
