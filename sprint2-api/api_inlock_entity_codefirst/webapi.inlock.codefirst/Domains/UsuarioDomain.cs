using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email),IsUnique = true)]
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatório!")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Senha obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        //Referência tabela TiposUsuario - FK
        [Required(ErrorMessage ="Tipo do usuário obrigatório!")]
        public Guid IdTipoUsuario{ get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuarioDomain TipoUsuario { get; set; }
    }
}
