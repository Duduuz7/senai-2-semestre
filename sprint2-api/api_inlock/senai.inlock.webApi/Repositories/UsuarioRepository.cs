using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
