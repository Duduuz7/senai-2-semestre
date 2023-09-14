using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BuscarUsuario(string email, string senha);

        void Cadastrar(UsuarioDomain usuario);
    }
}
