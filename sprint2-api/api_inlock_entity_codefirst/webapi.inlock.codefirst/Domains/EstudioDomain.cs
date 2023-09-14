using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Estudio")]
    public class EstudioDomain
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public string? Nome { get; set; }

        //Referência lista de jogos
        public List<UsuarioDomain> Jogo { get; set; }
    }
}
