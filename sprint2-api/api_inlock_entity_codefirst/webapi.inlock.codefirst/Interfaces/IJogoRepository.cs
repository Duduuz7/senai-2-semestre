using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    public interface IJogoRepository
    {
        List<UsuarioDomain> Listar();

        UsuarioDomain BuscarPorId(Guid id);

        void Cadastrar(UsuarioDomain jogo);

        void Atualizar(Guid id, UsuarioDomain jogo);

        void Deletar(Guid id);
    }
}
