using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        //Instância de Estudio
        public EstudioDomain Estudio { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório !")]
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória !")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório !")]
        public float Valor { get; set; }
    }
}
