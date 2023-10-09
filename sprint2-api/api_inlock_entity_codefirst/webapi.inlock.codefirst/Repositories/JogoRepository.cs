using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;

namespace webapi.inlock.codefirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, UsuarioDomain jogo)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain jogo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> Listar()
        {
            return ctx.Jogo.ToList();
        }
    }
}
