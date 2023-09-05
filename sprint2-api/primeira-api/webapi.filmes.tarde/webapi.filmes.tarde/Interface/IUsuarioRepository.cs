using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BuscarLogin(string email, string senha);
    }
}
