using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// CLasse que representa a entidade(tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do genero é obrigatório!")]
        public string? Nome { get; set; }
    }
}
