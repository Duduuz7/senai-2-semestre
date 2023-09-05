using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }  
    }
}
