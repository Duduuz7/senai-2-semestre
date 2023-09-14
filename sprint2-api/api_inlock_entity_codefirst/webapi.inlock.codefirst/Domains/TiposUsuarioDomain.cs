using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuarioDomain
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();   

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Título é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
