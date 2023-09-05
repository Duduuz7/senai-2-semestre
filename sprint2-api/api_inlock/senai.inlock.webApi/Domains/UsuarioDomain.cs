using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }
        public TiposUsuarioDomain TiposUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório !")]
        public string? Email { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "O campo senha precisa de no mínimo 3 e no máximo 20 caracteres")]
        [Required(ErrorMessage = "A senha é obrigatória !")]
        public string? Senha { get; set; }
    }
}
