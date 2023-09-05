using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// CLasse que representa a entidade(tabela) Usuário 
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        public string? Email { get; set; }

        [StringLength(20,MinimumLength = 4,ErrorMessage ="O campo senha precisa de no mínimo 3 e no máximo 20 caracteres")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "A permissão do usuário é obrigatória!")]
        public string? Permissao { get; set; }
    }
}
