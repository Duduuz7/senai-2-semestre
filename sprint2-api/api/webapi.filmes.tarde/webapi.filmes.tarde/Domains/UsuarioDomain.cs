using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "A permissão do usuário é obrigatória!")]
        public string? Permissao { get; set; }
    }
}
