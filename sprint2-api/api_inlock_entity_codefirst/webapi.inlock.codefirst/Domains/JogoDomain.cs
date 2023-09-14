using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    [Table("Jogo")]
    public class JogoDomain
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do jogo obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage ="Descrição do jogo obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lançamento do jogo obrigatória!")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "Preço do jogo obrigatória!")]
        public decimal Preco { get; set; }

        //Referência tabela estudio - FK
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public EstudioDomain? Estudio { get; set; }
    }
}
